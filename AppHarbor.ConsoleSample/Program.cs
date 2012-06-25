using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;

namespace AppHarbor.ConsoleSample
{
    public class Program
    {
        public static void Main(string[] arguments)
        {
            //CheckUsage(arguments);

            //string clientId = arguments[0];
            //string clientSecret = arguments[1];

            string clientId = "49e17241-0631-47ec-bbf5-eface6552ea8";
            string clientSecret = "1d4e4d1b-9798-4bd3-bd86-f17ca00505e3";

            Console.WriteLine("Please authorize this application in the browser window that has just opened");
            var authInfo = GetAuthorization(clientId, clientSecret);

            Console.WriteLine("Authorization successful");
            var client = new AppHarborClient(authInfo);

            Console.WriteLine("Applications:");
            foreach (var application in client.GetApplications())
            {
                Console.WriteLine(" - {0}, {1}", application.Name, application.Slug);
                var builds = client.GetBuilds(application.Slug);
                Console.WriteLine("Builds:\n{0}", String.Join(", ", builds.Select(x => new { x.Status, x.Deployed, x.DownloadUrl })));
            }            
            
            var user = client.GetUser();
            Console.WriteLine("User: {0}, Email: {1}", user.Username, String.Join(", ", user.Email_Addresses));
        }

        private static void CheckUsage(string[] arguments)
        {
            if (arguments.Length != 2)
            {
                Console.WriteLine("Usage: {0} [clientId] [clientSecret]", ExecutableName);
                Environment.Exit(1);
            }
        }

        private static AuthInfo GetAuthorization(string clientId, string clientSecret)
        {
            try
            {
                return AppHarborClient.AskForAuthorization(clientId, clientSecret, TimeSpan.FromMinutes(1));
            }
            catch (AuthenticationException)
            {
                Console.WriteLine("Failed to get authorization");
                Environment.Exit(-1);
                throw;
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Timeout, you have to be faster than that");
                Environment.Exit(-1);
                throw;
            }
        }

        private static string ExecutableName
        {
            get
            {
                return Path.GetFileName(Assembly.GetEntryAssembly().Location);
            }
        }
    }
}
