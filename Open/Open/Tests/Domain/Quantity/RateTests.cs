using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class RateTests : EntityBaseTests<Rate, RateData> {
        protected override Rate getRandomObject()
        {
            createdWithNullArg = new Rate(null);
            dbRecordType = typeof(RateData);
            return GetRandom.Object<Rate>();
        }

        [TestMethod] public void CurrencyTest() {
            Assert.AreEqual(obj.Currency.ID, obj.Data.Currency.ID);
        }

        [TestMethod] public void RateTypeTest() {
            Assert.AreEqual(obj.RateType.ID, obj.Data.RateType.ID);
        }
    }
}