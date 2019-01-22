using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
using Open.Data.Customers;
using Open.Domain.Customers;
using Open.Infra;
using Open.Infra.Customers;

namespace Open.Tests.Infra.Customers
{
    [TestClass]
    public class CustomersInitializerTests : BaseTableInitializerTests<SentryDbContext, Customer, CustomersData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CustomersInitializer);
        }

        protected override SentryDbContext createContext(DbContextOptions<SentryDbContext> builderOptions)
        {
            return new SentryDbContext(builderOptions);
        }

        protected override ICrudRepository<Customer> getRepository()
            => new CustomersRepository(db);

        protected override DbSet<CustomersData> getDbSet() => db.Customers;

        protected override void initialize() => CustomersInitializer.Initialize(db);
    }
}
