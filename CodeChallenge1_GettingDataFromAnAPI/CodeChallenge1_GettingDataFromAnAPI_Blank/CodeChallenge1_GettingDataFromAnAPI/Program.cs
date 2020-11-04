using System.Threading.Tasks;
using CodeChallenge1_GettingDataFromAnAPI.Controllers;
using System;

namespace CodeChallenge1_GettingDataFromAnAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /**
             * Objective: Write a controller to pull data from an API.
             * I don't want to see too much work done within this main class. You should encapsulate anything you can in a
             * controller. Output the result to the console window.
             * 
             * Endpoint: https://ccm.cps.golf/RegressionSRCCM/Transactions.svc/GetTerminalIdentifiers
             * Result type: String array
             * User: Regression
             * User Token: f8cd3f4554f74a89bdb625bc
             * 
             * To authenticate against this API, you need to send an HTTP header called Authorization and provide the username
             * and user token in the format of user:token as a Base64 encoded string.
             * 
             * Helpers:
             * EncodingHelper class in the Helpers folder will allow you to encode/decode a base64 string for doing API autentication. 
             * The use case is EncodingHelper.Encode(string).
             * 
             * NuGet Packages:
             * Newtonsoft.Json allows you to convert JSON replies from API requests to a usable object or vice versa. Documentation: https://www.newtonsoft.com/json
             * 
             * Advice #1 - The System.Net.Http.HttpClient class will allow you to send/receive responses from an API. Documentation: https://www.dotnetperls.com/httpclient
             * Advice #2 - API requests are done asynchronously so you'll have to use an await.
             * Advice #3 - Here's how you add the auth header after Base64 encoding it: client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", AUTHENTICATION);
             * Advice #4 - Even though you aren't passing any body to the API, the Credit Card API still requires you to use a POST request.
             * Advice #5 - When doing the JSONConvert, deserialize the result to type string[].
             * */
            CreditCardAPIController CCMTerminalList = new CreditCardAPIController("Regression", "f8cd3f4554f74a89bdb625bc");

            string[] terminalList = await CCMTerminalList.GetTerminalIdentifiers();

            foreach (string terminal in terminalList)
            {
                System.Console.WriteLine(terminal);
            }
            System.Console.ReadLine();
        }
    }
}
