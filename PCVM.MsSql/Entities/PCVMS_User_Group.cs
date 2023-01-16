using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_User_Group")]
    public  class PCVMS_User_Group
    {
        public Guid ID { get; set; }
        public Guid GroupId { get; set; }

        public Guid UserId { get; set; }

        public bool Deleted { get; set; }
    }
}
