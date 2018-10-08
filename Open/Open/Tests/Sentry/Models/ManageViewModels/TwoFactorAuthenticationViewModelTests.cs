using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.ManageViewModels;
namespace Open.Tests.Sentry.Models.ManageViewModels {
    [TestClass]
    public class
        TwoFactorAuthenticationViewModelTests : ObjectTests<TwoFactorAuthenticationViewModel> {

        [TestMethod] public void HasAuthenticatorTest() {
            canReadWrite(() => obj.HasAuthenticator, x => obj.HasAuthenticator = x);
            hasAttributes(o => o.HasAuthenticator);
        }

        [TestMethod] public void RecoveryCodesLeftTest() {
            canReadWrite(() => obj.RecoveryCodesLeft, x => obj.RecoveryCodesLeft = x);
            hasAttributes(o => o.RecoveryCodesLeft);
        }

        [TestMethod] public void Is2FaEnabledTest() {
            canReadWrite(() => obj.Is2FaEnabled, x => obj.Is2FaEnabled = x);
            hasAttributes(o => o.Is2FaEnabled);
        }

        protected override TwoFactorAuthenticationViewModel getRandomObject() =>
            GetRandom.Object<TwoFactorAuthenticationViewModel>();
    }
}
