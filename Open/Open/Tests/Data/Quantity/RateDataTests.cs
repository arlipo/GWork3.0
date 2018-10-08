using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class RateDataTests : ObjectTests<RateData> {
        protected override RateData getRandomObject() {
            return GetRandom.Object<RateData>();
        }

        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(IdentifiedData));
        }

        [TestMethod] public void CurrencyTest() {
            canReadWrite(() => obj.Currency, x => obj.Currency = x);
        }

        [TestMethod] public void RateTest() {
            canReadWrite(() => obj.Rate, x => obj.Rate = x);
        }

        [TestMethod] public void CurrencyIDTest() {
            canReadWrite(() => obj.CurrencyID, x => obj.CurrencyID = x);
        }

        [TestMethod] public void RateTypeIDTest() {
            canReadWrite(() => obj.RateTypeID, x => obj.RateTypeID = x);
        }

        [TestMethod] public void RateTypeTest() {
            canReadWrite(() => obj.RateType, x => obj.RateType = x);
        }
    }
}