using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Domain.Rule {
    [TestClass] public class RuleUsagesTests //: ClassTests<RuleUsages>
    {
        //private static readonly RuleUsage empty = RuleUsage.Empty;
        //protected override RuleUsages getRandomObj() {
        //    return RuleUsages.Random();
        //}
        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsTrue(RuleUsages.Empty.IsEmpty());
        //    Assert.IsFalse(RuleUsages.Random().IsEmpty());
        //    Assert.IsFalse(new RuleUsages().IsEmpty());
        //}
        //[TestMethod] public void EmptyTest() {
        //    testSingleton(() => RuleUsages.Empty);
        //}
        //[TestMethod] public void InstanceTest() {
        //    testSingleton(() => RuleUsages.Empty);
        //}
        //[TestMethod] public void FindTest() {
        //    var ruleUsage = RuleUsage.Random();
        //    Assert.AreEqual(empty, RuleUsages.Find(null));
        //    Assert.AreEqual(empty, RuleUsages.Find(ruleUsage.UniqueId));
        //    RuleUsages.Instance.Add(ruleUsage);
        //    Assert.AreEqual(ruleUsage, RuleUsages.Find(ruleUsage.UniqueId));
        //}
        //[TestMethod]
        //public void FindForSetTest() {
        //    var ruleSetId = GetRandom.String();
        //    var ruleUsage1 = RuleUsage.Random();
        //    var ruleUsage2 = RuleUsage.Random();
        //    var ruleUsage3 = RuleUsage.Random();
        //    ruleUsage1.RuleSetId = ruleSetId;
        //    ruleUsage2.RuleSetId = ruleSetId;
        //    Assert.AreEqual(0, RuleUsages.FindForSet(null).Count);
        //    Assert.AreEqual(0, RuleUsages.FindForSet(ruleSetId).Count);
        //    RuleUsages.Instance.AddRange(new []{ruleUsage1, ruleUsage2, ruleUsage3});
        //    Assert.AreEqual(2, RuleUsages.FindForSet(ruleSetId).Count);
        //}
        //[TestMethod]
        //public void FindForRuleTest()
        //{
        //    var ruleId = GetRandom.String();
        //    var ruleUsage1 = RuleUsage.Random();
        //    var ruleUsage2 = RuleUsage.Random();
        //    var ruleUsage3 = RuleUsage.Random();
        //    ruleUsage1.RuleId = ruleId;
        //    ruleUsage2.RuleId = ruleId;
        //    Assert.AreEqual(0, RuleUsages.FindForRule(null).Count);
        //    Assert.AreEqual(0, RuleUsages.FindForRule(ruleId).Count);
        //    RuleUsages.Instance.AddRange(new[] { ruleUsage1, ruleUsage2, ruleUsage3 });
        //    Assert.AreEqual(2, RuleUsages.FindForRule(ruleId).Count);
        //}
    }
}
