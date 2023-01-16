using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_User_Group_Name")]
    public  class PCVMS_User_Group_Name
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
    }
}
