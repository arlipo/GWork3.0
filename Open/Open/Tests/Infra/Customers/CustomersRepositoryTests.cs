using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Customers;
using Open.Domain.Customers;
using Open.Infra;
using Open.Infra.Customers;

namespace Open.Tests.Infra.Customers
{
    [TestClass]
    public class CustomersRepositoryTests : PaginatedRepositoryTests<SentryDbContext, Customer, CustomersData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CustomersRepository);
        }

        protected override SentryDbContext createContext(DbContextOptions<SentryDbContext> builderOptions)
        {
            return new SentryDbContext(builderOptions);
        }

        protected override Customer createObject(CustomersData r) => CustomerFactory.Create(r);
        protected override string getID(CustomersData r) => r.ID;
        protected override CustomersData getData(Customer o) => o.Data;
        protected override ICrudRepository<Customer> getRepository() => new CustomersRepository(db);
        protected override DbSet<CustomersData> getDbSet() => db.Customers;

        protected override Func<CustomersData, object> getRandomSortFunction()
        {
            var i = GetRandom.UInt32() % 4;
            if (i == 0) return x => x.Code;
            if (i == 1) return x => x.ID;
            if (i == 2) return x => x.Name;
            if (i == 3) return x => x.ValidFrom;
            return x => x.ValidTo;
        }
    }
}
