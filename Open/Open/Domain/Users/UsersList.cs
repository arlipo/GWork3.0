using System.Collections.Generic;
using Open.Core;
using Open.Data.Users;

namespace Open.Domain.Users
{
    public class UsersList : PaginatedList<User>
    {
        public UsersList(IEnumerable<UsersData> users, RepositoryPage page) : base(page)
        {
            if (users is null) return;
            foreach (var dbRecord in users)
            {
                Add(UserFactory.Create(dbRecord));
            }
        }
    }
}
