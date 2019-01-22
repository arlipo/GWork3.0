using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Infra {
    public abstract class
        BaseTableInitializerTests<TContext, TObject, TDbRecord> : BaseDbSetTests<TContext, TObject, TDbRecord>
        where TContext: DbContext
        where TDbRecord : class, new() {
        protected abstract void initialize();
        protected virtual void doBeforeCleanup() {}
        [TestCleanup] public override void TestCleanup() {
            doBeforeCleanup();
            base.TestCleanup();
        }
        [TestMethod] public void CantInitializeTest() {
            Assert.AreEqual(count, dbSet.Count());
            initialize();
            Assert.AreEqual(count, dbSet.Count());
        }
        [TestMethod] public void InitializeTest() {
            doBeforeCleanup();
            clearDbSet();
            Assert.AreEqual(0, dbSet.Count());
            initialize();
            Assert.AreNotEqual(0, dbSet.Count());
        }
    }
}
