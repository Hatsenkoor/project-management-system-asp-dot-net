using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class PCVMS_Property
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid OwnerType { get; set; }
        public string CardId { get; set; }
        public string PropertyNumber { get; set; }
        public string Email { get; set; }
        public string LandLine { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Remark { get; set; }
        public Guid ProjectId { get; set; }
        public bool? Deleted { get; set; }
    }
    public class PCVMS_PropertyChannle
    {
        public Guid ID { get; set; }
        public Guid PropertyId { get; set; }

        public Guid ChannelCode { get; set; }


        public Guid Type { get; set; }
        public Guid Description { get; set; }

        public Guid Cladding { get; set; }

        public string CreatedUserId { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Length { get; set; }
        public bool? Deleted { get; set; }
    }
    public class PCVMS_PropertyCrop
    {
        public Guid ID { get; set; }
        public Guid PropertyId { get; set; }
        public Guid CropCode { get; set; }
        public Guid CropType { get; set; }
        public Guid CropName { get; set; }

        public string TotalArea { get; set; }
        public string TotalProduction { get; set; }

        public bool? Deleted { get; set; }
    }
    public class PCVMS_PropertyItem
    {
        public Guid ID { get; set; }
        public Guid ItemCode { get; set; }

        public Guid ItemType { get; set; }
        public Guid ItemDescription { get; set; }
        public string ItemNumber { get; set; }
        public Guid ItemCondition { get; set; }
        public Guid PropertyId { get; set; }
        public Guid CreatedUserId { get; set; }

        public bool? Deleted { get; set; }
    }
    public class PCVMS_PropertyLandInfo
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
    public class PCVMS_PropertyMeterial
    {
        public Guid ID { get; set; }
        public Guid Type { get; set; }
        public Guid PropertyId { get; set; }

        public string TotalArea { get; set; }

        public string Note { get; set; }

        public bool? Deleted { get; set; }


    }
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
    public class PCVMS_PropertyStorage
    {

        public Guid ID { get; set; }
        public Guid WellsCode { get; set; }
        public Guid PropertyId { get; set; }
        public Guid Type { get; set; }

        public Guid Description { get; set; }

        public Guid Size { get; set; }

        public Guid Cladding { get; set; }

        public Guid CladSize { get; set; }

        public Guid SoilType { get; set; }

        public Guid Status { get; set; }
        public bool? deleted { get; set; }
    }
    public class PCVMS_PropertyWalls
    {
        public Guid ID { get; set; }
        public Guid Type { get; set; }

        public Guid PropertyId { get; set; }
        public string Height { get; set; }

        public string Thickness { get; set; }
        public string Length { get; set; }
        public string Line { get; set; }
        public bool Deleted { get; set; }


    }
    public class PCVMS_PropertyTree
    {
        public Guid ID { get; set; }
        public Guid PropertyId { get; set; }

        public Guid TreeCode { get; set; }

        public Guid TreeCategory { get; set; }

        public Guid TreeType { get; set; }
        public Guid TreeSize { get; set; }

        public string Number { get; set; }

        public string CreatedUserId { get; set; }

        public bool? Deleted { get; set; }
    }
    public class PCVMS_PropertyDraft
    {
        public Guid ID { get; set; }
        public Guid PropertyId { get; set; }
        public Guid DraftId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
