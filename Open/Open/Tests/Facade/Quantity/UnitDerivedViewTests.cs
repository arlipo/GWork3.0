//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class UnitDerivedViewTests //: ClassTests<UnitDerivedView>
    {
        //private SystemOfUnits systemOfUnits;
        //private MeasureBase measure1;
        //private MeasureBase measure2;
        //private MeasureBase measure3;

        //protected override UnitDerived getRandomObj() { return UnitDerived.Random(); }

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    Measures.Instance.Clear();
        //    SystemsOfUnits.Instance.Clear();
        //    Units.Instance.Clear();
        //    systemOfUnits = SystemOfUnits.Random();
        //    measure1 = MeasureBase.Random();
        //    measure2 = MeasureBase.Random();
        //    measure3 = MeasureBase.Random();
        //}

        //private UnitDerived create() {
        //    var u1 = Units.Add("unit1", measure1, "u1", null, systemOfUnits);
        //    var u2 = Units.Add("unit2", measure2, "u2", null, systemOfUnits);
        //    var t1 = new UnitTerm(u1, 2);
        //    var t2 = new UnitTerm(u2, -1);
        //    var l = new List<UnitTerm> {t1, t2};
        //    var terms = new UnitTerms(l);
        //    return new UnitDerived("unit3", terms, measure3, "u3", null, systemOfUnits);
        //}

        //[TestMethod] public void PowerTest() {
        //    void Test(Unit x, string y, string z, string n) {
        //        Assert.IsNotNull(x);
        //        Assert.IsInstanceOfType(x, typeof(UnitDerived));
        //        Assert.AreEqual(y, x.Formula(true));
        //        Assert.AreEqual(z, x.Formula());
        //        Assert.AreEqual(n ?? x.Formula(true), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    var t = create();
        //    Test(t.Power(2), "unit1^4*unit2^-2", "u1^4*u2^-2", null);
        //    Test(t.Power(-2, name), "unit1^-4*unit2^2", "u1^-4*u2^2", name);
        //}

        //[TestMethod] public void InverseTest() {
        //    void Test(Unit x, string y, string z, string n) {
        //        Assert.IsNotNull(x);
        //        Assert.IsInstanceOfType(x, typeof(UnitDerived));
        //        Assert.AreEqual(y, x.Formula(true));
        //        Assert.AreEqual(z, x.Formula());
        //        Assert.AreEqual(n ?? x.Formula(true), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    var t = create().Inverse();
        //    Test(t, "unit1^-2*unit2", "u1^-2*u2", null);
        //    Test(t.Inverse(name), "unit1^2*unit2^-1", "u1^2*u2^-1", name);
        //}

        //[TestMethod] public void MultiplyTest() {
        //    void Test(Unit x, string y, string z, string n) {
        //        Assert.IsNotNull(x);
        //        Assert.IsInstanceOfType(x, typeof(UnitDerived));
        //        Assert.AreEqual(y, x.Formula(true));
        //        Assert.AreEqual(z, x.Formula());
        //        Assert.AreEqual(n ?? x.Formula(true), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    var t = create().Multiply(create());
        //    Test(t, "unit1^4*unit2^-2", "u1^4*u2^-2", null);
        //    Test(t.Multiply(t, name), "unit1^8*unit2^-4", "u1^8*u2^-4", name);
        //}

        //[TestMethod] public void DivideTest() {
        //    void Test(Unit x, string y, string z, string n, Type q) {
        //        Assert.IsNotNull(x);
        //        Assert.IsInstanceOfType(x, q);
        //        Assert.AreEqual(y, x.Formula(true));
        //        Assert.AreEqual(z, x.Formula());
        //        Assert.AreEqual(n ?? x.Formula(true), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    var t = create().Multiply(create());
        //    Test(t.Divide(create()), "unit1^2*unit2^-1", "u1^2*u2^-1", null, typeof(UnitDerived));
        //    Test(t.Divide(t, name), "", "", "", typeof(UnitBase));
        //}

        //[TestMethod] public void TermsTest() { testProperty(() => Obj.Terms, x => Obj.Terms = x); }

        //[TestMethod] public void ToBaseTest() {
        //    void Test(UnitDerived x, double y, double z) {
        //        Obj = x;
        //        var d1 = y * z;
        //        var d2 = Obj.ToBase(y);
        //        Assert.AreEqual(d1, d2);
        //    }

        //    const double d = 1000;
        //    var u1 = Units.Add("unit1", 0.1, Measure.Empty);
        //    var u2 = Units.Add("unit2", 100, Measure.Empty);
        //    var t1 = new UnitTerm(u1, 2);
        //    var t2 = new UnitTerm(u2, -1);
        //    var terms1 = new UnitTerms {t1};
        //    var terms2 = new UnitTerms {t2};
        //    var terms3 = new UnitTerms {t1, t2};
        //    Test(new UnitDerived(null, terms1, Measure.Empty), d, 0.01);
        //    Test(new UnitDerived(null, terms2, Measure.Empty), d, 0.01);
        //    Test(new UnitDerived(null, terms3, Measure.Empty), d, 0.0001);
        //}

        //[TestMethod] public void FromBaseTest() {
        //    void Test(UnitDerived x, double y, double z) {
        //        Obj = x;
        //        var d1 = y * z;
        //        var d2 = Obj.FromBase(y);
        //        Assert.AreEqual(d1, d2);
        //    }

        //    const double d = 1000;
        //    var u1 = Units.Add("unit1", 0.1, Measure.Empty);
        //    var u2 = Units.Add("unit2", 100, Measure.Empty);
        //    var t1 = new UnitTerm(u1, 2);
        //    var t2 = new UnitTerm(u2, -1);
        //    var terms1 = new UnitTerms {t1};
        //    var terms2 = new UnitTerms {t2};
        //    var terms3 = new UnitTerms {t1, t2};
        //    Test(new UnitDerived(null, terms1, Measure.Empty), d, 100);
        //    Test(new UnitDerived(null, terms2, Measure.Empty), d, 100);
        //    Test(new UnitDerived(null, terms3, Measure.Empty), d, 10000);
        //}

        //[TestMethod] public void FormulaTest() {
        //    Assert.AreEqual(Obj.Terms.Formula(), Obj.Formula());
        //    Assert.AreEqual(Obj.Terms.Formula(true), Obj.Formula(true));
        //}

    }
}
