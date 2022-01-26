﻿using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using Digst.OioIdws.LibBas.StrCustomization;

namespace Digst.OioIdws.LibBas.Bindings
{
    public class LibBasBinding : CustomBinding
    {
        private bool _useHttps = true;

        /// <summary>
        /// True specifies that transport layer security is required. False indicates the opposite.
        /// </summary>
        internal bool UseHttps
        {
            get { return _useHttps; }
            set { _useHttps = value; }
        }

        public override BindingElementCollection CreateBindingElements()
        {
            //var transport = _useHttps ? new HttpsTransportBindingElement() : new HttpTransportBindingElement();

            // Added to always use HTTPS and require client certificate
            var transport = new HttpsTransportBindingElement();
            transport.RequireClientCertificate = true;

            var encoding = new TextMessageEncodingBindingElement();
            // [LIB-BAS] requires SOAP 1.1 and WS-Adressing 1.0
            encoding.MessageVersion = MessageVersion.Soap11WSAddressing10;

            // AlwaysToInitiator is required by the [LIB-BAS] profile. This specifies that the server certificate must be embedded in the response.
            var recipientTokenParameters = new X509SecurityTokenParameters(
                X509KeyIdentifierClauseType.Any,
                SecurityTokenInclusionMode.AlwaysToInitiator);

            var initiatorTokenParameters = new CustomizeIdStrIssuedSecurityTokenParameters(
                "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0");
            initiatorTokenParameters.UseStrTransform = true;

            var asymmetric = new AsymmetricSecurityBindingElement(recipientTokenParameters, initiatorTokenParameters);

            // Must be true in order for client to accept embedded server certificates instead of references. This is required by the [LIB-BAS] profile.
            // However, the client must still specify the server certificate explicitly.
            // Have not figured out how the client can use the embedded server certificate and make trust to it through a CA certificate and a CN (Common Name). This way the client should not need the server certificate.
            asymmetric.AllowSerializedSigningTokenOnReply = true;

            // No need for derived keys when both parties has a certificate. Also LIB-BAS does not make use of derived keys.
            asymmetric.SetKeyDerivation(false);

            // Include token (encrypted assertion from NemLog-in STS) in signature
            asymmetric.ProtectTokens = true;
            asymmetric.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic256Sha256;
            
            // Specifies that WCF can send and receive unsecured responses to secured requests.
            // Concrete this means that SOAP faults are send unencrypted. [LIB-BAS] does not specify whether or not SOAP faults can be encrypted but it looks like they should not be encrypted.
            // If encrypted the client is not able to process the encrypted SOAP fault if client is not setup correctly.
            // setting EnableUnsecuredResponse to true makes normal responses unsigned and processed by the client without error. This is not what we want :)
            //asymmetric.EnableUnsecuredResponse = true;

            var elements = new BindingElementCollection();
            elements.Add(asymmetric);
            elements.Add(encoding);
            elements.Add(transport);

            return elements;
        }
    }
}