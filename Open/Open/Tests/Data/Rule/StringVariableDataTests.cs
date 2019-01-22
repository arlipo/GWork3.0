using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class StringVariableDataTests : ObjectTests<StringVariableData>
    {
        class testClass : StringVariableData { }
        protected override StringVariableData getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void ValueTests()
        {
            var s = GetRandom.String();
            obj.Value = s;
            Assert.AreEqual(s, obj.Value);
            Assert.AreEqual(s, obj.ValueAsString);
        }
        [TestMethod]
        public void ValueIsDateTimeTests()
        {
            Assert.IsInstanceOfType(obj.Value, typeof(string));
        }
        [TestMethod]
        public void ValueAsStringTests()
        {
            var s = GetRandom.String();
            obj.ValueAsString = s;
            Assert.AreEqual(s, obj.Value);
            Assert.AreEqual(s, obj.ValueAsString);
        }
    }
}
