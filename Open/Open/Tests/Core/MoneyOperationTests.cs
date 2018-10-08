using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core
{
    [TestClass]
    public class MoneyOperationTests : ClassTests<MoneyOperation>
    {
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(7, GetEnum.Count<MoneyOperation>());
        }

        [TestMethod]
        public void DummyTest() =>
            Assert.AreEqual(0, (int)MoneyOperation.Dummy);

        [TestMethod]
        public void AddTest() =>
            Assert.AreEqual(1, (int)MoneyOperation.Add);

        [TestMethod]
        public void SubtractTest() =>
            Assert.AreEqual(2, (int)MoneyOperation.Subtract);

        [TestMethod]
        public void MultiplyTest() =>
            Assert.AreEqual(3, (int)MoneyOperation.Multiply);

        [TestMethod]
        public void DivideTest() =>
            Assert.AreEqual(4, (int)MoneyOperation.Divide);

        [TestMethod]
        public void ConvertTest() =>
            Assert.AreEqual(5, (int)MoneyOperation.Convert);

        [TestMethod]
        public void RoundTest() =>
            Assert.AreEqual(6, (int)MoneyOperation.Round);

    }

}
