using Open.Core;
using Open.Data.Common;

namespace Open.Data.Goods
{
    public class GoodsData : NamedData
    {
        private string description, price, imgName, quantity, brand;

        public byte[] ImgData { get; set; }

        public string ImgName
        {
            get => getString(ref imgName);
            set => imgName = value;
        }

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

        public string Quantity
        {
            get => getString(ref quantity);
            set => price = value;
        }

        public string Brand
        {
            get => getString(ref brand);
            set => price = value;
        }
    }
}