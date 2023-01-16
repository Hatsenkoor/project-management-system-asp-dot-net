using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyTank")]
   public class PCVMS_PropertyTank
    {
        public Guid ID { get; set; }
        public Guid PropertyId { get; set; }
        public Guid TankCode { get; set; }
        public Guid TankType { get; set; }
        public Guid TankDescription { get; set; }
        public Guid Size { get; set; }
        public Guid Cladding { get; set; }
        public Guid CladSize { get; set; }
        public Guid SoilType { get; set; }
        public Guid CreatedUserId { get; set; }
        public bool? Deleted { get; set; }


    }
}
