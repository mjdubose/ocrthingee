using System;

namespace OCRTHINGEE
{
    internal class ReturnedSearchView
    {
        public int Systemid { get; set; }
        public string Systemname { get; set; }
        public int Stationid { get; set; }
        public string Stationname { get; set; }
        public long ProductsId { get; set; }
        public int Itemid { get; set; }
        public int? Buyprice { get; set; }
        public int? Sellprice { get; set; }
        public int? Supply { get; set; }
        public DateTime? Lastupdate { get; set; }
    }
}