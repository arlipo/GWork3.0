using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Extensions;
namespace Open.Tests.Sentry.Extensions
{
    [TestClass]  public class UrlHelperExtensionsTests : BaseTests {
        private mockUrlHelper helper;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(UrlHelperExtensions);
            helper = new mockUrlHelper();
        }
        [TestMethod] public void EmailConfirmationLinkTest() {
            var userId = GetRandom.String();
            var code = GetRandom.String();
            var scheme = GetRandom.String();
            helper.EmailConfirmationLink(userId, code, scheme);
            Assert.AreEqual("ConfirmEmail", helper.ActionName);
            Assert.AreEqual("Account", helper.ControllerName);
            Assert.AreEqual(scheme, helper.ProtocolScheme);
            Assert.AreEqual("{ userId = " +
                            userId +
                            ", code = " +
                            code +
                            " }", helper.Values);
        }

        [TestMethod] public void ResetPasswordCallbackLinkTest() {
            var userId = GetRandom.String();
            var code = GetRandom.String();
            var scheme = GetRandom.String();
            helper.ResetPasswordCallbackLink(userId, code, scheme);
            Assert.AreEqual("ResetPassword", helper.ActionName);
            Assert.AreEqual("Account", helper.ControllerName);
            Assert.AreEqual(scheme, helper.ProtocolScheme);
            Assert.AreEqual("{ userId = " +
                            userId +
                            ", code = " +
                            code +
                            " }", helper.Values);
        }
    }
}
