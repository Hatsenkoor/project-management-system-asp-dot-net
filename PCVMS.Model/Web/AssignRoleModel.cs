
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class AssignRoleModel
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleGroupId { get; set; }

        public Guid UserGroupId { get; set; }

        public List<SelectListItem> UserList { get; set; }

        public List<SelectListItem> RoleList { get; set; }

        public List<SelectListItem> RoleGroupList { get; set; }

        public List<SelectListItem> UserGroupList { get; set; }

        public string FromDate { get; set; }
        public string EndDate { get; set; }
    }
}
