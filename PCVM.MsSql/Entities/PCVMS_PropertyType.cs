using System;
using System.Collections.Generic;
using System.Text;

namespace PCVM.MsSql.Entities
{
  public  class PCVMS_PropertyType
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public bool? Deleted { get; set; }
    }
}
