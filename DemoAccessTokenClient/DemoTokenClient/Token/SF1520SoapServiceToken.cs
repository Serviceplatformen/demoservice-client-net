using System;
using System.Net;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using DemoTokenClient.SF1520;

namespace DemoTokenClient.Token
{
    internal class SF1520SoapServiceToken
    {
        private const string Sf1520Url = "https://exttest.serviceplatformen.dk/service/CPR/PersonBaseDataExtended/5";

        public PersonLookupResponseType CallPersonLookup(string cpr10)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new PersonBaseDataExtendedPortTypeClient("PersonBaseDataExtended_v5");

            // === A) Client cert (dit funktionscert) ===
            var clientCert = CertificateLoader.LoadCertificate(
                ConfigVariables.ClientCertificateStoreName,
                ConfigVariables.ClientCertificateStoreLocation,
                ConfigVariables.ClientCertificateThumbprint);

            client.ClientCredentials.ClientCertificate.Certificate = clientCert;

            // === B) STS (ADG) cert til token-issuer identity ===
            var adgStsCert = CertificateLoader.LoadCertificate(
                StoreName.TrustedPeople,
                StoreLocation.CurrentUser,
                ConfigVariables.StsCertificateThumbprint);

            client.ClientCredentials.IssuedToken.LocalIssuerAddress =
                new EndpointAddress(new Uri(ConfigVariables.StsEndpoint),
                    EndpointIdentity.CreateX509CertificateIdentity(adgStsCert));

            client.ClientCredentials.IssuedToken.LocalIssuerBinding =
                new MutualCertificateWithMessageSecurityBinding();

            // === C) Serviceplatform (SP) cert til SELVE SF1520 endpointet ===
            var spServiceCert = CertificateLoader.LoadCertificate(
                StoreName.TrustedPeople,
                StoreLocation.CurrentUser,
                ConfigVariables.ServicePlatformCertificateThumbprint);

            // Pin cert til SF1520 endpoint
            client.ClientCredentials.ServiceCertificate.ScopedCertificates.Add(
                new Uri(Sf1520Url),
                spServiceCert);

            // Sørg for at endpoint identity matcher DNS som WCF forventer
            client.Endpoint.Address = new EndpointAddress(
                new Uri(Sf1520Url),
                EndpointIdentity.CreateDnsIdentity("exttest.serviceplatformen.dk"));

            // (Kun til test – fjern igen senere)
            client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                System.ServiceModel.Security.X509CertificateValidationMode.None;

            // === Call ===
            var req = new PersonLookupRequestType { PNR = cpr10 };
            return client.PersonLookup(req);
        }
    }
}
