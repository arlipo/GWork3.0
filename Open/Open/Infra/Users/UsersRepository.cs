using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Users;
using Open.Domain.Users;

namespace Open.Infra.Users
{
    public class UsersRepository : Repository<User, UsersData>,
        IUsersRepository
    {
        protected internal override async Task<UsersData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        protected internal override async Task<UsersData> getObjectByCode(string code)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Code == code);
        }

        public UsersRepository(SentryDbContext c) : base(c?.Users, c) { }
        protected internal override User createObject(UsersData r)
        {
            return new User(r);
        }
        protected internal override PaginatedList<User> createList(
            List<UsersData> l, RepositoryPage p)
        {
            return new UsersList(l, p);
        }
    }
}
