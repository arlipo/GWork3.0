//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class MeasureTermViewsListTests : ClassTests<MeasureTermViewsList> {
       //private Measure m1;
       // private Measure m2;
       // private Measure m3;
       // private Measure m4;

       // protected override MeasureTerms getRandomObj() {
       //     return MeasureTerms.Random();
       // }

       // [TestInitialize] public override void TestInitialize() {
       //     base.TestInitialize();
       //     var c = GetRandom.Count();
       //     for (var i = 0; i < c; i++)
       //         Measures.Add(GetRandom.String());
       //     m1 = Measures.insert(GetRandom.UInt8(0, c),"measure1", "m1");
       //     m2 = Measures.insert(GetRandom.UInt8(0, c), "measure2", "m2");
       //     m3 = Measures.insert(GetRandom.UInt8(0, c), "measure3", "m3");
       //     m4 = Measures.insert(GetRandom.UInt8(0, c), "measure4", "m4");
       // }

       // [TestCleanup] public override void TestCleanup() {
       //     base.TestCleanup();
       //     Measures.Instance.Clear();
       // }

       // [TestMethod] public void AddTest() {
       //     var terms = new MeasureTerms();
       //     var t1 = new MeasureTerm(m1, 2);
       //     var t2 = new MeasureTerm(m1, -2);
       //     terms.Add(t1);
       //     Assert.AreEqual(1, terms.Count);
       //     terms.Add(t2);
       //     Assert.AreEqual(0, terms.Count);
       // }

       // [TestMethod] public void AddRangeTest() {
       //     Obj = create();
       //     var terms = create();
       //     terms.Add(new MeasureTerm(m3, 2));
       //     terms.Add(new MeasureTerm(m3, -2));
       //     terms.Add(new MeasureTerm(m4, -2));
       //     Obj.AddRange(terms);
       //     Assert.AreEqual("m1^4*m2^-2*m4^-2", Obj.Formula());
       // }

       // private MeasureTerms create() {
       //     var terms = new MeasureTerms();
       //     var t1 = new MeasureTerm(m1, 2);
       //     var t2 = new MeasureTerm(m2, -1);
       //     terms.Add(t1);
       //     terms.Add(t2);
       //     return terms;
       // }

       // [TestMethod] public void DivideTest() {
       //     void Test(Measure x, string y, string z) {
       //         var t = create();
       //         t = t.Divide(x);
       //         Assert.AreEqual(y, t.Formula(true));
       //         Assert.AreEqual(z, t.Formula());
       //     }

       //     Test(m3, "measure1^2*measure2^-1*measure3^-1",
       //         "m1^2*m2^-1*m3^-1");
       //     m3 = new MeasureBase();
       //     Test(m3, "measure1^2*measure2^-1", "m1^2*m2^-1");
       //     m3 = Measures.Add(create());
       //     Test(m3, string.Empty, string.Empty);
       // }

       // [TestMethod] public void EmptyTest() {
       //     testSingleton(() => MeasureTerms.Empty);
       // }

       // [TestMethod] public void FormulaTest() {
       //     var t = new MeasureTerms {new MeasureTerm(), new MeasureTerm()};
       //     Assert.AreEqual(string.Empty, t.Formula(true));
       //     Assert.AreEqual(string.Empty, t.Formula());
       // }

       // [TestMethod] public void InsertTest() {
       //     var terms = new MeasureTerms();
       //     var t1 = new MeasureTerm(m1, 2);
       //     var t2 = new MeasureTerm(m1, -2);
       //     var t3 = new MeasureTerm(m2, -2);
       //     terms.Insert(-1, t1);
       //     Assert.AreEqual(1, terms.Count);
       //     terms.Insert(-1, t3);
       //     Assert.AreEqual(2, terms.Count);
       //     terms.Insert(100, t2);
       //     Assert.AreEqual(1, terms.Count);
       // }

       // [TestMethod] public void InverseTest() {
       //     var t = create().Inverse();
       //     Assert.AreEqual("measure1^-2*measure2", t.Formula(true));
       //     Assert.AreEqual("m1^-2*m2", t.Formula());
       // }

       // [TestMethod] public void IsMeasureBaseTest() {
       //     Assert.IsFalse(Obj.IsMeasureBase());
       //     Obj.Clear();
       //     Obj.Add(new MeasureTerm(MeasureBase.Random(), 1));
       //     Assert.IsTrue(Obj.IsMeasureBase());
       // }

       // [TestMethod] public void IsListEmptyTest() {
       //     Assert.IsFalse(Obj.IsListEmpty());
       //     Obj.Clear();
       //     Assert.IsTrue(Obj.IsListEmpty());
       // }

       // [TestMethod] public void IsEmptyTest() {
       //     Assert.IsTrue(MeasureTerms.Empty.IsEmpty());
       //     Assert.IsFalse(new MeasureTerms().IsEmpty());
       //     Assert.IsFalse(MeasureTerms.Random().IsEmpty());
       //     Assert.IsFalse(Obj.IsEmpty());
       // }

       // [TestMethod] public void MultiplyTest() {
       //     void Test(Measure x, string y, string z) {
       //         var t = create();
       //         t = t.Multiply(x);
       //         Assert.AreEqual(y, t.Formula(true));
       //         Assert.AreEqual(z, t.Formula());
       //     }

       //     Test(m3, "measure1^2*measure2^-1*measure3",
       //         "m1^2*m2^-1*m3");
       //     m3 = new MeasureBase();
       //     Test(m3, "measure1^2*measure2^-1", "m1^2*m2^-1");
       //     m3 = Measures.Add(create());
       //     Test(m3, "measure1^4*measure2^-2", "m1^4*m2^-2");
       // }

       // [TestMethod] public void PowerTest() {
       //     var t = create().Power(3);
       //     Assert.AreEqual("measure1^6*measure2^-3", t.Formula(true));
       //     Assert.AreEqual("m1^6*m2^-3", t.Formula());
       // }
    }
}
