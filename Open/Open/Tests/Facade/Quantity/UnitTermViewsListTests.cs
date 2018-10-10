//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class UnitTermViewsListTests //: ClassTests<UnitTermViewsList>
    {

        //private static readonly Measure measure = Measure.Empty;

        //protected override UnitTerms getRandomObj()
        //{
        //    return UnitTerms.Random();
        //}

        //[ClassInitialize] public static void ClassInitialize(TestContext c) {
        //    Units.Instance.Clear();
        //    for (var i = 0; i < 100; i++)
        //        Units.Add(GetRandom.String(), Measure.Empty);
        //}

        //[TestMethod] public void AddTest() {
        //    var terms = new UnitTerms();
        //    var u = Units.Add("unit", measure, "u");
        //    var t1 = new UnitTerm(u, 2);
        //    var t2 = new UnitTerm(u, -2);
        //    terms.Add(t1);
        //    Assert.AreEqual(1, terms.Count);
        //    terms.Add(t2);
        //    Assert.AreEqual(0, terms.Count);
        //}

        //[TestMethod] public void InsertTest() {
        //    var terms = new UnitTerms();
        //    var u1 = Units.Add("unit1", measure, "u1");
        //    var u2 = Units.Add("unit2", measure, "u2");
        //    var t1 = new UnitTerm(u1, 2);
        //    var t2 = new UnitTerm(u1, -2);
        //    var t3 = new UnitTerm(u2, -2);
        //    terms.Insert(-1, t1);
        //    Assert.AreEqual(1, terms.Count);
        //    terms.Insert(-1, t3);
        //    Assert.AreEqual(2, terms.Count);
        //    terms.Insert(100, t2);
        //    Assert.AreEqual(1, terms.Count);
        //}

        //[TestMethod] public void AddRangeTest() {
        //    Obj = create();
        //    var terms = create();
        //    var u1 = Units.Add("unit3", measure, "u3");
        //    var u2 = Units.Add("unit4", measure, "u4");
        //    terms.Add(new UnitTerm(u1, 2));
        //    terms.Add(new UnitTerm(u1, -2));
        //    terms.Add(new UnitTerm(u2, -2));
        //    Obj.AddRange(terms);
        //    Assert.AreEqual("u1^4*u2^-2*u4^-2", Obj.Formula());
        //}

        //[TestMethod] public void FormulaTest() { }

        //private static UnitTerms create() {
        //    var m1 = Measures.Add("measure1", "m1");
        //    var m2 = Measures.Add("measure2", "m2");
        //    var u1 = Units.Add("unit1", m1, "u1");
        //    var u2 = Units.Add("unit2", m2, "u2");
        //    var t1 = new UnitTerm(u1, 2);
        //    var t2 = new UnitTerm(u2, -1);
        //    var l = new List<UnitTerm> {t1, t2};
        //    return new UnitTerms(l);
        //}

        //[TestMethod] public void PowerTest() {
        //    var t = create().Power(3);
        //    Assert.AreEqual("unit1^6*unit2^-3", t.Formula(true));
        //    Assert.AreEqual("u1^6*u2^-3", t.Formula());
        //}

        //[TestMethod] public void InverseTest() {
        //    var t = create().Inverse();
        //    Assert.AreEqual("unit1^-2*unit2", t.Formula(true));
        //    Assert.AreEqual("u1^-2*u2", t.Formula());
        //}

        //[TestMethod] public void MultiplyTest() {
        //    void Test(Unit x, string y, string z) {
        //        var t = create();
        //        t = t.Multiply(x);
        //        Assert.AreEqual(y, t.Formula(true));
        //        Assert.AreEqual(z, t.Formula());
        //    }

        //    var m3 = MeasureBase.Random();
        //    var u3 = Units.Add("unit3", m3, "u3");
        //    Test(u3, "unit1^2*unit2^-1*unit3", "u1^2*u2^-1*u3");
        //    u3 = new UnitBase();
        //    Test(u3, "unit1^2*unit2^-1", "u1^2*u2^-1");
        //    u3 = Units.Add(GetRandom.String(), create(), measure);
        //    Test(u3, "unit1^4*unit2^-2", "u1^4*u2^-2");
        //}

        //[TestMethod] public void DivideTest() {
        //    void Test(Unit x, string y, string z) {
        //        var t = create();
        //        t = t.Divide(x);
        //        Assert.AreEqual(y, t.Formula(true));
        //        Assert.AreEqual(z, t.Formula());
        //    }

        //    var u3 = Units.Add("unit3", measure, "u3");
        //    Test(u3, "unit1^2*unit2^-1*unit3^-1", "u1^2*u2^-1*u3^-1");
        //    u3 = new UnitBase();
        //    Test(u3, "unit1^2*unit2^-1", "u1^2*u2^-1");
        //    u3 = Units.Add(GetRandom.String(), create(), measure);
        //    Test(u3, string.Empty, string.Empty);
        //}

        //[TestMethod] public void EmptyTest() {
        //    testSingleton(() => UnitTerms.Empty);
        //}

        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsTrue(UnitTerms.Empty.IsEmpty());
        //    Assert.IsFalse(new UnitTerms().IsEmpty());
        //    Assert.IsFalse(Obj.IsEmpty());
        //}

    }
}
