using System;
using Open.Domain.Quantity;
using Open.Facade.Party;
namespace Open.Facade.Quantity {
    public static class CurrencyViewFactory {
        public static CurrencyView Create(Currency o) {
            var v = new CurrencyView {
                Name = o?.Data.Name,
                IsoCode = o?.Data.ID,
                Symbol = o?.Data.Code
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.Data.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.Data.ValidTo);
            foreach (var c in o.UsedInCountries) {
                var country = CountryViewFactory.Create(c);
                v.UsedInCountries.Add(country);
            } 
            return v;
        }
        private static DateTime? setNullIfExtremum(DateTime d) {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}

