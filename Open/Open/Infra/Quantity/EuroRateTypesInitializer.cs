using System.Linq;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Infra.Quantity {
    public class EuroRateTypesInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.RateTypes.Any()) return;
            foreach (var rate in RateFactory.RateTypes) {
                c.RateTypes.Add(rateType(rate));
            }
            c.SaveChanges();
        }

        private static RateTypeData rateType(string name) {
            var x = new RateTypeData {Code = name};
            return x;
        }
    }
}