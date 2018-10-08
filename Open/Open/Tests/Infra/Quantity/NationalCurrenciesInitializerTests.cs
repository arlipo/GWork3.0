using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity {
    [TestClass]
    public class NationalCurrenciesInitializerTests 
        : BaseTableInitializerTests<NationalCurrency, NationalCurrencyData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(NationalCurrenciesInitializer);
        }
        protected override ICrudRepository<NationalCurrency> getRepository() 
            => new NationalCurrenciesRepository(db);
        protected override DbSet<NationalCurrencyData> getDbSet() => db.CountryCurrencies;
        protected override void initialize() => NationalCurrenciesInitializer.Initialize(db);
    }
}


