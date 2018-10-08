using Open.Data.Common;
using Open.Data.Party;
namespace Open.Data.Quantity {
    public class NationalCurrencyData : PeriodData {
        private string countryID;
        private string currencyID;
        public string CountryID {
            get => getString(ref countryID);
            set => countryID = value;
        }
        public string CurrencyID {
            get => getString(ref currencyID);
            set => currencyID = value;
        }
        public virtual CountryData Country { get; set; }
        public virtual CurrencyData Currency { get; set; }

    }
}





