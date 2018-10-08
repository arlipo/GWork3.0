using System.Linq;
using Open.Aids;
using Open.Domain.Party;
namespace Open.Infra.Party {

    public static class CountriesInitializer {

        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Countries.Any()) return;
            var regions = SystemRegionInfo.GetRegionsList();
            foreach (var r in regions) {
                if (!SystemRegionInfo.IsCountry(r)) continue;
                var e = CountryFactory.Create(r);
                c.Countries.Add(e.Data);
            }
            c.SaveChanges();
        }
    }
}







