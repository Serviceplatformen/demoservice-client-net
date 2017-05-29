using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

namespace DemoTokenClient
{
    public class MutualCertificateWithMessageSecurityBinding : CustomBinding
    {
        public MutualCertificateWithMessageSecurityBinding() : base(CreateBindingElements(null))
        {
        }

        public MutualCertificateWithMessageSecurityBinding(Func<MessageEncodingBindingElement> messageEncodingElementFunc) : base(CreateBindingElements(messageEncodingElementFunc))
        {
        }

        private static BindingElementCollection CreateBindingElements(Func<MessageEncodingBindingElement> encodingElementFunc)
        {
            var transportBinding = CreateTransportBindingElement();
            var encodingBinding = CreateEncodingBindingElement(encodingElementFunc);
            var securityBinding = CreateSecurityBindingElement();

            var bindings = new BindingElementCollection();
            bindings.Add(securityBinding);
            bindings.Add(encodingBinding);
            bindings.Add(transportBinding);

            return bindings;
        }

        private static HttpTransportBindingElement CreateTransportBindingElement()
        {
            return new HttpsTransportBindingElement { RequireClientCertificate = false };
        }

        private static MessageEncodingBindingElement CreateEncodingBindingElement(Func<MessageEncodingBindingElement> encodingElementFunc)
        {
            if (encodingElementFunc != null)
            {
                return encodingElementFunc();
            }

            var messageEncodingBindingElement = new TextMessageEncodingBindingElement()
            {
                MessageVersion = MessageVersion.Soap12WSAddressing10
            };

            return messageEncodingBindingElement;
        }

        private static SecurityBindingElement CreateSecurityBindingElement()
        {
            var messageSecurity = new AsymmetricSecurityBindingElement();

            messageSecurity.AllowSerializedSigningTokenOnReply = true;
            messageSecurity.MessageSecurityVersion = MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
            messageSecurity.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128Sha256;
            messageSecurity.MessageProtectionOrder = MessageProtectionOrder.EncryptBeforeSign;
            messageSecurity.LocalClientSettings.MaxClockSkew = new TimeSpan(0, 0, 1, 0);
            messageSecurity.LocalClientSettings.TimestampValidityDuration = new TimeSpan(0, 0, 10, 0);
            messageSecurity.LocalServiceSettings.MaxClockSkew = new TimeSpan(0, 0, 1, 0);
            messageSecurity.LocalClientSettings.TimestampValidityDuration = new TimeSpan(0, 0, 10, 0);

            var x509SecurityParamter = new X509SecurityTokenParameters(X509KeyIdentifierClauseType.Any, SecurityTokenInclusionMode.AlwaysToInitiator);
            messageSecurity.RecipientTokenParameters = x509SecurityParamter;
            messageSecurity.RecipientTokenParameters.RequireDerivedKeys = false;

            var initiator = new X509SecurityTokenParameters(X509KeyIdentifierClauseType.Any, SecurityTokenInclusionMode.AlwaysToRecipient) { RequireDerivedKeys = false };
            messageSecurity.InitiatorTokenParameters = initiator;

            return messageSecurity;
        }
    }
}
