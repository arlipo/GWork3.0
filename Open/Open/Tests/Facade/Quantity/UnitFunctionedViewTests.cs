//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class UnitFunctionedViewTests //: ClassTests<UnitFunctionedView>
    {

        //[TestMethod] public void FromBaseRuleIdTest() {
        //    testProperty(() => Obj.FromBaseRuleId, x => Obj.FromBaseRuleId = x);
        //}

        //[TestMethod] public void FromBaseTest() {
        //    var rule = new RuleElements {
        //        new Operand(UnitFunctioned.variableToken),
        //        new DoubleVariable("y", 9.0),
        //        new DoubleVariable("y", 5.0),
        //        new Operator(Operation.Divide),
        //        new Operator(Operation.Multiply),
        //        new DoubleVariable("x", 32.0),
        //        new Operator(Operation.Add),
        //    };
        //    var v = new Open.Domain.Rule.Rule("Celsius to Fahrenheit", rule);
        //    Obj.FromBaseRuleId = v.Name;
        //    Rules.Instance.Add(v);
        //    Assert.AreEqual(68, Obj.FromBase(20));
        //}

        //[TestMethod] public void GetFromBaseRuleTest() {
        //    testGetRule(() => Obj.GetFromBaseRule(), Obj.FromBaseRuleId);
        //}

        //[TestMethod] public void GetToBaseRuleTest() {
        //    testGetRule(() => Obj.GetToBaseRule(), Obj.ToBaseRuleId);
        //}

        //[TestMethod] public void ToBaseRuleIdTest() {
        //    testProperty(() => Obj.ToBaseRuleId, x => Obj.ToBaseRuleId = x);
        //}

        //[TestMethod] public void ToBaseTest() {
        //    var rule = new RuleElements {
        //        new Operand(UnitFunctioned.variableToken),
        //        new DoubleVariable("x", 32.0),
        //        new Operator(Operation.Subtract),
        //        new DoubleVariable("y", 5.0),
        //        new DoubleVariable("y", 9.0),
        //        new Operator(Operation.Divide),
        //        new Operator(Operation.Multiply)
        //    };
        //    var v = new Open.Domain.Rule.Rule("Fahrenheit to Celsius", rule);
        //    Obj.ToBaseRuleId = v.Name;
        //    Rules.Instance.Add(v);
        //    Assert.AreEqual(20, Obj.ToBase(68));
        //}

        //protected override UnitFunctioned getRandomObj() { return UnitFunctioned.Random(); }

        //private static void testGetRule(Func<Open.Domain.Rule.Rule> f, string s) {
        //    var r = f();
        //    Assert.IsNotNull(r);
        //    Assert.AreEqual(string.Empty, r.Name);
        //    Assert.AreNotEqual(string.Empty, s);
        //    r = Open.Domain.Rule.Rule.Random();
        //    r.Name = s;
        //    Rules.Instance.Add(r);
        //    r = f();
        //    Assert.IsNotNull(r);
        //    Assert.AreNotEqual(string.Empty, r.Name);
        //    Assert.AreEqual(s, r.Name);
        //}
    }
}

