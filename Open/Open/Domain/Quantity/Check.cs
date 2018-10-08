using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public sealed class Check : PaymentMethod<CheckData> {
        public Check(CheckData data) : base(data) { }
    }
}