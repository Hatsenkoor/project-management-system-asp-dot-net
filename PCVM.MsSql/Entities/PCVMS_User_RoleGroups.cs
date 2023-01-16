using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_User_RoleGroups")]
    public  class PCVMS_User_RoleGroups
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleGroupId { get; set; }
        public bool Deleted { get; set; }
       // public PCVMS_User PCVMS_User { get; set; }
       // public List<PCVMS_Roles_Group> PCVMS_Roles_Group { get; set; }

        
    }
}
