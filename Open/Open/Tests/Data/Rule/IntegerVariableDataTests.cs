using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class IntegerVariableDataTests : ObjectTests<IntegerVariableData> {
        protected override IntegerVariableData getRandomObject() {
            return GetRandom.Object<IntegerVariableData>();
        }

        [TestMethod] public void ValueTests() {
            var d = GetRandom.Int64();
            obj.Value = d;
            Assert.AreEqual(d, obj.Value);
            Assert.AreEqual(d.ToString(UseCulture.Invariant), obj.ValueAsString);
        }
        [TestMethod] public void ValueIsDateTimeTests() {
            Assert.IsInstanceOfType(obj.Value, typeof(long));
        }
        [TestMethod] public void ValueAsStringTests() {
            obj.ValueAsString = GetRandom.String();
            Assert.AreEqual(0, obj.Value);
            var d = GetRandom.Int64();
            obj.ValueAsString = d.ToString(UseCulture.Invariant);
            Assert.AreEqual(d, obj.Value);
        }
    }
}
