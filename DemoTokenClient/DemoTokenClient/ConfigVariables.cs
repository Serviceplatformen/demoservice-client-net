using System.Security.Cryptography.X509Certificates;

namespace DemoTokenClient
{
    // TO_BE_MODIFIED
    // All these constants can be modified to configure the client.
    // See document TEN0002 for details.
    static class ConfigVariables
    {
        // The alias used for Serviceplatformen endpoint identity check.
        public const string ServiceCertificateAlias = "kombit-sp-signing-test (funktionscertifikat)";

        // Thumbprint of the client certificate to call STS and Serviceplatformen.
        public const string ClientCertificateThumbprint = "3f 22 72 a1 83 37 f4 1a 60 86 c7 ef 02 c0 86 11 2c cb ef 2f";

        public const StoreLocation ClientCertificateStoreLocation = StoreLocation.CurrentUser;

        public const StoreName ClientCertificateStoreName = StoreName.My;

        // Entity ID for the Serviceplatform service to fetch token for and call.
        // This ID can be found in the service contract package from the Serviceplatform as 'service.entityID' inside /sp/service.properties.
        public const string ServiceEntityId = "http://demo.prod-serviceplatformen.dk/service/DemoService/1";

        // The STS issuer for token requests.
        public const string StsIssuer = "https://adgangsstyring.eksterntest-stoettesystemerne.dk/";
        
        // The endpoint of the STS (Secure Token Service).
        public const string StsEndpoint = "https://adgangsstyring.eksterntest-stoettesystemerne.dk/runtime/services/kombittrust/14/certificatemixed";

        // The alias used for STS endpoint identity check.
	public const string StsCertificateAlias = "test-ekstern-adgangsstyring (funktionscertifikat)";

        // Thumbprint of the certificate used for signing by STS.
        public const string StsCertificateThumbprint = "81 08 49 10 37 F7 7A 8F 9F 90 38 A0 FF ED 9D 2A 58 0B 84 91";

        public const StoreLocation StsCertificateStoreLocation = StoreLocation.CurrentUser;

        public const StoreName StsCertificateStoreName = StoreName.My;

        // The CVR of the municipality involved in the service agreement.
        // Used in the token request to STS.
        public const string Cvr = "29189846";

        // Below are some of the optional values that can be used in the CallContext.
        public const string AccountingInfo = ".Net DemoService sample call";
        public const string OnBehalfOfUser = "Jens Andersen";
        public const string CallersServiceCallIdentifier = "DemoPortType.test.uuid";
    }
}
