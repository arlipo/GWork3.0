using System;
using System.ComponentModel;
namespace Open.Facade.Quantity
{
    public class PaymentView : MoneyView
    {
        [DisplayName("Payment Method")] public string PaymentMethodID { get; set; }

        [DisplayName("Date Made")]
        public DateTime? DateMade {
            get => ValidFrom;
            set => ValidFrom = value;
        }

        [DisplayName("Date Due")] public DateTime? DateDue { get; set; }
    }
}