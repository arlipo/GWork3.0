using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity
{
    [TestClass]
    public class RateTypesRepositoryTests : BaseRepositoryTests<RateType, RateTypeData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(RateTypesRepository);
        }

        protected override RateType createObject(RateTypeData r) => new RateType(r);

        protected override RateTypeData getData(RateType o) => o.Data;

        protected override string getID(RateTypeData r) => r.ID;

        protected override ICrudRepository<RateType> getRepository() => new RateTypesRepository(db);

        protected override DbSet<RateTypeData> getDbSet() => db.RateTypes;
    }
}

