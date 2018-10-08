using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Quantity;
using Open.Domain.Common;
namespace Open.Tests.Domain.Common {
    [TestClass] public class MetricsTests : EntityBaseTests<Metrics<CurrencyData>, CurrencyData> {
        class testClass : Metrics<CurrencyData> {
            public testClass(CurrencyData dbRecord) : base(dbRecord) { }
        }
        protected override Metrics<CurrencyData> getRandomObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(MetricsData);
            return GetRandom.Object<testClass>();
        }
        [TestMethod] public void IDTest() {
            var id = GetRandom.String();
            obj.Data.ID = id;
            Assert.AreEqual(obj.ID, obj.Data.ID);
            Assert.AreEqual(id, obj.ID);
        }
        //private class metric : Metric {
        //    public static metric Random() {
        //        var x = new metric();
        //        x.setRandomValues();
        //        return x;
        //    }
        //}

        //private metric obj;

        //[TestCleanup] public override void TestCleanup() {
        //    base.TestCleanup();
        //    obj = null;
        //}

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    obj = metric.Random();
        //}

        //[TestMethod] public void ConstructorTest() {
        //    Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(UniqueEntity));
        //}

        //[TestMethod] public void FormulaTest() {
        //    Assert.AreEqual(obj.Name, obj.Formula(true));
        //    Assert.AreEqual(obj.Symbol, obj.Formula());
        //}

        //[TestMethod] public void IsFormulaTest() {
        //    Assert.IsFalse(Metric.IsFormula(null));
        //    Assert.IsFalse(Metric.IsFormula(string.Empty));
        //    var s = GetRandom.String();
        //    var i = GetRandom.Int32(0, s.Length);
        //    Assert.IsFalse(Metric.IsFormula(s));
        //    Assert.IsTrue(Metric.IsFormula(s.Insert(i, "^")));
        //}

        //[TestMethod] public void IsThisTest() {
        //    Assert.IsTrue(obj.IsThis(obj.Name));
        //    Assert.IsTrue(obj.IsThis(obj.Symbol));
        //    Assert.IsTrue(obj.IsThis(obj.Formula()));
        //    Assert.IsTrue(obj.IsThis(obj.Formula(true)));
        //    Assert.IsFalse(obj.IsThis(GetRandom.String()));
        //}

        //[TestMethod] public void IsSameFormulaTest() {
        //    var a = createMeasureDerived();
        //    var b = createMeasureDerived();
        //    Assert.IsTrue(a.IsSameFormula(b));
        //    Assert.IsFalse(obj.IsSameFormula(a));
        //    Assert.IsTrue(new MeasureBase().IsSameFormula(new MeasureBase()));
        //    Assert.IsFalse(new MeasureBase().IsSameFormula(null));
        //    var t = MeasureTerms.Random();
        //    Assert.IsTrue(new MeasureDerived(t).IsSameFormula(new MeasureDerived(t)));
        //}

        //[TestMethod] public void SymbolTest() {
        //    testProperty(() => obj.Symbol, x => obj.Symbol = x);
        //}

        //[TestMethod] public void DefinitionTest() {
        //    testProperty(() => obj.Definition, x => obj.Definition = x);
        //}

        //[TestMethod] public void NameTest() { testProperty(() => obj.Name, x => obj.Name = x); }

        //private static Measure createMeasureDerived() {
        //    var m1 = Measures.Add("measure1", "m1");
        //    var m2 = Measures.Add("measure2", "m2");
        //    var t1 = new MeasureTerm(m1, 2);
        //    var t2 = new MeasureTerm(m2, -1);
        //    var l = new List<MeasureTerm> {t1, t2};
        //    var terms = new MeasureTerms(l);
        //    return new MeasureDerived(terms, "measure3", "m3");
        //}

    }
}


