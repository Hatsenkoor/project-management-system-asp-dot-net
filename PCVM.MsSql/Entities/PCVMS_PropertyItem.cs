using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyItem")]
   public class PCVMS_PropertyItem
    {
        public Guid ID { get; set; }
        public Guid ItemCode { get; set; }

        public Guid ItemType { get; set; }
        public Guid ItemDescription { get; set; }
        public string ItemNumber { get; set; }
        public Guid ItemCondition { get; set; }
        public Guid PropertyId { get; set; }

        public Guid CreatedUserId { get; set; }

        public bool? Deleted { get; set; }
    }
}
