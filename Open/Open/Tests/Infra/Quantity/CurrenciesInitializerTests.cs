using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity {

    [TestClass]
    public class
        CurrenciesInitializerTests : BaseTableInitializerTests<Currency,
            CurrencyData> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CurrenciesInitializer);
        }
        protected override ICrudRepository<Currency> getRepository() =>
            new CurrenciesRepository(db);
        protected override DbSet<CurrencyData> getDbSet() => db.Currencies;
        protected override void initialize() => CurrenciesInitializer.Initialize(db);
        protected override void doBeforeCleanup() => clearDbSet(db.CountryCurrencies);
    }
}

