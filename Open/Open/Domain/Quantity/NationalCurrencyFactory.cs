using System;
using Open.Data.Party;
using Open.Data.Quantity;
using Open.Domain.Party;
namespace Open.Domain.Quantity {
    public static class NationalCurrencyFactory {
        public static NationalCurrency Create(Country country, Currency currency,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var o = new NationalCurrencyData {
                Country = country?.Data?? new CountryData(),
                Currency = currency?.Data?? new CurrencyData(),
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.CountryID = o.Country.ID;
            o.CurrencyID = o.Currency.ID;
            return new NationalCurrency(o);
        }
    }
}


