using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class PCVMS_User
    {
        public Guid UserId { get; set; }
        public string NameEn { get; set; }
        public string nameAr { get; set; }
        public string Password { get; set; }
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





       

        public List<PCVMS_User_Role> UserRoles { get; set; }

        public List<PCVMS_User_RoleGroups> PCVMS_User_RoleGroups { get; set; }

        public List<PCVMS_Permission> PermissionList { get; set; }



    }
    public class PCVMS_User_RoleGroups
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleGroupId { get; set; }
        public bool Deleted { get; set; }
        public PCVMS_User PCVMS_User { get; set; }
    }
    public class PCVMS_User_Role
    {
        public Guid ID { get; set; }
        public Guid RoleId { get; set; }

        public Guid UserId { get; set; }

        public bool Deleted { get; set; }
        public PCVMS_User PCVMS_User { get; set; }

        public List<PCVMS_Role_Permission> PCVMS_Role_Permission { get; set; }
    }
    public class PCVMS_User_Group_Name
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
    }
    public class PCVMS_User_Group
    {
        public Guid ID { get; set; }
        public Guid GroupId { get; set; }

        public Guid UserId { get; set; }

        public bool Deleted { get; set; }
    }
}
