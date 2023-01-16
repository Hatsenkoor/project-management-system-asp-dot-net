using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_GeometryDetails")]
   public class PCVMS_GeometryDetails
    {
        public Guid ID { get; set; }
        public Guid GeometryId { get; set; }

        public Guid ProjectId { get; set; }

        
        public string Easting { get; set; }

        public string Northing { get; set; }
        public bool? Deleted { get; set; }
    }
}
