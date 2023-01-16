using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class PropertyModel
    {
        public Guid Id { get; set; }
       public string PropertyName { get; set; }
        public string PropertyOwnerTypeEn { get; set; }
        public string PropertyOwnerTypeAr { get; set; }
        public string PropertyCardId { get; set; }
        public string PropertyNumber { get; set; }


        public string PropertyEmail { get; set; }
        public string PropertyLandline { get; set; }
        public string PropertyMobile { get; set; }
        public string PropertyFax { get; set; }
        public string PropertyRemark { get; set; }
        public Guid LandUse { get; set; }
        public List<SelectListItem> PropertyLandUseList { get; set; }
    }
    public class PropertyChannelModel
    {
        public Guid ID { get; set; }
        public string CodeNameEn { get; set; }
        public string CodeNameAr { get; set; }
        public string TypeNameEn { get; set; }
        public string TypeNameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string CladdingNameEn { get; set; }
        public string CladdingNameAr { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Length { get; set; }

    }
    public class PropertyItemModel
    {
        public Guid ID { get; set; }
        public string CodeNameEn { get; set; }
        public string CodeNameAr { get; set; }
        public string TypeNameEn { get; set; }
        public string TypeNameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string ConditionEn { get; set; }
        public string ConditionAr { get; set; }
        public string Number { get; set; }

    }
    public class PropertyMeterialModel
    {
        public Guid ID { get; set; }

        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string TotalArea { get; set; }
        public string Note { get; set; }
    }
    public class PropertyCropList
    {

        public Guid ID { get; set; }
        public string CodeNameEn { get; set; }
        public string CodeNameAr { get; set; }
        public string TypeNameEn { get; set; }
        public string TypeNameAr { get; set; }
        public string CropNameEn { get; set; }
        public string CropNameAr { get; set; }
        public string Area { get; set; }
        public string Production { get; set; }
    }
    public class PropertyTankModel
    {
        public Guid ID { get; set; }
        public string CodeNameEn { get; set; }
        public string CodeNameAr { get; set; }
        public string TypeNameEn { get; set; }
        public string TypeNameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string SizeEn { get; set; }
        public string SizeAr { get; set; }
        public string SoilNameEn { get; set; }
        public string SoilNameAr { get; set; }
        public string StatusEn { get; set; }
        public string StatusAr { get; set; }

        public string CladdingNameEn { get; set; }
        public string CladdingNameAr { get; set; }
        public string CladSizeEn { get; set; }
        public string CladSizeAr { get; set; }
    }
    public class PropertyTreeList
    {

        public Guid ID { get; set; }
        public string TreeCodeNameEn { get; set; }
        public string TreeCodeNameAr { get; set; }
        public string CategoryNameEn { get; set; }
        public string CategoryNameAr { get; set; }
        public string TypeNameEn { get; set; }
        public string TypeNameAr { get; set; }
        public string SizeNameEn { get; set; }
        public string SizeNameAr { get; set; }
        public string Number { get; set; }
    }
    public class PropertyWallsModel
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Height { get; set; }
        public string Thickness { get; set; }
        public string Length { get; set; }
        public string Line { get; set; }
    }
    public class PropertyWellModel
    {

        public Guid ID { get; set; }
        public string WellCodeNameEn { get; set; }
        public string WellCodeNameAr { get; set; }
        public string TypeNameEn { get; set; }
        public string TypeNameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string SizeEn { get; set; }
        public string SizeAr { get; set; }
        public string SoilNameEn { get; set; }
        public string SoilNameAr { get; set; }
        public string StatusEn { get; set; }
        public string StatusAr { get; set; }

        public string CladdingNameEn { get; set; }
        public string CladdingNameAr { get; set; }
        public string CladSizeEn { get; set; }
        public string CladSizeAr { get; set; }
    }
    public class PCVMS_PropertyItemPriceModel
    {
        public string PropertyName { get; set; }

        public string ItemName { get; set; }

        public string TotalPrice  { get; set; }

       
    }
}
