using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyDraft")]
   public class PCVMS_PropertyDraft
    {
        public Guid ID { get; set; }
        public Guid PropertyId { get; set; }
        public Guid DraftId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
