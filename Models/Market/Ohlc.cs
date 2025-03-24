namespace BtcTurk.Client.Models.Market
{
    public class OhlcBar
    {
        public long Time { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
    }

    public class OhlcData
    {
        public string PairSymbol { get; set; } = string.Empty;
        public OhlcBar[] Bars { get; set; } = System.Array.Empty<OhlcBar>();
    }
}
