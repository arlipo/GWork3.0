using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.AccountViewModels;
namespace Open.Tests.Sentry.Models.AccountViewModels {
    [TestClass] public class LoginViewModelTests : ObjectTests<LoginViewModel> {

        protected override LoginViewModel getRandomObject() => GetRandom.Object<LoginViewModel>();

        [TestMethod] public void EmailTest() {
            isNullableReadWriteStringProperty(() => obj.Email, x => obj.Email = x);
            hasAttributes(o => o.Email, typeof(RequiredAttribute), typeof(EmailAddressAttribute));
        }

        [TestMethod] public void PasswordTest() {
            isNullableReadWriteStringProperty(() => obj.Password, x => obj.Password = x);
            hasAttributes(o => o.Password, typeof(RequiredAttribute), typeof(DataTypeAttribute));
        }

        [TestMethod] public void RememberMeTest() {
            canReadWrite(() => obj.RememberMe, x => obj.RememberMe = x);
            hasAttributes(o => o.RememberMe, typeof(DisplayAttribute));
        }

    }
}
