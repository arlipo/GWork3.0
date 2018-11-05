using Open.Infra.Customers;
using Open.Infra.Goods;
using Open.Infra.Party;
using Open.Infra.Quantity;
namespace Open.Infra {
    public static class DbInitializer {
        public static void Initialize(SentryDbContext dbContext) {
            GoodsInitializer.Initialize(dbContext);
            CountriesInitializer.Initialize(dbContext);
            CurrenciesInitializer.Initialize(dbContext);
            NationalCurrenciesInitializer.Initialize(dbContext);
            ContactsInitializer.Initialize(dbContext);
            EuroRateTypesInitializer.Initialize(dbContext);
            EuroRatesInitializer.Initialize(dbContext);
            CustomersInitializer.Initialize(dbContext);
        }
    }
}


