using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Party;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class NationalCurrencyFactoryTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(NationalCurrencyFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<NationalCurrencyData>();
            var country = GetRandom.Object<Country>();
            var currency = new Currency(GetRandom.Object<CurrencyData>());
            var v = NationalCurrencyFactory.Create(country, currency, r.ValidFrom, r.ValidTo);
            Assert.AreEqual(v.Data.Currency, currency.Data);
            Assert.AreEqual(v.Data.Country, country.Data);
            Assert.AreEqual(v.Data.ValidFrom, r.ValidFrom);
            Assert.AreEqual(v.Data.ValidTo, r.ValidTo);
            Assert.AreEqual(v.Data.CountryID, country.Data.ID);
            Assert.AreEqual(v.Data.CurrencyID, currency.Data.ID);
        }

        [TestMethod] public void CreateNullTest() {
            var v = NationalCurrencyFactory.Create(null, null);
            Assert.IsNotNull(v.Data.Currency);
            Assert.IsNotNull(v.Data.Country);
            Assert.AreEqual(v.Data.ValidFrom, DateTime.MinValue);
            Assert.AreEqual(v.Data.ValidTo, DateTime.MaxValue);
            Assert.AreEqual(v.Data.CountryID, Constants.Unspecified);
            Assert.AreEqual(v.Data.CurrencyID, Constants.Unspecified);
            Assert.AreEqual(v.Data.Country.ID, Constants.Unspecified);
            Assert.AreEqual(v.Data.Currency.ID, Constants.Unspecified);
        }

        [TestMethod] public void CreateWithExtremumDatesTest() {
            var r = GetRandom.Object<NationalCurrencyData>();
            var country = GetRandom.Object<Country>();
            var currency = new Currency(GetRandom.Object<CurrencyData>());
            r.ValidFrom = DateTime.MinValue;
            r.ValidTo = DateTime.MaxValue;
            var v = NationalCurrencyFactory.Create(country, currency, r.ValidFrom, r.ValidTo);
            Assert.AreEqual(v.Data.Currency, currency.Data);
            Assert.AreEqual(v.Data.Country, country.Data);
            Assert.AreEqual(v.Data.ValidFrom, r.ValidFrom);
            Assert.AreEqual(v.Data.ValidTo, r.ValidTo);
            Assert.AreEqual(v.Data.CountryID, country.Data.ID);
            Assert.AreEqual(v.Data.CurrencyID, currency.Data.ID);
        }
    }
}