using System;
using System.ServiceModel.Security;

namespace Digst.OioIdws.LibBas.Bindings
{
    internal class CustomAlgorithmSuite : SecurityAlgorithmSuite
    {
        public override string DefaultAsymmetricKeyWrapAlgorithm
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128Sha256.DefaultAsymmetricKeyWrapAlgorithm;
            }
        }

        public override string DefaultAsymmetricSignatureAlgorithm
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128Sha256.DefaultAsymmetricSignatureAlgorithm;
            }
        }

        public override string DefaultCanonicalizationAlgorithm
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128Sha256.DefaultCanonicalizationAlgorithm;
            }
        }

        public override string DefaultDigestAlgorithm
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128.DefaultDigestAlgorithm;
            }
        }

        public override string DefaultEncryptionAlgorithm
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128Sha256.DefaultEncryptionAlgorithm;
            }
        }

        public override int DefaultEncryptionKeyDerivationLength
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128Sha256.DefaultEncryptionKeyDerivationLength;
            }
        }

        public override int DefaultSignatureKeyDerivationLength
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128Sha256.DefaultEncryptionKeyDerivationLength;
            }
        }

        public override int DefaultSymmetricKeyLength
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128Sha256.DefaultSymmetricKeyLength;
            }
        }

        public override string DefaultSymmetricKeyWrapAlgorithm
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128Sha256.DefaultSymmetricKeyWrapAlgorithm;
            }
        }

        public override string DefaultSymmetricSignatureAlgorithm
        {
            get
            {
                return SecurityAlgorithmSuite.Basic128Sha256.DefaultSymmetricSignatureAlgorithm;
            }
        }

        public override bool IsAsymmetricKeyLengthSupported(int length)
        {
            return SecurityAlgorithmSuite.Basic128Sha256.IsAsymmetricKeyLengthSupported(length);
        }

        public override bool IsSymmetricKeyLengthSupported(int length)
        {
            return SecurityAlgorithmSuite.Basic128Sha256.IsSymmetricKeyLengthSupported(length);
        }
    }
}