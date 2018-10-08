using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Views.Manage;
namespace Open.Tests.Sentry.Views.Manage {
    [TestClass] public class ManageNavPagesTests : BaseTests {
        private ViewContext view;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(ManageNavPages);
            view = new ViewContext();
        }

        [TestMethod] public void ActivePageKeyTest() =>
            Assert.AreEqual("ActivePage", ManageNavPages.ActivePageKey);

        [TestMethod] public void IndexTest() => Assert.AreEqual("Index", ManageNavPages.Index);

        [TestMethod] public void ChangePasswordTest() =>
            Assert.AreEqual("ChangePassword", ManageNavPages.ChangePassword);

        [TestMethod] public void ExternalLoginsTest() =>
            Assert.AreEqual("ExternalLogins", ManageNavPages.ExternalLogins);

        [TestMethod] public void TwoFactorAuthenticationTest() =>
            Assert.AreEqual("TwoFactorAuthentication", ManageNavPages.TwoFactorAuthentication);

        [TestMethod] public void IndexNavClassTest() {
            Assert.AreEqual(null, ManageNavPages.IndexNavClass(view));
            view.ViewData.AddActivePage(ManageNavPages.Index);
            Assert.AreEqual("active", ManageNavPages.IndexNavClass(view));
        }

        [TestMethod] public void ChangePasswordNavClassTest() {
            Assert.AreEqual(null, ManageNavPages.ChangePasswordNavClass(view));
            view.ViewData.AddActivePage(ManageNavPages.ChangePassword);
            Assert.AreEqual("active", ManageNavPages.ChangePasswordNavClass(view));
        }

        [TestMethod] public void ExternalLoginsNavClassTest() {
            Assert.AreEqual(null, ManageNavPages.ExternalLoginsNavClass(view));
            view.ViewData.AddActivePage(ManageNavPages.ExternalLogins);
            Assert.AreEqual("active", ManageNavPages.ExternalLoginsNavClass(view));
        }

        [TestMethod] public void TwoFactorAuthenticationNavClassTest() {
            Assert.AreEqual(null, ManageNavPages.TwoFactorAuthenticationNavClass(view));
            view.ViewData.AddActivePage(ManageNavPages.TwoFactorAuthentication);
            Assert.AreEqual("active", ManageNavPages.TwoFactorAuthenticationNavClass(view));
        }

        [TestMethod] public void PageNavClassTest() {
            var s = GetRandom.String();
            Assert.AreEqual(null, ManageNavPages.PageNavClass(view, s));
            view.ViewData.AddActivePage(s);
            Assert.AreEqual("active", ManageNavPages.PageNavClass(view, s));
        }

        [TestMethod] public void AddActivePageTest() { }
    }
}
