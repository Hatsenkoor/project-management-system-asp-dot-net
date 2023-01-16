using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using PCVM.Web.Helpers;
using PCVMS.Model.Web;
using PCVMS.Model;
using PCVMS.Model.BusinessModel;
using Microsoft.AspNetCore.Authorization;

namespace PCVM.Web.Controllers
{
    public class PCVDEngineerController : Controller
    {
        private PropertyModel model { get; set; }

        public IOptions<Helpers.AppSettings> AppSettings { get; }

        public PCVDEngineerController(IOptions<PCVM.Web.Helpers.AppSettings> appSettings)
        {

            AppSettings = appSettings;
            model = new PropertyModel();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> SiteSurvey()
        {

            model = new PropertyModel();
            model.PropertyLandUseList = new List<SelectListItem>();
            model.PropertyLandUseList.Add(new SelectListItem());
            var LandUserList = await this.GetLandUse();
            model.PropertyLandUseList.AddRange(LandUserList.ToSelectionList());

            return View(model);
        }
        public async Task<PropertyModel> GetPropertyByNumber(string PropertyNumber)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<PropertyModel>("API/Property/GetPropertyByNumber?PropertyNumber=" + PropertyNumber, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    Property.PropertyOwnerTypeEn = Property.PropertyOwnerTypeAr;
                }
                return Property;
            }
        }

