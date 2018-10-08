using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Open.Facade.Quantity {
    public class CheckView : PaymentMethodView {

        public string Payee { get; set; }

        [DisplayName("Account Name")] public string AccountName { get; set; }
        [DisplayName("Account Number")] public string AccountNumber { get; set; }
        [DisplayName("Bank Address")] public string BankAddress { get; set; }
        [DisplayName("Bank Identification Number")] public string BankID { get; set; }
        [DisplayName("Bank Name")] public string BankName { get; set; }
        [DisplayName("Check Number")] public string CheckNumber { get; set; }

        [DataType(DataType.Date)] [DisplayName("Date Written")]
        public DateTime? DateWritten { get => ValidFrom; set => ValidFrom = value; }

        public override string ToString() { return $"Check ({CheckNumber}, {BankName})"; }
    }
}


