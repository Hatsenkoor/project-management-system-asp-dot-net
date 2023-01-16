using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyMeterial")]
 public   class PCVMS_PropertyMeterial
    {
        public Guid ID { get; set; }
        public Guid Type { get; set; }
        public Guid PropertyId { get; set; }

        public string TotalArea { get; set; }

        public string Note { get; set; }

        public bool? Deleted { get; set; }


    }

}
