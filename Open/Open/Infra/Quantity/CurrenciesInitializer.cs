using System.Collections.Generic;
using System.Linq;
using Open.Aids;
using Open.Domain.Quantity;
namespace Open.Infra.Quantity {
    public static class CurrenciesInitializer {

        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Currencies.Any()) return;
            var list = new List<string>();
            var regions = SystemRegionInfo.GetRegionsList();
            foreach (var r in regions) {
                if (!SystemRegionInfo.IsCountry(r)) continue;
                if (list.Contains(r.ISOCurrencySymbol)) continue;
                var e = CurrencyFactory.Create(r);
                c.Currencies.Add(e.Data);
                list.Add(r.ISOCurrencySymbol);
            }
            c.SaveChanges();
        }
    }
}

