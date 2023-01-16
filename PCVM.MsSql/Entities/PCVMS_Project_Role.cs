using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Project_Role")]
    public class PCVMS_Project_Role
    {
        public Guid ID { get; set; }
        public Guid ProjectId { get; set; }
        public Guid RoleId { get; set; }
        public bool Deleted { get; set; }
    }
}
