using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_ProjectLocation")]
   public class PCVMS_ProjectLocation
    {
        public Guid ID { get; set; }
        public Guid ProjectID { get; set; }

        public Guid GovernorateID { get; set; }
        public Guid Wilayat { get; set; }
        public Guid Village { get; set; }
        public string Remark { get; set; }
        public bool? deleted { get; set; }
    }
}
