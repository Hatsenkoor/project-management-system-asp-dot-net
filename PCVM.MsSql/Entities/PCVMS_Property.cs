using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Property")]
    public class PCVMS_Property
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid OwnerType { get; set; }
        public string CardId { get; set; }
        public string PropertyNumber { get; set; }
        public string Email { get; set; }
        public string LandLine { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Remark { get; set; }
        public Guid ProjectId { get; set; }
        public bool? Deleted { get; set; }
    }

}
