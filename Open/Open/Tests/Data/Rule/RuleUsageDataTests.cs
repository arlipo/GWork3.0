using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class RuleUsageDataTests : ObjectTests<RuleUsageData>
    {
        protected override RuleUsageData getRandomObject()
        {
            return GetRandom.Object<RuleUsageData>();
        }

        [TestMethod]
        public void RuleIdTest()
        {
            canReadWrite(() => obj.RuleId, x => obj.RuleId = x);
        }
        [TestMethod]
        public void RuleSetIdTest()
        {
            canReadWrite(() => obj.RuleSetId, x => obj.RuleSetId = x);
        }
        [TestMethod]
        public void RuleTest()
        {
            canReadWrite(() => obj.Rule, x => obj.Rule = x);
        }
        [TestMethod]
        public void RuleSetTest()
        {
            canReadWrite(() => obj.RuleSet, x => obj.RuleSet = x);
        }
        //protected override RuleUsage getRandomObj() { return RuleUsage.Random(); }
        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsTrue(RuleUsage.Empty.IsEmpty());
        //    Assert.IsFalse(RuleUsage.Random().IsEmpty());
        //    Assert.IsFalse(new RuleUsage().IsEmpty());
        //}
        //[TestMethod] public void RuleIdTest() {
        //    testProperty(() => Obj.RuleId, x => Obj.RuleId = x);
        //}
        //[TestMethod] public void RuleSetIdTest() {
        //    testProperty(() => Obj.RuleSetId, x => Obj.RuleSetId = x);
        //}
        //[TestMethod] public void GetRuleTest() {
        //    var empty = Open.Domain.Rule.Rule.Empty;
        //    Assert.AreEqual(empty, Obj.GetRule());
        //    var rule = Open.Domain.Rule.Rule.Random();
        //    Obj.RuleId = rule.UniqueId;
        //    Assert.AreEqual(empty, Obj.GetRule());
        //    Rules.Instance.Add(rule);
        //    Assert.AreEqual(rule, Obj.GetRule());
        //}
        //[TestMethod] public void GetRuleSetTest() {
        //    var empty = RuleSet.Empty;
        //    Assert.AreEqual(empty, Obj.GetRuleSet());
        //    var ruleSet = RuleSet.Random();
        //    Obj.RuleSetId = ruleSet.UniqueId;
        //    Assert.AreEqual(empty, Obj.GetRuleSet());
        //    RuleSets.Instance.Add(ruleSet);
        //    Assert.AreEqual(ruleSet, Obj.GetRuleSet());
        //}
        //[TestMethod] public void EmptyTest() {
        //    testSingleton(()=> RuleUsage.Empty);
        //}
    }
}
