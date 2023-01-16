using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyLandInfo")]
 public   class PCVMS_PropertyLandInfo
    {
        public Guid ID { get; set; }
        public Guid LandUse { get; set; }
        public Guid SubLandUse { get; set; }
        public Guid ActualLandUse { get; set; }
        public string TotalArea { get; set; }
        public string AffectedLandArea { get; set; }
        public string RemainingLandArea { get; set; }
        public string TotalBuildAre { get; set; }

        public string AffectedBuildArea { get; set; }

        public string RemainingBuildArea { get; set; }
        public string Remark { get; set; }
        public Guid PropertyId { get; set; }
        public bool? Deleted { get; set; }
    }
}
