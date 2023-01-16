using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class Property
    {
        public Guid Id { get; set; }
        public Int64 nPropertyId { get; set; }
        public Int64 nProjectId { get; set; }
        public string cRegionCode { get; set; }
        public string cWilayatCode { get; set; }
        public string cVillageCode { get; set; }
        public string Owner_IDNO { get; set; }
        public string cOwnerShipType { get; set; }
        public string cLandUse { get; set; }

        public string cSubLeaseUse { get; set; }
        public string cActualLandUse { get; set; }
        public string cLandAria { get; set; }
        public int cPropertyType { get; set; }
        public string cComments { get; set; }
        public Guid RoleType { get; set; }
        public Guid ManagerId { get; set; }
        public string StateNameToSet { get; set; }
    }
}
