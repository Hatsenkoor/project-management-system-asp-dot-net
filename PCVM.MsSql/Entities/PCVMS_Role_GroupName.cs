using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Role_GroupName")]
    public  class PCVMS_Role_GroupName
    {
        public Guid ID { get; set; }
        public string RoleGroupNameEn { get; set; }
        public string RoleGroupNameAR { get; set; }
        public bool Deleted { get; set; }
    }
}
