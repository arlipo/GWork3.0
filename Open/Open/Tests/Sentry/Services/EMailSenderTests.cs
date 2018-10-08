using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Sentry.Services;
namespace Open.Tests.Sentry.Services
{
    [TestClass] public class EmailSenderTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EmailSender);
        }
        [TestMethod]
        public void SendEmailAsyncTest()
        {
            Assert.Inconclusive();
        }

    }
}
