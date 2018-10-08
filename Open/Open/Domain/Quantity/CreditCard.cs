using System;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public sealed class CreditCard : CardPaymentMethod<CreditCardData> {
        public readonly Money CreditLimit;

        public CreditCard(CreditCardData data) : base(data) {
            CreditLimit = new Money(currency, data.CreditLimit, DateTime.Now);
        }
    }
}