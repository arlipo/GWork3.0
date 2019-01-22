using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Domain.Rule {

    [TestClass] public class RuleSetTests //: ClassTests<RuleSet>
    {

        //protected override RuleSet getRandomObj() { return RuleSet.Random(); }

        //[TestMethod] public void AddRuleTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var c1 = Rules.Instance.Count;
        //    var c2 = RuleUsages.Instance.Count;
        //    var c3 = Obj.GetRuleUsages().Count;
        //    var u = Obj.AddRule(r);
        //    Assert.AreEqual(c1 + 1, Rules.Instance.Count);
        //    Assert.AreEqual(c2 + 1, RuleUsages.Instance.Count);
        //    Assert.AreEqual(c3 + 1, Obj.GetRuleUsages().Count);
        //    Assert.AreEqual(r, Rules.Find(r.UniqueId));
        //    Assert.AreEqual(u, RuleUsages.Find(u.UniqueId));
        //    Assert.AreEqual(u, Obj.GetRuleUsages().Find(x => x.UniqueId == u.UniqueId));
        //    Assert.AreEqual(r, u.GetRule());
        //}

        //[TestMethod] public void AddNullRuleTest() {
        //    var c1 = Rules.Instance.Count;
        //    var c2 = RuleUsages.Instance.Count;
        //    var c3 = Obj.GetRuleUsages().Count;
        //    Obj.AddRule(null);
        //    Assert.AreEqual(c1, Rules.Instance.Count);
        //    Assert.AreEqual(c2, RuleUsages.Instance.Count);
        //    Assert.AreEqual(c3, Obj.GetRuleUsages().Count);
        //}

        //[TestMethod] public void AddExistingRuleTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var c1 = Rules.Instance.Count;
        //    var c2 = RuleUsages.Instance.Count;
        //    var c3 = Obj.GetRuleUsages().Count;
        //    var u1 = Obj.AddRule(r);
        //    var u2 = Obj.AddRule(r);
        //    Assert.AreEqual(c1 + 1, Rules.Instance.Count);
        //    Assert.AreEqual(c2 + 1, RuleUsages.Instance.Count);
        //    Assert.AreEqual(c3 + 1, Obj.GetRuleUsages().Count);
        //    Assert.AreEqual(u1, u2);
        //}

        //[TestMethod] public void AddClonedRuleTest() {
        //    var r1 = Open.Domain.Rule.Rule.Random();
        //    var r2 = Common.Clone(r1);
        //    var c1 = Rules.Instance.Count;
        //    var c2 = RuleUsages.Instance.Count;
        //    var c3 = Obj.GetRuleUsages().Count;
        //    var u1 = Obj.AddRule(r1);
        //    var u2 = Obj.AddRule(r2);
        //    Assert.AreEqual(c1 + 1, Rules.Instance.Count);
        //    Assert.AreEqual(c2 + 1, RuleUsages.Instance.Count);
        //    Assert.AreEqual(c3 + 1, Obj.GetRuleUsages().Count);
        //    Assert.AreEqual(u1, u2);
        //}

        //[TestMethod] public void ComputeTest() {
        //    var r1 = Open.Domain.Rule.Rule.Random();
        //    r1.Elements.Clear();
        //    r1.Elements.Add(new Operand {Name = "dx"});
        //    r1.Elements.Add(new Operator {Operation = Operation.Square});
        //    r1.Elements.Add(new Operand {Name = "dy"});
        //    r1.Elements.Add(new Operator {Operation = Operation.Square});
        //    r1.Elements.Add(new Operator {Operation = Operation.Add});
        //    r1.Elements.Add(new Operator {Operation = Operation.Sqrt});
        //    var r2 = Open.Domain.Rule.Rule.Random();
        //    r2.Elements.Clear();
        //    r2.Elements.Add(new Operand {Name = "IsColdCardHolder"});
        //    r2.Elements.Add(new Operand {Name = "IsSilverCardHolder"});
        //    r2.Elements.Add(new Operator {Operation = Operation.Or});
        //    r2.Elements.Add(new Operand {Name = "CarryOnBagageKg"});
        //    r2.Elements.Add(new Operand {Name = "AllowedBagageKg"});
        //    r2.Elements.Add(new Operator {Operation = Operation.Less});
        //    r2.Elements.Add(new Operator {Operation = Operation.And});
        //    var r3 = Open.Domain.Rule.Rule.Random();
        //    r3.Elements.Clear();
        //    r3.Elements.Add(new Operand {Name = "sx"});
        //    r3.Elements.Add(new Operand {Name = "sy"});
        //    r3.Elements.Add(new Operator {Operation = Operation.Add});
        //    r3.Elements.Add(new Operator {Operation = Operation.Trim});
        //    r3.Elements.Add(new Operand {Name = "sz"});
        //    r3.Elements.Add(new Operand {Name = "sq"});
        //    r3.Elements.Add(new Operator {Operation = Operation.Substring});
        //    r3.Elements.Add(new Operator {Operation = Operation.ToUpper});
        //    var r4 = Open.Domain.Rule.Rule.Random();
        //    r4.Elements.Clear();
        //    r4.Elements.Add(new Operand {Name = "dtx"});
        //    r4.Elements.Add(new Operand {Name = "dty"});
        //    r4.Elements.Add(new Operator {Operation = Operation.AddYears});
        //    r4.Elements.Add(new Operator {Operation = Operation.Age});
        //    r1 = Rules.AddRule(r1);
        //    r2 = Rules.AddRule(r2);
        //    r3 = Rules.AddRule(r3);
        //    r4 = Rules.AddRule(r4);
        //    RuleUsages.Instance.Add(new RuleUsage {
        //        RuleId = r1.UniqueId,
        //        RuleSetId = Obj.UniqueId,
        //        UniqueId = Guid.NewGuid().ToString()
        //    });
        //    RuleUsages.Instance.Add(new RuleUsage {
        //        RuleId = r2.UniqueId,
        //        RuleSetId = Obj.UniqueId,
        //        UniqueId = Guid.NewGuid().ToString()
        //    });
        //    RuleUsages.Instance.Add(new RuleUsage {
        //        RuleId = r3.UniqueId,
        //        RuleSetId = Obj.UniqueId,
        //        UniqueId = Guid.NewGuid().ToString()
        //    });
        //    RuleUsages.Instance.Add(new RuleUsage {
        //        RuleId = r4.UniqueId,
        //        RuleSetId = Obj.UniqueId,
        //        UniqueId = Guid.NewGuid().ToString()
        //    });
        //    var c = new RuleContext();
        //    c.Variables.Add(Variable.Create("dx", 3.0));
        //    c.Variables.Add(Variable.Create("dy", 4.0));
        //    c.Variables.Add(Variable.Create("dtx", DateTime.Now));
        //    c.Variables.Add(Variable.Create("dty", -4));
        //    c.Variables.Add(Variable.Create("sx", "   absdefg"));
        //    c.Variables.Add(Variable.Create("sy", "1234567     "));
        //    c.Variables.Add(Variable.Create("sz", 5));
        //    c.Variables.Add(Variable.Create("sq", 3));
        //    c.Variables.Add(Variable.Create("IsColdCardHolder", true));
        //    c.Variables.Add(Variable.Create("IsSilverCardHolder", false));
        //    c.Variables.Add(Variable.Create("CarryOnBagageKg", 4.5));
        //    c.Variables.Add(Variable.Create("AllowedBagageKg", 5.0));
        //    var res = Obj.Compute(c);
        //    Assert.AreEqual(4, res.Count);
        //    var d = res.Find(x => x.Name == r1.Name) as DoubleVariable;
        //    var b = res.Find(x => x.Name == r2.Name) as BooleanVariable;
        //    var dt = res.Find(x => x.Name == r4.Name) as IntegerVariable;
        //    var s = res.Find(x => x.Name == r3.Name) as StringVariable;
        //    Assert.IsNotNull(d);
        //    Assert.IsNotNull(b);
        //    Assert.IsNotNull(dt);
        //    Assert.IsNotNull(s);
        //    Assert.AreEqual(5.0, d.Value);
        //    Assert.AreEqual("FG1", s.Value);
        //    Assert.AreEqual(true, b.Value);
        //    Assert.AreEqual(4, dt.Value);
        //}

        //[TestMethod] public void EmptyTest() { testSingleton(() => RuleSet.Empty); }

        //[TestMethod] public void GetRuleUsagesTest() {
        //    testBelongings(RuleUsage.Random, () => RuleUsages.Instance,
        //        x => x.RuleSetId = Obj.UniqueId, () => Obj.GetRuleUsages());
        //}

        //[TestMethod] public void GetOverridesTest() {
        //    testBelongings(RuleOverride.Random, () => RuleOverrides.Instance,
        //        x => x.RuleSetId = Obj.UniqueId, () => Obj.GetOverrides());
        //}

        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsTrue(RuleSet.Empty.IsEmpty());
        //    Assert.IsFalse(Obj.IsEmpty());
        //    Assert.IsFalse(new RuleSet().IsEmpty());
        //}

        //[TestMethod] public void RemoveNullRuleTest() {
        //    var c1 = Rules.Instance.Count;
        //    var c2 = RuleUsages.Instance.Count;
        //    var c3 = Obj.GetRuleUsages().Count;
        //    Obj.RemoveRule((Open.Domain.Rule.Rule) null);
        //    Obj.RemoveRule((RuleUsage) null);
        //    Assert.AreEqual(c1, Rules.Instance.Count);
        //    Assert.AreEqual(c2, RuleUsages.Instance.Count);
        //    Assert.AreEqual(c3, Obj.GetRuleUsages().Count);
        //}

        //[TestMethod] public void RemoveRuleTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var u = Obj.AddRule(r);
        //    var c1 = Rules.Instance.Count;
        //    var c2 = RuleUsages.Instance.Count;
        //    var c3 = Obj.GetRuleUsages().Count;
        //    Obj.RemoveRule(r);
        //    Assert.AreEqual(c1, Rules.Instance.Count);
        //    Assert.AreEqual(c2 - 1, RuleUsages.Instance.Count);
        //    Assert.AreEqual(c3 - 1, Obj.GetRuleUsages().Count);
        //    Assert.AreEqual(r, Rules.Find(r.UniqueId));
        //    Assert.AreEqual(RuleUsage.Empty, RuleUsages.Find(u.UniqueId));
        //    Assert.AreEqual(null, Obj.GetRuleUsages().Find(x => x.UniqueId == u.UniqueId));
        //    Assert.AreEqual(r, u.GetRule());
        //}
        //[TestMethod] public void RemoveRuleUsageTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var u = Obj.AddRule(r);
        //    var c1 = Rules.Instance.Count;
        //    var c2 = RuleUsages.Instance.Count;
        //    var c3 = Obj.GetRuleUsages().Count;
        //    Obj.RemoveRule(u);
        //    Assert.AreEqual(c1, Rules.Instance.Count);
        //    Assert.AreEqual(c2 - 1, RuleUsages.Instance.Count);
        //    Assert.AreEqual(c3 - 1, Obj.GetRuleUsages().Count);
        //    Assert.AreEqual(r, Rules.Find(r.UniqueId));
        //    Assert.AreEqual(RuleUsage.Empty, RuleUsages.Find(u.UniqueId));
        //    Assert.AreEqual(null, Obj.GetRuleUsages().Find(x => x.UniqueId == u.UniqueId));
        //    Assert.AreEqual(r, u.GetRule());
        //}
        //[TestMethod] public void RemoveClonedRuleTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var u = Obj.AddRule(r);
        //    var r1 = Common.Clone(r);
        //    var c1 = Rules.Instance.Count;
        //    var c2 = RuleUsages.Instance.Count;
        //    var c3 = Obj.GetRuleUsages().Count;
        //    Obj.RemoveRule(r1);
        //    Assert.AreEqual(c1, Rules.Instance.Count);
        //    Assert.AreEqual(c2 - 1, RuleUsages.Instance.Count);
        //    Assert.AreEqual(c3 - 1, Obj.GetRuleUsages().Count);
        //    Assert.AreEqual(r, Rules.Find(r.UniqueId));
        //    Assert.AreEqual(RuleUsage.Empty, RuleUsages.Find(u.UniqueId));
        //    Assert.AreEqual(null, Obj.GetRuleUsages().Find(x => x.UniqueId == u.UniqueId));
        //    Assert.AreEqual(r, u.GetRule());
        //}
        //[TestMethod] public void RemoveClonedRuleUsageTest() {
        //    var r = Open.Domain.Rule.Rule.Random();
        //    var u = Obj.AddRule(r);
        //    var u1 = Common.Clone(u);
        //    var c1 = Rules.Instance.Count;
        //    var c2 = RuleUsages.Instance.Count;
        //    var c3 = Obj.GetRuleUsages().Count;
        //    Obj.RemoveRule(u1);
        //    Assert.AreEqual(c1, Rules.Instance.Count);
        //    Assert.AreEqual(c2 - 1, RuleUsages.Instance.Count);
        //    Assert.AreEqual(c3 - 1, Obj.GetRuleUsages().Count);
        //    Assert.AreEqual(r, Rules.Find(r.UniqueId));
        //    Assert.AreEqual(RuleUsage.Empty, RuleUsages.Find(u.UniqueId));
        //    Assert.AreEqual(null, Obj.GetRuleUsages().Find(x => x.UniqueId == u.UniqueId));
        //    Assert.AreEqual(r, u.GetRule());
        //}
    }
}
