using System.Linq;

namespace OCRTHINGEE
{
    public class RowAsText
    {
        private string _buyprice;
        private string _galacticaverage;
       
        private string _numsupply;
       

        private string _sellprice;
       
        public string GoodsName { get; set; }

        public string SellPrice
        {
            get { return _sellprice; }
            set { _sellprice = ClearPunctuationAndWhiteSpace(value); }
        }

        public string BuyPrice
        {
            get { return _buyprice; }
            set { _buyprice = ClearPunctuationAndWhiteSpace(value); }
        }

        

        public string NumSupply
        {
            get { return _numsupply; }
            set { _numsupply = ClearPunctuationAndWhiteSpace(value); }
        }

     

        public string GalacticAverage
        {
            get { return _galacticaverage; }
            set { _galacticaverage = ClearPunctuationAndWhiteSpace(value); }
        }

        private static string ClearPunctuationAndWhiteSpace(string original)
        {
            original = original.Trim();

            return original.Where(char.IsDigit).Aggregate(string.Empty, (current, x) => current + x);
        }
    }
}