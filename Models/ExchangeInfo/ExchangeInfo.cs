using System;
using System.Text.Json.Serialization;

namespace BtcTurk.Client.Models.ExchangeInfo
{
    public class ExchangeInfo
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("numeratorScale")]
        public int NumeratorScale { get; set; }

        [JsonPropertyName("denominatorScale")]
        public int DenominatorScale { get; set; }

        [JsonPropertyName("numeratorSymbol")]
        public string NumeratorSymbol { get; set; } = string.Empty;

        [JsonPropertyName("denominatorSymbol")]
        public string DenominatorSymbol { get; set; } = string.Empty;

        [JsonPropertyName("minExchangeValue")]
        public decimal MinExchangeValue { get; set; }

        [JsonPropertyName("minPrice")]
        public decimal MinPrice { get; set; }

        [JsonPropertyName("minAmount")]
        public decimal MinAmount { get; set; }

        [JsonPropertyName("didNumeratorChange")]
        public bool DidNumeratorChange { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
    }

    public class ExchangeInfoResponse
    {
        [JsonPropertyName("data")]
        public ExchangeInfo[] Data { get; set; } = Array.Empty<ExchangeInfo>();

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
