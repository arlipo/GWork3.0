using System.Collections.Generic;
using Open.Core;
using Open.Data.Party;
namespace Open.Domain.Party {

    public class CountriesList : PaginatedList<Country> {
        public CountriesList(IEnumerable<CountryData> items, RepositoryPage page): base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) {
                Add(new Country(dbRecord));
            }
        }
    }
}


