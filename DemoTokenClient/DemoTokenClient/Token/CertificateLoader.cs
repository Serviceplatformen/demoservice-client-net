using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DemoTokenClient.Token
{
    public static class CertificateLoader
    {
        public static X509Certificate2 LoadCertificate(StoreName storeName, StoreLocation storeLocation,
            string thumbprint)
        {
            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);
            var cleanThumbprint = GetThumbprintWithoutProblematicCharacters(thumbprint);
            var result = store.Certificates.Find(X509FindType.FindByThumbprint, cleanThumbprint, false);

            if (result.Count == 0)
            {
                throw new ArgumentException("No certificate with thumbprint " + cleanThumbprint + " is found.");
            }

            return result[0];
        }

        /// <summary>
        /// When copy-pasting from the Windows "certmgr" some unprintable characters are copied.
        /// This method removes these characters.
        /// </summary>
        /// <param name="thumbprint"></param>
        /// <returns></returns>
        private static string GetThumbprintWithoutProblematicCharacters(string thumbprint)
        {
            var acceptableCharacters = "0123456789abcdefABCDEF ";
            var result = new StringBuilder(thumbprint.Length);
            foreach (char c in thumbprint)
            {
                if (!(-1 < acceptableCharacters.IndexOf(c)))
                    continue;
                result.Append(c);
            }
            return result.ToString().ToUpper();
        }
    }
}
