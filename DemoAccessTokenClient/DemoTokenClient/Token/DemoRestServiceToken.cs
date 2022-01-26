using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IdentityModel.Tokens;
using DemoTokenClient.Token;
using System.IO;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Web;
using System.Runtime.Caching;

namespace DemoTokenClient.Token
{
    class DemoRestServiceToken
    {
        private static readonly MemoryCache accessTokenCache = new MemoryCache("accessTokenCache");

        private static readonly MemoryCache samlTokenCache = new MemoryCache("samlTokenCache");
        // Datetime formats
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ"; // Results in format 2015-01-14T14:50:24Z mandated by spec.
            
        private string ReadRequestData(Stream input)
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
          

        private string SendRequest(AccessToken token, string message, string errorMessage)
        {
           
            String demoServiceURL = ConfigVariables.DemoServiceUrl + message;
            UriBuilder demoServiceURI =  new UriBuilder(demoServiceURL);
            if (errorMessage != null && !errorMessage.Equals(""))
            {
                string queryToAppend = HttpUtility.UrlEncode("errogrMessage=")  + HttpUtility.UrlEncode(errorMessage);
                demoServiceURI.Query = queryToAppend;
                
            }
           
            try { 
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(demoServiceURI.Uri);
                webrequest.Method = "GET";
                webrequest.ContentType = "application/json";
                TokenFetcher.AddClientCertificate(ref webrequest);
                webrequest.Headers.Add("Authorization", "Holder-of-key " + token.Value);
                string transaktionsId = Guid.NewGuid().ToString();
                webrequest.Headers.Add("x-TransaktionsId", transaktionsId);
                string transaktionsTid = DateTime.UtcNow.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
                webrequest.Headers.Add("x-TransaktionsTid", transaktionsTid);
           
                Console.WriteLine("----------");
                Console.WriteLine("Request URL: " + demoServiceURI.Uri.OriginalString);
                Console.WriteLine("Request Headers: " + webrequest.Headers);
                Console.WriteLine("----------");

                WebResponse response = webrequest.GetResponse();
                Console.WriteLine("**********Response From Demo Service******************************");
                Console.WriteLine("\nContentType: " + response.ContentType);
                Console.WriteLine("ContentLength: " + response.ContentLength);
                Console.WriteLine("Headers: " + response.Headers);
                Console.WriteLine("Type: " + response.GetType());
                Console.WriteLine("IsFromCache: " + response.IsFromCache);
                Console.WriteLine("ResponseUri: " + response.ResponseUri);           
                string responseData = TokenFetcher.ReadResponseData(response.GetResponseStream());
                response.Close();
                return responseData;
            }
            catch (WebException webExcp)
            {
                // If you reach this point, an exception has been caught.  
                Console.WriteLine("A WebException has been caught.");
                // Write out the WebException message.  
                Console.WriteLine(webExcp.ToString());
                // Get the WebException status code.  
                WebExceptionStatus status = webExcp.Status;
                // If status is WebExceptionStatus.ProtocolError,
                //   there has been a protocol error and a WebResponse
                //   should exist. Display the protocol error.  
                if (status == WebExceptionStatus.ProtocolError)
                {
                    Console.Write("The server returned protocol error ");
                    // Get HttpWebResponse so that you can check the HTTP status code.  
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                   
                    Console.WriteLine((int)httpResponse.StatusCode + " - "
                       + httpResponse.StatusCode);
                }
                return errorMessage;
            }
            catch (Exception e)
            {
                // Code to catch other exceptions goes here.
                Console.WriteLine(e.Message);
                return errorMessage;
            }
           

        }


        public void CallService(string message, string errorMessage)
         {

              ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
              AccessToken accessToken = (AccessToken)accessTokenCache.Get(ConfigVariables.AccessTokenServiceUrl);
              string responseData;
              if (accessToken != null) {
                Console.WriteLine("AccessToken received from Cache: " + accessToken.Value);
                responseData = SendRequest(accessToken, message, errorMessage);
                Console.WriteLine("ResponseData:\n" + responseData);

                return;
              }
            
              SecurityToken samltoken = (SecurityToken)samlTokenCache.Get(ConfigVariables.DemoServiceUrl);
              if (samltoken == null) { 
                    // Get SAML token

                
                  samltoken = (SecurityToken)TokenFetcher.IssueSamlToken(ConfigVariables.ServiceEntityId);
                  samlTokenCache.Add(new CacheItem(ConfigVariables.DemoServiceUrl, samltoken),
                    new CacheItemPolicy { AbsoluteExpiration = samltoken.ValidTo.ToUniversalTime() });
                //print all cache key value again to check updates
                Console.WriteLine("All key-values after updates of samlTokenCache ");
                PrintAllCache(samlTokenCache);
              }
                                     
              Console.WriteLine("SamlTokenId: " + samltoken.Id);
              // Convert to Access Token
              accessToken = TokenFetcher.ConvertToAccessToken(samltoken);
              Console.WriteLine("AccessToken received from Service: " + accessToken.Value);
              accessTokenCache.Add(new CacheItem(ConfigVariables.AccessTokenServiceUrl, accessToken),
              new CacheItemPolicy { AbsoluteExpiration = DateTime.UtcNow + accessToken.ExpiresIn });
              //print all cache key value again to check updates
              Console.WriteLine("All key-values after updates of accessTokenCache ");
              PrintAllCache(accessTokenCache);
              // Call REST service
              responseData = SendRequest(accessToken, message, errorMessage);
              Console.WriteLine("ResponseData:\n" + responseData);
                         
         }

        public static void PrintAllCache(ObjectCache cache)
        {
            //loop through all key-value pairs and print them
            foreach (var item in cache)
            {
                Console.WriteLine("cache object key-value: " + item.Key + "-" + item.Value);
                if (item.Value is AccessToken)
                {
                    AccessToken accessToken =(AccessToken) item.Value;
                    Console.WriteLine("access_token is {0}", accessToken.Value);
                    Console.WriteLine("expires_in is {0}", accessToken.ExpiresIn);
                    Console.WriteLine("RetrievedAtUtc is {0}", accessToken.RetrievedAtUtc);
                    Console.WriteLine("token_type is {0}", accessToken.Type);
                }
                
            }
        }
    }
}

  