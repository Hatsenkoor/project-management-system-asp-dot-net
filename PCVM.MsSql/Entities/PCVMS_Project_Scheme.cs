using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Project_Scheme")]
    public   class PCVMS_Project_Scheme
    {
        public Guid ID { get; set; }
        public Guid Project_ID { get; set; }

        public Guid Permission_Scheme_ID { get; set; }
    }
}
