using System;
using System.Net;
using System.ServiceModel;
using DemoClient.DemoService;

namespace DemoClient
{
    public class DemoServiceInvocationContext
    {
        // Certificate and URL are configured in the app.config.
        private static InvocationContextType GetInvocationContext()
        {
            return new InvocationContextType()
            {
                ServiceAgreementUUID = ConfigVariables.ServiceAgreementUUID,
                UserSystemUUID = ConfigVariables.UserSystemUUID,
                UserUUID = ConfigVariables.UserUUID,
                ServiceUUID = ConfigVariables.ServiceUUID,
                AccountingInfo = ConfigVariables.AccountingInfo,
                OnBehalfOfUser = ConfigVariables.OnBehalfOfUser,
                CallersServiceCallIdentifier = ConfigVariables.CallersServiceCallIdentifier
            };
        }

        public string CallDemoServiceWithInvocationContext(string message, string endpointURL)
        {
            // Security protocols supported by the DemoService.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            DemoPortTypeClient demoPortType = new DemoPortTypeClient();
            if (endpointURL != null)
            {
                EndpointAddress endpointAddress = new EndpointAddress(new Uri(endpointURL));
                demoPortType.Endpoint.Address = endpointAddress;
            }

            DemoPortType channel = demoPortType.ChannelFactory.CreateChannel();

            callDemoServiceRequest request = new callDemoServiceRequest()
            {
                CallDemoServiceRequest1 = new CallDemoServiceRequestType()
                {
                    messageString = message,
                    InvocationContext = GetInvocationContext()
                }
            };
	    
            // Disable server certificate check when using self-signed certificate (do not use in production).
            // Should be uncommented if you intent to call DemoService locally.
            // ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;

            var response = channel.callDemoService(request);
            return response.CallDemoServiceResponse1.responseString;
        }
    }
}
