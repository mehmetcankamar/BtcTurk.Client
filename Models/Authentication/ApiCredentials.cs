namespace BtcTurk.Client.Models.Authentication
{
    public class ApiCredentials
    {
        public string ApiKey { get; }
        public string ApiSecret { get; }

        public ApiCredentials(string apiKey, string apiSecret)
        {
            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }
    }
}
