using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;
namespace Open.Tests.Data.Common {
    [TestClass] public class IdentifiedDataTests : ObjectTests<IdentifiedData> {
        private class testClass : IdentifiedData { }
        protected override IdentifiedData getRandomObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod] public void IsAbstract() { Assert.IsTrue(typeof(IdentifiedData).IsAbstract); }

        [TestMethod] public void BaseTypeIsTemporalDbRecord() {
            Assert.AreEqual(typeof(PeriodData), typeof(IdentifiedData).BaseType);
        }

        [TestMethod] public void IDTest() {
            canReadWrite(() => obj.ID, x => obj.ID = x);
            allowNullEmptyAndWhitespace(() => obj.ID, x => obj.ID = x, () => Constants.Unspecified);
        }

    }
}



