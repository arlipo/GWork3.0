using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class ValueTests : BaseTests {
        [TestInitialize] public override void TestInitialize() { type = typeof(Value<,,>); }
        [TestMethod] public void AddTest() { Assert.IsTrue(type.GetMethod("Add").IsAbstract); }
        [TestMethod] public void CompareToTest() {
            Assert.IsTrue(type.GetMethod("CompareTo", new[] {typeof(object)}).IsAbstract);
        }
        [TestMethod] public void ConvertToTest() {
            Assert.IsTrue(type.GetMethod("ConvertTo").IsAbstract);
        }
        [TestMethod] public void DivideTest() {
            Assert.IsTrue(type.GetMethod("Divide").IsAbstract);
        }
        [TestMethod] public void MultiplyTest() {
            Assert.IsTrue(type.GetMethod("Multiply").IsAbstract);
        }
        [TestMethod] public void RoundTest() { Assert.IsTrue(type.GetMethod("Round").IsAbstract); }
        [TestMethod] public void SubtractTest() {
            Assert.IsTrue(type.GetMethod("Subtract").IsAbstract);
        }
        [TestMethod] public void AmountTest() { }
        [TestMethod] public void UnitTest() { }
        [TestMethod] public void GetUnitTest() {
            Assert.IsTrue(type.GetMethod("GetUnit").IsAbstract);
        }
        [TestMethod] public void DefaultFormatTest() {
            Assert.IsTrue(type.GetField("DefaultFormat").IsStatic);
        }
    }
}
