using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Domain.Rule {
    [TestClass] public class RuleTests //: ClassTests<Open.Domain.Rule.Rule>
    {

        //[TestInitialize] public override void TestInitialize() { base.TestInitialize(); }

        //[TestMethod] public void ConstructorTest() {
        //    var a = new Open.Domain.Rule.Rule().GetType().BaseType;
        //    Assert.AreEqual(a, typeof(NamedItem));
        //}

        //[TestMethod] public void NameInConstructorWillBeUniqueIdTest()
        //{
        //    var o = new Open.Domain.Rule.Rule("Name");
        //    Assert.AreEqual("Name", o.UniqueId);
        //    Assert.AreEqual("Name", o.Name);
        //}

        //protected override Open.Domain.Rule.Rule getRandomObj() { return Open.Domain.Rule.Rule.Random(); }

        //[TestMethod] public void AddTest() {
        //    var r = RuleElement.Random();
        //    Assert.AreEqual(null, Obj.Elements.Find(x => x.Name == r.Name));
        //    Obj.Add(r);
        //    Assert.AreEqual(r, Obj.Elements.Find(x => x.Name == r.Name));
        //}

        //[TestMethod] public void AddRuleElementsTest() {
        //    var r = RuleElements.Random();
        //    var c = Obj.Elements.Count;
        //    Obj.Add(r);
        //    Assert.AreEqual(c + r.Count, Obj.Elements.Count);
        //    foreach (var e in r) { Assert.IsTrue(Obj.Elements.Contains(e)); }
        //}

        //[TestMethod] public void IsSameRuleTest() {
        //    var obj = Open.Domain.Rule.Rule.Random();
        //    Assert.IsFalse(Obj.IsSameContent(obj));
        //    obj.Elements.Clear();
        //    Obj.Elements.Clear();
        //    Assert.IsTrue(Obj.IsSameContent(obj));
        //    var e = RuleElements.Random();
        //    Obj.Add(e);
        //    Assert.IsFalse(Obj.IsSameContent(obj));
        //    obj.Add(e);
        //    Assert.IsTrue(Obj.IsSameContent(obj));
        //}

        //[TestMethod] public void IsThisTest() {
        //    Assert.IsFalse(Obj.IsThis(GetRandom.String()));
        //    Assert.IsTrue(Obj.IsThis(Obj.UniqueId));
        //    Assert.IsTrue(Obj.IsThis(Obj.Name));
        //    Assert.IsTrue(Obj.IsThis(Obj.Elements.ToString()));
        //}

        //[TestMethod] public void ElementsTest() {
        //    testProperty(() => Obj.Elements, x => Obj.Elements = x);
        //}

        //[TestMethod] public void EmptyTest() { testSingleton(() => Open.Domain.Rule.Rule.Empty); }

        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsTrue(Open.Domain.Rule.Rule.Empty.IsEmpty());
        //    Assert.IsFalse(new Open.Domain.Rule.Rule().IsEmpty());
        //    Assert.IsFalse(Obj.IsEmpty());
        //    Assert.IsFalse(Open.Domain.Rule.Rule.Random().IsEmpty());
        //}

        //[TestMethod] public void ComputeTest() { }

        //[TestMethod] public void ErrorMessagesTest() {
        //    void Test(Operand x, string y) {
        //        var o = x as StringVariable;
        //        Assert.IsNotNull(o);
        //        Assert.AreEqual(Obj.Name, o.Name);
        //        Assert.AreEqual(y, o.Value);
        //    }

        //    Test(Obj.Compute(null), RuleError.unknown);
        //    Obj.Elements.Clear();
        //    Test(Obj.Compute(new RuleContext()), RuleError.inRule);
        //    Test(Obj.Compute(new RuleOverride()), RuleError.inRule);
        //}

        //[TestMethod] public void ArithmeticOperationsTest() {
        //    void Test(double x, double y, double r) {
        //        Obj.Elements.Clear();
        //        Obj.Elements.Add(new Operand {Name = "x"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Square});
        //        Obj.Elements.Add(new Operand {Name = "y"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Square});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Add});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Sqrt});
        //        var c = new RuleContext();
        //        c.Variables.Add(Variable.Create("x", x));
        //        c.Variables.Add(Variable.Create("y", y));
        //        var o = Obj.Compute(c) as DoubleVariable;
        //        Assert.IsNotNull(o);
        //        Assert.AreEqual(Obj.Name, o.Name);
        //        Assert.AreEqual(r, o.Value);
        //    }

        //    Test(3.0, 4.0, 5.0);
        //    Test(6.0, 8.0, 10.0);
        //}

        //[TestMethod] public void DateTimeOperationsTest() {
        //    void Test(DateTime x, int y, long r) {
        //        Obj.Elements.Clear();
        //        Obj.Elements.Add(new Operand {Name = "x"});
        //        Obj.Elements.Add(new Operand {Name = "y"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.AddYears});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Age});
        //        var c = new RuleContext();
        //        c.Variables.Add(Variable.Create("x", x));
        //        c.Variables.Add(Variable.Create("y", y));
        //        var o = Obj.Compute(c) as IntegerVariable;
        //        Assert.IsNotNull(o);
        //        Assert.AreEqual(Obj.Name, o.Name);
        //        Assert.AreEqual(r, o.Value);
        //    }

        //    Test(DateTime.Now, -4, 4);
        //    Test(DateTime.Now, -10, 10);
        //}

        //[TestMethod] public void StringOperationsTest() {
        //    void Test(string x, string y, int z, int q, string r) {
        //        Obj.Elements.Clear();
        //        Obj.Elements.Add(new Operand {Name = "x"});
        //        Obj.Elements.Add(new Operand {Name = "y"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Add});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Trim});
        //        Obj.Elements.Add(new Operand {Name = "z"});
        //        Obj.Elements.Add(new Operand {Name = "q"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Substring});
        //        Obj.Elements.Add(new Operator {Operation = Operation.ToUpper});
        //        var c = new RuleContext();
        //        c.Variables.Add(Variable.Create("x", x));
        //        c.Variables.Add(Variable.Create("y", y));
        //        c.Variables.Add(Variable.Create("z", z));
        //        c.Variables.Add(Variable.Create("q", q));
        //        var o = Obj.Compute(c) as StringVariable;
        //        Assert.IsNotNull(o);
        //        Assert.AreEqual(Obj.Name, o.Name);
        //        Assert.AreEqual(r, o.Value);
        //    }

        //    Test("   absdefg", "1234567     ", 5, 3, "FG1");
        //    Test("   absdefg", "1234567     ", 3, 6, "DEFG12");
        //}

        //[TestMethod] public void LogicOperations() {
        //    void Test(bool x, bool y, double z, double q, bool r) {
        //        composeBooleanRule(Obj);
        //        var c = composeBooleanRuleContext(x, y, z, q);
        //        var o = Obj.Compute(c) as BooleanVariable;
        //        Assert.IsNotNull(o);
        //        Assert.AreEqual(Obj.Name, o.Name);
        //        Assert.AreEqual(r, o.Value);
        //    }
        //    Test(true, false, 4.5, 5.0, true);
        //    Test(false, false, 4.5, 5.0, false);
        //    Test(true, false, 5.5, 5.0, false);
        //}
        //internal static RuleContext composeBooleanRuleContext(bool x, bool y, double z, double q) {
        //    var c = new RuleContext();
        //    c.Variables.Add(Variable.Create("IsColdCardHolder", x));
        //    c.Variables.Add(Variable.Create("IsSilverCardHolder", y));
        //    c.Variables.Add(Variable.Create("CarryOnBagageKg", z));
        //    c.Variables.Add(Variable.Create("AllowedBagageKg", q));
        //    return c;
        //}
        //internal static void composeBooleanRule(Open.Domain.Rule.Rule r) {
        //    r.Elements.Clear();
        //    r.Elements.Add(new Operand {Name = "IsColdCardHolder"});
        //    r.Elements.Add(new Operand {Name = "IsSilverCardHolder"});
        //    r.Elements.Add(new Operator {Operation = Operation.Or});
        //    r.Elements.Add(new Operand {Name = "CarryOnBagageKg"});
        //    r.Elements.Add(new Operand {Name = "AllowedBagageKg"});
        //    r.Elements.Add(new Operator {Operation = Operation.Less});
        //    r.Elements.Add(new Operator {Operation = Operation.And});
        //}

        //[TestMethod] public void OverridedTest() {
        //    void Test(RuleOverride z, string r) {
        //        Obj.Elements.Clear();
        //        Obj.Elements.Add(new Operand {Name = "x"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Square});
        //        Obj.Elements.Add(new Operand {Name = "y"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Square});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Add});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Sqrt});
        //        var c = Obj.Compute(z);
        //        var e = c as StringVariable;
        //        Assert.IsNotNull(e);
        //        Assert.AreEqual(Obj.Name, e.Name);
        //        Assert.AreEqual(r, e.Value);
        //    }

        //    var o = new RuleOverride {Variables = null};
        //    Test(o, RuleError.inRule);
        //    var v = StringVariable.Random();
        //    o.Variables.Add(v);
        //    Test(o, RuleError.inRule);
        //    v.Name = Obj.Name;
        //    Test(o, RuleError.notSigned);
        //    o.PartyId = GetRandom.String();
        //    Test(o, RuleError.notSigned);
        //    o.Valid.From = DateTime.Now.AddYears(-1);
        //    Test(o, RuleError.notAuthorized);
        //    for (var i = 0; i < GetRandom.Count(); i++) o.Authorized.Add(new PartySignature());
        //    foreach (var a in o.Authorized) a.PartyId = GetRandom.String();
        //    Test(o, RuleError.notAuthorized);
        //    foreach (var a in o.Authorized) a.Valid.From = DateTime.Now.AddYears(-1);
        //    Test(o, v.Value);
        //    var s = GetRandom.String();
        //    v.Value = s;
        //    Test(o, s);
        //}

        //[TestMethod] public void RuleElementsTest() {
        //    void Test() {
        //        Assert.IsTrue(Obj.IsChanged());
        //        Obj = getRandomObj();
        //        Assert.IsFalse(Obj.IsChanged());
        //    }

        //    Assert.IsFalse(Obj.IsChanged());
        //    Obj.Elements.Clear();
        //    Test();
        //    Obj.Elements.Remove(Obj.Elements[0]);
        //    Test();
        //    Obj.Elements.Add(Operand.Random());
        //    Test();
        //    Obj.Elements.Insert(0, Operand.Random());
        //    Assert.IsTrue(Obj.IsChanged());
        //}

        //[TestMethod] public void IsChangedTest() {
        //    Assert.IsFalse(Obj.IsChanged());
        //    Obj.Name = GetRandom.String();
        //    Assert.IsTrue(Obj.IsChanged());
        //    Obj = getRandomObj();
        //    Assert.IsFalse(Obj.IsChanged());
        //    foreach (var element in Obj.Elements) {
        //        if (element is Operator) continue;
        //        element.Name = GetRandom.String();
        //    }
        //    Assert.IsTrue(Obj.IsChanged());
        //}

        //[TestMethod] public void GetUsagesTest() {
        //    testBelongings(RuleUsage.Random, () => RuleUsages.Instance,
        //        x => x.RuleId = Obj.UniqueId, () => Obj.GetUsages());
        //}

        //[TestMethod] public void ComputeVariable() {
        //    var c = new Calculator();
        //    var v = Variable.Random();
        //    Open.Domain.Rule.Rule.compute(c, v);
        //    Assert.AreEqual(Variable.GetValue(v), c.Get());
        //}

        //[TestMethod] public void ComputeOperator() {
        //    var c = new Calculator();
        //    c.Set(5);
        //    c.Set(10);
        //    var op = new Operator(Operation.Add);
        //    Open.Domain.Rule.Rule.compute(c, op);
        //    Assert.AreEqual(15d, c.Get());
        //}

        //[TestMethod] public void ComputeOperand() {
        //    var c = new Calculator();
        //    var o = Operand.Random();
        //    var v = Variable.Random();
        //    v.Name = o.Name;
        //    Obj.context = RuleContext.Random();
        //    Obj.context.Variables.Add(v);
        //    Obj.compute(c, o);
        //    Assert.AreEqual(Variable.GetValue(v), c.Get());
        //}
    }
}