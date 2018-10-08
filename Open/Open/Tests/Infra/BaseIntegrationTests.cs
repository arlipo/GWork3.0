using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;
namespace Open.Tests.Infra {
    public abstract class BaseIntegrationTests<TClass> : ObjectTests<TClass> {
        protected SentryDbContext db;

        [TestInitialize] public override void TestInitialize() {
            db = initDatabase();
            db.Database.EnsureCreated();
            base.TestInitialize();
        }
        [TestCleanup] public override void TestCleanup() {
            base.TestCleanup();
            db = null;
        }
        private static SentryDbContext initDatabase() {
            var name = getGuid();
            var provider = getServiceProvider();
            var builder = getDbBuilder<SentryDbContext>(name, provider);
            return new SentryDbContext(builder.Options);
        }
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
    }
}



