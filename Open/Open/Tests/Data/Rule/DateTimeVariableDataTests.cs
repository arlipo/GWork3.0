using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class DateTimeVariableDataTests : ObjectTests<DateTimeVariableData> {
        protected override DateTimeVariableData getRandomObject() {
            return GetRandom.Object<DateTimeVariableData>();
        }

        [TestMethod] public void ValueTests() {
            var d = GetRandom.DateTime();
            obj.Value = d;
            Assert.AreEqual(d.ToString(UseCulture.Invariant), obj.Value.ToString(UseCulture.Invariant));
            Assert.AreEqual(d.ToString(UseCulture.Invariant), obj.ValueAsString);
        }
        [TestMethod] public void ValueIsDateTimeTests() {
            Assert.IsInstanceOfType(obj.Value, typeof(DateTime));
        }
        [TestMethod] public void ValueAsStringTests() {
            obj.ValueAsString = GetRandom.String();
            Assert.AreEqual(DateTime.MaxValue, obj.Value);
            var d = GetRandom.DateTime();
            obj.ValueAsString = d.ToString(UseCulture.Invariant);
            Assert.AreEqual(d.ToString(UseCulture.Invariant), obj.Value.ToString(UseCulture.Invariant));
        }
    }
}
