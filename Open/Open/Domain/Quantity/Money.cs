using System;
using Open.Core;
namespace Open.Domain.Quantity {
    public class Money : Common.Value<Currency, decimal, Money>, IComparable<Money> {
        private RoundingPolicy rounding;

        public Money() : this(null) { }

        public Money(Currency c, decimal amount = 0, DateTime? dt = null) : base(
            c ?? new Currency(), amount) {
            Date = dt ?? DateTime.Now;
        }

        public override Money Add(Money m) {
            var money = ConvertMoney.ToCurrency(this, m.Currency);
            return new Money(m.Currency, m.Amount + money.Amount, m.Date);
        }

        public override int CompareTo(Money m) {
            var money = ConvertMoney.ToCurrency(m, Currency);
            return Amount.CompareTo(money.Amount);
        }

        public override Money ConvertTo(Currency c) { return ConvertMoney.ToCurrency(this, c); }

        public DateTime Date { get; }

        public override Money Divide(decimal d) {
            d = d == decimal.Zero? decimal.MaxValue : Amount / d;
            var m = new Money(Currency, d, Date);
            return m;
        }

        public Currency Currency => unit;

        public override Money Multiply(decimal d) {
            d = Amount * d;
            var m = new Money(Currency, d, Date);
            return m;
        }

        public override Money Round(RoundingPolicy policy) {
            rounding = policy;
            var d = round();
            return new Money(Currency, d);
        }

        public override Money Subtract(Money m) {
            var money = ConvertMoney.ToCurrency(this, m.Currency);
            return new Money(m.Currency, money.Amount - m.Amount, m.Date);
        }

        internal decimal round() {
            var p = rounding;
            var d = Amount;
            if (p.Strategy == RoundingStrategy.RoundUp) return Rounding.Up(d, p.Decimals);
            if (p.Strategy == RoundingStrategy.RoundDown) return Rounding.Down(d, p.Decimals);
            if (p.Strategy == RoundingStrategy.RoundUpByStep) return Rounding.UpByStep(d, p.Step);
            if (p.Strategy == RoundingStrategy.RoundDownByStep)
                return Rounding.DownByStep(d, p.Step);
            if (p.Strategy == RoundingStrategy.RoundTowardsPositive)
                return Rounding.TowardsPositive(d, p.Decimals);
            if (p.Strategy == RoundingStrategy.RoundTowardsNegative)
                return Rounding.TowardsNegative(d, p.Decimals);
            return Rounding.Off(d, p.Decimals, p.Digit);
        }

        public override int CompareTo(object obj) { return CompareTo(obj as Money); }
    }
}
