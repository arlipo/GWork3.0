using Open.Core;
namespace Open.Domain.Quantity {
    public sealed class Cash : Archetype, IPaymentMethod {
        public string ID { get; } = "Cash";
    }
}