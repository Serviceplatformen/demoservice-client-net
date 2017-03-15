using System;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.Security;
using System.ServiceModel;
using DemoTokenClient.DemoService;

namespace DemoTokenClient
{
    public class DemoServiceToken
    {
        public string CallDemoServiceWithToken(string message, string endpointURL)
        {
            var token = TokenFetcher.IssueToken(ConfigVariables.ServiceEntityID);

            callDemoServiceRequest request = new callDemoServiceRequest
            {
                CallDemoServiceRequest1 = new CallDemoServiceRequestType
                {
                    messageString = message,
                    CallContext = GetCallContext()
                }
            };

            DemoPortType channel = CreateChannel(token, endpointURL);

            // Security protocols supported by the DemoService
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 |
                                                   SecurityProtocolType.Ssl3;

            // Disable server certificate check when using self-signed certificate (do not use in production).
            // Should be uncommented if you intent to call DemoService locally.
            // ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;

            callDemoServiceResponse response = channel.callDemoService(request);
            return response.CallDemoServiceResponse1.responseString;
        }

        private DemoPortType CreateChannel(SecurityToken token, string endpointURL)
        {
            DemoPortTypeClient demoPortType = new DemoPortTypeClient();

            // Disable revocation checking (do not use in production).
            // Should be uncommented if you intent to call DemoService locally.
            // demoPortType.ClientCredentials.ServiceCertificate.Authentication.RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck;

            EndpointIdentity identity = EndpointIdentity.CreateDnsIdentity(ConfigVariables.ServiceCertAlias);
            EndpointAddress endpointAddress = endpointURL != null ? new EndpointAddress(new Uri(endpointURL), identity) : new EndpointAddress(demoPortType.Endpoint.Address.Uri, identity);

            demoPortType.Endpoint.Address = endpointAddress;
            demoPortType.ClientCredentials.ClientCertificate.Certificate = CertificateLoader.LoadCertificateFromMyStore(ConfigVariables.ClientCertThumbprint);
            demoPortType.Endpoint.Contract.ProtectionLevel = ProtectionLevel.Sign;

            return demoPortType.ChannelFactory.CreateChannelWithIssuedToken(token);
        }

        private static CallContextType GetCallContext()
        {
            return new CallContextType()
            {
                AccountingInfo = ConfigVariables.AccountingInfo,
                OnBehalfOfUser = ConfigVariables.OnBehalfOfUser,
                CallersServiceCallIdentifier = ConfigVariables.CallersServiceCallIdentifier
            };
        }
    }
}