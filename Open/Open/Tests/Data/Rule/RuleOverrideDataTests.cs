using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class RuleOverrideDataTests : ObjectTests<RuleOverrideData>
    {
        protected override RuleOverrideData getRandomObject()
        {
            return GetRandom.Object<RuleOverrideData>();
        }

        [TestMethod]
        public void RuleSetIdTest()
        {
            canReadWrite(() => obj.RuleSetId, x => obj.RuleSetId = x);
        }
        [TestMethod]
        public void RuleContextIdTest()
        {
            canReadWrite(() => obj.RuleContextId, x => obj.RuleContextId = x);
        }
        [TestMethod]
        public void RuleContextTest()
        {
            canReadWrite(() => obj.RuleContext, x => obj.RuleContext = x);
        }
        [TestMethod]
        public void RuleSetTest()
        {
            canReadWrite(() => obj.RuleSet, x => obj.RuleSet = x);
        }
    }
}
