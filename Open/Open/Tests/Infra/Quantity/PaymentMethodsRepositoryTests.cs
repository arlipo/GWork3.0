using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Infra.Quantity;
namespace Open.Tests.Infra.Quantity {
    [TestClass]
    public class
        PaymentMethodsRepositoryTests : PaginatedRepositoryTests<IPaymentMethod, PaymentMethodData> {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(PaymentMethodsRepository);
        }
        protected override string getRandomMemberStringValue(PaymentMethodData d)
        {
            var i = GetRandom.UInt32() % 10;
            if (i == 0) return d.Code;
            if (i == 1) return d.Address;
            if (i == 2) return d.ID;
            if (i == 3) return d.Name;
            if (i == 4) return d.CurrencyID;
            if (i == 5) return d.DailyLimit.ToString(CultureInfo.CurrentCulture);
            if (i == 6) return d.Issue;
            if (i == 7) return d.Number;
            if (i == 8) return d.Organization;
            return base.getRandomMemberStringValue(d);
        }
        protected override Func<PaymentMethodData, object> getRandomSortFunction()
        {
            var i = GetRandom.UInt32() % 11;
            if (i == 0) return x => x.Code;
            if (i == 1) return x => x.Address;
            if (i == 2) return x => x.ID;
            if (i == 3) return x => x.Name;
            if (i == 4) return x => x.CurrencyID;
            if (i == 5) return x => x.DailyLimit;
            if (i == 6) return x => x.Issue;
            if (i == 7) return x => x.Number;
            if (i == 8) return x => x.Organization;
            if (i == 9) return x => x.ValidFrom;
            return x => x.ValidTo;
        }
        protected override IPaymentMethod createObject(PaymentMethodData r) =>
            PaymentMethodFactory.Create(r);
        protected override PaymentMethodData getData(IPaymentMethod o) {
            switch (o) {
                case Check check: return check.Data;
                case DebitCard debit: return debit.Data;
                case CreditCard credit: return credit.Data;
                default: return new CheckData();
            }
        }
        protected override PaymentMethodData getRandomDbRecord() {
            var i = GetRandom.Int32() % 3;
            if (i == 0) return GetRandom.Object<CheckData>();
            if (i == 1) return GetRandom.Object<DebitCardData>();
            return GetRandom.Object<CreditCardData>();
        }

        protected override string getID(PaymentMethodData r) => r.ID;

        protected override ICrudRepository<IPaymentMethod> getRepository() =>
            new PaymentMethodsRepository(db);

        protected override DbSet<PaymentMethodData> getDbSet() => db.PaymentMethods;

        [TestMethod] public void CanCreateWithNullTest() {
            Assert.IsNotNull(new PaymentMethodsRepository(null));
        }

    }
}

