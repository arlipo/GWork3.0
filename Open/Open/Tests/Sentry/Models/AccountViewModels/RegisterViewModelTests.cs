using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.AccountViewModels;
namespace Open.Tests.Sentry.Models.AccountViewModels {
    [TestClass] public class RegisterViewModelTests : ObjectTests<RegisterViewModel> {
        [TestMethod] public void EmailTest() {
            isNullableReadWriteStringProperty(() => obj.Email, x => obj.Email = x);
            hasAttributes(o => o.Email, typeof(RequiredAttribute), typeof(DisplayAttribute),
                typeof(EmailAddressAttribute));
        }

        [TestMethod] public void PasswordTest() {
            isNullableReadWriteStringProperty(() => obj.Password, x => obj.Password = x);
            hasAttributes(o => o.Password, typeof(RequiredAttribute), typeof(DisplayAttribute),
                typeof(DataTypeAttribute), typeof(StringLengthAttribute));
        }

        [TestMethod] public void ConfirmPasswordTest() {
            isNullableReadWriteStringProperty(() => obj.ConfirmPassword,
                x => obj.ConfirmPassword = x);
            hasAttributes(o => o.ConfirmPassword, typeof(CompareAttribute),
                typeof(DisplayAttribute), typeof(DataTypeAttribute));
        }

        protected override RegisterViewModel getRandomObject() =>
            GetRandom.Object<RegisterViewModel>();
    }
}
