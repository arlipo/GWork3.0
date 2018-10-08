using System.Collections.Generic;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Common;
using Open.Domain.Quantity;
namespace Open.Domain.Party {
    public sealed class Country : NamedEntity<CountryData> {

        private readonly List<Currency> currenciesInUse;

        public Country(CountryData r) : base(r?? new CountryData()) {
            currenciesInUse = new List<Currency>();
        }

        public IReadOnlyList<Currency> CurrenciesInUse =>  currenciesInUse.AsReadOnly();

        public void CurrencyInUse(Currency currencyObject) {
            if (currencyObject is null) return;
            if (currencyObject.Data.ID == Constants.Unspecified) return;
            if (currenciesInUse.Find(x => x.Data.ID == currencyObject.Data.ID) != null)
                return;
            currenciesInUse.Add(currencyObject);
        }
    }
}


