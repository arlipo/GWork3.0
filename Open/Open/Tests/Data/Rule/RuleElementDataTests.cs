using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class RuleElementDataTests : ObjectTests<RuleElementData> {

        private class testClass: RuleElementData { }
        protected override RuleElementData getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void NameTest()
        {
            canReadWrite(() => obj.Name, x => obj.Name = x);
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
