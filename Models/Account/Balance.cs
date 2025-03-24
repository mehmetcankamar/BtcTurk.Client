using System.Text.Json.Serialization;

namespace BtcTurk.Client.Models.Account
{
    public class Balance
    {
        [JsonPropertyName("asset")]
        public string Asset { get; set; } = string.Empty;

        [JsonPropertyName("assetname")]
        public string AssetName { get; set; } = string.Empty;

        [JsonPropertyName("balance")]
        public decimal Amount { get; set; }

        [JsonPropertyName("free")]
        public decimal Free { get; set; }

        [JsonPropertyName("locked")]
        public decimal Locked { get; set; }

        [JsonPropertyName("orderFree")]
        public decimal OrderFree { get; set; }

        [JsonPropertyName("withdrawFree")]
        public decimal WithdrawFree { get; set; }
    }
}
