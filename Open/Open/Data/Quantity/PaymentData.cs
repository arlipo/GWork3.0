using System;
using Open.Data.Common;
namespace Open.Data.Quantity {
    public class PaymentData : IdentifiedData {
        public decimal Amount { get; set; }

        public DateTime DateDue { get; set; }

        public DateTime DateMade {
            get => ValidFrom;
            set => ValidFrom = value;
        }

        public string CurrencyID { get; set; }

        public virtual CurrencyData Currency { get; set; }

        public string PaymentMethodID { get; set; }

        public virtual PaymentMethodData PaymentMethod { get; set; }
    }
}
