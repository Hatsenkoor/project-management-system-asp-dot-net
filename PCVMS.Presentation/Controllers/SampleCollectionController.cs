using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCVM.Web.Helpers;
using PCVMS.Model.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System;

using PCVMS.Model.BusinessModel;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.Drawing;
using Microsoft.Extensions.Configuration;

namespace PCVM.Web.Controllers
{
    public class SampleCollectionController : Controller
    {
        public LabSample.LabSample_Model model { get; set; }
        IConfiguration configuration;
        string url;

        public Receipt receiptObj = new Receipt();

        public List<LabSample.ImportExport> lstImportExport = new List<LabSample.ImportExport>();

        public IWebHostEnvironment Env { get; }
        public IOptions<Helpers.AppSettings> AppSettings { get; }

        public SampleCollectionController(IConfiguration configuration, IOptions<Helpers.AppSettings> appSettings, IWebHostEnvironment web)
        {
            AppSettings = appSettings;
            Env = web;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            this.configuration = configuration;
            url = this.configuration.GetSection("AppSettings:ApiUrl.Finance").Value;
        }

        public async Task<string> SaveImportExport(LabSample.ImportExport obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            obj.Created_by = UserId.ToString();
            obj.Updated_by = UserId.ToString();
            obj.Created_date = DateTime.Now;
            obj.Updated_date = DateTime.Now;
           

           
          /*  obj.PC_Number = "1111";
            obj.Request_ID = System.Guid.NewGuid();
            obj.Payment_ID = System.Guid.NewGuid();
            obj.Collection_Date = DateTime.Now;         
            obj.Port_ID = System.Guid.NewGuid();
            obj.Port_Name = "2222";
            obj.Custom_Document_Number = "1111";
            obj.Shipment_Document_Number = "12233";
            obj.Company_Name = "123";
            obj.Country_Origin_ID= System.Guid.NewGuid();
            obj.Country_Origin_Name = "13123";
            obj.Country_Export_ID = System.Guid.NewGuid();
            obj.Country_Export_Name = "1111";
            obj.Sample_Type_ID = System.Guid.NewGuid();
            obj.Sample_Type_Name = "213123";
            obj.Sample_Source_ID = System.Guid.NewGuid();
            obj.Sample_Source_Name = "2312";
            obj.Analysis_Type_ID = System.Guid.NewGuid();
            obj.Analysis_Type_Name = "121";
            obj.Importer_Name = "2323";
            obj.Importer_Contact_Detail = "232";
            obj.Testing_Lab_ID = System.Guid.NewGuid();
            obj.Testing_Lab_Name = "232";
            obj.Remark = "werwerwe";
            obj.Created_by = "21123";
            obj.Created_date = DateTime.Now;
            obj.Updated_by = "2323213";
            obj.Updated_date = DateTime.Now;
            obj.Deleted = false;
            obj.StatusId = "12312";
           */

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<string>("API/LabSample/SaveImportExport", stringContent, "");
                return result;

            }
        }

        

