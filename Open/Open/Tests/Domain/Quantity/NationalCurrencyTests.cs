using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class NationalCurrencyTests : ObjectTests<NationalCurrency> {
        protected override NationalCurrency getRandomObject() {
            return GetRandom.Object<NationalCurrency>();
        }
        [TestMethod] public void CountryTest() {
            Assert.AreEqual(obj.Currency.Data, obj.Data.Currency);
        }
        [TestMethod] public void CurrencyTest() {
            Assert.AreEqual(obj.Currency.Data, obj.Data.Currency);
        }
        [TestMethod] public void WhenCreatedWithNullArgumentsTest() {
            obj = new NationalCurrency(null);
            Assert.IsNotNull(obj.Data.Currency);
            Assert.AreEqual(obj.Data.CurrencyID, Constants.Unspecified);
            Assert.IsNotNull(obj.Data.Currency.ID, Constants.Unspecified);
        }
    }
}