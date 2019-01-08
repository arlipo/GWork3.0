using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Core;
using Open.Facade.Common;

namespace Open.Facade.Goods {
    public class GoodView : EntityView {
        private string name,
            code,
            description,
            price,
            imgName;

        [Required]
        public string Name {
            get => getString(ref name);
            set => name = value;
        }

        public string Code {
            get => getString(ref code);
            set => code = value;
        }

        public GoodTypes Type { get; set; }
        public string Quantity { get; set; }
        public string Brand { get; set; }

        [DisplayName("Picture")]
        public byte[] ImgData { get; set; }
        public string ImgName {
            get => getString(ref imgName);
            set => imgName = value;
        }

        public string Description {
            get => getString(ref description);
            set => description = value;
        }

        [Required, RegularExpression(RegularExpressionFor.Price)]
        public string Price {
            get => getString(ref price);
            set => price = value;
        }
    }
}