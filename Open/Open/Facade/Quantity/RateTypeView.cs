using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Facade.Common;
namespace Open.Facade.Quantity {
    public class RateTypeView: NamedView {
        private string code;
        private string id;
        private string description;
        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        public string ID {
            get => getString(ref id);
            set => id = value;
        }

        public string Code {
            get => getString(ref code);
            set => code = value;
        }

        public string Description {
            get => getString(ref description);
            set => description = value;
        }
    }
}
