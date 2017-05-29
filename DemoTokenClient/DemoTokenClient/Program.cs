using System;

namespace DemoTokenClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string endpointURL = null;
            string message;
            bool pressButtonForExit = true;

            // This part of code allows to call client through the console without user interaction.
            // That's why some variables should be set from arguments.
            if (args.Length == 1 || args.Length == 2)
            {
                message = args[0];
                pressButtonForExit = false;

                if (args.Length == 2)
                {
                    endpointURL = args[1];
                }
            }
            else
            {
                Console.WriteLine("Write a message to send to DemoService: ");
                message = Console.ReadLine();
            }

            Console.WriteLine("\nCalling DemoService with token...");
            string demoServiceResponse = new DemoServiceToken().CallDemoServiceWithToken(message, endpointURL);
            Console.WriteLine("Response from DemoService:\n");
            Console.WriteLine(demoServiceResponse);

            if (pressButtonForExit)
            {
                Console.WriteLine("\nPress any key to exit");
                Console.ReadKey();
            }
        }
    }
}