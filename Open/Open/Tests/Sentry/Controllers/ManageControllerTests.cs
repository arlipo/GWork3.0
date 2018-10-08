using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Sentry.Controllers;
namespace Open.Tests.Sentry.Controllers
{
    [TestClass] public class ManageControllerTests: AcceptanceTests
    {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(ManageController);
        }
        [TestMethod]
        public void IndexTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void SendVerificationEmailTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ChangePasswordTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void SetPasswordTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ExternalLoginsTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void LinkLoginTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void LinkLoginCallbackTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void RemoveLoginTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void TwoFactorAuthenticationTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void Disable2FaWarningTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void Disable2FaTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void EnableAuthenticatorTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ShowRecoveryCodesTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ResetAuthenticatorWarningTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ResetAuthenticatorTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GenerateRecoveryCodesWarningTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GenerateRecoveryCodesTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void StatusMessageTest()
        {
            Assert.Inconclusive();
        }

    }
}