        public async Task<List<PCVMS_PropertyItemPriceModel>> GetPropertyItemPrice(string PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<List<PCVMS_PropertyItemPriceModel>>("API/Property/GetPropertyItemPrice?PropertyId=" + PropertyId, "");

                return Property;
            }
        }
        public async Task<List<PropertyMeterialModel>> GetPropertyMeterial(Guid PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<List<PropertyMeterialModel>>("API/Property/GetPropertyMeterial?PropertyId=" + PropertyId, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var p in Property)
                    {
                        p.NameEn = p.NameAr;
                    }
                }
                return Property;
            }
        }
        public async Task<List<PropertyWallsModel>> GetPropertyWalls(Guid PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<List<PropertyWallsModel>>("API/Property/GetPropertyWalls?PropertyId=" + PropertyId, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var p in Property)
                    {
                        p.NameEn = p.NameAr;
                    }
                }
                return Property;
            }
        }
        public async Task<List<PropertyWellModel>> GetPropertyWells(Guid PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<List<PropertyWellModel>>("API/Property/GetPropertyWells?PropertyId=" + PropertyId, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var p in Property)
                    {
                        p.DescriptionEn = p.DescriptionAr;
                        p.SizeEn = p.SizeAr;
                        p.SoilNameEn = p.SoilNameAr;
                        p.StatusEn = p.StatusAr;
                        p.TypeNameEn = p.TypeNameAr;
                        p.WellCodeNameEn = p.WellCodeNameAr;
                        p.CladdingNameEn = p.CladdingNameAr;
                        p.CladSizeEn = p.CladSizeAr;

                    }
                }
                return Property;
            }
        }
        public async Task<List<PropertyTankModel>> GetPropertyTank(Guid PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<List<PropertyTankModel>>("API/Property/GetPropertyTank?PropertyId=" + PropertyId, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var p in Property)
                    {
                        p.DescriptionEn = p.DescriptionAr;
                        p.SizeEn = p.SizeAr;
                        p.SoilNameEn = p.SoilNameAr;
                        p.StatusEn = p.StatusAr;
                        p.TypeNameEn = p.TypeNameAr;
                        p.CodeNameEn = p.CodeNameAr;
                        p.CladdingNameEn = p.CladdingNameAr;
                        p.CladSizeEn = p.CladSizeAr;

                    }
                }
                return Property;
            }
        }
        public async Task<List<PropertyChannelModel>> GetPropertyChannel(Guid PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<List<PropertyChannelModel>>("API/Property/GetPropertyChannel?PropertyId=" + PropertyId, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var p in Property)
                    {
                        p.DescriptionEn = p.DescriptionAr;

                        p.TypeNameEn = p.TypeNameAr;
                        p.CodeNameEn = p.CodeNameAr;
                        p.CladdingNameEn = p.CladdingNameAr;


                    }
                }
                return Property;
            }
        }
        public async Task<List<PropertyItemModel>> GetPropertyItem(Guid PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<List<PropertyItemModel>>("API/Property/GetPropertyItem?PropertyId=" + PropertyId, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var p in Property)
                    {
                        p.DescriptionEn = p.DescriptionAr;

                        p.TypeNameEn = p.TypeNameAr;
                        p.CodeNameEn = p.CodeNameAr;
                        p.ConditionEn = p.ConditionAr;


                    }
                }
                return Property;
            }
        }

        public async Task<PCVMS_PropertyLandInfo> GetPropertyLandInfo(Guid PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<PCVMS_PropertyLandInfo>("API/Property/GetPropertyLandInfo?PropertyId=" + PropertyId, "");

                return Property;
            }
        }
        public async Task<List<PCVMS_CommonLookUp>> GetLandUse()
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var PropertyList = await objectClient.Get<List<PCVMS_CommonLookUp>>("API/LookUp/GetLandUse", "");

                return PropertyList;
            }
        }

        [HttpPost]

        public async Task<PCVMS_PropertyLandInfo> SavePropertyInfo(PCVMS_PropertyLandInfo obj)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_PropertyLandInfo>("API/Property/SavePropertyInfo", stringContent, "");
                return result;
            }
        }

        [HttpPost]

        public async Task<List<PropertyTreeList>> AddPropertTree(PCVMS_PropertyTree obj)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_PropertyTree>("API/Property/AddPropertTree", stringContent, "");
                return await this.GetPropertyTreeList(obj.PropertyId);
            }

        }
        public async Task<List<PropertyTreeList>> GetPropertyTreeList(Guid PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<List<PropertyTreeList>>("API/Property/GetPropertyTreeList?PropertyId=" + PropertyId, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var p in Property)
                    {
                        p.CategoryNameEn = p.CategoryNameAr;
                        p.SizeNameEn = p.SizeNameAr;
                        p.TreeCodeNameEn = p.TreeCodeNameEn;
                        p.TypeNameEn = p.TypeNameAr;
                    }
                }
                return Property;
            }

        }
        [HttpPost]

        public async Task<List<PropertyCropList>> AddPropertCrop(PCVMS_PropertyCrop obj)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_PropertyCrop>("API/Property/AddPropertCrop", stringContent, "");
                return await this.GetPropertyCropList(obj.PropertyId);
            }
        }

        public async Task<List<PropertyCropList>> GetPropertyCropList(Guid PropertyId)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Property = await objectClient.Get<List<PropertyCropList>>("API/Property/GetPropertyCropList?PropertyId=" + PropertyId, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var p in Property)
                    {
                        p.CodeNameEn = p.CodeNameAr;
                        p.CropNameEn = p.CropNameAr;
                        p.TypeNameEn = p.TypeNameAr;

                    }
                }
                return Property;
            }

        }

        [HttpPost]
        public async Task<List<PropertyMeterialModel>> AddUpdatePropertyMaterial(PCVMS_PropertyMeterial obj)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_PropertyLandInfo>("API/Property/AddUpdatePropertyMaterial", stringContent, "");

            }
            return await this.GetPropertyMeterial(obj.PropertyId);
        }
        [HttpPost]
        public async Task<List<PropertyWallsModel>> AddPropertyWalls(PCVMS_PropertyWalls obj)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_PropertyLandInfo>("API/Property/AddPropertyWalls", stringContent, "");

            }
            return await this.GetPropertyWalls(obj.PropertyId);
        }
        [HttpPost]
        public async Task<List<PropertyWellModel>> AddPropertStorage(PCVMS_PropertyStorage obj)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_PropertyStorage>("API/Property/AddPropertStorage", stringContent, "");
                return await this.GetPropertyWells(obj.PropertyId);
            }

        }
        [HttpPost]
        public async Task<List<PropertyTankModel>> AddPropertTank(PCVMS_PropertyTank obj)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_PropertyTank>("API/Property/AddPropertTank", stringContent, "");
                return await this.GetPropertyTank(obj.PropertyId);
            }

        }
        [HttpPost]
        public async Task<List<PropertyChannelModel>> AddPropertChannel(PCVMS_PropertyChannle obj)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_PropertyChannle>("API/Property/AddPropertChannel", stringContent, "");
                return await this.GetPropertyChannel(obj.PropertyId);
            }

        }
        public async Task<bool> SubmitProperty(Guid PropertyId)
        {

            var stringContent = new StringContent("");
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/Property/SubmitProperty?PropertyId=" + PropertyId.ToString(), stringContent, "");
                return result;
            }
        }
        [HttpPost]
        public async Task<List<PropertyItemModel>> AddPropertItem(PCVMS_PropertyItem obj)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_PropertyItem>("API/Property/AddPropertItem", stringContent, "");
                return await this.GetPropertyItem(obj.PropertyId);
            }

        }

        [HttpDelete]
        public async Task<bool> DeletePropertyMeterial(Guid Id)
        {
            var id = "?Id=" + Id;

            using (var objectClient = new ApiClient(AppSettings))
            {

                var result = await objectClient.Delete<bool>("API/Property/DeletePropertyMeterial", id);
                return true;
            }
        }
        [HttpDelete]
        public async Task<bool> DeletePropertyWalls(Guid Id)
        {
            var id = "?Id=" + Id;

            using (var objectClient = new ApiClient(AppSettings))
            {

                var result = await objectClient.Delete<bool>("API/Property/DeletePropertyWalls", id);
                return true;
            }
        }
        [HttpDelete]
        public async Task<bool> DeletePropertyTree(Guid Id)
        {
            var id = "?Id=" + Id;

            using (var objectClient = new ApiClient(AppSettings))
            {

                var result = await objectClient.Delete<bool>("API/Property/DeletePropertyTree", id);
                return true;
            }
        }
        [HttpDelete]
        public async Task<bool> DeletePropertyCrop(Guid Id)
        {
            var id = "?Id=" + Id;

            using (var objectClient = new ApiClient(AppSettings))
            {

                var result = await objectClient.Delete<bool>("API/Property/DeletePropertyCrop", id);
                return true;
            }
        }
        [HttpDelete]
        public async Task<bool> DeletePropertyWells(Guid Id)
        {
            var id = "?Id=" + Id;

            using (var objectClient = new ApiClient(AppSettings))
            {

                var result = await objectClient.Delete<bool>("API/Property/DeletePropertyWell", id);
                return true;
            }
        }
        [HttpDelete]
        public async Task<bool> DeletePropertyTank(Guid Id)
        {
            var id = "?Id=" + Id;

            using (var objectClient = new ApiClient(AppSettings))
            {

                var result = await objectClient.Delete<bool>("API/Property/DeletePropertyTank", id);
                return true;
            }
        }

        [HttpDelete]
        public async Task<bool> DeletePropertyChannel(Guid Id)
        {
            var id = "?Id=" + Id;

            using (var objectClient = new ApiClient(AppSettings))
            {

                var result = await objectClient.Delete<bool>("API/Property/DeletePropertyChannel", id);
                return true;
            }
        }
        [HttpDelete]
        public async Task<bool> DeletePropertyItem(Guid Id)
        {
            var id = "?Id=" + Id;

            using (var objectClient = new ApiClient(AppSettings))
            {

                var result = await objectClient.Delete<bool>("API/Property/DeletePropertyItem", id);
                return true;
            }
        }

    }
}