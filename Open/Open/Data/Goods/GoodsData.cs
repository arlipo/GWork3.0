using Open.Core;
using Open.Data.Common;

namespace Open.Data.Goods
{
    public class GoodsData : NamedData
    {
        private string description, price, imgName;

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
    }
}