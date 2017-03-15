namespace DemoTokenClient
{
    // TO_BE_MODIFIED
    // All these constants can be modified to configure client.
    // See document TEN0002 for details.
    static class ConfigVariables
    {
        // The alias used for Serviceplatformen endpoint identity check.
        public const string ServiceCertAlias = "kombit-sp-signing-test (funktionscertifikat)";

        // Thumbprint of the client certificate to call STS and Serviceplatformen.
        public const string ClientCertThumbprint = "3f 22 72 a1 83 37 f4 1a 60 86 c7 ef 02 c0 86 11 2c cb ef 2f";

        // Entity ID for the Serviceplatformen service to fetch token for and call.
        // This ID can be found in the service contract package from Serviceplatformen as 'service.entityID' inside /sp/service.properties.
        public const string ServiceEntityID = "http://demo.prod-serviceplatformen.dk/service/DemoService/1";

        // The STS issuer for token requests.
        public const string STSIssuer = "https://adgangsstyring.eksterntest-stoettesystemerne.dk/";
        
        // The endpoint of the STS.
        public const string STSEndpoint = "https://adgangsstyring.eksterntest-stoettesystemerne.dk/runtime/services/kombittrust/14/certificatemixed";

        // The alias used for STS endpoint identity check.
        public const string STSCertAlias = "KOMBIT Støttesystemer-T (funktionscertifikat)";

        // Thumbprint of the certificate used for signing by STS.
        public const string STSCertThumbprint = "3a 10 3c f6 0a 9d 97 7b a5 a4 99 3e 06 d8 c9 ba 36 f2 58 3e";

        // The CVR of the municipality involved in the service agreement.
        // Used in the token request to STS.
        public const string CVR = "29189846";

        // Below are some of the optional values that can be used in the CallContext.
        public const string AccountingInfo = ".Net DemoService sample call";
        public const string OnBehalfOfUser = "Jens Andersen";
        public const string CallersServiceCallIdentifier = "DemoPortType.test.uuid";
    }
}
