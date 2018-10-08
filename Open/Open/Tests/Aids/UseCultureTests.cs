using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class UseCultureTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(UseCulture);
        }

        [TestMethod] public void CurrentTest() {
            var current = CultureInfo.CurrentCulture;
            Assert.AreEqual(current, UseCulture.Current);
        }

        [TestMethod] public void EnglishTest() {
            var current = new CultureInfo("en-GB");
            Assert.AreEqual(current, UseCulture.English);
        }

        [TestMethod] public void InvariantTest() {
            var current = new CultureInfo("");
            Assert.AreEqual(current, UseCulture.Invariant);
        }
    }
}