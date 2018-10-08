using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class CurrencyViewFactoryTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CurrencyViewFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<CurrencyData>();
            var o = new Currency(r);
            var v = CurrencyViewFactory.Create(o);
            Assert.AreEqual(v.Name, o.Data.Name);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.Data.ValidTo);
            Assert.AreEqual(v.IsoCode, o.Data.ID);
            Assert.AreEqual(v.Symbol, o.Data.Code);
        }
    }
}