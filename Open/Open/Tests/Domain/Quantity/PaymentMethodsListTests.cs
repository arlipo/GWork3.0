using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass]
    public class PaymentMethodsListTests : ListBaseTests<PaymentMethodsList, IPaymentMethod> {
        protected override PaymentMethodsList getRandomObject() {
            createWithNullArgs = new PaymentMethodsList(null, null);
            var l = getRandomPaymentMethodDbRecordsList();
            return new PaymentMethodsList(l, GetRandom.Object<RepositoryPage>());
        }
        internal static IEnumerable<PaymentMethodData> getRandomPaymentMethodDbRecordsList() {
            var l = new List<PaymentMethodData>();
            for (var i = 0; i < GetRandom.UInt8(5, 10); i++) {
                l.Add(getRandomPaymentMethodDbRecord(i));
            }

            return l;
        }
        internal static PaymentMethodData getRandomPaymentMethodDbRecord(int i = int.MinValue) {
            i = i == int.MinValue ? GetRandom.UInt8() : i;
            var x = i % 3;
            if (x == 0) return GetRandom.Object<CheckData>();
            if (x == 1) return GetRandom.Object<DebitCardData>();
            return GetRandom.Object<CreditCardData>();
        }
    }
}
