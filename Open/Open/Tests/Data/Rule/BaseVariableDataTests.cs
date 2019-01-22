using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class BaseVariableDataTests : ObjectTests<BaseVariableData> {
        private class testClass : BaseVariableData { }
        protected override BaseVariableData getRandomObject() {
            return GetRandom.Object<testClass>();
        }
        [TestMethod] public void ValueAsStringTest() {
            canReadWrite(() => obj.ValueAsString, x => obj.ValueAsString = x);
        }
        [TestMethod] public void RuleContextIDTest() {
            canReadWrite(() => obj.RuleContextID, x => obj.RuleContextID = x);
        }
        [TestMethod] public void RuleContextTest() {
            canReadWrite(() => obj.RuleContext, x => obj.RuleContext = x);
        }
        [TestMethod] public void RuleContextIDIsNullTest() {
            obj.RuleContextID = null;
            Assert.IsNull(obj.RuleContextID);
        }
    }
}
