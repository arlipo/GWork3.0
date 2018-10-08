using Open.Data.Quantity;
namespace Open.Domain.Quantity
{
    public sealed class DebitCard : CardPaymentMethod<DebitCardData>
    {
        public DebitCard(DebitCardData data) : base(data) { }
    }
}