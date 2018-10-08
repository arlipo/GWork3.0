using Open.Data.Quantity;
using Open.Domain.Common;
namespace Open.Domain.Quantity {
    public class Rate : Entity<RateData> {
        public readonly Currency Currency;
        public readonly RateType RateType;
        public Rate(RateData data) : base(data) {
            Currency = new Currency(data?.Currency);
            RateType = new  RateType(data?.RateType);
        }
        public Rate() : this(null) { }


    }
}