using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Extensions;
using Open.Sentry.Services;
namespace Open.Tests.Sentry.Extensions
{
    [TestClass]
    public class EmailSenderExtensionsTests : BaseTests
    {
        private IEmailSender sender;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EmailSenderExtensions);
            sender = new mockEmailSender();
        }
        [TestMethod]
        public void SendEmailConfirmationAsyncTest() {
            var email = GetRandom.String();
            var link = GetRandom.String();
            sender.SendEmailConfirmationAsync(email, link);
            var s = sender as mockEmailSender;
            Assert.IsNotNull(s);
            Assert.AreEqual(email, s.Email);
            Assert.AreEqual("Confirm your email", s.Subject);
            var m =
                $"Please confirm your account by clicking this link: <a href='{link}'>link</a>";
            Assert.AreEqual(m, s.Message);
        }
    }
}
