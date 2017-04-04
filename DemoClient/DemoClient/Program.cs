using System;

namespace DemoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string securityModel;
            string message;
            string endpointURL = null;
            bool pressButtonForExit = true;

            // This part of code allows to call client through the console without user interaction.
            // That's why some variables should be set from arguments.
            if (args.Length == 2 || args.Length == 3)
            {
                securityModel = args[0];
                message = args[1];
                pressButtonForExit = false;

                if (args.Length == 3)
                {
                    endpointURL = args[2];
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Choose context for calling DemoService: ");
                    Console.WriteLine("1: AuthorityContext");
                    Console.WriteLine("2: InvocationContext");

                    securityModel = Console.ReadLine();

                    if ("1".Equals(securityModel) || "2".Equals(securityModel))
                    {
                        break;
                    }
                    Console.WriteLine("\nInvalid option. Try again.");
                }

                Console.WriteLine("\nWrite a message to send to DemoService: ");
                message = Console.ReadLine();
            }

            if ("1".Equals(securityModel))
            {
                // Call DemoService with Authority Context.
                string authorityContextResponse =
                    new DemoServiceAuthorityContext().CallDemoServiceWithAuthorityContext(message, endpointURL);
                Console.WriteLine("\nCalling DemoService with AuthorityContext...");
                Console.WriteLine("Response from DemoService:\n");
                Console.WriteLine(authorityContextResponse);
            }
            else if ("2".Equals(securityModel))
            {
                // Call DemoService with Invocation Context.
                string invocationContextResponse =
                    new DemoServiceInvocationContext().CallDemoServiceWithInvocationContext(message, endpointURL);
                Console.WriteLine("\nCalling DemoService with InvocationContext...");
                Console.WriteLine("Response from DemoService:\n");
                Console.WriteLine(invocationContextResponse);
            }

            if (pressButtonForExit)
            {
                Console.WriteLine("\nPress any key to exit");
                Console.ReadKey();
            }
        }
    }
}