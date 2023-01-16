using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Role_Scheme")]
    public class PCVMS_Role_Scheme
    {
        public Guid ID { get; set; }
        public Guid RoleId { get; set; }
        public Guid SchemeId { get; set; }
        public bool Deleted { get; set; }
    }
}
