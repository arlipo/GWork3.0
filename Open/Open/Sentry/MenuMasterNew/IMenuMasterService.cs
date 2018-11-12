using System.Collections.Generic;
using Open.Data.MenuMaster;

namespace Open.Sentry.MenuMasterNew
{
    public interface IMenuMasterService
    {
        IEnumerable<MenuMasterData> GetMenuMaster();
        IEnumerable<MenuMasterData> GetMenuMaster(string UserRole);
    }
}

