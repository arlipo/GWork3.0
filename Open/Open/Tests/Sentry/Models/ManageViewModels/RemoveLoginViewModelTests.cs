using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.ManageViewModels;
namespace Open.Tests.Sentry.Models.ManageViewModels {
    [TestClass] public class RemoveLoginViewModelTests : ObjectTests<RemoveLoginViewModel> {

        [TestMethod] public void LoginProviderTest() {
            isNullableReadWriteStringProperty(() => obj.LoginProvider, x => obj.LoginProvider = x);
            hasAttributes(o => o.LoginProvider);
        }

        [TestMethod] public void ProviderKeyTest() {
            isNullableReadWriteStringProperty(() => obj.ProviderKey, x => obj.ProviderKey = x);
            hasAttributes(o => o.ProviderKey);
        }

        protected override RemoveLoginViewModel getRandomObject() =>
            GetRandom.Object<RemoveLoginViewModel>();
    }
}