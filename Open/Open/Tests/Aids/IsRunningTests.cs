using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class IsRunningTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(IsRunning);
        }

        [TestMethod] public void NamespaceTest() {
            Assert.IsFalse(IsRunning.Namespace(null));
            namespaceIsRunning();
            namespceIsNotRunning();
        }

        private static void namespaceIsRunning() {
            var name = "Open.Aids";
            Assert.IsNotNull(name);
            Assert.IsTrue(IsRunning.Namespace(name));
        }
        private static void namespceIsNotRunning() {
            var name = "001";
            Assert.IsNotNull(name);
            Assert.IsFalse(IsRunning.Namespace(name));
        }
        [TestMethod] public void TestsTest() {
            Assert.IsTrue(IsRunning.Tests());
            Assert.IsFalse(IsRunning.Tests(true));
        }

    }
}