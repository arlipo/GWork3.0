using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
namespace Open.Tests.Core {
    [TestClass] public class ConstantsTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(Constants);
        }
        [TestMethod] public void UnspecifiedTest() {
            Assert.IsTrue(!string.IsNullOrWhiteSpace(Constants.Unspecified.Trim()));
        }
    }
}



