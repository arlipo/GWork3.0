using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity {
    [TestClass] public class EuroRateTypesInitializerTests : BaseTableInitializerTests<RateType,
        RateTypeData> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(EuroRateTypesInitializer);
        }
        protected override ICrudRepository<RateType> getRepository() =>
            new RateTypesRepository(db);
        protected override DbSet<RateTypeData> getDbSet() => db.RateTypes;
        protected override void initialize() => EuroRateTypesInitializer.Initialize(db);
        protected override void doBeforeCleanup() => clearDbSet(db.RateTypes);
    }
}
