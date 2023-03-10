using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{

    [Table("PCVMS_Documents")]
    public class PCVMS_Documents
    {
        public Guid ID { get; set; }
        public Guid GroupID { get; set; }
        public Guid ParentId { get; set; }
        public string Description { get; set; }
        public string DocumentType { get; set; }

        public string DocumentName { get; set; }

        public string DocumentPath { get; set; }

        public bool? Deleted { get; set; }       
    }
}
