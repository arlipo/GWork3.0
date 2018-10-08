using System;
using System.ComponentModel;
namespace Open.Facade.Quantity {
    public abstract class PaymentCardView: PaymentMethodView {
        private string cardNumber;
        private string cardName;
        private string nameOnCard;
        private string billingAddress;
        private string verificationCode;
        private string issueNumber;
        private string currencyID;

        [DisplayName("Name on card")] public string NameOnCard {
            get => getString(ref nameOnCard);
            set => nameOnCard = value;
        }
        [DisplayName("Card name")] public string CardName {
            get => getString(ref cardName);
            set => cardName = value;
        }
        [DisplayName("Card number")] public string CardNumber {
            get => getString(ref cardNumber);
            set => cardNumber = value;
        }
        [DisplayName("Currency ID")] public string CurrencyID {
            get => getString(ref currencyID);
            set => currencyID = value;
        }
        [DisplayName("Daily limit")] public decimal DailyLimit { get; set; }
        [DisplayName("Billing address")] public string BillingAddress {
            get => getString(ref billingAddress);
            set => billingAddress = value;
        }
        [DisplayName("Issue number")] public string IssueNumber {
            get => getString(ref issueNumber);
            set => issueNumber = value;
        }
        [DisplayName("Verification code")] public string VerificationCode {
            get => getString(ref verificationCode);
            set => verificationCode = value;
        }
        [DisplayName("Expire date")] public DateTime? ExpireDate {
            get => ValidTo;
            set => ValidTo = value;
        }
    }
}