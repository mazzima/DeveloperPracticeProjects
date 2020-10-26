namespace CodeChallenge1_GettingDataFromAnAPI.Helpers
{
    public class EncodingHelper
    {
        public string Encode(string decodedValue)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(decodedValue);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Decode(string encodedValue)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(encodedValue);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
