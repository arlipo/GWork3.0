using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Domain.Rule {
    [TestClass] public class VariableTests //: ClassTests<Variable<string>>
    {
        //private class testClass : Variable<string> {
        //    public new static testClass Random() {
        //        var o = new testClass();
        //        o.setRandomValues();
        //        o.Value = GetRandom.String();
        //        o.Name = GetRandom.String();
        //        return o;
        //    }
        //}
        //private Variable<string> obj;
        //private static Variable<string> getRandomObj() {
        //    return testClass.Random();
        //}
        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    obj = getRandomObj();
        //}
        //[TestMethod] public void ConstructorTest() {
        //    Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(Variable));
        //}
        //[TestMethod] public void IsEqualTest() {
        //    var s = GetRandom.String();
        //    Assert.IsFalse(obj.IsEqual(s));
        //    Assert.IsTrue(obj.IsEqual(obj.Value));
        //}
        //[TestMethod] public void IsNotEqualTest() {
        //    var s = GetRandom.String();
        //    Assert.IsTrue(obj.IsNotEqual(s));
        //    Assert.IsFalse(obj.IsNotEqual(obj.Value));
        //}
        //[TestMethod] public void IsGreaterTest() {
        //    const string s = "AAAA";
        //    obj.Value = "Z" + GetRandom.String();
        //    Assert.IsTrue(obj.IsGreater(s));
        //    Assert.IsFalse(obj.IsGreater(obj.Value));
        //}
        //[TestMethod] public void IsNotGreaterTest() {
        //    const string s = "AAAA";
        //    obj.Value = "Z" + obj.Value;
        //    Assert.IsFalse(obj.IsNotGreater(s));
        //    Assert.IsTrue(obj.IsNotGreater(obj.Value));
        //}
        //[TestMethod] public void IsLessTest() {
        //    const string s = "ZZZZ";
        //    Assert.IsTrue(obj.IsLess(s));
        //    Assert.IsFalse(obj.IsLess(obj.Value));
        //}
        //[TestMethod] public void IsNotLessTest() {
        //    const string s = "ZZZZ";
        //    Assert.IsFalse(obj.IsNotLess(s));
        //    Assert.IsTrue(obj.IsNotLess(obj.Value));
        //}
        //[TestMethod] public void ConvertTest() {
        //    var s = GetRandom.String();
        //    Assert.AreEqual(s, obj.Convert(s));
        //}
        //[TestMethod] public void ValueTest() {
        //    obj.Value = string.Empty;
        //    testProperty(() => obj.Value, x => obj.Value = x);
        //}
    }
}
