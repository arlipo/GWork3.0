using Open.Core;
using Open.Domain.Users;

namespace Open.Facade.Users
{
    public class UserViewsList : PaginatedList<UserView>
    {
        public UserViewsList(IPaginatedList<User> list)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(UserViewFactory.Create(e)); }
        }
    }
}
