using System;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Facade.Quantity {
    public class PaymentViewFactory {
        public static PaymentView Create(Payment o) {
            var v = new PaymentView {
                Amount = o?.Amount?.Amount ?? 0,
                PaymentMethodID = o?.Data.PaymentMethodID,
                CurrencyID = o?.Data.CurrencyID,
                ID = o?.Data?.ID
            };
            if (o is null) return v;
            v.DateDue = Date.SetNullIfMaxOrMin(o.Data.DateDue);
            v.DateMade = Date.SetNullIfMaxOrMin(o.Data.DateMade);
            v.ValidTo = Date.SetNullIfMaxOrMin(o.Data.ValidTo);
            return v;
        }
        public static Payment Create(PaymentView v) {
            var r = new PaymentData {
                Amount = v?.Amount ?? 0,
                PaymentMethodID = v?.PaymentMethodID,
                CurrencyID = v?.CurrencyID,
                DateDue = v?.DateDue ?? DateTime.MinValue,
                DateMade = v?.DateMade ?? DateTime.MinValue,
                ValidTo = v?.ValidTo ?? DateTime.MaxValue,
                ID = v?.ID
            };
            return new Payment(r);
        }
    }
}