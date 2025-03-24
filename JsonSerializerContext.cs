using System;
using System.Text.Json.Serialization;
using BtcTurk.Client.Models.Account;
using BtcTurk.Client.Models.Common;
using BtcTurk.Client.Models.ExchangeInfo;
using BtcTurk.Client.Models.Market;
using BtcTurk.Client.Models.Trading;

namespace BtcTurk.Client
{
    [JsonSourceGenerationOptions(
        WriteIndented = false,
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    )]
    [JsonSerializable(typeof(BaseResponse<ExchangeInfo[]>))]
    [JsonSerializable(typeof(BaseResponse<Ticker[]>))]
    [JsonSerializable(typeof(BaseResponse<OrderBook>))]
    [JsonSerializable(typeof(BaseResponse<Trade[]>))]
    [JsonSerializable(typeof(BaseResponse<OhlcData>))]
    [JsonSerializable(typeof(BaseResponse<Balance[]>))]
    [JsonSerializable(typeof(BaseResponse<Transaction[]>))]
    [JsonSerializable(typeof(BaseResponse<Order>))]
    [JsonSerializable(typeof(BaseResponse<Order[]>))]
    [JsonSerializable(typeof(OrderRequest))]
    internal partial class BtcTurkJsonContext : JsonSerializerContext
    {
    }
}
