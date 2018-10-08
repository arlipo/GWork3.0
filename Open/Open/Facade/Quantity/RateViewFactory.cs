using Open.Aids;
using Open.Domain.Quantity;
namespace Open.Facade.Quantity {
    public static class RateViewFactory {
        public static RateView Create(Rate o) {
            var v = new RateView {
                Rate = o?.Data.Rate ?? 0,
                ID = o?.Data.ID,
                RateTypeID = o?.Data.RateTypeID,
                CurrencyID = o?.Data.CurrencyID
            };
            if (o is null) return v;
            v.ValidFrom = Date.SetNullIfMaxOrMin(o.Data.ValidFrom);
            v.ValidTo = Date.SetNullIfMaxOrMin(o.Data.ValidTo);
            return v;
        }
    }
}