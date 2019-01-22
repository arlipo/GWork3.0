using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class OperandDataTests : ObjectTests<OperandData>
    {
        protected override OperandData getRandomObject() {
            return GetRandom.Object<OperandData>();
        }
        [TestMethod] public void IsRuleElementDataTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(RuleElementData));
        }
    }
}
