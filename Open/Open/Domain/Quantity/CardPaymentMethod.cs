using System;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public abstract class CardPaymentMethod<T>: PaymentMethod<T> where T : PaymentMethodData, new() {
        public readonly Money DailyLimit;

        protected readonly Currency currency;
        protected CardPaymentMethod(T data) : base(data) {
            currency = new Currency(data?.Currency);
            DailyLimit = new Money(currency, data?.DailyLimit??0, DateTime.Now);
        }

    }
}