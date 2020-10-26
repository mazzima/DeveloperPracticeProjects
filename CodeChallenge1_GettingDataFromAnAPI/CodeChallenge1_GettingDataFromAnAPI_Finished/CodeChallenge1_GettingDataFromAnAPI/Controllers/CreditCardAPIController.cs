using System;
using System.Threading.Tasks;
using CodeChallenge1_GettingDataFromAnAPI.Helpers;
using Newtonsoft.Json;

namespace CodeChallenge1_GettingDataFromAnAPI.Controllers
{
    public class CreditCardAPIController
    {
        private string _user = "";
        private string _token = "";
        private const string APIENDPOINT = @"https://ccm.cps.golf/RegressionSRCCM/Transactions.svc/GetTerminalIdentifiers";

        public string user
        {
            get { return _user; }
            set { _user = value; }
        }

        public string token
        {
            get { return _token; }
            set { _token = value; }
        }

        public async Task<string[]> GetTerminalIdentifiers()
        {
            string[] res;
            EncodingHelper encodingHelper = new EncodingHelper();
            string AUTHENTICATION = encodingHelper.Encode(String.Format("{0}:{1}", _user, _token));

            using(System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", AUTHENTICATION);
                var result = await client.PostAsync(APIENDPOINT, null);
                var theString = await result.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<string[]>(theString);
            }

            return res;

        }
    }

}
