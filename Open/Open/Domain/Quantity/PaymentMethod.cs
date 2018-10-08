using Open.Data.Quantity;
using Open.Domain.Common;
namespace Open.Domain.Quantity {
    public abstract class PaymentMethod<T>: Entity<T>, IPaymentMethod where T: PaymentMethodData, new() {
        public string ID { get; }
        protected PaymentMethod(T data) : base(data) { ID = data?.ID; }
    }
}