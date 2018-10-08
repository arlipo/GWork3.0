using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Sentry;
namespace Open.Tests.Sentry {
    [TestClass] public class ProgramTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(Program);
        }
        [TestMethod] public void MainTest() { }

        [TestMethod] public void BuildWebHostTest() { }
    }
}
