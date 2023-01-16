using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyStorage")]
 public   class PCVMS_PropertyStorage
    {

        public Guid ID { get; set; }
        public Guid WellsCode { get; set; }
        public Guid PropertyId { get; set; }
        public Guid Type { get; set; }

        public Guid Description { get; set; }

        public Guid Size { get; set; }

        public Guid Cladding { get; set; }

        public Guid CladSize { get; set; }

        public Guid SoilType { get; set; }

        public Guid Status { get; set; }
        public bool? deleted { get; set; }
    }
}
