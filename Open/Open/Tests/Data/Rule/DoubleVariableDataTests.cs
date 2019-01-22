using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class DoubleVariableDataTests : ObjectTests<DoubleVariableData>
    {
        protected override DoubleVariableData getRandomObject()
        {
            return GetRandom.Object<DoubleVariableData>();
        }

        [TestMethod]
        public void ValueTests()
        {
            var d = GetRandom.Double();
            obj.Value = d;
            Assert.AreEqual(d, obj.Value);
            Assert.AreEqual(d.ToString(UseCulture.Invariant), obj.ValueAsString);
        }
        [TestMethod]
        public void ValueIsDateTimeTests()
        {
            Assert.IsInstanceOfType(obj.Value, typeof(double));
        }
        [TestMethod]
        public void ValueAsStringTests()
        {
            obj.ValueAsString = GetRandom.String();
            Assert.AreEqual(double.NaN, obj.Value);
            var d = GetRandom.Double();
            obj.ValueAsString = d.ToString(UseCulture.Invariant);
            Assert.AreEqual(d.ToString(UseCulture.Invariant), obj.Value.ToString(UseCulture.Invariant));
        }
    }
}
