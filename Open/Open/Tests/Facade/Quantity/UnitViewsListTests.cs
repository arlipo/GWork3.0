//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {

    [TestClass] public class UnitViewsListTests //: ClassTests<UnitViewsList>
    {

        //private UnitBase unit;
        //private string name;
        //private string code;
        //private string note;
        //private MeasureBase measure;
        //private SystemOfUnits sOfUnits;

        //protected override Units getRandomObj() { return Units.Random(); }

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    setRandomValues();
        //    unit = new UnitBase(name, measure, code, note, sOfUnits);
        //    setRandomValues();
        //}

        //private void setRandomValues() {
        //    name = GetRandom.String();
        //    code = GetRandom.String();
        //    note = GetRandom.String();
        //    measure = MeasureBase.Random();
        //    sOfUnits = SystemOfUnits.Random();
        //}

        //[TestMethod] public void AddTest() {
        //    Units.Instance.Clear();
        //    var s = GetRandom.String();
        //    Units.Add(s, MeasureBase.Random());
        //    Assert.AreEqual(1, Units.Instance.Count);
        //    var m = Units.Instance[0];
        //    Assert.AreEqual(s, m.Name);
        //    Assert.IsTrue(m is UnitBase);
        //}

        //[TestMethod] public void AddFactoredTest() {
        //    Units.Instance.Clear();
        //    var s = GetRandom.String();
        //    var f = GetRandom.Double();
        //    Units.Add(s, f, MeasureBase.Random());
        //    Assert.AreEqual(1, Units.Instance.Count);
        //    var m = Units.Instance[0] as UnitFactored;
        //    Assert.AreEqual(s, m.Name);
        //    Assert.AreEqual(f, m.Factor);
        //}

        //[TestMethod] public void AddFunctionedTest() {
        //    Units.Instance.Clear();
        //    var s = GetRandom.String();
        //    var rFrom = Open.Domain.Rule.Rule.Random();
        //    var rTo = Open.Domain.Rule.Rule.Random();
        //    Units.Add(s, rTo, rFrom, MeasureBase.Random());
        //    Assert.AreEqual(1, Units.Instance.Count);
        //    var m = Units.Instance[0] as UnitFunctioned;
        //    Assert.AreEqual(s, m.Name);
        //    Assert.AreEqual(rFrom.Name, m.FromBaseRuleId);
        //    Assert.AreEqual(rTo.Name, m.ToBaseRuleId);
        //}

        //[TestMethod] public void AddDerivedTest() {
        //    Units.Instance.Clear();
        //    var s = GetRandom.String();
        //    var t = UnitTerms.Random();
        //    var c = Units.Instance.Count;
        //    Units.Add(s, t, MeasureBase.Random());
        //    Assert.AreEqual(c + 1, Units.Instance.Count);
        //    var m = Units.Instance[c] as UnitDerived;
        //    Assert.AreEqual(s, m.Name);
        //    Assert.AreEqual(t.Formula(), m.Formula());
        //}

        //[TestMethod] public void FindTest() {
        //    Assert.AreEqual(Unit.Empty, Units.Find(unit.UniqueId));
        //    Units.Instance.Add(unit);
        //    Assert.AreEqual(unit, Units.Find(unit.UniqueId));
        //}

        //[TestMethod] public void FindAllForMeasureTest() {
        //    var u1 = Unit.Random();
        //    var u2 = Unit.Random();
        //    var u3 = Unit.Random();
        //    var u4 = Unit.Random();
        //    var m = Measure.Random();
        //    u1.Measure = m.Name;
        //    u2.Measure = m.Name;
        //    Assert.AreEqual(0, Units.FindAllForMeasure(m.UniqueId).Count);
        //    Assert.AreEqual(0, Units.FindAllForMeasure(m.Name).Count);
        //    Units.Instance.AddRange(new[] {u1, u2, u3, u4});
        //    Measures.Instance.Add(m);
        //    Assert.AreEqual(2, Units.FindAllForMeasure(m.UniqueId).Count);
        //    Assert.IsTrue(Units.FindAllForMeasure(m.Name).Contains(u1));
        //    Assert.IsTrue(Units.FindAllForMeasure(m.UniqueId).Contains(u2));
        //    Assert.IsFalse(Units.FindAllForMeasure(m.UniqueId).Contains(u3));
        //    Assert.IsFalse(Units.FindAllForMeasure(m.Name).Contains(u4));
        //    u3.Measure = m.UniqueId;
        //    u4.Measure = m.UniqueId;
        //    Assert.AreEqual(4, Units.FindAllForMeasure(m.UniqueId).Count);
        //}

        //[TestMethod] public void InstanceTest() { testSingleton(() => Units.Instance); }
    }
}

