using System.Threading.Tasks;
using Open.Core;
using Open.Domain.Party;
namespace Open.Domain.Quantity {
    public interface INationalCurrenciesRepository
        : ICrudRepository<NationalCurrency> {
        Task LoadCountries(Currency currency);
        Task LoadCurrencies(Country country);
    }
}



