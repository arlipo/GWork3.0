using Open.Data.Users;
using Open.Domain.Common;

namespace Open.Domain.Users
{
        public class User : NamedEntity<UsersData>
        {
            public User(UsersData r) : base(r) { }
        }
    }

