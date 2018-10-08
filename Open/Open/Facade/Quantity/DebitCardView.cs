namespace Open.Facade.Quantity {
    public class DebitCardView : PaymentCardView {
        public override string ToString()
        {
            return $"Debit Card ({CardName}, {CardNumber})";
        }

    }
}