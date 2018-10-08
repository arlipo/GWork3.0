using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Sentry.Controllers;
namespace Open.Tests.Aids {

    [TestClass] public class GetUrlTests : BaseTests {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetUrl);
        }

        [TestMethod] public void ForControllerActionTest() {
            Assert.AreEqual("/home", GetUrl.ForControllerAction<HomeController>());
            Assert.AreEqual("/home/index",
                GetUrl.ForControllerAction<HomeController>(x => x.Index()));
        }
    }
}







