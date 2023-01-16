using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Roles")]
    public   class PCVMS_Roles
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }

        public string NameAr { get; set; }
        public bool Deleted { get; set; }

        public Guid Permission_Master_ID { get; set; }

       
    }
}
