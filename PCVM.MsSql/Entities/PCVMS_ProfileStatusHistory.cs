using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_ProfileStatusHistory")]
    public  class PCVMS_ProfileStatusHistory
    {
        public Guid ID { get; set; }
        public string StatusId { get; set; }
        public Guid ProfileId { get; set; }

        public Guid UserId { get; set; }

        public string UserComment { get; set; }
    }
}
