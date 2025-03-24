using System.Text.Json.Serialization;

namespace BtcTurk.Client.Services.Public.Requests
{
    public class TickerRequest
    {
        [JsonPropertyName("pairSymbol")]
        public string? PairSymbol { get; set; }
    }
}
