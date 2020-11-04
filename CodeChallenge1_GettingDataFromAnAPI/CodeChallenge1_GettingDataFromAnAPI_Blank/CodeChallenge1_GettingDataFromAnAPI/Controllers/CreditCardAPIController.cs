using System;
using System.Threading.Tasks;
using CodeChallenge1_GettingDataFromAnAPI.Helpers;
using Newtonsoft.Json;
using System.Net.Http;

namespace CodeChallenge1_GettingDataFromAnAPI.Controllers
{
    public class CreditCardAPIController
    {
        private const string TERMINALURL = "https://ccm.cps.golf/RegressionSRCCM/Transactions.svc/GetTerminalIdentifiers";

        private string mUserName = "";
        private string mToken = "";

        public CreditCardAPIController(string pUserName, string pToken)
        {
            mUserName = pUserName;
            mToken = pToken;
        }

        public async Task<string[]> GetTerminalIdentifiers()
        {
            string[] results;

            EncodingHelper encoder = new EncodingHelper();

            string authCode = encoder.Encode(mUserName + ":" + mToken);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", authCode);
                var response = await client.PostAsync(TERMINALURL, null);
                var reply = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<string[]>(reply);
            }

            return results;
        }
        
    }
}
