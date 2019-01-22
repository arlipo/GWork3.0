using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class ActiveRuleDataTests : ObjectTests<ActiveRuleData>
    {
        protected override ActiveRuleData getRandomObject()
        {
            return GetRandom.Object<ActiveRuleData>();
        }

        [TestMethod]
        public void RuleIDTest()
        {
            canReadWrite(() => obj.RuleID, x => obj.RuleID = x);
        }

        [TestMethod]
        public void RuleTest()
        {
            canReadWrite(() => obj.Rule, x => obj.Rule = x);
        }


    }
}
