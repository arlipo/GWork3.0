using System.ComponentModel;
using Open.Facade.Common;
namespace Open.Facade.Quantity {
    public class MoneyView : EntityView {
        public decimal Amount { get; set; }

        [DisplayName("Currency")]
        public string CurrencyID { get; set; }
    }
}