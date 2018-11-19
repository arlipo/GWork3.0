using Open.Core;
using Open.Data.Common;

namespace Open.Data.Goods
{
    public class GoodsData : NamedData
    {
        private string imageType;
        private byte[] image;
        private string description;
        private string fileLocation;
        private string price;

        public string ImageType
        {
            get => getString(ref imageType);
            set => imageType = value;
        }

        public byte[] Image { get; set; }
        public string Description 
        {
            get => getString(ref description);
            set => description = value;
        }

        public string PicFileLocation
        {
            get => getString(ref fileLocation);
            set => fileLocation = value;
        }

        public string Price
        {
            get => getString(ref price);
            set => price = value;
        }
        public GoodTypes Type { get; set; }
    }
}