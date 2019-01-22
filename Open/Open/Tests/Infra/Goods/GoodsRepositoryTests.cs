using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Goods;
using Open.Domain.Goods;
using Open.Infra;
using Open.Infra.Goods;

namespace Open.Tests.Infra.Goods
{
    [TestClass]
    public class GoodsRepositoryTests : PaginatedRepositoryTests<SentryDbContext, Good, GoodsData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(GoodsRepository);
        }

        protected GoodsRepository repository;

        protected override SentryDbContext createContext(DbContextOptions<SentryDbContext> builderOptions)
        {
            return new SentryDbContext(builderOptions);
        }

        protected override Good createObject(GoodsData r) => GoodFactory.Create(r);
        protected override string getID(GoodsData r) => r.ID;
        protected override GoodsData getData(Good o) => o.Data;
        protected override ICrudRepository<Good> getRepository() => new GoodsRepository(db);
        protected override DbSet<GoodsData> getDbSet() => db.Goods;

        protected override Func<GoodsData, object> getRandomSortFunction()
        {
            var i = GetRandom.UInt32() % 6;
            if (i == 0) return x => x.Code;
            if (i == 1) return x => x.ID;
            if (i == 2) return x => x.Name;
            if (i == 3) return x => x.ValidFrom;
            if (i == 4) return x => x.Description;
            if (i == 5) return x => x.Type;
            return x => x.ValidTo;
        }

        [TestMethod] public void GetWithSpecificTypeTest() {
            Assert.Inconclusive();
        }
    }
}

