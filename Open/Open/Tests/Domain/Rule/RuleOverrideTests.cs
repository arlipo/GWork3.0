using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Domain.Rule {
    [TestClass] public class RuleOverrideTests //: ClassTests<RuleOverride>
    {
        //protected override RuleOverride getRandomObj() { return RuleOverride.Random(); }
        //[TestMethod] public void EmptyTest() { testSingleton(() => RuleOverride.Empty); }
        //[TestMethod]
        //public void RuleSetIdTest()
        //{
        //    testProperty(() => Obj.Variables, x => Obj.Variables = x);
        //}
        //[TestMethod] public void VariablesTest() {
        //    testProperty(() => Obj.Variables, x => Obj.Variables = x);
        //}
        //[TestMethod] public void AuthorizedTest() {
        //    testProperty(() => Obj.Authorized, x => Obj.Authorized = x);
        //}
        //[TestMethod] public void IsSignedTest() {
        //    Assert.IsFalse(RuleOverride.Empty.IsSigned());
        //    Assert.IsTrue(Obj.IsSigned());
        //    Obj.PartyId = string.Empty;
        //    Assert.IsFalse(Obj.IsSigned());
        //    Obj = getRandomObj();
        //    Assert.IsTrue(Obj.IsSigned());
        //    Obj.Valid.From = DateTime.MinValue.AddHours(12);
        //    Assert.IsFalse(Obj.IsSigned());
        //}
        //[TestMethod] public void IsAuthorizedTest() {
        //    Assert.IsFalse(RuleOverride.Empty.IsAuthorized());
        //    Assert.IsTrue(Obj.IsAuthorized());
        //    foreach(var a in Obj.Authorized) a.PartyId = string.Empty;
        //    Assert.IsFalse(Obj.IsAuthorized());
        //    Obj = getRandomObj();
        //    Assert.IsTrue(Obj.IsAuthorized());
        //    foreach(var a in Obj.Authorized)
        //        a.Valid.From = DateTime.MinValue.AddHours(12);
        //    Assert.IsFalse(Obj.IsAuthorized());
        //}
        //[TestMethod] public void IsValidTest() {
        //    Obj = getRandomObj();
        //    var dt = GetRandom.DateTime(max: Obj.Valid.From);
        //    Assert.IsFalse(Obj.IsValid(dt));
        //    dt = GetRandom.DateTime(Obj.Valid.To);
        //    Assert.IsFalse(Obj.IsValid(dt));
        //    dt = GetRandom.DateTime(Obj.Valid.From, Obj.Valid.To);
        //    Assert.IsTrue(Obj.IsValid(dt));
        //}
        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsFalse(Obj.IsEmpty());
        //    Assert.IsTrue(RuleOverride.Empty.IsEmpty());
        //    Assert.IsFalse(new RuleOverride().IsEmpty());
        //    Assert.IsFalse(RuleOverride.Random().IsEmpty());
        //}
        //[TestMethod] public void ComputeTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var variable = StringVariable.Random();
        //    Obj.Variables.Add( variable);
        //    variable.Name = r.Name;
        //    var v = Obj.Compute(r) as StringVariable;
        //    Assert.IsNotNull(v);
        //    Assert.AreEqual(variable,v);
        //}
        //[TestMethod] public void IsNotAuthorizedTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var variable = StringVariable.Random();
        //    variable.Name = r.Name;
        //    Obj.Variables.Add(variable);
        //    foreach(var a in Obj.Authorized)
        //        a.PartyId = string.Empty;
        //    var v = Obj.Compute(r) as StringVariable;
        //    Assert.IsNotNull(v);
        //    Assert.AreEqual(r.Name,v.Name);
        //    Assert.AreEqual(RuleError.notAuthorized,v.Value);
        //}
        //[TestMethod] public void IsNotSignedTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var variable = StringVariable.Random();
        //    variable.Name = r.Name;
        //    Obj.Variables.Add(variable);
        //    Obj.PartyId = string.Empty;
        //    var v = Obj.Compute(r) as StringVariable;
        //    Assert.IsNotNull(v);
        //    Assert.AreEqual(r.Name,v.Name);
        //    Assert.AreEqual(RuleError.notSigned,v.Value);
        //}
        //[TestMethod] public void IsWrongRuleTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var v = Obj.Compute(r) as StringVariable;
        //    Assert.IsNotNull(v);
        //    Assert.AreEqual(r.Name,v.Name);
        //    Assert.AreEqual(RuleError.inRule,v.Value);
        //}
        //[TestMethod] public void VariableIsNullTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    Obj.Variables = null;
        //    var v = Obj.Compute(r) as StringVariable;
        //    Assert.IsNotNull(v);
        //    Assert.AreEqual(r.Name,  v.Name);
        //    Assert.AreEqual(RuleError.inRule, v.Value);
        //}
        //[TestMethod] public void RuleIsNullTest() {
        //    var v = Obj.Compute(null) as StringVariable;
        //    Assert.IsNotNull(v);
        //    Assert.AreEqual(string.Empty,v.Name);
        //    Assert.AreEqual(RuleError.unknown,v.Value);
        //}
        //[TestMethod]
        //public void IsValidRuleTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    Assert.IsFalse(Obj.IsValidRule(r));
        //    Obj.Variables[0].Name = r.Name;
        //    Assert.IsTrue(Obj.IsValidRule(r));
        //}
        //[TestMethod] public void GetRuleSetTest() {
        //    var s = RuleSet.Random();
        //    Obj.RuleSetId = s.UniqueId;
        //    Assert.AreEqual(RuleSet.Empty, Obj.GetRuleSet);
        //    RuleSets.Instance.Add(s);
        //    Assert.AreEqual(s, Obj.GetRuleSet);
        //}
    }
}
