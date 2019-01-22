using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Domain.Rule {
    [TestClass] public class RuleOverridesTests //: ClassTests<RuleOverrides>
    {
        //protected override RuleOverrides getRandomObj() { return RuleOverrides.Random(); }
        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsTrue(RuleOverrides.Empty.IsEmpty());
        //    Assert.IsFalse(RuleOverrides.Random().IsEmpty());
        //    Assert.IsFalse(new RuleOverrides().IsEmpty());
        //}
        //[TestMethod] public void FindTest() {
        //    var empty = RuleOverride.Empty;
        //    var obj = RuleOverride.Random();
        //    Assert.AreEqual(empty, RuleOverrides.Find(null));
        //    Assert.AreEqual(empty, RuleOverrides.Find(obj.UniqueId));
        //    RuleOverrides.Instance.Add(obj);
        //    Assert.AreEqual(obj, RuleOverrides.Find(obj.UniqueId));
        //}
        //[TestMethod] public void InstanceTest() { testSingleton(() => RuleOverrides.Instance); }
        //[TestMethod] public void EmptyTest() { testSingleton(() => RuleOverrides.Instance); }
        //[TestMethod] public void FindForSetTest() {
        //    var s = RuleSet.Random();
        //    var o1 = RuleOverride.Random();
        //    var o2 = RuleOverride.Random();
        //    var o3 = RuleOverride.Random();
        //    var o4 = RuleOverride.Random();
        //    o1.RuleSetId = s.UniqueId;
        //    o2.RuleSetId = s.UniqueId;
        //    Assert.AreEqual(0, RuleOverrides.FindForSet(s.UniqueId).Count);
        //    RuleOverrides.Instance.AddRange(new []{o1, o2, o3, o4});
        //    var x = RuleOverrides.FindForSet(s.UniqueId);
        //    Assert.AreEqual(2, x.Count);
        //    Assert.IsTrue(x.Contains(o1));
        //    Assert.IsTrue(x.Contains(o2));
        //    Assert.IsFalse(x.Contains(o3));
        //    Assert.IsFalse(x.Contains(o4));
        //}
    }
}
