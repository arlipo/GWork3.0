using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Party;
namespace Open.Tests.Domain.Party {
    [TestClass] public class CountryFactoryTests : BaseTests {
        private string id;
        private string name;
        private string code;
        private DateTime validFrom;
        private DateTime validTo;
        private Country o;
        private void initializeTestData() {
            var min = DateTime.Now.AddYears(-50);
            var max = DateTime.Now.AddYears(50);
            id = GetRandom.String();
            name = GetRandom.String();
            code = GetRandom.String();
            validFrom = GetRandom.DateTime(min, max);
            validTo = GetRandom.DateTime(validFrom, max);
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
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CountryFactory);
            initializeTestData();
        }
        [TestMethod] public void CreateTest() {
            o = CountryFactory.Create(id, name, code, validFrom, validTo);
            validateResults(id, name, code, validFrom, validTo);
        }
        [TestMethod] public void CreateValidFromGreaterThanValidToTest() {
            o = CountryFactory.Create(id, name, code, validTo, validFrom);
            validateResults(id, name, code, validFrom, validTo);
        }
        [TestMethod] public void CreateWithNullArgumentsTest() {
            o = CountryFactory.Create(null, null, null);
            validateResults();
        }
        [TestMethod] public void CreateWithCodeOnlyTest() {
            o = CountryFactory.Create(null, null, code);
            validateResults(code, code, code);
        }
        [TestMethod] public void CreateWithNameOnlyTest() {
            o = CountryFactory.Create(null, name, null);
            validateResults(name, name);
        }
        [TestMethod] public void CreateWithNullRegionInfoTest() {
            o = CountryFactory.Create(null);
            validateResults();
        }
        [TestMethod] public void CreateWithRegionInfoTest() {
            var i = new RegionInfo("ee-EE");
            o = CountryFactory.Create(i);
            validateResults(i.ThreeLetterISORegionName, i.DisplayName, i.TwoLetterISORegionName);
        }
    }
}


