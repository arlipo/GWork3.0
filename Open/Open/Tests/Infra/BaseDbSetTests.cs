using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Infra {
    public abstract class BaseDbSetTests<TContext, TObject, TDbRecord> : BaseIntegrationTests<TContext, ICrudRepository<TObject>>
        where TContext: DbContext
        where TDbRecord : class{
        protected DbSet<TDbRecord> dbSet;
        protected ICrudRepository<TObject> repository;
        protected int count;
        protected override ICrudRepository<TObject> getRandomObject() {
            dbSet = getDbSet();
            repository = getRepository();
            initDbSet();
            return repository;
        }
        [TestCleanup] public override void TestCleanup() {
            clearDbSet();
            base.TestCleanup();
        }
        protected abstract ICrudRepository<TObject> getRepository();
        protected abstract DbSet<TDbRecord> getDbSet();
        protected virtual TDbRecord getRandomDbRecord() {
            return GetRandom.Object<TDbRecord>();
        }
        protected virtual void clearDbSet() {
            clearDbSet(dbSet);
        }
        protected virtual void initDbSet() {
            Safe.Run(() => {
                var c = GetRandom.UInt8(10, 20);
                count = recordsCount(dbSet) + c;
                for (var i = 0; i < c; i++) dbSet.Add(getRandomDbRecord());
                db.SaveChanges();
            });
            Assert.AreEqual(count, recordsCount(dbSet), "Cant initialize dbSet");
        }
    }
}





















