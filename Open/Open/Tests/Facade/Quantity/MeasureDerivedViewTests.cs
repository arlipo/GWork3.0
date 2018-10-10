//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class MeasureDerivedViewTests //: ClassTests<MeasureDerivedView>
    {

        //protected override MeasureDerived getRandomObj() {
        //    return  MeasureDerived.Random();
        //}

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    for (var i = 0; i < GetRandom.Count(); i++)
        //        Measures.Add(GetRandom.String());
        //    Measures.Instance.Add(Obj);
        //    foreach (var t in Obj.Terms) { Measures.Add(t.Measure); }
        //}

        //[TestCleanup] public override void TestCleanup() {
        //    base.TestCleanup();
        //    Measures.Instance.Clear();
        //}

        //[TestMethod] public void CreateMeasureDerivedTest() {
        //    var terms = MeasureTerms.Random();
        //    var m = Measures.Add(terms);
        //    Assert.IsInstanceOfType(m, typeof(MeasureDerived));
        //    Assert.AreEqual(m, Measures.Find(m.UniqueId));
        //    Assert.AreEqual(m, Measures.Find(m.Name));
        //    Assert.AreEqual(m, Measures.Find(m.Symbol));
        //    Assert.AreEqual(m, Measures.Find(m.Formula()));
        //    Assert.AreEqual(m, Measures.Find(m.Formula(true)));
        //}

        //private static MeasureDerived create() {
        //    var m1 = Measures.Add("measure1", "m1");
        //    var m2 = Measures.Add("measure2", "m2");
        //    var t1 = new MeasureTerm(m1, 2);
        //    var t2 = new MeasureTerm(m2, -1);
        //    var l = new List<MeasureTerm> {t1, t2};
        //    var terms = new MeasureTerms(l);
        //    return new MeasureDerived(terms, "measure3", "m3");
        //}

        //[TestMethod] public void DivideTest() {
        //    Measures.Instance.Clear();

        //    void Test(Measure x, string y, string z, string n, bool q) {
        //        Assert.IsNotNull(x);
        //        if (q) Assert.IsNotInstanceOfType(x, typeof(MeasureDerived));
        //        else Assert.IsInstanceOfType(x, typeof(MeasureDerived));
        //        Assert.AreEqual(y, x.Formula(true));
        //        Assert.AreEqual(z, x.Formula());
        //        Assert.AreEqual(n ?? x.Formula(), x.Name);
        //    }

        //    var t = create().Multiply(create());
        //    Test(t.Divide(create()), "measure1^2*measure2^-1",
        //        "m1^2*m2^-1", null, false);
        //    Test(t.Divide(t), "", "", "", true);
        //}

        //[TestMethod] public void FormulaTest() {
        //    Obj.Name = string.Empty;
        //    Obj.Symbol = string.Empty;
        //    Assert.AreEqual(Obj.Terms.Formula(true), Obj.Formula(true));
        //    Assert.AreEqual(Obj.Terms.Formula(), Obj.Formula());
        //    Obj.Name = GetRandom.String();
        //    Obj.Symbol = GetRandom.String();
        //    Assert.AreEqual(Obj.Terms.Formula(true), Obj.Formula(true));
        //    Assert.AreEqual(Obj.Terms.Formula(), Obj.Formula());
        //}

        //[TestMethod] public void InverseTest() {
        //    void Test(Measure x, string y, string z, string n) {
        //        Assert.IsInstanceOfType(x, typeof(MeasureDerived));
        //        Assert.AreEqual(y, x.Formula(true));
        //        Assert.AreEqual(z, x.Formula());
        //        Assert.AreEqual(n ?? x.Formula(), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    var t = create().Inverse();
        //    Test(t, "measure1^-2*measure2", "m1^-2*m2", null);
        //    Test(t.Inverse(name), "measure1^2*measure2^-1", "m1^2*m2^-1",
        //        name);
        //}

        //[TestMethod] public void MultiplyTest() {
        //    void Test(Measure x, string y, string z, string n) {
        //        Assert.IsInstanceOfType(x, typeof(MeasureDerived));
        //        Assert.AreEqual(y, x.Formula(true));
        //        Assert.AreEqual(z, x.Formula());
        //        Assert.AreEqual(n ?? x.Formula(), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    var t = create().Multiply(create());
        //    Test(t, "measure1^4*measure2^-2", "m1^4*m2^-2", null);
        //    Test(t.Multiply(t, name), "measure1^8*measure2^-4",
        //        "m1^8*m2^-4", name);
        //}

        //[TestMethod] public void PowerTest() {
        //    void Test(Measure x, string y, string z, string n) {
        //        Assert.AreEqual(y, x.Formula(true));
        //        Assert.AreEqual(z, x.Formula());
        //        Assert.AreEqual(n ?? x.Formula(), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    var t = create();
        //    Test(t.Power(2), "measure1^4*measure2^-2", "m1^4*m2^-2",
        //        null);
        //    Test(t.Power(-2, name), "measure1^-4*measure2^2",
        //        "m1^-4*m2^2", name);
        //}

        //[TestMethod] public void TermsTest() {
        //    Obj = new MeasureDerived();
        //    testProperty(() => Obj.Terms, x => Obj.Terms = x);
        //    Assert.IsNotNull(Obj.Terms);
        //    Obj.Terms = null;
        //    Assert.IsNotNull(Obj.Terms);
        //}
    }
}
