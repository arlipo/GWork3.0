using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Open.Sentry.Data;

namespace Open.Sentry.MenuMasterNew
{
    public class MenuMasterService : IMenuMasterService
    {
        private readonly ApplicationDbContext _dbContext;

        public MenuMasterService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MenuMaster> GetMenuMaster()
        {
            return _dbContext.MenuMaster.AsEnumerable();

        }

        public IEnumerable<MenuMaster> GetMenuMaster(string UserRole)
        {
            var result = _dbContext.MenuMaster.Where(m => m.User_Roll == UserRole).ToList();
            return result;
        }
    }
}