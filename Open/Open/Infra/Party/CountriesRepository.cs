using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Infra.Party {

    public class CountriesRepository : Repository<Country, CountryData>,
        ICountriesRepository {

        protected internal override async Task<CountryData> getObject(string id) {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }

        public CountriesRepository(SentryDbContext c) : base(c?.Countries, c) { }
        protected internal override Country createObject(CountryData r) {
            return new Country(r);
        }
        protected internal override PaginatedList<Country> createList(
            List<CountryData> l, RepositoryPage p) {
            return new CountriesList(l, p);
        }
    }
}



