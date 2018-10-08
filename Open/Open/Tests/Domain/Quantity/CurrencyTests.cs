using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Party;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class CurrencyTests : EntityBaseTests<Currency, CurrencyData> {
        protected override Currency getRandomObject() {
            createdWithNullArg = new Currency(null);
            dbRecordType = typeof(CurrencyData);
            return GetRandom.Object<Currency>();
        }

        [TestMethod] public void UsedInCountriesTest() {
            Assert.IsNotNull(obj.UsedInCountries);
            Assert.IsInstanceOfType(obj.UsedInCountries, typeof(IReadOnlyList<Country>));
        }

        [TestMethod] public void UsedInCountryTest() {
            var country = GetRandom.Object<Country>();
            Assert.IsFalse(obj.UsedInCountries.Contains(country));
            obj.UsedInCountry(country);
            Assert.IsTrue(obj.UsedInCountries.Contains(country));
        }
    }
}