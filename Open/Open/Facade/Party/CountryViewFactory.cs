using System;
using Open.Domain.Party;
using Open.Facade.Quantity;
namespace Open.Facade.Party {
    public static class CountryViewFactory {
        public static CountryView Create(Country o) {
            var v = new CountryView {
                Name = o?.Data.Name,
                Alpha3Code = o?.Data.ID,
                Alpha2Code = o?.Data.Code
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.Data.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.Data.ValidTo);
            foreach (var c in o.CurrenciesInUse) {
                var currency = CurrencyViewFactory.Create(c);
                v.CurrenciesInUse.Add(currency);
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





