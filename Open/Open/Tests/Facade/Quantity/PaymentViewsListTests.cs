using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class PaymentViewsListTests : ObjectTests<PaymentViewsList> {
        protected override PaymentViewsList getRandomObject() {
            var payments = new PaymentsList(null, null);
            SetRandom.Values(payments);
            var l = new PaymentViewsList(payments);
            return l;
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new PaymentViewsList(null));
        }
    }
}