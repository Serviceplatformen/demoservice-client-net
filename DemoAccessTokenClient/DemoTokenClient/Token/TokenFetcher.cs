using System;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Net;
using System.Web;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace DemoTokenClient.Token
{
    public static class TokenFetcher
    {
             
        public static SecurityToken IssueSamlToken(string entityId)
        {
            var certificate = CertificateLoader.LoadCertificate(
                ConfigVariables.ClientCertificateStoreName, 
                ConfigVariables.ClientCertificateStoreLocation, 
                ConfigVariables.ClientCertificateThumbprint);
            var absoluteUri = new Uri(entityId).AbsoluteUri;
            return SendSecurityTokenRequest(absoluteUri, certificate, ConfigVariables.Cvr);
        }

        public static void AddClientCertificate(ref HttpWebRequest request)
        {
            request.ClientCertificates.Add(
            CertificateLoader.LoadCertificate(
            ConfigVariables.ClientCertificateStoreName,
            ConfigVariables.ClientCertificateStoreLocation,
            ConfigVariables.ClientCertificateThumbprint));
        }
                   
        public static  AccessToken ConvertToAccessToken(SecurityToken token)
        {
           
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(ConfigVariables.AccessTokenServiceUrl);
            webrequest.Method = "POST";
            webrequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            AddClientCertificate(ref webrequest);
            string postData = HttpUtility.UrlEncode("saml-token") + "=" + HttpUtility.UrlEncode(EncodeSAMLToken(token));
            byte[] body = Encoding.UTF8.GetBytes(postData);
            webrequest.ContentLength = body.Length;
            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(body, 0, body.Length);
            newStream.Close();

            Console.WriteLine("**********Request to Authorization**********");
            Console.WriteLine("Request Details: ");
            Console.WriteLine("Address is {0}", webrequest.Address);
            Console.WriteLine("RequestUri is {0}", webrequest.RequestUri);
            Console.WriteLine("Method is {0}", webrequest.Method);
            Console.WriteLine("Headers is {0}", webrequest.Headers);
            Console.WriteLine("{0}", postData);
                       
            WebResponse response = webrequest.GetResponse();
            string responseData = ReadResponseData(response.GetResponseStream());
            JObject jsonValue = JObject.Parse(responseData);
            AccessToken accessToken = new AccessToken
            {
                Value = (string)jsonValue["access_token"],
                ExpiresIn = TimeSpan.FromSeconds((int)jsonValue["expires_in"]),
                RetrievedAtUtc = DateTime.UtcNow,
                Type = (string)jsonValue["token_type"]
            };

            Console.WriteLine("**********Response from Authorization**********");
            Console.WriteLine("access_token is {0}", accessToken.Value);
            Console.WriteLine("expires_in is {0}", accessToken.ExpiresIn);
            Console.WriteLine("RetrievedAtUtc is {0}", accessToken.RetrievedAtUtc);
            Console.WriteLine("token_type is {0}", accessToken.Type);
            Console.WriteLine("IsValid is {0}", accessToken.IsValid());

            return accessToken;
        }


        public static string ReadResponseData(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return Encoding.Default.GetString(ms.ToArray());
            }
            
        }

        private static SecurityToken SendSecurityTokenRequest(string appliesTo, X509Certificate2 clientCertificate, string cvr)
        {                       
            var rst = new RequestSecurityToken
            {
                AppliesTo = new EndpointReference(appliesTo),
                RequestType = RequestTypes.Issue,
                TokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0",
                KeyType = KeyTypes.Asymmetric,
                Issuer = new EndpointReference(ConfigVariables.StsIssuer),
                UseKey = new UseKey(new X509SecurityToken(clientCertificate))
            };
            
            rst.Claims.Dialect = "http://docs.oasis-open.org/wsfed/authorization/200706/authclaims";
            rst.Claims.Add(new RequestClaim("dk:gov:saml:attribute:CvrNumberIdentifier", false, cvr));

            var client = GenerateStsCertificateClientChannel(clientCertificate);
          
            return client.Issue(rst);
        }
              

        private static IWSTrustChannelContract GenerateStsCertificateClientChannel(X509Certificate2 clientCertificate)
        {  
            var stsAddress = new EndpointAddress(new Uri(ConfigVariables.StsEndpoint), EndpointIdentity.CreateDnsIdentity(ConfigVariables.StsCertificateAlias));
            var binding = new MutualCertificateWithMessageSecurityBinding(null);
            var factory = new WSTrustChannelFactory(binding, stsAddress);
            factory.TrustVersion = TrustVersion.WSTrust13;
            factory.Credentials.ClientCertificate.Certificate = clientCertificate;
            var certificate = CertificateLoader.LoadCertificate(
                ConfigVariables.StsCertificateStoreName,
                ConfigVariables.StsCertificateStoreLocation,
                ConfigVariables.StsCertificateThumbprint);

            factory.Credentials.ServiceCertificate.ScopedCertificates.Add(stsAddress.Uri, certificate);
            factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            // Disable revocation checking (do not use in production)
            // Should be uncommented if you intent to call DemoService locally.
            //factory.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            factory.Endpoint.Contract.ProtectionLevel = ProtectionLevel.Sign;
            return factory.CreateChannel();
        }

        private static string EncodeSAMLToken(SecurityToken token)
        {
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
               ((GenericXmlSecurityToken) token).TokenXml.OwnerDocument.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                string samltokenOuterxml = stringWriter.GetStringBuilder().ToString();
                Console.WriteLine("SamlToken received : " + samltokenOuterxml);
                return Base64Encode(samltokenOuterxml);
            }
        }

        private static string Base64Encode(string plainText)
        {
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(textBytes);
        }
    }
}
