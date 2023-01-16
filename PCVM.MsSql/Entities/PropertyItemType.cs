using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PropertyItemType")]
    public  class PropertyItemType
    {
        public Int64 nItemId { get; set; }
        public Int64 nPropertyId { get; set; }
        public Int64 nItemParentId { get; set; }
        public DateTime dCreatedDate { get; set; }
        public bool bDeleted { get; set; }
        public string cItemName { get; set; }
        public decimal nConsultantPrice { get; set; }
        public string cNote { get; set; }
    }
}
