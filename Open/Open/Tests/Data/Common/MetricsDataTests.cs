using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;
namespace Open.Tests.Data.Common {
    [TestClass] public class MetricsDataTests : ObjectTests<MetricsData> {
        private class testClass : MetricsData { }
        protected override MetricsData getRandomObject() {
            return GetRandom.Object<testClass>();
        }
        [TestMethod] public void IsAbstract() {
            Assert.IsTrue(typeof(MetricsData).IsAbstract);
        }
        [TestMethod] public void BaseTypeIsRootObjectDbRecord() {
            Assert.AreEqual(typeof(NamedData), typeof(MetricsData).BaseType);
        }
        [TestMethod]
        public void DefinitionTest()
        {
            canReadWrite(() => obj.Definition, x => obj.Definition = x);
            allowNullEmptyAndWhitespace(() => obj.Definition, x => obj.Definition = x, () => Constants.Unspecified);
        }

    }
}


