using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Roles_Group")]
    public  class PCVMS_Roles_Group
    {
        public Guid ID { get; set; }
        public Guid RoleId { get; set; }

        public Guid RoleGroupId { get; set; }

        public bool Deleted { get; set; }
        //public List<PCVMS_Role_Permission> PCVMS_Role_Permission { get; set; }
    }
}
