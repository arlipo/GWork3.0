using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;
namespace Open.Tests.Infra {

    public class SentryDbContextTests : BaseIntegrationTests<SentryDbContext>
    {

        private class testClass : SentryDbContext
        {
            public testClass(DbContextOptions<SentryDbContext> o) : base(o)
            {
            }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);
                return mb;
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(SentryDbContext);
        }

        protected override SentryDbContext getRandomObject()
        {
            return db;
        }
     private static IMutableEntityType testEntity<T>(ModelBuilder mb, bool hasPrimaryKey = false,
            int foreignKeysCount = 0)
        {
            var name = typeof(T).FullName;
            var entity = mb.Model.FindEntityType(name);
            Assert.IsNotNull(entity, name);
            testPrimaryKey(entity, hasPrimaryKey);
            testForeignKey(entity, foreignKeysCount);
            return entity;
        }

        private static void testForeignKey(IMutableEntityType entity, int foreignKeysCount)
        {
            Assert.AreEqual(foreignKeysCount, entity.GetForeignKeys().Count());
        }

        private static void testPrimaryKey(IMutableEntityType entity, bool hasPrimaryKey)
        {
            if (hasPrimaryKey) Assert.IsNotNull(entity.FindPrimaryKey());
            else Assert.IsNull(entity.FindPrimaryKey());
        }

        private static void testForeignKey(IMutableEntityType entity, string name = null, Type t = null)
        {
            var keys = entity.GetForeignKeys();
            foreach (var k in keys)
            {
                var key = k.Properties.FirstOrDefault(x => x.Name == name);
                if (key is null) continue;
                Assert.AreEqual(k.PrincipalEntityType.Name, t?.FullName);
                return;
            }

            Assert.Fail("No foreign key found");
        }

        private static void testPrimaryKey(IMutableEntityType entity, params string[] values)
        {
            var key = entity.FindPrimaryKey();
            if (values is null) Assert.IsNull(key);
            else
                foreach (var v in values)
                {
                    Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == v));
                }
        }
    }
}







