using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
using Open.Data.Quantity;
using Open.Domain.Party;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Party {

    [TestClass]
    public class CountryTests : EntityBaseTests<Country, CountryData> {

        protected override Country getRandomObject() {
            createdWithNullArg = new Country(null);
            dbRecordType = typeof(CountryData);
            return GetRandom.Object<Country>();
        }

        [TestMethod] public void CurrenciesInUseTest() {
            Assert.IsNotNull(obj.CurrenciesInUse);
            Assert.IsInstanceOfType(obj.CurrenciesInUse, typeof(IReadOnlyList<Currency>));
        }

        [TestMethod] public void CurrencyInUseTest() {
            var data = GetRandom.Object<CurrencyData>();
            var currency = new Currency(data);
            Assert.IsFalse(obj.CurrenciesInUse.Contains(currency));
            obj.CurrencyInUse(currency);
            Assert.IsTrue(obj.CurrenciesInUse.Contains(currency));
        }
    }
}



