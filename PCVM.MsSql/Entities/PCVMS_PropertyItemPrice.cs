using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyItemPrice")]
   public class PCVMS_PropertyItemPrice
    {
        public Guid ID { get; set; }

        public Guid ProjectId { get; set; }

        public Guid ItemId { get; set; }

        public string Unit { get; set; }

        public decimal Price { get; set; }
        public string TotalPrice { get; set; }
        public DateTime ? DateCalculated { get; set; }
    }
}
