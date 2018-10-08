using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Data.Quantity;
using Open.Domain.Party;
using Open.Domain.Quantity;
namespace Open.Infra.Quantity {
    public class NationalCurrenciesRepository : BaseRepository<NationalCurrency, NationalCurrencyData>, 
        INationalCurrenciesRepository {
        public NationalCurrenciesRepository(SentryDbContext c): base(c?.CountryCurrencies, c) { }
        public async Task LoadCountries(Currency currency) {
            if (currency is null) return;
            var id = currency.Data?.ID ?? string.Empty;
            var countries = await dbSet.Include(x => x.Country).Where(x => x.CurrencyID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in countries)
                currency.UsedInCountry(new Country(c.Country));
        }
        public async Task LoadCurrencies(Country country) {
            if (country is null) return;
            var id = country.Data?.ID ?? string.Empty;
            var currencies = await dbSet.Include(x => x.Currency).Where(x => x.CountryID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in currencies)
                country.CurrencyInUse(new Currency(c.Currency));
        }
        protected internal override NationalCurrency createObject(NationalCurrencyData r) {
            return new NationalCurrency(r);
        }
        protected internal override async Task<NationalCurrencyData> getObject(string id) {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.CountryID == id || x.CurrencyID == id);
        }
    }
}


