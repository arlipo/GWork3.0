using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Core;
using Open.Facade.Common;

namespace Open.Facade.Goods
{
    public class GoodView : EntityView
    {
        private string name, code, imageType,
        description, fileLocation, price;

        [Required]
        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }

        public string Code
        {
            get => getString(ref code);
            set => code = value;
        }

        public GoodTypes Type { get; set; }

        public string ImageType
        {
            get => getString(ref imageType);
            set => imageType = value;
        }
        
        public string Picture
        {
            get => getString(ref fileLocation);
            set => fileLocation = value;
        }

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