using Open.Data.Quantity;
using Open.Domain.Common;
namespace Open.Domain.Quantity {
    public sealed class Payment : Entity<PaymentData> {
        public readonly Money Amount;
        public readonly IPaymentMethod PaymentMethod;

        public Payment(PaymentData data) : base(data) {
            PaymentMethod = PaymentMethodFactory.Create(data?.PaymentMethod);
            var c = new Currency(data?.Currency);
            Amount = new Money(c, data?.Amount??0, data?.DateMade);
        }
    }
}
