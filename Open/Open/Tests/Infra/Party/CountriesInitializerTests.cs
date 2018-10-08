using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Infra.Party;
namespace Open.Tests.Infra.Party {
    [TestClass]
    public class
        CountriesInitializerTests : BaseTableInitializerTests<Country, CountryData> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CountriesInitializer);
        }
        protected override ICrudRepository<Country> getRepository() => new CountriesRepository(db);
        protected override DbSet<CountryData> getDbSet() => db.Countries;
        protected override void initialize() => CountriesInitializer.Initialize(db);
        protected override void doBeforeCleanup() => clearDbSet(db.CountryCurrencies);
    }
}

