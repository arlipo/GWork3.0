//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class MeasureViewsListTests //: ClassTests<MeasureViewsList>
    {

        //private Measure measure;

        //protected override Measures getRandomObj() {
        //    var r = Measures.Random();
        //    return r;
        //}

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    for (var i = 0; i < GetRandom.Count(); i++) Measures.Add(GetRandom.String());
        //    var t = MeasureTerms.Random();
        //    var n = GetRandom.String();
        //    var c = GetRandom.String();
        //    var d = GetRandom.String();
        //    measure = Measures.Add(t, n, c, d) as MeasureDerived;
        //    for (var i = 0; i < GetRandom.Count(); i++) Measures.Add(GetRandom.String());
        //}

        //[TestMethod] public void AddTest() {
        //    Measures.Instance.Clear();
        //    var n = GetRandom.String();
        //    var s = GetRandom.String();
        //    var d = GetRandom.String();
        //    Measures.Add(n, s, d);
        //    Assert.AreEqual(1, Measures.Instance.Count);
        //    var m = Measures.Instance[0];
        //    Assert.AreEqual(n, m.UniqueId);
        //    Assert.AreEqual(n, m.Name);
        //    Assert.AreEqual(s, m.Symbol);
        //    Assert.AreEqual(d, m.Definition);
        //    Assert.IsInstanceOfType(m, typeof(MeasureBase));
        //    Assert.IsNotInstanceOfType(m, typeof(MeasureDerived));
        //}

        //[TestMethod] public void AddDerivedTest() {
        //    Measures.Instance.Clear();
        //    var t = MeasureTerms.Random();
        //    var n = GetRandom.String();
        //    var s = GetRandom.String();
        //    var d = GetRandom.String();
        //    var m1 = Measures.Add(t, n, s, d);
        //    Assert.AreEqual(1 + t.Count, Measures.Instance.Count);
        //    var m = Measures.Find(m1.UniqueId);
        //    Assert.AreEqual(n, m.UniqueId);
        //    Assert.AreEqual(n, m.Name);
        //    Assert.AreEqual(s, m.Symbol);
        //    Assert.AreEqual(d, m.Definition);
        //    Assert.IsNotInstanceOfType(m, typeof(MeasureBase));
        //    Assert.IsInstanceOfType(m, typeof(MeasureDerived));
        //}

        //[TestMethod] public void TermsOnlyTest() {
        //    Measures.Instance.Clear();
        //    var t = MeasureTerms.Random();
        //    var m1 = Measures.Add(t);
        //    Assert.AreEqual(1 + t.Count, Measures.Instance.Count);
        //    var m = Measures.Find(m1.UniqueId);
        //    Assert.AreEqual(t.Formula(true), m.UniqueId);
        //    Assert.AreEqual(t.Formula(true), m.Name);
        //    Assert.AreEqual(t.Formula(true), m.Symbol);
        //    Assert.AreEqual(t.Formula(true), m.Definition);
        //    Assert.IsNotInstanceOfType(m, typeof(MeasureBase));
        //    Assert.IsInstanceOfType(m, typeof(MeasureDerived));
        //}

        //[TestMethod] public void NameIsEmptyTest() {
        //    Measures.Instance.Clear();
        //    var m = Measures.Add(string.Empty);
        //    Assert.AreEqual(0, Measures.Instance.Count);
        //    Assert.AreEqual(Measure.Empty, m);
        //    Assert.IsInstanceOfType(m, typeof(MeasureBase));
        //    Assert.IsNotInstanceOfType(m, typeof(MeasureDerived));
        //}

        //[TestMethod] public void NameOnlyTest() {
        //    Measures.Instance.Clear();
        //    var n = GetRandom.String();
        //    Measures.Add(n);
        //    Assert.AreEqual(1, Measures.Instance.Count);
        //    var m = Measures.Instance[0];
        //    Assert.AreEqual(n, m.UniqueId);
        //    Assert.AreEqual(n, m.Name);
        //    Assert.AreEqual(n, m.Symbol);
        //    Assert.AreEqual(n, m.Definition);
        //    Assert.IsInstanceOfType(m, typeof(MeasureBase));
        //    Assert.IsNotInstanceOfType(m, typeof(MeasureDerived));
        //}

        //[TestMethod] public void FindTest() {
        //    Assert.AreEqual(measure, Measures.Find(measure.UniqueId));
        //    Assert.AreEqual(measure, Measures.Find(measure.Name));
        //    Assert.AreEqual(measure, Measures.Find(measure.Symbol));
        //    Assert.AreEqual(measure, Measures.Find(measure.Formula()));
        //    Assert.AreEqual(measure, Measures.Find(measure.Formula(true)));
        //}

        //[TestMethod] public void InstanceTest() { testSingleton(() => Measures.Instance); }
    }
}
