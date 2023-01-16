using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_ValuetionDraft")]
  public  class PCVMS_ValuetionDraft
    {
        public Guid ID { get; set; }
        public string DraftName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool Active { get; set; }

    }
}
