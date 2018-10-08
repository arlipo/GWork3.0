using System.ComponentModel;
using Open.Facade.Common;
namespace Open.Facade.Quantity {
    public class RateView : PeriodView {
        private string id;
        private string currencyID;
        private string rateTypeID;

        public decimal Rate { get; set; }

        public string ID {
            get => getString(ref id);
            set => id = value;
        }

        [DisplayName("Currency")] public string CurrencyID {
            get => getString(ref currencyID);
            set => currencyID = value;
        }

        [DisplayName("Rate Type")] public string RateTypeID {
            get => getString(ref rateTypeID);
            set => rateTypeID = value;
        }

    }
}