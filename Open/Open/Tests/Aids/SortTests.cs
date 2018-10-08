using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class SortTests: BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(Sort);
        }
        [TestMethod] public void UpwardsTest() {
            sortUpwardsTest(DateTime.MaxValue, DateTime.MinValue);
            sortUpwardsTest(double.MaxValue, double.MinValue);
            sortUpwardsTest(int.MaxValue, int.MinValue);
        }
        private static void sortUpwardsTest<T>(T maxValue, T minValue) where T : IComparable {
            Assert.IsTrue(maxValue.CompareTo(minValue) >= 0);
            Sort.Upwards(ref maxValue, ref minValue);
            Assert.IsTrue(maxValue.CompareTo(minValue) <= 0);
        }
    }
}


