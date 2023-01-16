using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class PCVMS_GeometryDetails
    {
        public Guid ID { get; set; }
        public Guid GeometryId { get; set; }
        public Guid ProjectID { get; set; }
        public string GeometryNameEn { get; set; }
        public string GeometryNameAr { get; set; }
        
        public string Easting { get; set; }

        public string Northing { get; set; }
        public bool? Deleted { get; set; }
    }
}
