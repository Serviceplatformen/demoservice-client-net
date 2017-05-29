using System;
using System.Security.Cryptography.X509Certificates;

namespace DemoTokenClient
{
    public static class CertificateLoader
    {
        public static X509Certificate2 LoadCertificateFromMyStore(string thumbprint)
        {
            return LoadCertificateFromStore(StoreName.My, StoreLocation.LocalMachine, thumbprint);
        }

        public static X509Certificate2 LoadCertificateFromTrustedPeopleStore(string thumbprint)
        {
            return LoadCertificateFromStore(StoreName.TrustedPeople, StoreLocation.LocalMachine, thumbprint);
        }

        private static X509Certificate2 LoadCertificateFromStore(StoreName storeName, StoreLocation storeLocation,
            string thumbprint)
        {
            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);
            var result = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);

            if (result.Count == 0)
            {
                throw new ArgumentException("No certificate with thumbprint " + thumbprint + " is found.");
            }

            return result[0];
        }
    }
}
