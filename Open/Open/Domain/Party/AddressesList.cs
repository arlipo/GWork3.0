using System.Collections.Generic;
using Open.Core;
using Open.Data.Party;
namespace Open.Domain.Party
{
    public class AddressesList : PaginatedList<IAddress>
    {
        public AddressesList(IEnumerable<AddressData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(AddressFactory.Create(dbRecord));
            }
        }
    }
}




