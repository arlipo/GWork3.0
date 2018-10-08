using System;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Facade.Quantity {
    public static class PaymentMethodViewFactory {
        public static PaymentMethodView Create(IPaymentMethod paymentMethod) {
            switch (paymentMethod) {
                case DebitCard debitCard:
                    return create(debitCard);
                case CreditCard creditCard:
                    return create(creditCard);
                case Check check:
                    return create(check);
                default:
                    return create();
            }
        }

        private static CashView create() {
            return new CashView{ID = "Cash"};
        }

        private static CheckView create(Check check) {
            var view = new CheckView {
                AccountName = check?.Data?.Name,
                AccountNumber = check?.Data?.Number,
                BankAddress = check?.Data?.Address,
                BankID = check?.Data?.Issue,
                BankName = check?.Data?.Organization,
                Payee = check?.Data?.Payee,
                CheckNumber = check?.Data?.Code,
                ID = check?.Data?.ID,
                ValidFrom = check?.Data?.ValidFrom,
                ValidTo = check?.Data?.ValidTo
            };
            return view;
        }

        private static CreditCardView create(CreditCard card) {

            var view = new CreditCardView
            {
                CardNumber = card?.Data?.Number,
                CreditLimit = card?.CreditLimit?.Amount?? 0,
                DailyLimit = card?.DailyLimit?.Amount ?? 0,
                CurrencyID = card?.Data?.CurrencyID,
                BillingAddress = card?.Data?.Address,
                CardName = card?.Data?.Organization,
                NameOnCard = card?.Data?.Name,
                VerificationCode = card?.Data?.Code,
                IssueNumber = card?.Data?.Issue,
                ID = card?.Data?.ID,
                ValidFrom = card?.Data?.ValidFrom,
                ExpireDate = card?.Data?.ValidTo
            };
            return view;
        }

        private static DebitCardView create(DebitCard card) {
            var view = new DebitCardView
            {
                CardNumber = card?.Data?.Number,
                DailyLimit = card?.DailyLimit?.Amount?? 0,
                CurrencyID = card?.Data?.CurrencyID,
                BillingAddress = card?.Data?.Address,
                CardName = card?.Data?.Organization,
                NameOnCard = card?.Data?.Name,
                VerificationCode = card?.Data?.Code,
                IssueNumber = card?.Data?.Issue,
                ID = card?.Data?.ID,
                ValidFrom = card?.Data?.ValidFrom,
                ExpireDate = card?.Data?.ValidTo
            };
            return view;
        }
        public static Cash Create(CashView view)
        {
            return new Cash();
        }

        public static Check Create(CheckView view)
        {
            var check = new CheckData
            {
                Name = view?.AccountName,
                Number = view?.AccountNumber,
                Address = view?.BankAddress,
                Issue = view?.BankID,
                Organization = view?.BankName,
                Payee = view?.Payee,
                Code = view?.CheckNumber,
                ID = view?.ID,
                ValidFrom = view?.ValidFrom?? DateTime.MinValue,
                ValidTo = view?.ValidTo ?? DateTime.MaxValue
                
            };
            return new Check(check);
        }

        public static CreditCard Create(CreditCardView view) {
            var card = new CreditCardData {
                Number = view?.CardNumber,
                CreditLimit = view?.CreditLimit ?? 0,
                DailyLimit = view?.DailyLimit ?? 0,
                CurrencyID = view?.CurrencyID,
                Address = view?.BillingAddress,
                Organization = view?.CardName,
                Name = view?.NameOnCard,
                Code = view?.VerificationCode,
                Issue = view?.IssueNumber,
                ID = view?.ID,
                ValidFrom = view?.ValidFrom ?? DateTime.MinValue,
                ValidTo = view?.ExpireDate ?? DateTime.MaxValue
            };
            card.Currency = new CurrencyData {ID = card.CurrencyID};
            return new CreditCard(card);
        }

        public static DebitCard Create(DebitCardView view)
        {
            var card = new DebitCardData
            {
                Number = view?.CardNumber,
                DailyLimit = view?.DailyLimit??0,
                CurrencyID = view?.CurrencyID,
                Address = view?.BillingAddress,
                Organization = view?.CardName,
                Name = view?.NameOnCard,
                Code = view?.VerificationCode,
                Issue = view?.IssueNumber,
                ID = view?.ID,
                ValidFrom = view?.ValidFrom ?? DateTime.MinValue,
                ValidTo = view?.ExpireDate ?? DateTime.MaxValue
            };
            card.Currency = new CurrencyData { ID = card.CurrencyID };
            return new DebitCard(card);
        }
    }
}