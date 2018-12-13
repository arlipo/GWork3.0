using Open.Core;
using Open.Data.Common;

namespace Open.Data.Goods
{
    public class GoodsData : NamedData
    {
        private string description;
        private string price;

        public byte[] Image { get; set; }

        public string Description 
        {
            get => getString(ref description);
            set => description = value;
        }

        public string Price
        {
            get => getString(ref price);
            set => price = value;
        }
        public GoodTypes Type { get; set; }

        public int Quantity { get; set; }

        public int Brand
        {
            get; set;
        }
    }
}