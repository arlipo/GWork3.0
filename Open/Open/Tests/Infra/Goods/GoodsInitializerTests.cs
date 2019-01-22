using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
using Open.Data.Goods;
using Open.Domain.Goods;
using Open.Infra;
using Open.Infra.Goods;

namespace Open.Tests.Infra.Goods
{
    [TestClass]
    public class GoodsInitializerTests : BaseTableInitializerTests<SentryDbContext, Good, GoodsData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(GoodsInitializer);
        }

        protected override SentryDbContext createContext(DbContextOptions<SentryDbContext> builderOptions)
        {
            return new SentryDbContext(builderOptions);
        }

        protected override ICrudRepository<Good> getRepository()
            => new GoodsRepository(db);

        protected override DbSet<GoodsData> getDbSet() => db.Goods;

        protected override void initialize() => GoodsInitializer.Initialize(db);
    }
}
