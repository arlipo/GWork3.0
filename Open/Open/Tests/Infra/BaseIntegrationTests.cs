using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Infra.Rule;
namespace Open.Tests.Infra {
    public abstract class BaseIntegrationTests<TContext, TClass> : ObjectTests<TClass> where TContext: DbContext {
        protected TContext db;
        protected RulesDbContext rulesDb;
        [TestInitialize] public override void TestInitialize() {
            db = initDatabase();
            db.Database.EnsureCreated();
            base.TestInitialize();
        }
        [TestCleanup] public override void TestCleanup() {
            base.TestCleanup();
            db = null;
        }
        private TContext initDatabase() {
            var name = getGuid();
            var provider = getServiceProvider();
            rulesDb = new RulesDbContext(getDbBuilder<RulesDbContext>(name, provider).Options);
            var builder = getDbBuilder<TContext>(name, provider);
            return createContext(builder.Options);
        }
        protected abstract TContext createContext(DbContextOptions<TContext> builderOptions);
        private static DbContextOptionsBuilder<T> getDbBuilder<T>(string name, IServiceProvider p)
        where T: DbContext{
            return new DbContextOptionsBuilder<T>()
                .UseInMemoryDatabase(name)
                .UseInternalServiceProvider(p);
        }
        private static IServiceProvider getServiceProvider() {
            return new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
        }
        private static string getGuid() {
            return Guid.NewGuid().ToString();
        }
        protected virtual void clearDbSet<T>(DbSet<T> set) where T : class
        {
            Safe.Run(() => {
                foreach (var e in set) set.Remove(e);
                db.SaveChanges();
            });
            Assert.AreEqual(0, recordsCount(set), "Cant remove from dbSet");
        }
        protected static int recordsCount<T>(DbSet<T> set) where T : class => Safe.Run(set.Count, -1);

    }
}



