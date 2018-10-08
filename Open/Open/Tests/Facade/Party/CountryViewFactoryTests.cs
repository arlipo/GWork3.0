using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Party;
using Open.Facade.Party;
namespace Open.Tests.Facade.Party {
    [TestClass] public class CountryViewFactoryTests : BaseTests {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CountryViewFactory);
        }

        [TestMethod] public void CreateTest() {
            var o = GetRandom.Object<Country>();
            var v = CountryViewFactory.Create(o);
            Assert.AreEqual(v.Name, o.Data.Name);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.Data.ValidTo);
            Assert.AreEqual(v.Alpha2Code, o.Data.Code);
            Assert.AreEqual(v.Alpha3Code, o.Data.ID);
        }

        [TestMethod] public void CreateNullTest() {
            var v = CountryViewFactory.Create(null);
            Assert.AreEqual(v.Name, Constants.Unspecified);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
            Assert.AreEqual(v.Alpha2Code, Constants.Unspecified);
            Assert.AreEqual(v.Alpha3Code, Constants.Unspecified);
        }
        [TestMethod] public void CreateWithExtremumDatesTest() {
            var o = GetRandom.Object<Country>();
            o.Data.ValidFrom = DateTime.MinValue;
            o.Data.ValidTo = DateTime.MaxValue;
            var v = CountryViewFactory.Create(o);
            Assert.AreEqual(v.Name, o.Data.Name);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
            Assert.AreEqual(v.Alpha2Code, o.Data.Code);
            Assert.AreEqual(v.Alpha3Code, o.Data.ID);
        }
    }
}
