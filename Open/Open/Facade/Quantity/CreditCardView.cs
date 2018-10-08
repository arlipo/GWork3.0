using System.ComponentModel;
namespace Open.Facade.Quantity {
    public class CreditCardView : PaymentCardView {
        [DisplayName("Credit limit")] public decimal CreditLimit { get; set; }
        public override string ToString() {
            return $"Credit Card ({CardName}, {CardNumber})";
        }
    }
}