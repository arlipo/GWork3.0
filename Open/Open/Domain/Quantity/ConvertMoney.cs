using System;
namespace Open.Domain.Quantity {
    public static class ConvertMoney {
        internal static IRateRepository rates;

        public static Money ToCurrency(Money m, Currency c) {
            var dt = m?.Date ?? DateTime.Now;
            var amount = m?.Amount ?? 0M;
            var rateFrom = getRate(m?.Currency, dt);
            var rateTo = getRate(c, dt);
            try {
                amount = amount / rateFrom;
                amount = amount * rateTo;
            } catch { amount = decimal.MaxValue; }
            return new Money(c, amount, dt);
        }

        internal static decimal getRate(Currency c, DateTime dt) {
            if (c is null) return decimal.Zero;
            var rateID = RateFactory.CalculateID(c.ID, dt, RateFactory.EuroRate);
            var rate = rates?.GetRate(rateID);
            var r = rate?.Data?.Rate;
            if (r is null || r == 0) r = getClosestKnownRate(c, dt);
            return (decimal) r;
        }

        internal static decimal getClosestKnownRate(Currency c, DateTime dt) {
            var r = decimal.One;
            var d = DateTime.MaxValue.Ticks;
            if (c is null) return decimal.Zero;
            var l = rates?.GetRates(c);
            if (l == null) return r;
            foreach (var e in l) {
                var d1 = Math.Abs(e.Data.ValidFrom.Date.Ticks - dt.Date.Ticks);
                if (d1 > d) continue;
                d = d1;
                r = e.Data.Rate;
            }

            return r;
        }
    }
}