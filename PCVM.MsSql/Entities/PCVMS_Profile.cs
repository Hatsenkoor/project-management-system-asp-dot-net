using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Profile")]
    public class PCVMS_Profile
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string CardId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationHQ { get; set; }
        public string PoBox { get; set; }

        public string PostalCode { get; set; }

        public string Email { get; set; }

        public string LandLine { get; set; }

        public string Mobile { get; set; }
        public string Fax { get; set; }

        public string Remark { get; set; }

        public Guid ProfileId { get; set; }

        public bool? Deleted { get; set; }        
        public DateTime? CreatedDate { get; set; }

        public string StatusId { get; set; }
    }
}
