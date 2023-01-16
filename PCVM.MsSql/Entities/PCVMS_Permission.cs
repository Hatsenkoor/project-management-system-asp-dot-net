using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Permission")]
    public   class PCVMS_Permission
    {
        public Guid  ID { get; set; }
        public string NameEn { get; set; }
        public string nameAr { get; set; }
        public string Url { get; set; }
        public string ControllerName { get; set; }

        public string ParentId { get; set; }
        public string MenuId { get; set; }      
        public int OrderNo { get; set; }
        public int MenuOrderNo { get; set; }

        public string MenuName { get; set; }
        public int Level { get; set; }
    }
}
