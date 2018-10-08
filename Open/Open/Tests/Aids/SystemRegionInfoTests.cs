using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class SystemRegionInfoTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(SystemRegionInfo);
        }
        [TestMethod] public void GetRegionsListTest() {
            var l = SystemRegionInfo.GetRegionsList();
            Assert.IsInstanceOfType(l, typeof(List<RegionInfo>));
            Assert.IsTrue(l.Count > 100);
            Assert.IsTrue(l[0].EnglishName.StartsWith("A"));
        }
        [TestMethod] public void IsCountryTest() {
            Assert.IsFalse(SystemRegionInfo.IsCountry(null));
            testEstonia();
            testWorld();
        }
        private static void testEstonia() {
            var r = new RegionInfo("et-EE");
            Assert.IsNotNull(r);
            Assert.IsTrue(SystemRegionInfo.IsCountry(r));
            Assert.AreEqual("Estonia", r.EnglishName);
        }
        private static void testWorld() {
            var r = new RegionInfo("001");
            Assert.IsNotNull(r);
            Assert.IsFalse(SystemRegionInfo.IsCountry(r));
            Assert.AreEqual("World", r.EnglishName);
        }
    }
}


