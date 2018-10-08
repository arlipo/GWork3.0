using System.Collections.Generic;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Common;
using Open.Domain.Party;
namespace Open.Domain.Quantity {
    public sealed class Currency : Metrics<CurrencyData> {
        private readonly List<Country> usedInCountries;
        public Currency() : this(null) { }
        public Currency(CurrencyData data) : base(data ?? new CurrencyData()) {
            usedInCountries = new List<Country>();
        }
        public IReadOnlyList<Country> UsedInCountries => usedInCountries.AsReadOnly();
        public void UsedInCountry(Country countryObject) {
            if (countryObject is null) return;
            if (countryObject.Data.ID == Constants.Unspecified) return;
            if (usedInCountries.Find(x => x.Data.ID == countryObject.Data.ID) != null)
                return;
            usedInCountries.Add(countryObject);
        }

    }

}




