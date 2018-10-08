using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.ManageViewModels;
namespace Open.Tests.Sentry.Models.ManageViewModels {
    [TestClass] public class ExternalLoginsViewModelTests : ObjectTests<ExternalLoginsViewModel> {

        [TestMethod] public void CurrentLoginsTest() {
            isNullableReadWriteProperty(() => obj.CurrentLogins, x => obj.CurrentLogins = x,
                GetRandom.Object<List<UserLoginInfo>>);
            hasAttributes(o => o.CurrentLogins);
        }

        [TestMethod] public void OtherLoginsTest() {
            isNullableReadWriteProperty(() => obj.OtherLogins, x => obj.OtherLogins = x,
                GetRandom.Object<List<AuthenticationScheme>>);
            hasAttributes(o => o.OtherLogins);
        }

        [TestMethod] public void ShowRemoveButtonTest() {
            canReadWrite(() => obj.ShowRemoveButton, x => obj.ShowRemoveButton = x);
            hasAttributes(o => o.ShowRemoveButton);
        }

        [TestMethod] public void StatusMessageTest() {
            isNullableReadWriteStringProperty(() => obj.StatusMessage, x => obj.StatusMessage = x);
            hasAttributes(o => o.StatusMessage);
        }

        protected override ExternalLoginsViewModel getRandomObject() =>
            GetRandom.Object<ExternalLoginsViewModel>();
    }
}