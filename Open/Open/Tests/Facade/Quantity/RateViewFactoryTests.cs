using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class RateViewFactoryTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(RateViewFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<RateData>();
            var o = new Rate(r);
            var v = RateViewFactory.Create(o);
            Assert.AreEqual(v.Rate, o.Data.Rate);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.Data.ValidTo);
            Assert.AreEqual(v.ID, o.Data.ID);
            Assert.AreEqual(v.RateTypeID, o.Data.RateTypeID);
            Assert.AreEqual(v.CurrencyID, o.Data.CurrencyID);
        }
    }
}