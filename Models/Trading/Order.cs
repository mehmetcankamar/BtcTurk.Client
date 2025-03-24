namespace BtcTurk.Client.Models.Trading
{
    public class Order
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }
        public string PairSymbol { get; set; } = string.Empty;
        public string PairSymbolNormalized { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string OrderSide { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public long DateTime { get; set; }
        public decimal LeftAmount { get; set; }
        public decimal? StopPrice { get; set; }
    }
}
