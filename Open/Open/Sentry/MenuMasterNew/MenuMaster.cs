using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Open.Sentry.MenuMasterNew
{
    public class MenuMaster
    {
        [Key]
        public int MenuIdentity { get; set; }
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public string Parent_MenuID { get; set; }
        public string User_Roll { get; set; }
        public string MenuFileName { get; set; }
        public string MenuURL { get; set; }
        public string USE_YN { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}