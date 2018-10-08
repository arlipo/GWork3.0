using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {
    public interface IPaymentsRepository : IRepository<Payment, PaymentData> { }
}