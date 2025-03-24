using System.Text.Json.Serialization;

namespace BtcTurk.Client.Models.Trading
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderType
    {
        Limit,
        Market,
        StopLimit,
        StopMarket
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderSide
    {
        Buy,
        Sell
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderMethod
    {
        [JsonPropertyName("limit")]
        Limit,
        [JsonPropertyName("market")]
        Market,
        [JsonPropertyName("stoplimit")]
        StopLimit,
        [JsonPropertyName("stopmarket")]
        StopMarket
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        [JsonPropertyName("Untouched")]
        Untouched,
        [JsonPropertyName("Partial")]
        Partial,
        [JsonPropertyName("Closed")]
        Closed,
        [JsonPropertyName("Canceled")]
        Canceled
    }
}
