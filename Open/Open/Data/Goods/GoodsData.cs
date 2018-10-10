using Open.Data.Common;

namespace Open.Data.Goods
{
    public class GoodsData : NamedData
    {
        private string imageType;
        private string description;
        private string fileLocation;
        private string price;

        public string ImageType
        {
            get => getString(ref imageType);
            set => imageType = value;
        }

        public string Description
        {
            get => getString(ref description);
            set => description = value;
        }

        public string FileLocation
        {
            get => getString(ref fileLocation);
            set => fileLocation = value;
        }

        public string Price
        {
            get => getString(ref price);
            set => price = value;
        }
    }
}