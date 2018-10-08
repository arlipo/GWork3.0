using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Infra {
    public abstract class BaseDbSetTests<TObject, TDbRecord> : BaseIntegrationTests<ICrudRepository<TObject>>
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
        protected virtual void clearDbSet<T>(DbSet<T> set) where T : class {
            Safe.Run(() => {
                foreach (var e in set) set.Remove(e);
                db.SaveChanges();
            });
            Assert.AreEqual(0, recordsCount(set), "Cant remove from dbSet");
        }
        private static int recordsCount<T>(DbSet<T> set) where T: class => Safe.Run(set.Count, -1);
    }
}





















