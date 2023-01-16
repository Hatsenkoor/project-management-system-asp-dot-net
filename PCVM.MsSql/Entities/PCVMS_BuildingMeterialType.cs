using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_BuildingMeterialType")]
  public  class PCVMS_BuildingMeterialType
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }

        public string NameAr { get; set; }
        public string Screen { get; set; }

        public bool? Deleted { get; set; }
    }
}
