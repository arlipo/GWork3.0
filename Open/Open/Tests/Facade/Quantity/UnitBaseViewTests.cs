//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class UnitBaseViewTests //: ClassTests<UnitBaseView>
    {

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    for (var i = 0; i < GetRandom.Count(); i++)
        //        Units.Add(GetRandom.String(), MeasureBase.Random());
        //    Units.Instance.Add(Obj);
        //    SystemsOfUnits.Add(Obj.SystemOfUnits);
        //    Measures.Add(Obj.Measure);
        //}

        //[TestCleanup] public override void TestCleanup() {
        //    base.TestCleanup();
        //    Units.Instance.Clear();
        //}

        //protected string elementPattern => "{0}";

        //protected string multiplyPattern => "{0}*{1}";

        //protected string powerPattern => "{0}^{1}";

        //protected override UnitBase getRandomObj() { return UnitBase.Random(); }

        //[TestMethod] public void DivideTest() {
        //    var u1 = UnitBase.Random();
        //    var u2 = UnitBase.Random();
        //    Units.Instance.Add(u1);
        //    Units.Instance.Add(u2);
        //    var l = new List<string> {u1.Name, u2.Name};
        //    l.Sort();
        //    var o1 = l[0] == u1.Name ? u1 : u2;
        //    var o2 = l[1] == u2.Name ? u2 : u1;

        //    void Test(Unit x, string y) {
        //        Assert.AreEqual(y ?? x.Formula(true), x.Name);
        //        var s1 = o1.Name;
        //        s1 = string.Format(elementPattern, s1);
        //        var s2 = string.Format(powerPattern, o2.Name, -1);
        //        s2 = string.Format(elementPattern, s2);
        //        var s = string.Format(multiplyPattern, s1, s2);
        //        Assert.AreEqual(s, x.Formula(true));
        //    }
        //    var name = GetRandom.String(5, 10);
        //    Test(o1.Divide(o2), null);
        //    Test(o1.Divide(o2, name), name);
        //}

        //[TestMethod] public void EmptyTest() {
        //    testSingleton(() => Unit.Empty);
        //}

        //[TestMethod] public void FromBaseTest() {
        //    var d = GetRandom.Double();
        //    Assert.AreEqual(d, Obj.FromBase(d));
        //}

        //[TestMethod] public void GetMeasureTest() {
        //    Measures.Instance.Clear();
        //    Assert.AreEqual(string.Empty, Obj.GetMeasure().Name);
        //    Assert.IsTrue(Obj.GetMeasure().IsEmpty());
        //    Measures.Add(Obj.Measure);
        //    Assert.AreEqual(Obj.Measure, Obj.GetMeasure().Name);
        //}

        //[TestMethod] public void GetSystemOfUnitsTest() {
        //    SystemsOfUnits.Instance.Clear();
        //    Assert.AreEqual(string.Empty, Obj.GetSystemOfUnits.Name);
        //    Assert.IsTrue(Obj.GetSystemOfUnits.IsEmpty());
        //    SystemsOfUnits.Add(Obj.SystemOfUnits);
        //    Assert.AreEqual(Obj.SystemOfUnits, Obj.GetSystemOfUnits.Name);
        //}

        //[TestMethod] public void InverseTest() {
        //    void Test(Unit x, string y) {
        //        var s = string.Format(powerPattern, Obj.Name, -1);
        //        s = string.Format(elementPattern, s);
        //        Assert.AreEqual(s, x.Formula(true));
        //        Assert.AreEqual(y ?? x.Formula(true), x.Name);
        //        Assert.AreEqual(Obj.SystemOfUnits, x.SystemOfUnits);
        //        Assert.AreEqual(x.GetMeasure().Formula(), x.Measure);
        //        Assert.AreNotEqual(string.Empty, x.Measure);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    Test(Obj.Inverse(), null);
        //    Test(Obj.Inverse(name), name);
        //}

        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsFalse(Obj.IsEmpty());
        //    Assert.IsFalse(new UnitBase().IsEmpty());
        //    Assert.IsTrue(Unit.Empty.IsEmpty());
        //}

        //[TestMethod] public void IsThisTest() {
        //    Assert.IsTrue(Obj.IsThis(Obj.Name));
        //    Assert.IsTrue(Obj.IsThis(Obj.Symbol));
        //    Assert.IsTrue(Obj.IsThis(Obj.Formula()));
        //    Assert.IsTrue(Obj.IsThis(Obj.Formula(true)));
        //    Assert.IsFalse(Obj.IsThis(GetRandom.String()));
        //}

        //[TestMethod] public void MeasureIdTest() {
        //    Obj.Measure = string.Empty;
        //    testProperty(() => Obj.Measure, x => Obj.Measure = x);
        //}

        //[TestMethod] public void MultiplyTest() {
        //    var b1 = UnitBase.Random();
        //    var b2 = UnitBase.Random();
        //    Units.Instance.Add(b1);
        //    Units.Instance.Add(b2);
        //    SystemsOfUnits.Add(b1.SystemOfUnits);
        //    b2.SystemOfUnits = b1.SystemOfUnits;
        //    Measures.Add(b1.Measure);
        //    Measures.Add(b2.Measure);
        //    var l = new List<string> {b1.Name, b2.Name};
        //    l.Sort();
        //    var o1 = l[0] == b1.Name ? b1 : b2;
        //    var o2 = l[1] == b2.Name ? b2 : b1;

        //    void Test(Unit x, string y, SystemOfUnits z) {
        //        Assert.AreEqual(y ?? x.Formula(true), x.Name);
        //        var s1 = o1.Name;
        //        s1 = string.Format(elementPattern, s1);
        //        var s2 = o2.Name;
        //        s2 = string.Format(elementPattern, s2);
        //        var s = string.Format(multiplyPattern, s1, s2);
        //        Assert.AreEqual(s, x.Formula(true));
        //        Assert.AreEqual(z, x.GetSystemOfUnits);
        //        var n1 = o1.GetMeasure().Name;
        //        var n2 = o2.GetMeasure().Name;
        //        var m1 = n1;
        //        m1 = string.Format(elementPattern, m1);
        //        var m2 = n2;
        //        m2 = string.Format(elementPattern, m2);
        //        var m = StringValue.IsLess(n1, n2) ? string.Format(multiplyPattern, m1, m2) : string.Format(multiplyPattern, m2, m1);
        //        Assert.AreEqual(m, x.GetMeasure().Formula(true));
        //    }

        //    var name = GetRandom.String(5, 10);
        //    Test(o1.Multiply(o2), null, SystemsOfUnits.Find(o1.SystemOfUnits));
        //    Test(o1.Multiply(o2, name), name, SystemsOfUnits.Find(o1.SystemOfUnits));
        //}

        //[TestMethod] public void PowerTest() {
        //    var power = GetRandom.Bool()? GetRandom.Int8(2): GetRandom.Int8(max: -2);

        //    void Test(Unit x, string y) {
        //        var s = string.Format(powerPattern, Obj.Name, power);
        //        s = string.Format(elementPattern, s);
        //        Assert.AreEqual(s, x.Formula(true));
        //        Assert.AreEqual(y ?? x.Formula(true), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    Test(Obj.Power(power), null);
        //    Test(Obj.Power(power, name), name);
        //}

        //[TestMethod] public void SystemOfUnitsIdTest() {
        //    Obj.SystemOfUnits = string.Empty;
        //    testProperty(() => Obj.SystemOfUnits, x => Obj.SystemOfUnits = x);
        //}

        //[TestMethod] public void ToBaseTest() {
        //    var d = GetRandom.Double();
        //    Assert.AreEqual(d, Obj.ToBase(d));
        //}

    }
}
