using System.Text.Json.Serialization;

namespace BtcTurk.Client.Models.Market
{
    public class OrderBookEntry
    {
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }

    public class OrderBook
    {
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("pair")]
        public string Pair { get; set; } = string.Empty;

        [JsonPropertyName("pairNormalized")]
        public string PairNormalized { get; set; } = string.Empty;

        [JsonPropertyName("numerator")]
        public string Numerator { get; set; } = string.Empty;

        [JsonPropertyName("denominator")]
        public string Denominator { get; set; } = string.Empty;

        [JsonPropertyName("bids")]
        public OrderBookEntry[] Bids { get; set; } = System.Array.Empty<OrderBookEntry>();

        [JsonPropertyName("asks")]
        public OrderBookEntry[] Asks { get; set; } = System.Array.Empty<OrderBookEntry>();
    }
}
