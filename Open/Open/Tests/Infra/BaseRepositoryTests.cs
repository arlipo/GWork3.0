using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;

namespace Open.Tests.Infra
{
    public abstract class BaseRepositoryTests<TContext, TObject, TDbRecord>
        : BaseDbSetTests<TContext, TObject, TDbRecord>
        where TContext : DbContext
        where TDbRecord : PeriodData
    {
        private TDbRecord expected;
        private TObject random;
        private TDbRecord actual;

        protected abstract TObject createObject(TDbRecord r);

        protected virtual void doBeforeDelete()
        {
        }

        protected abstract TDbRecord getData(TObject o);
        protected abstract string getID(TDbRecord r);
        protected virtual object[] getKey(TDbRecord r) => new object[] {getID(r)};

        protected virtual void setRandomValues(TObject o)
        {
            var r = getData(o);
            r.ValidFrom = GetRandom.DateTime(maxValue: r.ValidTo);
            r.ValidTo = GetRandom.DateTime(r.ValidFrom);
        }

        protected virtual void validateDbRecords(TDbRecord e, TDbRecord a)
        {
            Assert.AreEqual(getID(e), getID(a));
            Assert.AreEqual(e.ValidFrom, a.ValidFrom);
            Assert.AreEqual(e.ValidTo, a.ValidTo);
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            expected = getRandomDbRecord();
            random = createObject(expected);
            actual = dbSet.Find(getKey(getData(random)));
            Assert.IsNull(actual);
        }

        [TestMethod]
        public async Task GetObjectTest()
        {
            random = await repository.GetObject(getID(expected));
            Assert.AreEqual(Constants.Unspecified, getID(getData(random)));
            dbSet.Add(expected);
            db.SaveChanges();
            random = await repository.GetObject(getID(expected));
            validateDbRecords(expected, getData(random));
        }

        [TestMethod]
        public async Task AddObjectTest()
        {
            await repository.AddObject(random);
            actual = dbSet.Find(getKey(expected));
            validateDbRecords(expected, actual);
        }

        [TestMethod]
        public async Task UpdateObjectTest()
        {
            await AddObjectTest();
            setRandomValues(random);
            await repository.UpdateObject(random);
            Assert.AreEqual(count + 1, dbSet.Count());
            actual = dbSet.Find(getKey(expected));
            validateDbRecords(expected, actual);
        }

        [TestMethod]
        public async Task DeleteObjectTest()
        {
            var c = count;
            Assert.AreEqual(c, dbSet.Count());
            doBeforeDelete();
            foreach (var e in dbSet)
            {
                await repository.DeleteObject(createObject(e));
                Assert.AreEqual(--c, dbSet.Count());
            }
        }

        [TestMethod]
        public void IsInitializedTest()
        {
            Assert.IsTrue(repository.IsInitialized());
            clearDbSet();
            Assert.IsFalse(repository.IsInitialized());
        }
    }
}