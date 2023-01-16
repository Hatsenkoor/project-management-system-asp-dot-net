using Microsoft.AspNetCore.Mvc.Rendering;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class RoleModel
    {
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100)]

        [Display(Name = "Name")]
        public string RoleName { get; set; }

        public List<PCVMS_Roles> RoleList {get;set;}
    }
    public class RolePermissionModel
    {

        public Guid ID { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public bool Deleted { get; set; }



        public List<SelectListItem> RoleList { get; set; }

        public List<SelectListItem> PermissionList { get; set; }
    }
}
