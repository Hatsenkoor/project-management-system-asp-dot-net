using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("Propertydetails")]
    public   class Propertydetails
    {
        public Int64 nPropertyDetails { get; set; }
        public Int64 nItemId { get; set; }
        public string cFiledName { get; set; }
        public string cFieldValue { get; set; }
        public string cPartNumber { get; set; }
        public DateTime dCreatedDate { get; set; }
        public string cCreatedUserId { get; set; }
        public string bGroup { get; set; }
        public string cGroupname { get; set; }

    }
}
