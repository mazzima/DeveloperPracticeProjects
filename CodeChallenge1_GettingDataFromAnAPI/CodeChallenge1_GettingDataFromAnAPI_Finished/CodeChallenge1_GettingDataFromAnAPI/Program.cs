using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge1_GettingDataFromAnAPI.Controllers;

namespace CodeChallenge1_GettingDataFromAnAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /**
             * Objective: Write a controller to pull data from an API. Data must be stored in a model. 
             * I don't want to see too much work done within this main class. You should encapsulate anything you can in a
             * controller.
             * 
             * Endpoint: https://ccm.cps.golf/RegressionSRCCM/Transactions.svc/GetTerminalIdentifiers
             * Result type: List of Strings
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
             * Newtonsoft.Json allows you to convert JSON replies from API requests to a usable object or vice versa.
             * 
             * Advice - The HttpClient class will allow you to send/receive responses from an API. API requests are done asynchronously
             * so you'll have to use an await.
             * */
            CreditCardAPIController creditCardAPIController = new CreditCardAPIController();
            creditCardAPIController.user = "Regression";
            creditCardAPIController.token = "f8cd3f4554f74a89bdb625bc";

            string[] resultList = await creditCardAPIController.GetTerminalIdentifiers();

            foreach (string s in resultList)
            {
                System.Console.WriteLine(s);
            }
            System.Console.ReadLine();
        }
    }
}
