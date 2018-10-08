using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public static class PaymentMethodFactory {
        public static IPaymentMethod Create(PaymentMethodData data)
        {
            switch (data) {
                case DebitCardData debit: return create(debit);
                case CreditCardData credit: return create(credit);
                case CheckData check: return create(check);
                default: return new Cash();
            }
        }

        private static IPaymentMethod create(CheckData paymentMethod) {
            return new Check(paymentMethod);
        }

        private static IPaymentMethod create(CreditCardData paymentMethod)
        {
            return new CreditCard(paymentMethod);
        }

        private static IPaymentMethod create(DebitCardData paymentMethod) {
            return new DebitCard(paymentMethod);
        }
    }
}