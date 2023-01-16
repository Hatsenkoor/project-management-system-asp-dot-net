using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class PCVMS_User_Model
    {
        public Guid UserId { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Token { get; set; }

        public string NameEn { get; set; }

        public bool Active { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
        public string CardID { get; set; }
        public string JobTitle { get; set; }

        public string Department { get; set; }
        public string LandLine { get; set; }

        public string Fax { get; set; }
        public string Remark { get; set; }

        public Guid ProfileId { get; set; }
        public Roles_Modle Roles_Modle { get; set; }
        public AssignRoleModel AssignRoleModel { get; set; }
        public RolePermissionModel RolePermissionModel { get; set; }
        public PCVMS_Project_Model PCVMS_Project_Model { get; set; }
        public PCVMS_User_Group_Name_Model PCVMS_User_Group_Name_Model { get; set; }
    }
    public class UserRole {
        public Guid UserId { get; set; }
        public string NameEn { get; set; }
    }
    public class PCVMS_User_Group_Name_Model
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public List<SelectListItem> UserList { get; set; }
        public List<SelectListItem> PCVMS_User_Group_NameList { get; set; }
    }
}
