using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyTree")]
  public  class PCVMS_PropertyTree
    {
        public Guid ID { get; set; }
        public Guid PropertyId { get; set; }

        public Guid TreeCode { get; set; }

        public Guid TreeCategory { get; set; }

        public Guid TreeType { get; set; }
        public Guid TreeSize { get; set; }

        public string Number { get; set; }

        public string CreatedUserId { get; set; }

        public bool? Deleted { get; set; }
    }
}
