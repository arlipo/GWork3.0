using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models;
namespace Open.Tests.Sentry.Models
{
    [TestClass]
    public class ErrorViewModelTests : ObjectTests<ErrorViewModel> {

        protected override ErrorViewModel getRandomObject() => GetRandom.Object<ErrorViewModel>();

        [TestMethod] public void RequestIdTest() {
            isNullableReadWriteStringProperty(() => obj.RequestId, x => obj.RequestId = x);
            hasAttributes(o => o.RequestId);
        }

        [TestMethod] public void ShowRequestIdTest() {
            obj.RequestId = null;
            Assert.IsFalse(obj.ShowRequestId);
            obj.RequestId = string.Empty;
            Assert.IsFalse(obj.ShowRequestId);
            obj.RequestId = GetRandom.String();
            Assert.IsTrue(obj.ShowRequestId);
            hasAttributes(o => o.ShowRequestId);
        }

    }
}