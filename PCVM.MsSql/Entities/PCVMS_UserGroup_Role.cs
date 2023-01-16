using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_UserGroup_Role")]
   public class PCVMS_UserGroup_Role
    {
        public Guid ID { get; set; }
        public Guid UserGroupID { get; set; }
        public Guid RoleId { get; set; }
        public bool Deleted { get; set; }
    }

}
