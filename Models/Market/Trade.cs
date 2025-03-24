using System.Text.Json.Serialization;

namespace BtcTurk.Client.Models.Market
{
    public class Trade
    {
        [JsonPropertyName("pair")]
        public string Pair { get; set; } = string.Empty;

        [JsonPropertyName("pairNormalized")]
        public string PairNormalized { get; set; } = string.Empty;

        [JsonPropertyName("numerator")]
        public string Numerator { get; set; } = string.Empty;

        [JsonPropertyName("denominator")]
        public string Denominator { get; set; } = string.Empty;

        [JsonPropertyName("date")]
        public long Date { get; set; }

        [JsonPropertyName("tid")]
        public long TradeId { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; } = string.Empty;
    }
}
