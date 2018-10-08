using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class CurrencyDataTests : ObjectTests<CurrencyData> {
        protected override CurrencyData getRandomObject() {
            return GetRandom.Object<CurrencyData>();
        }

        [TestMethod] public void IsInstanceOfMetric() {
            Assert.AreEqual(typeof(MetricsData), obj.GetType().BaseType);
        }
    }
}



