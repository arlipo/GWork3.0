using Open.Data.Common;
namespace Open.Data.Quantity {
    public class PaymentMethodData : IdentifiedData {
        public decimal DailyLimit { get; set; }
        public string Code { get; set; }
        public string Issue { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string CurrencyID { get; set; }
        public virtual CurrencyData Currency { get; set; }
    }
}