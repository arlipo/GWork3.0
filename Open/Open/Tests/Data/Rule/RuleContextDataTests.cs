using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class RuleContextDataTests : ObjectTests<RuleContextData> {
        protected override RuleContextData getRandomObject() {
            return GetRandom.Object<RuleContextData>();
        }
        [TestMethod] public void RuleIDTest() {
            canReadWrite(() => obj.RuleID, x => obj.RuleID = x);
        }
        [TestMethod] public void RuleSetIDTest() {
            canReadWrite(() => obj.RuleID, x => obj.RuleID = x);
        }
        [TestMethod] public void RuleSetTest() {
            canReadWrite(() => obj.RuleSet, x => obj.RuleSet = x);
        }
        [TestMethod] public void RuleTest() {
            canReadWrite(() => obj.Rule, x => obj.Rule = x);
        }
    }
}
