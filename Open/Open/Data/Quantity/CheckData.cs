namespace Open.Data.Quantity {
    public class CheckData : PaymentMethodData {

        private string payee;

        public string Payee {
            get => getString(ref payee);
            set => payee = value;
        }
    }
}