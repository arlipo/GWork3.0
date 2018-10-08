using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class RateFactoryTests : BaseTests {
        private decimal rate;
        private Rate o;
        private DateTime date;
        private Currency currency;
        private RateType rateType;

        private void initializeTestData() {
            rate = GetRandom.Decimal(1, 10);
            currency = new Currency(GetRandom.Object<CurrencyData>());
            rateType = new RateType(GetRandom.Object<RateTypeData>());
            date = GetRandom.DateTime();
        }
        private void validateResults(Currency i = null, decimal a = 1M, DateTime? d = null,
            RateType b = null) {
            var dt = d ?? DateTime.Now;
            var id = RateFactory.CalculateID(i?.ID, d, b?.ID);
            Assert.AreEqual(id, o.Data.ID);
            Assert.AreEqual(a, o.Data.Rate);
            Assert.AreEqual(dt.Date, o.Data.ValidFrom);
            Assert.AreEqual(dt.Date.AddSeconds(24 * 60 * 60 - 1), o.Data.ValidTo);
            Assert.AreEqual(b?.ID ?? Constants.Unspecified, o.Data.RateTypeID);
        }
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(RateFactory);
            initializeTestData();
        }
        [TestMethod] public void CreateTest() {
            o = RateFactory.Create(currency, rate, date, rateType);
            validateResults(currency, rate, date, rateType);
        }
        [TestMethod] public void CreateWithNullArgumentsTest() {
            o = RateFactory.Create(new Currency());
            validateResults();
        }
        [TestMethod] public void CalculateIDTest() {
            var currencyID = GetRandom.String();
            var dt = GetRandom.DateTime();
            var rateTypeID = GetRandom.String();
            var actual = RateFactory.CalculateID(currencyID, dt, rateTypeID);
            var expected = currencyID + dt.ToString("-yyyy-MM-dd-") + rateTypeID;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod] public void RateTypesTest() {
            Assert.AreEqual(4, RateFactory.RateTypes.Length);
        }
        [TestMethod] public void EuroRateTest() {
            Assert.IsTrue(RateFactory.RateTypes.Contains(RateFactory.EuroRate));
        }
        [TestMethod]
        public void UsdRateTest()
        {
            Assert.IsTrue(RateFactory.RateTypes.Contains(RateFactory.UsdRate));
        }
        [TestMethod]
        public void WeBuyTest()
        {
            Assert.IsTrue(RateFactory.RateTypes.Contains(RateFactory.WeBuy));
        }
        [TestMethod]
        public void WeSellTest()
        {
            Assert.IsTrue(RateFactory.RateTypes.Contains(RateFactory.WeSell));
        }
    }
}