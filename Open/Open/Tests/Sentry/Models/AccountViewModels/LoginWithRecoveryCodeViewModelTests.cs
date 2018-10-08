using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.AccountViewModels;
namespace Open.Tests.Sentry.Models.AccountViewModels {
    [TestClass]
    public class LoginWithRecoveryCodeViewModelTests : ObjectTests<LoginWithRecoveryCodeViewModel>
    {
        [TestMethod] public void RecoveryCodeTest() {
            isNullableReadWriteStringProperty(() => obj.RecoveryCode, x => obj.RecoveryCode = x);
            hasAttributes(o => o.RecoveryCode, typeof(RequiredAttribute), typeof(DisplayAttribute),
                typeof(DataTypeAttribute));
        }

        protected override LoginWithRecoveryCodeViewModel getRandomObject() =>
            GetRandom.Object<LoginWithRecoveryCodeViewModel>();
    }
}