namespace OCRTHINGEE
{
    internal class TradeProfitView
    {
        public long TradeitemId { get; set; }
        public string SystemName { get; set; }
        public string StationName { get; set; }
        public string TradeItemName { get; set; }
        public int? Supply { get; set; }
        public int? BuyPrice { get; set; }
        public int? SellPrice { get; set; }
    }
}