using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Facade.Common;

namespace Open.Facade.Goods
{
    public class GoodView : NamedView
    {
        private string id, code, imageType,
        description, fileLocation, price, type;


        public string ID
        {
            get => getString(ref id);
            set => id = value;
        }

        public string Code
        {
            get => getString(ref code);
            set => code = value;
        }

        public string Type
        {
            get => getString(ref type);
            set => type = value;
        }

        public string ImageType
        {
            get => getString(ref imageType);
            set => imageType = value;
        }

        [DisplayName("Picture")]
        public string Picture
        {
            get => getString(ref fileLocation);
            set => fileLocation = value;
        }

        [Required, RegularExpression(RegularExpressionFor.EnglishTextOnly)]
        public string Description
        {
            get => getString(ref description);
            set => description = value;
        }

        [Required, RegularExpression(RegularExpressionFor.NumericOnly)]
        public string Price
        {
            get => getString(ref price);
            set => price = value;
        }
    }
}