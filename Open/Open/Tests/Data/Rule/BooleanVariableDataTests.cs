using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
using Open.Tests.Domain.Common;
namespace Open.Tests.Data.Rule {
    [TestClass]
    public class BooleanVariableDataTests : ObjectTests<BooleanVariableData>
    {
        protected override BooleanVariableData getRandomObject() {
            return GetRandom.Object<BooleanVariableData>();
        }

        [TestMethod] public void ValueTests() {
            obj.Value = true;
            Assert.AreEqual(true, obj.Value);
            Assert.AreEqual("True", obj.ValueAsString);
            obj.Value = false;
            Assert.AreEqual(false, obj.Value);
            Assert.AreEqual("False", obj.ValueAsString);
        }
        [TestMethod]
        public void ValueIsBoolTests()
        {
            Assert.IsInstanceOfType(obj.Value, typeof(bool));
        }
        [TestMethod]
        public void ValueAsStringTests() {
            obj.ValueAsString = GetRandom.String();
            Assert.AreEqual(false, obj.Value);
            obj.ValueAsString = "True";
            Assert.AreEqual(true, obj.Value);
            obj.ValueAsString = "False";
            Assert.AreEqual(false, obj.Value);
        }
    }
}
