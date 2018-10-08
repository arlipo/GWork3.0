using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core
{
    [TestClass]
    public class PricingStrategyTests: ClassTests<PricingStrategy>
    {
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(1, GetEnum.Count<PricingStrategy>());
        }

        [TestMethod]
        public void UndefinedTest() =>
            Assert.AreEqual(0, (int)PricingStrategy.Undefined);

    }
}
