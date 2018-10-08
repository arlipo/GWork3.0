using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids.Extensions;
namespace Open.Tests.Aids.Extensions {
    [TestClass] public class LinqExtensionsTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(LinqExtensions);
        }

        [TestMethod] public void DistinctByTest() {
            Assert.Inconclusive("Dont know what is doing");
        }

        [TestMethod] public void FlattenTest() {
            Assert.Inconclusive("Dont know what is doing");
        }

        [TestMethod] public void IsGroupedTest() {
            Assert.Inconclusive("Dont know what is doing");
        }
    }
}
