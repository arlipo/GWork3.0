using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity
{
    [TestClass]
    public class PaymentMethodViewsListTests : ObjectTests<PaymentMethodViewsList>
    {
        protected override PaymentMethodViewsList getRandomObject()
        {
            var l = new PaymentMethodViewsList(null);
            setRandomValues(l);
            return l;
        }

        private static void setRandomValues(PaymentMethodViewsList l) {
            var count = GetRandom.UInt8(5, 20);
            for (var i = 0; i < count; i++) {
                var x = GetRandom.UInt16() % 3;
                if (x == 0) l.Add(GetRandom.Object<DebitCardView>());
                if (x == 1) l.Add(GetRandom.Object<CreditCardView>());
                if (x == 2) l.Add(GetRandom.Object<CheckView>());
            }
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new PaymentMethodViewsList(null));
        }
    }
}