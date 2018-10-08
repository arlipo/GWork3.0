using Open.Data.Quantity;
using Open.Domain.Common;
namespace Open.Domain.Quantity {
    public sealed class RateType : Metrics<RateTypeData> {
        public RateType() : this(null) { }
        public RateType(RateTypeData dbRecord) : base(dbRecord) { }
    }
}