using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class CurrencyFactoryTests : BaseTests {
        private Currency o;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CurrencyFactory);
        }
        [TestMethod] public void CreateTest() {
            var b = GetRandom.Object<CurrencyData>();
            o = CurrencyFactory.Create(b.ID, b.Name, b.Code, b.ValidFrom, b.ValidTo);
            validateResults(b.ID, b.Name, b.Code, b.ValidFrom, b.ValidTo);
        }
        [TestMethod] public void CreateWithNullRegionInfoTest() {
            o = CurrencyFactory.Create(null);
            validateResults();
        }
        [TestMethod] public void CreateWithRegionInfoTest() {
            var i = new RegionInfo("ee-EE");
            o = CurrencyFactory.Create(i);
            validateResults(i.ISOCurrencySymbol, i.CurrencyEnglishName, i.CurrencySymbol);
        }
        private void validateResults(string i = Constants.Unspecified,
            string n = Constants.Unspecified, string c = Constants.Unspecified, DateTime? f = null,
            DateTime? t = null) {
            Assert.AreEqual(i, o.Data.ID);
            Assert.AreEqual(n, o.Data.Name);
            Assert.AreEqual(c, o.Data.Code);
            Assert.AreEqual(f ?? DateTime.MinValue, o.Data.ValidFrom);
            Assert.AreEqual(t ?? DateTime.MaxValue, o.Data.ValidTo);
        }
    }
}