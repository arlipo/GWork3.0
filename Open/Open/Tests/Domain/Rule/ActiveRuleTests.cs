using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Domain.Rule {
    [TestClass] public class ActiveRuleTests //: ClassTests<ActiveRule>
    {
        //protected override ActiveRule getRandomObj() { return ActiveRule.Random(); }
        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsTrue(ActiveRule.Empty.IsEmpty());
        //    Assert.IsFalse(Obj.IsEmpty());
        //    Assert.IsFalse(new ActiveRule().IsEmpty());
        //}
        //[TestMethod] public void CalculateTest() { }
        //[TestMethod]
        //public void LogicOperations()
        //{
        //    void TestTrue(bool x, bool y, double a, double b, double c, double d, double r) {
        //        Obj.Elements.Clear();
        //        Obj.Elements.Add(new Operand {Name = "IsColdCardHolder"});
        //        Obj.Elements.Add(new Operand {Name = "IsSilverCardHolder"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Or});
        //        Obj.Elements.Add(new Operand {Name = "CarryOnBagageKg"});
        //        Obj.Elements.Add(new Operand {Name = "AllowedBagageKg"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Less});
        //        Obj.Elements.Add(new Operator {Operation = Operation.And});
        //        Obj.Script.Clear();
        //        Obj.Script.Add(new Operand {Name = "x"});
        //        Obj.Script.Add(new Operator {Operation = Operation.Square});
        //        Obj.Script.Add(new Operand {Name = "y"});
        //        Obj.Script.Add(new Operator {Operation = Operation.Square});
        //        Obj.Script.Add(new Operator {Operation = Operation.Add});
        //        Obj.Script.Add(new Operator {Operation = Operation.Sqrt});
        //        var cx = new RuleContext();
        //        cx.Variables.Add(Variable.Create("IsColdCardHolder", x));
        //        cx.Variables.Add(Variable.Create("IsSilverCardHolder", y));
        //        cx.Variables.Add(Variable.Create("CarryOnBagageKg", a));
        //        cx.Variables.Add(Variable.Create("AllowedBagageKg", b));
        //        cx.Variables.Add(Variable.Create("x", c));
        //        cx.Variables.Add(Variable.Create("y", d));
        //        var o = Obj.Compute(cx) as DoubleVariable;
        //        Assert.IsNotNull(o);
        //        Assert.AreEqual(Obj.Name, o.Name);
        //        Assert.AreEqual(r, o.Value);
        //    }

        //    void TestFalse(bool x, bool y, double z, double q, bool r) {
        //        Obj.Elements.Clear();
        //        Obj.Elements.Add(new Operand {Name = "IsColdCardHolder"});
        //        Obj.Elements.Add(new Operand {Name = "IsSilverCardHolder"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Or});
        //        Obj.Elements.Add(new Operand {Name = "CarryOnBagageKg"});
        //        Obj.Elements.Add(new Operand {Name = "AllowedBagageKg"});
        //        Obj.Elements.Add(new Operator {Operation = Operation.Less});
        //        Obj.Elements.Add(new Operator {Operation = Operation.And});
        //        var c = new RuleContext();
        //        c.Variables.Add(Variable.Create("IsColdCardHolder", x));
        //        c.Variables.Add(Variable.Create("IsSilverCardHolder", y));
        //        c.Variables.Add(Variable.Create("CarryOnBagageKg", z));
        //        c.Variables.Add(Variable.Create("AllowedBagageKg", q));
        //        var o = Obj.Compute(c) as BooleanVariable;
        //        Assert.IsNotNull(o);
        //        Assert.AreEqual(Obj.Name, o.Name);
        //        Assert.AreEqual(r, o.Value);
        //    }

        //    TestFalse(false, false, 4.5, 5.0, false);
        //    TestFalse(true, false, 5.5, 5.0, false);
        //    TestTrue(true, false, 4.5, 5.0, 3.0, 4.0, 5.0);
        //    TestTrue(true, false, 4.5, 5.0, 6.0, 8.0, 10.0);
        //}
        //[TestMethod]
        //public void ScriptTest()
        //{
        //    testProperty(()=> Obj.Script, x=>Obj.Script = x);
        //}
        //[TestMethod]
        //public void EmptyTest()
        //{
        //    testSingleton(()=>ActiveRule.Empty);
        //}

    }
}