        public async Task<string> SaveSampleDetails(LabSample.SampleDetails obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            obj.Created_by = UserId.ToString();
            obj.Updated_by = UserId.ToString();
            obj.Created_date = DateTime.Now;
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<string>("API/LabSample/SaveSampleDetails", stringContent, "");
                return result;

            }
        }

        public async Task<string> SaveLabAnalysis(LabSample.LabAnalysis obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            obj.Created_by = UserId.ToString();
            obj.Updated_by = UserId.ToString();
            obj.Created_date = DateTime.Now;
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<string>("API/LabSample/SaveLabAnalysis", stringContent, "");
                return result;

            }
        }

        public async Task<string> SaveLabResult(LabSample.LabResult obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            obj.Created_by = UserId.ToString();
            obj.Updated_by = UserId.ToString();
            obj.Created_date = DateTime.Now;
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<string>("API/LabSample/SaveLabResult", stringContent, "");
                return result;

            }
        }

        public async Task<List<LabSample.ImportExport>> SubmitSample(LabSample.SampleDetails obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            obj.Updated_by = UserId.ToString();           
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<LabSample.ImportExport>>("API/LabSample/SubmitSample", stringContent, "");
                return result;

            }
        }

        public async Task<IActionResult> ExportedAgricultural()
        {

            return View(await PageLoad());

        }
        public async Task<IActionResult> ExportedPesticideAnalysisSample()
        {

            return View(await PageLoad());

        }
        public async Task<IActionResult> ExportedFertilizerSoilSample()
        {

            return View(await PageLoad());

        }
        public async Task<IActionResult> ExportedAgriculturalPestSample()
        {

            return View(await PageLoad());

        }
        public async Task<LabSample.LabSample_Model> PageLoad()
        {

            var browserLang = Request.Headers["Accept-Language"].ToString().Split(";").FirstOrDefault()?.Split(",").FirstOrDefault();
            browserLang = Thread.CurrentThread.CurrentCulture.Name;

            model = new LabSample.LabSample_Model();

            #region GetPortMaster

            model.PortMaster = new List<SelectListItem>();
            model.PortMaster.Add(new SelectListItem());

            var PortMasterList = await this.GetPortMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.PortMaster.AddRange(PortMasterList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PortMaster.AddRange(PortMasterList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.PortMaster.RemoveAt(0);

            #endregion

            #region GetCountryMaster

            model.CountryMaster = new List<SelectListItem>();
            model.CountryMaster.Add(new SelectListItem());

            var getCountryMaster = await this.GetCountryMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.CountryMaster.AddRange(getCountryMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.CountryMaster.AddRange(getCountryMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.CountryMaster.RemoveAt(0);

            #endregion

            #region GetCountryMaster

            model.AnalysisMaster = new List<SelectListItem>();
            model.AnalysisMaster.Add(new SelectListItem());

            var getAnalysisMaster = await this.GetAnalysisMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.AnalysisMaster.AddRange(getAnalysisMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.AnalysisMaster.AddRange(getAnalysisMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.AnalysisMaster.RemoveAt(0);

            #endregion

            #region GetLabMaster

            model.LabMaster = new List<SelectListItem>();
            model.LabMaster.Add(new SelectListItem());

            var getLabMaster = await this.GetLabMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.LabMaster.AddRange(getLabMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.LabMaster.AddRange(getLabMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.LabMaster.RemoveAt(0);

            #endregion

            #region GetSampleMaster

            model.SampleMaster = new List<SelectListItem>();
            model.SampleMaster.Add(new SelectListItem());

            var getSampleMaster = await this.GetSampleMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.SampleMaster.AddRange(getSampleMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.SampleMaster.AddRange(getSampleMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.SampleMaster.RemoveAt(0);

            #endregion

            #region GetSampleMaster

            model.SampleSourceMaster = new List<SelectListItem>();
            model.SampleSourceMaster.Add(new SelectListItem());

            var getSampleSourceMaster = await this.GetSampleSourceMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.SampleSourceMaster.AddRange(getSampleSourceMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.SampleSourceMaster.AddRange(getSampleSourceMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.SampleSourceMaster.RemoveAt(0);

            #endregion

            #region GetGovernoratMaster

            model.GovernorateMaster = new List<SelectListItem>();
            model.GovernorateMaster.Add(new SelectListItem());

            var getGovernorateMaster = await this.GetAllGovernorates();

            if (browserLang.ToLower() == "en-us")
            {
                model.GovernorateMaster.AddRange(getGovernorateMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());;
            }
            else
            {
                model.GovernorateMaster.AddRange(getGovernorateMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.GovernorateMaster.RemoveAt(0);

            #endregion GetGovernoratMaster

            #region GetFarmMaster

            model.FarmMaster = new List<SelectListItem>();
            model.FarmMaster.Add(new SelectListItem());

            var getFarmMaster = await this.GetFarmMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.FarmMaster.AddRange(getFarmMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList()); ;
            }
            else
            {
                model.FarmMaster.AddRange(getFarmMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.FarmMaster.RemoveAt(0);

            #endregion GetFarmMaster

            #region Get Commodity Type

            model.CommodityType = new List<SelectListItem>();
            model.CommodityType.Add(new SelectListItem());

            var getCommodityMaster = await this.GetCommodityTypeMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.CommodityType.AddRange(getCommodityMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList()); ;
            }
            else
            {
                model.CommodityType.AddRange(getCommodityMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.CommodityType.RemoveAt(0);

            #endregion Get Commodity Type

            #region GetCommodity Name

            model.CommodityName = new List<SelectListItem>();
            model.CommodityName.Add(new SelectListItem());

            var getCommodityNameMaster = await this.GetCommodityNameMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.CommodityName.AddRange(getCommodityNameMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList()); ;
            }
            else
            {
                model.CommodityName.AddRange(getCommodityNameMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.CommodityName.RemoveAt(0);

            #endregion GetCommodity Name

            #region Payment Master

            model.PaymentType = new List<SelectListItem>();
            model.PaymentType.Add(new SelectListItem());

            var ObjPaymentTypeMaster = await this.GetPaymentMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.PaymentType.AddRange(ObjPaymentTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PaymentType.AddRange(ObjPaymentTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.PaymentType.RemoveAt(0);

            #endregion

            #region Packaging Type Master

            model.PackagingType = new List<SelectListItem>();
            model.PackagingType.Add(new SelectListItem());

            var ObjPackagingTypeMaster = await this.GetPackagingTypeMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.PackagingType.AddRange(ObjPackagingTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PackagingType.AddRange(ObjPackagingTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.PackagingType.RemoveAt(0);

            #endregion

            #region Packaging Condition Master

            model.PackagingCondition = new List<SelectListItem>();
            model.PackagingCondition.Add(new SelectListItem());

            var ObjPackagingConditionMaster = await this.GetPackagingConditionMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.PackagingCondition.AddRange(ObjPackagingConditionMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PackagingCondition.AddRange(ObjPackagingConditionMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.PackagingCondition.RemoveAt(0);

            #endregion

            #region Finding Master

            model.FindingType = new List<SelectListItem>();
            model.FindingType.Add(new SelectListItem());

            var ObjFindingTypeMaster = await this.GetFindingMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.FindingType.AddRange(ObjFindingTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.FindingType.AddRange(ObjFindingTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.FindingType.RemoveAt(0);

            #endregion

            #region Pesticide Commercial Name

            model.PesticideCommercialName = new List<SelectListItem>();
            model.PesticideCommercialName.Add(new SelectListItem());

            var ObjPesticideCommercialName = await this.GetPesticideCommercialNameMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.PesticideCommercialName.AddRange(ObjPesticideCommercialName.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PesticideCommercialName.AddRange(ObjPesticideCommercialName.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.PesticideCommercialName.RemoveAt(0);

            #endregion

            #region Pesticide Use Master

            model.PesticideUseMaster = new List<SelectListItem>();
            model.PesticideUseMaster.Add(new SelectListItem());

            var ObjGetPesticideUseMaster = await this.GetPesticideUseMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.PesticideUseMaster.AddRange(ObjGetPesticideUseMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PesticideUseMaster.AddRange(ObjGetPesticideUseMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.PesticideUseMaster.RemoveAt(0);

            #endregion

            #region Fertilizer Common Name Master

            model.FertilizerCommonNameMaster = new List<SelectListItem>();
            model.FertilizerCommonNameMaster.Add(new SelectListItem());

            var ObjFertilizerCommonNameMaster = await this.GetFertilizerCommonNameMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.FertilizerCommonNameMaster.AddRange(ObjFertilizerCommonNameMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.FertilizerCommonNameMaster.AddRange(ObjFertilizerCommonNameMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.FertilizerCommonNameMaster.RemoveAt(0);

            #endregion

            #region Fertilizer Type Master

            model.FertilizerTypeMaster = new List<SelectListItem>();
            model.FertilizerTypeMaster.Add(new SelectListItem());

            var ObjFertilizerTypeMaster = await this.GetFertilizerTypeMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.FertilizerTypeMaster.AddRange(ObjFertilizerTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.FertilizerTypeMaster.AddRange(ObjFertilizerTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.FertilizerTypeMaster.RemoveAt(0);

            #endregion

            #region Element tobe Analyzed

            model.ElementtobeAnalyzed = new List<SelectListItem>();
            model.ElementtobeAnalyzed.Add(new SelectListItem());

            var ObjElementtobeAnalyzed = await this.GetElementtobeAnalyzed();

            if (browserLang.ToLower() == "en-us")
            {
                model.ElementtobeAnalyzed.AddRange(ObjElementtobeAnalyzed.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.ElementtobeAnalyzed.AddRange(ObjElementtobeAnalyzed.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.ElementtobeAnalyzed.RemoveAt(0);

            #endregion

            #region Get Plan tMaster

            model.PlantMaster = new List<SelectListItem>();
            model.PlantMaster.Add(new SelectListItem());

            var ObjPlantMaster = await this.GetPlantMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.PlantMaster.AddRange(ObjPlantMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PlantMaster.AddRange(ObjPlantMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.PlantMaster.RemoveAt(0);

            #endregion

            #region Infected Plant Parts 

            model.InfectedPlantParts = new List<SelectListItem>();
            model.InfectedPlantParts.Add(new SelectListItem());

            var ObjInfectedPlantParts = await this.GetInfectedPlantParts();

            if (browserLang.ToLower() == "en-us")
            {
                model.InfectedPlantParts.AddRange(ObjInfectedPlantParts.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.InfectedPlantParts.AddRange(ObjInfectedPlantParts.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.InfectedPlantParts.RemoveAt(0);

            #endregion

            #region Cultivation Type Master

            model.CultivationTypeMaster = new List<SelectListItem>();
            model.CultivationTypeMaster.Add(new SelectListItem());

            var ObjCultivationTypeMaster = await this.GetCultivationTypeMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.CultivationTypeMaster.AddRange(ObjCultivationTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.CultivationTypeMaster.AddRange(ObjCultivationTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.CultivationTypeMaster.RemoveAt(0);

            #endregion

            #region Irrigation System Master

            model.IrrigationSystemMaster = new List<SelectListItem>();
            model.IrrigationSystemMaster.Add(new SelectListItem());

            var ObjIrrigationSystemMaster = await this.GetIrrigationSystemMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.IrrigationSystemMaster.AddRange(ObjIrrigationSystemMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.IrrigationSystemMaster.AddRange(ObjIrrigationSystemMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.IrrigationSystemMaster.RemoveAt(0);

            #endregion

            #region Infection Symptoms Master

            model.InfectionSymptomsMaster = new List<SelectListItem>();
            model.InfectionSymptomsMaster.Add(new SelectListItem());

            var ObjInfectionSymptomsMaster = await this.GetInfectionSymptomsMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.InfectionSymptomsMaster.AddRange(ObjInfectionSymptomsMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.InfectionSymptomsMaster.AddRange(ObjInfectionSymptomsMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.InfectionSymptomsMaster.RemoveAt(0);

            #endregion

            #region Infection In One Plant

            model.InfectionInOnePlant = new List<SelectListItem>();
            model.InfectionInOnePlant.Add(new SelectListItem());

            var ObjInfectionInOnePlant = await this.GetInfectionInOnePlant();

            if (browserLang.ToLower() == "en-us")
            {
                model.InfectionInOnePlant.AddRange(ObjInfectionInOnePlant.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.InfectionInOnePlant.AddRange(ObjInfectionInOnePlant.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.InfectionInOnePlant.RemoveAt(0);

            #endregion

            #region Infection In Field

            model.InfectionInField = new List<SelectListItem>();
            model.InfectionInField.Add(new SelectListItem());

            var ObjInfectionInField = await this.GetInfectionInField();

            if (browserLang.ToLower() == "en-us")
            {
                model.InfectionInField.AddRange(ObjInfectionInField.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.InfectionInField.AddRange(ObjInfectionInField.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.InfectionInField.RemoveAt(0);

            #endregion

            #region Pesticide Type Master

            model.PesticideTypeMaster = new List<SelectListItem>();
            model.PesticideTypeMaster.Add(new SelectListItem());

            var ObjPesticideTypeMaster = await this.GetPesticideTypeMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.PesticideTypeMaster.AddRange(ObjPesticideTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PesticideTypeMaster.AddRange(ObjPesticideTypeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.PesticideTypeMaster.RemoveAt(0);

            #endregion

            return model;

        }

        public async Task<List<PCVMS_Governorates>> GetAllGovernorates()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_Governorates>>("API/LookUp/GetAllGovernorates", "");
            }


        }

        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
        public async Task<IActionResult> ImportedAgricultural()
        {

            return View(await PageLoad());

        }
        public async Task<IActionResult> ImportedPesticideAnalysisSample()
        {

            return View(await PageLoad());

        }
        public async Task<IActionResult> ImportedFertilizerSoilSample()
        {

            return View(await PageLoad());

        }
        public async Task<IActionResult> ImportedAgriculturalPestSample()
        {

            return View(await PageLoad());

        }

        public async Task<IActionResult> LocalAgriculturalPestSample()
        {

            return View(await PageLoad());

        }
        public async Task<IActionResult> LocalFertilizerSoilSample()
        {

            return View(await PageLoad());

        }
        public async Task<IActionResult> LocalPesticideAnalysisSample()
        {

            return View(await PageLoad());

        }
        public async Task<IActionResult> LocalAgricultural()
        {

            return View(await PageLoad());

        }
        

        public async Task<List<LabSample.PortMaster>> GetPortMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<LabSample.PortMaster>>("API/LabSample/GetPortMaster/", "");
                return result;
            }
        }

        public async Task<List<LabSample.CountryMaster>> GetCountryMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<LabSample.CountryMaster>>("API/LabSample/GetCountryMaster/", "");
                return result;
            }
        }

        public async Task<List<LabSample.AnalysisMaster>> GetAnalysisMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<LabSample.AnalysisMaster>>("API/LabSample/GetAnalysisMaster/", "");
                return result;
            }
        }

        public async Task<List<LabSample.SampleMaster>> GetSampleMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<LabSample.SampleMaster>>("API/LabSample/GetSampleMaster/", "");
                return result;
            }
        }

        public async Task<List<LabSample.SampleSourceMaster>> GetSampleSourceMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<LabSample.SampleSourceMaster>>("API/LabSample/GetSampleSourceMaster/", "");
                return result;
            }
        }

        public async Task<List<LabSample.LabMaster>> GetLabMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<LabSample.LabMaster>>("API/LabSample/GetLabMaster/", "");
                return result;
            }
        }

        public async Task<List<LabSample.FarmMaster>> GetFarmMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<LabSample.FarmMaster>>("API/LabSample/GetFarmMaster/", "");
                return result;
            }
        }

        public async Task<List<LabSample.ImportExport>> GetAllLabSample(string application_type)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<LabSample.ImportExport>>("API/LabSample/GetAllLabSample?application_type=" + application_type, "");
            }
        }

        public async Task<List<LabSample.SampleDetails>> GetSampleDetailsByID(Guid ID)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<LabSample.SampleDetails>>("API/LabSample/GetSampleDetailsByID?ID=" + ID, "");
            }
        }
        public async Task<LabSample.LabAnalysis> GetSampleAnalysisByID(Guid ID)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<LabSample.LabAnalysis>("API/LabSample/GetSampleAnalysisByID?ID=" + ID, "");
            }
        }

        public async Task<LabSample.LabResult> GetSampleResultByID(Guid ID)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<LabSample.LabResult>("API/LabSample/GetSampleResultByID?ID=" + ID, "");
            }
        }
        public async Task<List<LabSample.CommodityTypeMaster>> GetCommodityTypeMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<LabSample.CommodityTypeMaster>>("API/LabSample/GetCommodityTypeMaster/", "");
                return result;
            }
        }

        public async Task<List<LabSample.CommodityNameMaster>> GetCommodityNameMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<LabSample.CommodityNameMaster>>("API/LabSample/GetCommodityNameMaster/", "");
                return result;
            }
        }

        #region MASTER LIST
        public async Task<List<Lookup_Master>> GetPaymentMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetPaymentMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetPackagingTypeMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetPackagingTypeMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetPackagingConditionMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetPackagingConditionMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetFindingMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetFindingMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetPesticideCommercialNameMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetPesticideCommercialNameMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetPesticideUseMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetPesticideUseMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetFertilizerCommonNameMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetFertilizerCommonNameMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetFertilizerTypeMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetFertilizerTypeMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetElementtobeAnalyzed()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetElementtobeAnalyzed/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetPlantMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetPlantMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetInfectedPlantParts()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetInfectedPlantParts/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetCultivationTypeMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetCultivationTypeMaster/", "");
                return result;
            }
        }
        public async Task<List<Lookup_Master>> GetIrrigationSystemMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetIrrigationSystemMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetInfectionSymptomsMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetInfectionSymptomsMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetInfectionInOnePlant()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetInfectionInOnePlant/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetInfectionInField()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetInfectionInField/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetPesticideTypeMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/LabSample/GetPesticideTypeMaster/", "");
                return result;
            }
        }

        

        #endregion

        #region LAB SAMPLE APPROVAL SECTION
        public async Task<List<Review_History>> SaveRemark(Review_History obj)
        {

            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // obj.Local_Certificate_Registration_No = "0";
            obj.Created_by_Name = Convert.ToString(TempData.Peek("LoggedInUser"));
            obj.Created_by = UserId.ToString();
            obj.Created_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<Review_History>>("API/FertilizerCertificate/SaveRemark", stringContent, "");
                return result;

            }
        }

        public async Task<List<Review_History>> GetAllRemark(Guid CertificateID, string Remark_Type)
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<Review_History>>("API/FertilizerCertificate/GetAllRemark?CertificateID= " + CertificateID + "&Remark_Type=" + Remark_Type, "");
            }
        }

        #endregion LAB SAMPLE APPROVAL SECTION
    }
}