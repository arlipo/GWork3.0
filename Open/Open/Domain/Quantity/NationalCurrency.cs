using Open.Data.Party;
using Open.Data.Quantity;
using Open.Domain.Common;
using Open.Domain.Party;
namespace Open.Domain.Quantity {
    public class NationalCurrency : Period<NationalCurrencyData> {
        public readonly Country Country;
        public readonly Currency Currency;
        public NationalCurrency(NationalCurrencyData dbRecord) : base(dbRecord) {
            Data.Country = Data.Country ?? new CountryData();
            Data.Currency = Data.Currency ?? new CurrencyData();

            Country = new Country(Data.Country);
            Currency = new Currency(Data.Currency);
        }
    }
}



