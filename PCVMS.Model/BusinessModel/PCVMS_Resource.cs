using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class PCVMS_Resource
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool? Deleted { get; set; }
        public string Key { get; set; }

        public Dictionary<string, string> Resource { get; set; }
    }
}
