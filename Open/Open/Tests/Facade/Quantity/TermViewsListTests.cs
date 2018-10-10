//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class TermViewsListTests //: ClassTests<TermViewsList<MeasureTermView>>
    {

        //private MeasureTerms obj;

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    type = typeof(Terms<MeasureTerm>);
        //    obj = MeasureTerms.Random();
        //}

        //[TestMethod] public void AddRangeTest() {
        //    var terms = Common.Clone(obj);
        //    obj.AddRange(terms);
        //    Assert.AreEqual(terms.Count, obj.Count);
        //    foreach (var t in terms) {
        //        var t1 = obj.Find(x => x.Measure == t.Measure);
        //        Assert.AreEqual(t1.Power, t.Power*2);
        //    }
        //}

        //[TestMethod] public void InsertTest() {
        //    var c = obj.Count;
        //    var i = GetRandom.Int32(0, c);
        //    var t = MeasureTerm.Random();
        //    obj.Insert(i,t);
        //    Assert.AreEqual(c+1, obj.Count);
        //    Assert.AreEqual(t, obj[i]);
        //    var t1 = Common.Clone(t);
        //    obj.Insert(i, t1);
        //    Assert.AreEqual(c + 1, obj.Count);
        //    t1 = obj.Find(x => x.Measure == t.Measure);
        //    Assert.AreEqual(t1.Power, t.Power*2);
        //}

        //[TestMethod] public void ToTermsFormulaTest() {
        //    Assert.AreEqual("", obj.ToTermsFormula(null));
        //    Assert.AreEqual("",obj.ToTermsFormula(new List<string>()));
        //    Assert.AreEqual("A*B*C",obj.ToTermsFormula(new List<string> {"C", "B", "A"}));
        //}

        //[TestMethod] public void ToTermFormulaTest() {
        //    Assert.AreEqual("",obj.ToTermFormula(null));
        //    Assert.AreEqual("",obj.ToTermFormula(new MeasureTerm()));
        //    var t = new MeasureTerm(Measure.Random(), GetRandom.Int8());
        //    while (t.Power == 0 || t.Power == 1)
        //        t = new MeasureTerm(Measure.Random(), GetRandom.Int8());
        //    var s = $"{t.Measure}^{t.Power}";
        //    Assert.AreEqual(s,obj.ToTermFormula(t));
        //}

        //[TestMethod] public void ToTermsFormulasTest() {
        //    var l = obj.ToTermsFormulas();
        //    Assert.AreEqual(l.Count, obj.Count);
        //}

        //[TestMethod] public void FormulaTest() {
        //    var a = Measures.Add("A");
        //    var b = Measures.Add("B");
        //    var c = Measures.Add("C");
        //    obj = new MeasureTerms{new MeasureTerm(c, 3),new MeasureTerm(b,2),new MeasureTerm(a,1) };
        //    Assert.AreEqual("A*B^2*C^3", obj.Formula());
        //}

    }
}
