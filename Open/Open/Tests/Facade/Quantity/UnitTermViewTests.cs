//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class UnitTermViewTests : ClassTests<UnitTermView> {

        //protected override UnitTerm getRandomObj() { return UnitTerm.Random(); }

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    var c = GetRandom.Count();
        //    for (var i = 0; i < c; i++)
        //        Units.Add(GetRandom.String(), null);
        //}

        //[TestCleanup] public override void TestCleanup() {
        //    base.TestCleanup();
        //    Units.Instance.Clear();
        //}

        //[TestMethod] public void ConstructorTest() {
        //    Assert.AreEqual(Obj.GetType().BaseType, typeof(CommonTerm<Unit>));
        //}

        //[TestMethod] public void GetUnitTest() {
        //    Assert.AreNotEqual(0, Units.Instance.Count);
        //    var m = Obj.GetUnit;
        //    Assert.IsNotNull(m);
        //    Assert.AreEqual(Unit.Empty, m);
        //    Units.Add(Obj.Unit, Measure.Empty);
        //    m = Obj.GetUnit;
        //    Assert.AreEqual(Obj.Unit, m.Name);
        //}

        //[TestMethod] public void FormulaTest() {
        //    var unit = UnitBase.Random();
        //    unit.Name = Obj.Unit;
        //    Units.Instance.Add(unit);
        //    var longFormat = $"{Obj.GetUnit.Name}^{Obj.Power}";
        //    var shortFormat = $"{Obj.GetUnit.Symbol}^{Obj.Power}";
        //    Assert.AreEqual(longFormat, Obj.Formula(true));
        //    Assert.AreEqual(shortFormat, Obj.Formula());
        //}

        //[TestMethod] public void UnitTest() {
        //    testProperty(() => Obj.Unit, x => Obj.Unit = x);
        //}

        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsTrue(UnitTerm.Empty.IsEmpty());
        //    Assert.IsFalse(new UnitTerm().IsEmpty());
        //    Assert.IsFalse(Obj.IsEmpty());
        //}

        //[TestMethod] public void EmptyTest() {
        //    testSingleton(() => UnitTerm.Empty);
        //}

    }
}
