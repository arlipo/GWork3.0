using System.Linq;
using Open.Aids;
using Open.Data.Quantity;
namespace Open.Infra.Quantity {
    public static class NationalCurrenciesInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.CountryCurrencies.Any()) return;
            var regions = SystemRegionInfo.GetRegionsList();

            foreach (var r in regions) {
                if (!SystemRegionInfo.IsCountry(r)) continue;

                var x = new NationalCurrencyData {
                    CountryID = r.ThreeLetterISORegionName,
                    CurrencyID = r.ISOCurrencySymbol
                };

                c.CountryCurrencies.Add(x);
            }

            c.SaveChanges();
        }
    }
}




