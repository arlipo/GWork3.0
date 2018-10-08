using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class WebServiceTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(WebService);
        }
        [TestMethod] public void LoadTest() {
            const string source1 = "https://docs.microsoft.com/";
            const string source2 = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            const string source3 = "http://www.example.com/";

            var webpage = new WebClient();

            Assert.AreEqual(webpage.DownloadString(source1), WebService.Load(source1));
            Assert.AreEqual(webpage.DownloadString(source2), WebService.Load(source2));
            Assert.AreEqual(webpage.DownloadString(source3), WebService.Load(source3));
        }
    }
}