using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_ProjectProfile")]
    public class PCVMS_ProjectProfile
    {

        public  Guid ID {get;set;}
        public Guid ProjectId { get; set; }
        public Guid ProfileId { get; set; }
        public bool? Deleted { get; set; }
    }
}
