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
				
				while(true)					
                {
					Console.WriteLine("\nEnter test message or 'q' for exit");
					string message = Console.ReadLine();
					if ("q".Equals(message)) {
						return;
                    } else {
						Console.WriteLine("\nEnter error message");
						string errorMessage = Console.ReadLine();

						DemoRestServiceToken client = new DemoRestServiceToken();
						client.CallService(message, errorMessage);
                        Console.WriteLine("Test");
					}
                }
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.ToString());
			}
		} 
    }
}
