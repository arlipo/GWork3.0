using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity
{
    [TestClass]
    public class PaymentsRepositoryTests : PaginatedRepositoryTests<Payment, PaymentData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PaymentsRepository);
        }
        protected override string getRandomMemberStringValue(PaymentData d)
        {
            var i = GetRandom.UInt32() % 7;
            if (i == 0) return d.CurrencyID;
            if (i == 1) return d.Amount.ToString(CultureInfo.CurrentCulture);
            if (i == 2) return d.ID;
            if (i == 3) return d.PaymentMethodID;
            if (i == 4) return d.DateDue.ToString(CultureInfo.CurrentCulture);
            if (i == 5) return d.DateMade.ToString(CultureInfo.CurrentCulture);
            return base.getRandomMemberStringValue(d);
        }
        protected override Func<PaymentData, object> getRandomSortFunction()
        {
            var i = GetRandom.UInt32() % 8;
            if (i == 0) return x => x.CurrencyID;
            if (i == 1) return x => x.Amount;
            if (i == 2) return x => x.ID;
            if (i == 3) return x => x.PaymentMethodID;
            if (i == 4) return x => x.DateDue;
            if (i == 5) return x => x.DateMade;
            if (i == 6) return x => x.ValidFrom;
            return x => x.ValidTo;
        }

        protected override Payment createObject(PaymentData r) => new Payment(r);

        protected override PaymentData getData(Payment o) => o.Data;

        protected override string getID(PaymentData r) => r.ID;

        protected override ICrudRepository<Payment> getRepository() => new PaymentsRepository(db);

        protected override DbSet<PaymentData> getDbSet() => db.Payments;
    }
}

