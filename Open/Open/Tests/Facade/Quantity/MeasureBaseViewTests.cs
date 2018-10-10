//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class MeasureBaseViewTests //: ClassTests<MeasureBaseView>
    {

        //protected string elementPattern => "({0})";
        //protected string multiplyPattern => "{0}*{1}";
        //protected string powerPattern => "{0}^{1}";

        //protected override MeasureBase getRandomObj() { return MeasureBase.Random(); }

        //[ClassInitialize] public static void ClassInitialize(TestContext c) {
        //    Measures.Instance.Clear();
        //    for (var i = 0; i < 100; i++) Measures.Add(GetRandom.String());
        //}

        //private static Measure createMeasureDerived() {
        //    var m1 = Measures.Add("measure1", "m1");
        //    var m2 = Measures.Add("measure2", "m2");
        //    var t1 = new MeasureTerm(m1, 2);
        //    var t2 = new MeasureTerm(m2, -1);
        //    var l = new List<MeasureTerm> {t1, t2};
        //    var terms = new MeasureTerms(l);
        //    return new MeasureDerived(terms, "measure3", "m3");
        //}

        //[TestMethod] public void CreateTest() {
        //    var name = GetRandom.String(3, 5);
        //    var m = Measures.Add(name);
        //    Assert.IsInstanceOfType(m, typeof(MeasureBase));
        //    Assert.IsNotInstanceOfType(m, typeof(MeasureDerived));
        //    Assert.AreEqual(m, Measures.Find(m.UniqueId));
        //    Assert.AreEqual(m, Measures.Instance.Find(o => o.Name == name));
        //}

        //[TestMethod] public void FormulaTest() {
        //    Assert.AreEqual(Obj.Name, Obj.Formula(true));
        //    Assert.AreEqual(Obj.Symbol, Obj.Formula());
        //    Obj.Symbol = string.Empty;
        //    Obj.Name = string.Empty;
        //    Assert.AreEqual(string.Empty, Obj.Formula(true));
        //    Assert.AreEqual(string.Empty, Obj.Formula());
        //}

        //[TestMethod] public void IsSameFormulaTest() {
        //    var a = createMeasureDerived();
        //    var b = createMeasureDerived();
        //    Assert.IsTrue(a.IsSameFormula(b));
        //    Assert.IsFalse(Obj.IsSameFormula(a));
        //    Assert.IsTrue(new MeasureBase().IsSameFormula(new MeasureBase()));
        //    Assert.IsFalse(new MeasureBase().IsSameFormula(null));
        //    var t = MeasureTerms.Random();
        //    Assert.IsTrue(new MeasureDerived(t).IsSameFormula(new MeasureDerived(t)));
        //}

        //[TestMethod] public void IsThisTest() {
        //    var a = createMeasureDerived();
        //    Assert.IsTrue(a.IsThis(a.Name));
        //    Assert.IsTrue(a.IsThis(a.Symbol));
        //    Assert.IsTrue(a.IsThis(a.Formula()));
        //    Assert.IsTrue(a.IsThis(a.Formula(true)));
        //    Assert.IsFalse(a.IsThis(null));
        //    Assert.IsFalse(a.IsThis("  "));
        //    Assert.IsFalse(a.IsThis(GetRandom.String()));
        //}

        //[TestMethod] public void GetUnitsTest() {
        //    Measures.Instance.Add(Obj);
        //    var u = Units.Random();
        //    var v = Units.Random();
        //    foreach (var e in u) e.Measure = Obj.Name;
        //    Units.Instance.AddRange(u);
        //    Units.Instance.AddRange(v);
        //    var units = Obj.GetUnits();
        //    Assert.IsNotNull(units);
        //    Assert.AreEqual(u.Count, units.Count);
        //}

        //[TestMethod] public void IsValidQuantityTest() {
        //    var u = UnitBase.Random();
        //    var q = new Open.Domain.Quantity.Quantity(u, GetRandom.Double());
        //    Measures.Instance.Add(Obj);
        //    Assert.IsFalse(Obj.IsValidQuantity(q));
        //    GetUnitsTest();
        //    u.Measure = Obj.Name;
        //    Units.Instance.Add(u);
        //    Assert.IsTrue(Obj.IsValidQuantity(q));
        //}

        //[TestMethod] public void CreateEmptyTest() {
        //    var x = new MeasureBase();
        //    Assert.AreNotEqual("", x.UniqueId);
        //    Assert.AreEqual("", x.Name);
        //    Assert.AreEqual("", x.Symbol);
        //    Assert.AreEqual("", x.Definition);
        //    Assert.AreEqual("", x.Formula());
        //    Assert.AreEqual("", x.Formula(true));
        //}

        //[TestMethod] public void CreateWithNameTest() {
        //    var x = new MeasureBase("name");
        //    Assert.AreEqual("name", x.UniqueId);
        //    Assert.AreEqual("name", x.Name);
        //    Assert.AreEqual("name", x.Symbol);
        //    Assert.AreEqual("name", x.Definition);
        //    Assert.AreEqual("name", x.Formula());
        //    Assert.AreEqual("name", x.Formula(true));
        //}

        //[TestMethod] public void CreateWithNameAndSymbolTest() {
        //    var x = new MeasureBase("name", "symbol");
        //    Assert.AreEqual("name", x.UniqueId);
        //    Assert.AreEqual("name", x.Name);
        //    Assert.AreEqual("symbol", x.Symbol);
        //    Assert.AreEqual("name", x.Definition);
        //    Assert.AreEqual("symbol", x.Formula());
        //    Assert.AreEqual("name", x.Formula(true));
        //}

        //[TestMethod] public void CreateWithAllTest() {
        //    var x = new MeasureBase("name", "symbol", "definition");
        //    Assert.AreEqual("name", x.UniqueId);
        //    Assert.AreEqual("name", x.Name);
        //    Assert.AreEqual("symbol", x.Symbol);
        //    Assert.AreEqual("definition", x.Definition);
        //    Assert.AreEqual("symbol", x.Formula());
        //    Assert.AreEqual("name", x.Formula(true));
        //}

        //[TestMethod] public void MultiplyWithSameBaseTest() {
        //    var x = Measures.Add("n");
        //    var y = x.Multiply(x);
        //    Assert.AreEqual("n^2", y.UniqueId);
        //    Assert.AreEqual("n^2", y.Name);
        //    Assert.AreEqual("n^2", y.Symbol);
        //    Assert.AreEqual("n^2", y.Definition);
        //    Assert.AreEqual("n^2", y.Formula());
        //    Assert.AreEqual("n^2", y.Formula(true));
        //}

        //[TestMethod] public void DivideWithSameBaseTest() {
        //    var x = new MeasureBase("n");
        //    var y = x.Divide(x);
        //    Assert.IsTrue(y.IsEmpty());
        //    Assert.AreEqual("", y.UniqueId);
        //    Assert.AreEqual("", y.Name);
        //    Assert.AreEqual("", y.Symbol);
        //    Assert.AreEqual("", y.Definition);
        //    Assert.AreEqual("", y.Formula());
        //    Assert.AreEqual("", y.Formula(true));
        //}

        //[TestMethod] public void MultiplyTest() {
        //    var x = Measures.Add(GetRandom.String(3, 5));
        //    var y = Measures.Add(GetRandom.String(3, 5));
        //    var z = x.Multiply(y);
        //    var n = StringValue.IsLess(x.Name, y.Name)
        //        ? x.Name + "*" + y.Name
        //        : y.Name + "*" + x.Name;
        //    Assert.AreEqual(n, z.UniqueId);
        //    Assert.AreEqual(n, z.Name);
        //    Assert.AreEqual(n, z.Symbol);
        //    Assert.AreEqual(n, z.Definition);
        //    Assert.AreEqual(n, z.Formula());
        //    Assert.AreEqual(n, z.Formula(true));
        //}
    }
}
