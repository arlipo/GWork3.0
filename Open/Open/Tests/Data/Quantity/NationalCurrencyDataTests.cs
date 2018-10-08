using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class NationalCurrencyDataTests : ObjectTests<NationalCurrencyData> {
        protected override NationalCurrencyData getRandomObject() {
            return GetRandom.Object<NationalCurrencyData>();
        }
        [TestMethod] public void CountryIDTest() {
            canReadWrite(() => obj.CountryID, x => obj.CountryID = x);
            allowNullEmptyAndWhitespace(() => obj.CountryID, x => obj.CountryID = x,
                () => Constants.Unspecified);
        }
        [TestMethod] public void CurrencyIDTest() {
            canReadWrite(() => obj.CurrencyID, x => obj.CurrencyID = x);
            allowNullEmptyAndWhitespace(() => obj.CurrencyID, x => obj.CurrencyID = x,
                () => Constants.Unspecified);
        }
        [TestMethod] public void CountryTest() {
            canReadWrite(() => obj.Country, x => obj.Country = x);
            obj.Country = null;
            Assert.IsNull(obj.Country);
        }
        [TestMethod] public void CurrencyTest() {
            canReadWrite(() => obj.Currency, x => obj.Currency = x);
            obj.Currency = null;
            Assert.IsNull(obj.Currency);
        }
    }
}





