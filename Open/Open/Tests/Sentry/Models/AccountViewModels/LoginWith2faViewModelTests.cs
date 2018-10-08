using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.AccountViewModels;
namespace Open.Tests.Sentry.Models.AccountViewModels {
    [TestClass] public class LoginWith2FaViewModelTests : ObjectTests<LoginWith2FaViewModel> {
        [TestMethod] public void TwoFactorCodeTest() {
            isNullableReadWriteStringProperty(() => obj.TwoFactorCode, x => obj.TwoFactorCode = x);
            hasAttributes(o => o.TwoFactorCode, typeof(RequiredAttribute), typeof(DisplayAttribute),
                typeof(DataTypeAttribute), typeof(StringLengthAttribute));
        }

        [TestMethod] public void RememberMachineTest() {
            canReadWrite(() => obj.RememberMachine, x => obj.RememberMachine = x);
            hasAttributes(o => o.RememberMachine, typeof(DisplayAttribute));
        }

        [TestMethod] public void RememberMeTest() {
            canReadWrite(() => obj.RememberMe, x => obj.RememberMe = x);
            hasAttributes(o => o.RememberMe, typeof(DisplayAttribute));
        }

        protected override LoginWith2FaViewModel getRandomObject() =>
            GetRandom.Object<LoginWith2FaViewModel>();
    }
}
