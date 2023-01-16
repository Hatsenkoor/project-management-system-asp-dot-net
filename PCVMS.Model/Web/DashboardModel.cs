using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class DashboardModel
    {
        public List<SelectListItem> PermissionList { get; set; }
        public List<SelectListItem> RoleList { get; set; }

        public Guid ProjectId { get; set; }
        public List<SelectListItem> ProjectList { get; set; }
    }
}
