using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public interface IPaymentMethodsRepository : IRepository<IPaymentMethod, PaymentMethodData> { }
}