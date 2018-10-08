using Open.Core;
using Open.Domain.Party;
namespace Open.Facade.Party {

    public class AddressViewsList : PaginatedList<AddressView> {
        public AddressViewsList(IPaginatedList<IAddress> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(AddressViewFactory.Create(e)); }
        }
    }

}

