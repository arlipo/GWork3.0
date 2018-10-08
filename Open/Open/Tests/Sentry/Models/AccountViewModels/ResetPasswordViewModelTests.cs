using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.AccountViewModels;
namespace Open.Tests.Sentry.Models.AccountViewModels {
    [TestClass] public class ResetPasswordViewModelTests : ObjectTests<ResetPasswordViewModel> {
        [TestMethod] public void EmailTest() {
            isNullableReadWriteStringProperty(() => obj.Email, x => obj.Email = x);
            hasAttributes(o => o.Email, typeof(RequiredAttribute),
                typeof(EmailAddressAttribute));
        }

        [TestMethod] public void PasswordTest() {
            isNullableReadWriteStringProperty(() => obj.Password, x => obj.Password = x);
            hasAttributes(o => o.Password, typeof(RequiredAttribute), typeof(DataTypeAttribute),
                typeof(StringLengthAttribute));
        }

        [TestMethod] public void ConfirmPasswordTest() {
            isNullableReadWriteStringProperty(() => obj.ConfirmPassword,
                x => obj.ConfirmPassword = x);
            hasAttributes(o => o.ConfirmPassword, typeof(CompareAttribute),
                typeof(DisplayAttribute), typeof(DataTypeAttribute));
        }
        [TestMethod] public void CodeTest() {
            isNullableReadWriteStringProperty(() => obj.Code, x => obj.Code = x);
            hasAttributes(o => o.Code);
        }

        protected override ResetPasswordViewModel getRandomObject() =>
            GetRandom.Object<ResetPasswordViewModel>();
    }
}
