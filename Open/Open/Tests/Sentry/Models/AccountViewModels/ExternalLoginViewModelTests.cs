using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.AccountViewModels;
namespace Open.Tests.Sentry.Models.AccountViewModels {
    [TestClass] public class ExternalLoginViewModelTests : ObjectTests<ExternalLoginViewModel> {

        [TestMethod] public void EmailTest() {
            isNullableReadWriteStringProperty(() => obj.Email, x => obj.Email = x);
            hasAttributes(o => o.Email, typeof(RequiredAttribute), typeof(EmailAddressAttribute));
        }

        protected override ExternalLoginViewModel getRandomObject() => GetRandom.Object<ExternalLoginViewModel>();
    }
}
