using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;
namespace Open.Tests.Data.Common {
    [TestClass] public class NamedDataTests : ObjectTests<NamedData> {
        private class testClass : NamedData { }
        protected override NamedData getRandomObject() {
            return GetRandom.Object<testClass>();
        }
        [TestMethod] public void IsAbstract() {
            Assert.IsTrue(typeof(NamedData).IsAbstract);
        }
        [TestMethod] public void BaseTypeIsUniqueDbRecord() {
            Assert.AreEqual(typeof(IdentifiedData), typeof(NamedData).BaseType);
        }
        [TestMethod] public void IDTest() {
            canReadWrite(() => obj.ID, x => obj.ID = x);
            allowNullEmptyAndWhitespace(() => obj.ID, x => obj.ID = x, () => obj.Name);
        }
        [TestMethod] public void NameTest() {
            canReadWrite(() => obj.Name, x => obj.Name = x);
            allowNullEmptyAndWhitespace(() => obj.Name, x => obj.Name = x, () => obj.Code);
        }
        [TestMethod] public void CodeTest() {
            canReadWrite(() => obj.Code, x => obj.Code = x);
            allowNullEmptyAndWhitespace(() => obj.Code, x => obj.Code = x, () => Constants.Unspecified);
        }
    }
}







