using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyCrop")]
   public class PCVMS_PropertyCrop
    {
        public Guid ID { get; set; }
        public Guid PropertyId { get; set; }
        public Guid CropCode { get; set; }
        public Guid CropType { get; set; }
        public Guid CropName { get; set; }

        public string TotalArea { get; set; }
        public string TotalProduction { get; set; }

        public bool? Deleted { get; set; }
    }
}
