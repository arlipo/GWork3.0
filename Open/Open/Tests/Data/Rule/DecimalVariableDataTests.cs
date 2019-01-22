using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class DecimalVariableDataTests : ObjectTests<DecimalVariableData>
    {
        protected override DecimalVariableData getRandomObject()
        {
            return GetRandom.Object<DecimalVariableData>();
        }

        [TestMethod]
        public void ValueTests()
        {
            var d = GetRandom.Decimal();
            obj.Value = d;
            Assert.AreEqual(d, obj.Value);
            Assert.AreEqual(d.ToString(UseCulture.Invariant), obj.ValueAsString);
        }
        [TestMethod]
        public void ValueIsDateTimeTests()
        {
            Assert.IsInstanceOfType(obj.Value, typeof(decimal));
        }
        [TestMethod]
        public void ValueAsStringTests()
        {
            obj.ValueAsString = GetRandom.String();
            Assert.AreEqual(decimal.Zero, obj.Value);
            var d = GetRandom.Decimal();
            obj.ValueAsString = d.ToString(UseCulture.Invariant);
            Assert.AreEqual(d, obj.Value);
        }
    }
}
