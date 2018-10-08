using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.ManageViewModels;
namespace Open.Tests.Sentry.Models.ManageViewModels {
    [TestClass]
    public class ShowRecoveryCodesViewModelTests : ObjectTests<ShowRecoveryCodesViewModel> {

        [TestMethod] public void RecoveryCodesTest() {
            isNullableReadWriteProperty(() => obj.RecoveryCodes, x => obj.RecoveryCodes = x, () =>
                GetRandom.Object<List<string>>()
                    .ToArray());
            hasAttributes(o => o.RecoveryCodes);
        }

        protected override ShowRecoveryCodesViewModel getRandomObject() =>
            new ShowRecoveryCodesViewModel {
                RecoveryCodes = GetRandom.Object<List<string>>().ToArray()
            };
    }
}