using Open.Core;
using Open.Domain.Party;
namespace Open.Facade.Party {
    public class CountryViewsList : PaginatedList<CountryView> {
        public CountryViewsList(IPaginatedList<Country> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) {
                Add(CountryViewFactory.Create(e));
            }
        }
    }
}



