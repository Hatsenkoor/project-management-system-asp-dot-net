using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Project")]
    public  class PCVMS_Project
    {
        public Guid ID { get; set; }
        public string ProjectName { get; set; }
        public string RoyalDecree { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public DateTime RoyalDecreeDate { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public string Remark { get; set; }
        public bool Deleted { get; set; }
        public string StatusId { get; set; }
    }
}
