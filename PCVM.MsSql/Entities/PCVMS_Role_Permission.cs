using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Role_Permission")]
    public class PCVMS_Role_Permission
    {
        public Guid ID { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        
        public bool Deleted { get; set; }
       
      //  public PCVMS_Roles_Group PCVMS_Roles_Group { get; set; }

    }
}
