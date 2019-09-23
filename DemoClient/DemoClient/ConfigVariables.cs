namespace DemoClient
{
    // TO_BE_MODIFIED
    // All these constants can be modified to configure the client.
    // See the document "Programmers Guide - Serviceplatformen" for details.
    static class ConfigVariables
    {
        // Below are the four mandatory values that are needed as part of the InvocationContext.
        // In order to run this sample code you must change the values to match your own connection agreement and service agreement.
        public const string ServiceAgreementUUID = "17a44431-526a-416c-bb66-bd262049e751";
        public const string UserSystemUUID = "50be05bb-f31a-4673-9a93-d740e7397b16";
        public const string ServiceUUID = "d8a062c0-27d1-11e6-b67b-9e71128cae77";
        public const string UserUUID = "97782c1e-ec6a-4fcf-9c6c-cb030948d1d5";

        // Below are some of the optional values that can be added to the InvocationContext if desired.
        // They are also used with the optional CallContext, which can be sent along with an AuthorityContext.
        public const string AccountingInfo = "ed8aea2d-a6a4-40a1-bf5e-6adf583254ff";
        public const string OnBehalfOfUser = "behalfOfUserDemoServicePortType.test.uuid";
        public const string CallersServiceCallIdentifier = ".netDemoClientCall";

        // Below is the CVR number of the municipality involved in the service agreement. Used by the AuthorityContext.
        public const string CVR = "29189846";
    }
}
