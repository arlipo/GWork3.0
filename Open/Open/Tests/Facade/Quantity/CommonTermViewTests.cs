using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class CommonTermViewTests : ClassTests<CommonTermView<MetricsView>> {

        //private class testClass : CommonTerm<Metric> {
        //    public testClass() : this(null) { }
        //    public testClass(Metric m, int power = 0) : base(m, power) { }
        //    protected override Metric getMetric() { return null; }
        //    public static testClass Random() {
        //        var t = new testClass();
        //        t.setRandomValues();
        //        return t;
        //    }
        //}
        //private CommonTerm<Metric> obj;

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    obj = testClass.Random();
        //}

        //[TestMethod] public void ConstructorTest() {
        //    Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(Archetype));
        //}

        //[TestMethod] public void CreateTest() {
        //    obj = new testClass();
        //    Assert.AreEqual(0, obj.Power);
        //    Assert.AreEqual("", obj.Formula());
        //    Assert.AreEqual("", obj.Formula(true));
        //}

        //[TestMethod] public void CreateWithMetricAndPowerOneTest() {
        //    var m = new MeasureBase("m");
        //    obj = new testClass(m, 1);
        //    Assert.AreEqual(1, obj.Power);
        //    Assert.AreEqual("m", obj.Formula());
        //    Assert.AreEqual("m", obj.Formula(true));
        //}

        //[TestMethod] public void CreateWithMetricAndPowerTest() {
        //    var m = new MeasureBase("m");
        //    obj = new testClass(m, 3);
        //    Assert.AreEqual(3, obj.Power);
        //    Assert.AreEqual("m^3", obj.Formula());
        //    Assert.AreEqual("m^3", obj.Formula(true));
        //}

        //[TestMethod] public void CreateWithMetricTest() {
        //    var m = new MeasureBase("m");
        //    obj = new testClass(m);
        //    Assert.AreEqual(0, obj.Power);
        //    Assert.AreEqual("", obj.Formula());
        //    Assert.AreEqual("", obj.Formula(true));
        //}

        //[TestMethod] public void FormulaTest() { }

        //[TestMethod] public void GetFormulaTest() {
        //    Assert.AreEqual("", obj.getFormula(null));
        //    obj.power = 0;
        //    Assert.AreEqual("", obj.getFormula("name"));
        //    obj.power = 1;
        //    Assert.AreEqual("name", obj.getFormula("name"));
        //    obj.power = 2;
        //    Assert.AreEqual("name^2", obj.getFormula("name"));
        //}

        //[TestMethod] public void GetNameTest() {
        //    var m = new MeasureBase("name", "symbol");
        //    Assert.AreEqual("name", obj.getName(m, true));
        //    Assert.AreEqual("symbol", obj.getName(m, false));
        //    Assert.AreEqual(obj.metric, obj.getName(null, false));
        //}

        //[TestMethod] public void PowerTest() {
        //    testProperty(() => obj.Power, x => obj.Power = x);
        //}

        //[TestMethod] public void ToPowerTest() {
        //    var p1 = GetRandom.Int8();
        //    var p2 = GetRandom.Int8();
        //    obj.Power = p1;
        //    obj.ToPower(p2);
        //    Assert.AreEqual(p1 + p2, obj.Power);
        //}

    }
}

