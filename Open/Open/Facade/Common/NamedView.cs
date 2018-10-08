using System.ComponentModel.DataAnnotations;
using Open.Aids;
namespace Open.Facade.Common {
    public abstract class NamedView : PeriodView {
        private string name;
        [Required]
        [RegularExpression(RegularExpressionFor.EnglishTextOnly)]
        public string Name {
            get => getString(ref name);
            set => name = value;
        }
    }
}


