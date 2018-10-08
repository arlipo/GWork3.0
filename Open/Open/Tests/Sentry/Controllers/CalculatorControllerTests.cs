using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Sentry.Controllers;
namespace Open.Tests.Sentry.Controllers
{
    [TestClass] public class CalculatorControllerTests: AcceptanceTests
    {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CalculatorController);
        }
        [TestMethod] public void IndexTest() {
            Assert.Inconclusive();
        }
    }
}
