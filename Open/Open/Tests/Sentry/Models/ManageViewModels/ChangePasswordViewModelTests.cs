using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.ManageViewModels;
namespace Open.Tests.Sentry.Models.ManageViewModels {
    [TestClass] public class ChangePasswordViewModelTests : ObjectTests<ChangePasswordViewModel> {
        [TestMethod] public void OldPasswordTest() {
            isNullableReadWriteStringProperty(() => obj.OldPassword, x => obj.OldPassword = x);
            hasAttributes(o => o.OldPassword, typeof(RequiredAttribute), typeof(DisplayAttribute),
                typeof(RequiredAttribute));
        }

        [TestMethod] public void NewPasswordTest() {
            isNullableReadWriteStringProperty(() => obj.NewPassword, x => obj.NewPassword = x);
            hasAttributes(o => o.NewPassword, typeof(RequiredAttribute), typeof(DisplayAttribute),
                typeof(RequiredAttribute), typeof(StringLengthAttribute));
        }

        [TestMethod] public void ConfirmPasswordTest() {
            isNullableReadWriteStringProperty(() => obj.ConfirmPassword,
                x => obj.ConfirmPassword = x);
            hasAttributes(o => o.ConfirmPassword, typeof(DataTypeAttribute),
                typeof(DisplayAttribute), typeof(CompareAttribute));
        }

        [TestMethod] public void StatusMessageTest() {
            isNullableReadWriteStringProperty(() => obj.StatusMessage, x => obj.StatusMessage = x);
            hasAttributes(o => o.StatusMessage);
        }

        protected override ChangePasswordViewModel getRandomObject() =>
            GetRandom.Object<ChangePasswordViewModel>();
    }
}
