using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class PaymentsListTests : ListBaseTests<PaymentsList, Payment> {
        protected override PaymentsList getRandomObject() {
            createWithNullArgs = new PaymentsList(null, null);
            var l = GetRandom.Object<List<PaymentData>>();
            return new PaymentsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}