namespace BtcTurk.Client.Services.Public.Requests
{
    public class OhlcRequest
    {
        public string PairSymbol { get; set; } = string.Empty;
        public int From { get; set; }
        public int To { get; set; }
        public string Resolution { get; set; } = string.Empty;
    }
}
