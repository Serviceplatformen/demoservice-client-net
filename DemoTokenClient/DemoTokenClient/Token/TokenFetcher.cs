using System;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace DemoTokenClient
{
    public class TokenFetcher
    {
        public static SecurityToken IssueToken(string entityId)
        {
            return SendRequestSecurityTokenRequest(new Uri(entityId).AbsoluteUri, CertificateLoader.LoadCertificateFromMyStore(ConfigVariables.ClientCertThumbprint), ConfigVariables.CVR);
        }

        private static SecurityToken SendRequestSecurityTokenRequest(string appliesTo, X509Certificate2 clientCertificate, string cvr)
        {
            var rst = new RequestSecurityToken
            {
                AppliesTo = new EndpointReference(appliesTo),
                RequestType = RequestTypes.Issue,
                TokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0",
                KeyType = KeyTypes.Asymmetric,
                Issuer = new EndpointReference(ConfigVariables.STSIssuer),
                UseKey = new UseKey(new X509SecurityToken(clientCertificate))
            };

            rst.Claims.Dialect = "http://docs.oasis-open.org/wsfed/authorization/200706/authclaims";
            rst.Claims.Add(new RequestClaim("dk:gov:saml:attribute:CvrNumberIdentifier", false, cvr));

            var client = GenerateStsCertificateClientChannel(clientCertificate);
            return client.Issue(rst);
        }

        private static IWSTrustChannelContract GenerateStsCertificateClientChannel(X509Certificate2 clientCertificate)
        {
            var stsAddress = new EndpointAddress(new Uri(ConfigVariables.STSEndpoint), EndpointIdentity.CreateDnsIdentity(ConfigVariables.STSCertAlias));
            var binding = new MutualCertificateWithMessageSecurityBinding(null);
            var factory = new WSTrustChannelFactory(binding, stsAddress);

            factory.TrustVersion = TrustVersion.WSTrust13;
            factory.Credentials.ClientCertificate.Certificate = clientCertificate;
            factory.Credentials.ServiceCertificate.ScopedCertificates.Add(stsAddress.Uri, CertificateLoader.LoadCertificateFromTrustedPeopleStore(ConfigVariables.STSCertThumbprint));
            factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            // Disable revocation checking (do not use in production)
            // Should be uncommented if you intent to call DemoService locally.
            // factory.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            factory.Endpoint.Contract.ProtectionLevel = ProtectionLevel.Sign;

            return factory.CreateChannel();
        }
    }
}
