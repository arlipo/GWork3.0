using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;

namespace Open.Tests.Core
{
    [TestClass]
    public class GoodTypesTests
    {
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(3, GetEnum.Count<GoodTypes>());
        }

        [TestMethod]
        public void ChemistryTest()
        {
            Assert.AreEqual(0, (int) GoodTypes.Chemistry);
        }

        [TestMethod]
        public void AccessoriesTest()
        {
            Assert.AreEqual(1, (int) GoodTypes.Accessories);
        }

        [TestMethod]
        public void SparePartsTest()
        {
            Assert.AreEqual(2, (int) GoodTypes.SpareParts);
        }
    }
}