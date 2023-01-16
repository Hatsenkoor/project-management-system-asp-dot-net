using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class PCVMS_Scheme
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }

        public string NameAr { get; set; }
        public bool Deleted { get; set; }
    }
}
