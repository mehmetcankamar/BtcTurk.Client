namespace BtcTurk.Client.Models.Trading
{
    public class OrderRequest
    {
        public decimal? Price { get; set; }
        public decimal Amount { get; set; }
        public decimal? StopPrice { get; set; }
        public string PairSymbol { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string OrderSide { get; set; } = string.Empty;
    }
}
