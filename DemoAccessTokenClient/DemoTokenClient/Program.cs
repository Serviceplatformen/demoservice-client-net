using System;
using DemoTokenClient.Token;

namespace DemoTokenClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("\nEnter CPR (10 digits) or 'q' for exit");
                    string cpr = Console.ReadLine();
                    if ("q".Equals(cpr)) return;

                    var client = new SF1520SoapServiceToken();
                    var resp = client.CallPersonLookup(cpr);

                    Console.WriteLine("=== SUCCESS ===");
                    Console.WriteLine("Fornavn: " + resp?.persondata?.navn?.fornavn);
                    Console.WriteLine("Efternavn: " + resp?.persondata?.navn?.efternavn);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }
    }
}
