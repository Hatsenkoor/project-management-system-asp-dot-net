using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Excel")]
  public  class PCVMS_Excel
    {
        public Int64 Id { get; set; }
        public string One { get; set; }
        public string Two { get; set; }

        public string Three { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
        public string Six { get; set; }
    }
}
