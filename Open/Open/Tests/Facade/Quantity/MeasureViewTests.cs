//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class MeasureViewTests //: ClassTests<MeasureView>
    {
        //protected string elementPattern => "{0}";
        //protected string multiplyPattern => "{0}*{1}";
        //protected string powerPattern => "{0}^{1}";

        //protected override MeasureBase getRandomObj() { return MeasureBase.Random(); }

        //[ClassInitialize] public static void ClassInitialize(TestContext c) {
        //    Measures.Instance.Clear();
        //    for (var i = 0; i < 100; i++) Measures.Add(GetRandom.String());
        //}

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    type = typeof(Measure);
        //    Obj.UniqueId = Obj.Name;
        //    Measures.Add(Obj.UniqueId);
        //}

        //[TestMethod] public void DivideTest() {
        //    var b1 = MeasureBase.Random();
        //    var b2 = MeasureBase.Random();
        //    Measures.Instance.Add(b1);
        //    Measures.Instance.Add(b2);
        //    var l = new List<string> {b1.Name, b2.Name};
        //    l.Sort();
        //    var o1 = l[0] == b1.Name ? b1 : b2;
        //    var o2 = l[1] == b2.Name ? b2 : b1;

        //    void Test(Measure x, string y) {
        //        var s1 = o1.Name;
        //        s1 = string.Format(elementPattern, s1);
        //        var s2 = string.Format(powerPattern, o2.Name, -1);
        //        s2 = string.Format(elementPattern, s2);
        //        var s = string.Format(multiplyPattern, s1, s2);
        //        Assert.AreEqual(s, x.Formula(true));
        //        Assert.AreEqual(y ?? x.Formula(), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    Test(o1.Divide(o2), null);
        //    Test(o1.Divide(o2, name), name);
        //}

        //[TestMethod] public void InverseTest() {
        //    void Test(Measure x, string y) {
        //        y = y ?? x.Formula();
        //        Assert.IsNotNull(x);
        //        Assert.AreNotEqual(Obj, x);
        //        Assert.IsInstanceOfType(x, typeof(MeasureDerived));
        //        var s = string.Format(powerPattern, Obj.Name, -1);
        //        s = string.Format(elementPattern, s);
        //        Assert.AreEqual(s, x.Formula(true));
        //        Assert.AreEqual(y, x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    Test(Obj.Inverse(), null);
        //    Test(Obj.Inverse(name), name);
        //}

        //[TestMethod] public void MultiplyTest() {
        //    var b1 = MeasureBase.Random();
        //    var b2 = MeasureBase.Random();
        //    Measures.Instance.Add(b1);
        //    Measures.Instance.Add(b2);
        //    var l = new List<string> {b1.Name, b2.Name};
        //    l.Sort();
        //    var o1 = l[0] == b1.Name ? b1 : b2;
        //    var o2 = l[1] == b2.Name ? b2 : b1;

        //    void Test(Measure x, string y) {
        //        Assert.AreEqual(y ?? x.Formula(), x.Name);
        //        var s1 = o1.Name;
        //        s1 = string.Format(elementPattern, s1);
        //        var s2 = o2.Name;
        //        s2 = string.Format(elementPattern, s2);
        //        var s = string.Format(multiplyPattern, s1, s2);
        //        Assert.AreEqual(s, x.Formula(true));
        //    }

        //    var name = GetRandom.String(5, 10);
        //    Test(o1.Multiply(o2), null);
        //    Test(o1.Multiply(o2, name), name);
        //}

        //[TestMethod] public void PowerTest() {
        //    var power = GetRandom.Int8();

        //    void Test(Measure x, string y) {
        //        var s = string.Format(powerPattern, Obj.Name, power);
        //        s = string.Format(elementPattern, s);
        //        Assert.AreEqual(s, x.Formula(true));
        //        Assert.AreEqual(y ?? x.Formula(), x.Name);
        //    }

        //    var name = GetRandom.String(5, 10);
        //    Test(Obj.Power(power), null);
        //    Test(Obj.Power(power, name), name);
        //}

        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsFalse(Obj.IsEmpty());
        //    Assert.IsTrue(Measure.Empty.IsEmpty());
        //    Assert.IsFalse(new MeasureBase().IsEmpty());
        //}

        //[TestMethod] public void EmptyTest() { testSingleton(() => Measure.Empty); }

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
    }
}
