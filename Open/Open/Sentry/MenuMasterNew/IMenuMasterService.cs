using System;
using System.Collections.Generic;

namespace Open.Sentry.MenuMasterNew
{
    public interface IMenuMasterService
    {
        IEnumerable<MenuMaster> GetMenuMaster();
        IEnumerable<MenuMaster> GetMenuMaster(String UserRole);
    }
}

