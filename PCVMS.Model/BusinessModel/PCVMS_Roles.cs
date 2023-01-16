using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class PCVMS_Roles
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }

        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public Guid? Permission_Master_ID { get; set; }

        


    }
    public class PCVMS_Role_GroupName
    {
        public Guid ID { get; set; }
        public string RoleGroupNameEn { get; set; }
        public string RoleGroupNameAR { get; set; }
        public bool Deleted { get; set; }
    }
    public class PCVMS_Role_Permission
    {
        public Guid ID { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public bool Deleted { get; set; }



    }
    public class PCVMS_Role_Scheme
    {
        public Guid ID { get; set; }
        public Guid RoleId { get; set; }
        public Guid SchemeId { get; set; }
        public bool Deleted { get; set; }
    }
}
