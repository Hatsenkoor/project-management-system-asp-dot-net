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
using static iTextSharp.text.Font;



namespace PCVM.Web.Controllers
{
    public class PesticideCertificateController : Controller
    {
        public PesticideModel model { get; set; }

        public IOptions<Helpers.AppSettings> AppSettings { get; }

        IConfiguration configuration;
        string url;

        public Receipt receiptObj = new Receipt();

        public List<PesticideCertificate> lstPesticideCertificate = new List<PesticideCertificate>();

        public IWebHostEnvironment Env { get; }
   



        public PesticideCertificateController(IConfiguration configuration, IOptions<Helpers.AppSettings> appSettings, IWebHostEnvironment web)
        {
            AppSettings = appSettings;
            Env = web;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            this.configuration = configuration;
            url = this.configuration.GetSection("AppSettings:ApiUrl.Finance").Value;
        }

        #region SAVE UPDATE CANCEL METHOD
        public async Task<string> SaveCertificate(PesticideCertificate obj)
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
                var result = await objectClient.Post<string>("API/PesticideCertificate/SaveCertificate", stringContent, "");
                return result;

            }
        }

        public async Task<List<PesticideCertificate>> SubmitCertificate(PesticideCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

           // obj.Local_Certificate_Registration_No = "0";         
            obj.Updated_by = UserId.ToString();        
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/SubmitCertificate", stringContent, "");
                return result;

            }
        }
        public async Task<List<PesticideCertificate>> RequestCertificateCancel(PesticideCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // obj.Local_Certificate_Registration_No = "0";         
            obj.Updated_by = UserId.ToString();
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/RequestCertificateCancel", stringContent, "");
                return result;

            }
        }

        public async Task<List<PesticideCertificate>> CancelPesticideCertificate(PesticideCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // To Add Remark in case Approver want to approve with remark

            if (obj.Remark != null && obj.Remark.Length > 0)
            {
                Review_History review_History = new Review_History();
                review_History.CertificateID = obj.ID;
                review_History.Remark = obj.Remark;
                // we are using Certificate_Name for Remark_Type
                review_History.Remark_Type = obj.Certificate_Name;
                await SaveRemark(review_History);
            }


            // obj.Local_Certificate_Registration_No = "0";         
            obj.Updated_by = UserId.ToString();
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/CancelCertificate", stringContent, "");
                return result;

            }
        }

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

        public async Task<string> SaveCommonName(Common_Name_Concentration obj)
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
                var result = await objectClient.Post<string>("API/PesticideCertificate/SaveCommonName", stringContent, "");
                return result;

            }
        }
              
        #endregion SAVE UPDATE CANCEL METHOD

        #region Approval Method

        public async Task<List<PesticideCertificate>> SectionHeadApproval(PesticideCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // To Add Remark in case Approver want to approve with remark

            if (obj.Remark != null && obj.Remark.Length > 0)
            {
                Review_History review_History = new Review_History();
                review_History.CertificateID = obj.ID;
                review_History.Remark = obj.Remark;
                // we are using Certificate_Name for Remark_Type
                review_History.Remark_Type = obj.Certificate_Name;
                await SaveRemark(review_History);
            }

            // obj.Local_Certificate_Registration_No = "0";         
            obj.Updated_by = UserId.ToString();
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/SectionHeadApproval", stringContent, "");
                return result;

            }
        }

        public async Task<List<PesticideCertificate>> CommitteeApproval(PesticideCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // To Add Remark in case Approver want to approve with remark

            if (obj.Remark != null && obj.Remark.Length > 0)
            {
                Review_History review_History = new Review_History();
                review_History.CertificateID = obj.ID;
                review_History.Remark = obj.Remark;
                // we are using Certificate_Name for Remark_Type
                review_History.Remark_Type = obj.Certificate_Name;
                await SaveRemark(review_History);
            }


            // obj.Local_Certificate_Registration_No = "0";         
            obj.Updated_by = UserId.ToString();
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/CommitteeApproval", stringContent, "");
                return result;

            }
        }

        public async Task<List<PesticideCertificate>> DirectorApproval(PesticideCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // To Add Remark in case Approver want to approve with remark

            if (obj.Remark != null && obj.Remark.Length > 0)
            {
                Review_History review_History = new Review_History();
                review_History.CertificateID = obj.ID;
                review_History.Remark = obj.Remark;
                // we are using Certificate_Name for Remark_Type
                review_History.Remark_Type = obj.Certificate_Name;
                await SaveRemark(review_History);
            }


            // obj.Local_Certificate_Registration_No = "0";         
            obj.Updated_by = UserId.ToString();
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/DirectorApproval", stringContent, "");
                return result;

            }
        }


        #endregion

        #region PAYMENT METHOD

        public async Task<string> SavePayment(Payment obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<string>("API/FertilizerCertificate/SavePayment", stringContent, "");
                return result;

            }
        }

        public async Task<List<PesticideCertificate>> RegistrationFee(PesticideCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // obj.Local_Certificate_Registration_No = "0";         
            obj.Updated_by = UserId.ToString();
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/RegistrationFee", stringContent, "");
                return result;

            }
        }

        public async Task<List<PesticideCertificate>> CertificateFee(PesticideCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // obj.Local_Certificate_Registration_No = "0";         
            obj.Updated_by = UserId.ToString();
            obj.Updated_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/CertificateFee", stringContent, "");
                return result;

            }
        }

        #endregion

        #region GET LIST
        

        public async Task<List<PesticideCertificate>> GetAllCertificateDefault()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/GetAllCertificateDefault", "");
            }
        }
        public async Task<List<PesticideCertificate>> GetAllCertificate(string application_type)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/GetAllCertificate?application_type=" + application_type, "");
            }
        }

        public async Task<List<PesticideCertificate>> getAllSectionHeadCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/getAllSectionHeadCertificate", "");
            }
        }

        public async Task<List<PesticideCertificate>> getAllCommitteeCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/getAllCommitteeCertificate", "");
            }
        }
        public async Task<List<PesticideCertificate>> getAllApprovedCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/getAllApprovedCertificate", "");
            }
        }
        public async Task<List<PesticideCertificate>> getAllPaymentCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/getAllPaymentCertificate", "");
            }
        }
        public async Task<List<PesticideCertificate>> getAllIssuedCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/getAllIssuedCertificate", "");
            }
        }
        public async Task<List<PesticideCertificate>> getAllCancelCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/getAllCancelCertificate", "");
            }
        }

        public async Task<List<Review_History>> GetAllRemark(Guid CertificateID, string Remark_Type)
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<Review_History>>("API/FertilizerCertificate/GetAllRemark?CertificateID= " + CertificateID + "&Remark_Type=" + Remark_Type, "");
            }
        }
        public async Task<List<Common_Name_Concentration>> getAllCommonName(Guid certificateID)
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Common_Name_Concentration>>("API/PesticideCertificate/getAllCommonName?CertificateID= " + certificateID, "");
                return result;
            }
        }


        #endregion

        #region MASTER LIST

        public async Task<List<Lookup_Master>> getCertificateMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/PesticideCertificate/getCertificateMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> getPesticideUseMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/PesticideCertificate/getPesticideUseMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> getTypeFormulationMaster()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/PesticideCertificate/getTypeFormulationMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> getWHOToxicityMaster()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/PesticideCertificate/getWHOToxicityMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> getCommonNameMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/PesticideCertificate/getCommonNameMaster/", "");
                return result;
            }
        }

        public async Task<List<Chemical_Class_Master>> getChemicalClassMasterList()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Chemical_Class_Master>>("API/PesticideCertificate/getChemicalClassMasterList/", "");
                return result;
            }
        }

        public async Task<List<Target_Pest_Master>> getTargetPestMasterList()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Target_Pest_Master>>("API/PesticideCertificate/getTargetPestMasterList/", "");
                return result;
            }
        }

        public async Task<List<CAS_RN_Master>> getCASRNMasterList()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<CAS_RN_Master>>("API/PesticideCertificate/getCASRNMasterList/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> getServiceMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/PesticideCertificate/getServiceMaster/", "");
                return result;
            }
        }


        #endregion MASTER LIST


        #region ALL PAGE VIEW
        public IActionResult Approval()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }

        public IActionResult Issue()
        {
            return View();
        }
        public async Task<IActionResult> Payment()
        {
            return View(await PageLoad());
        }
      
        public IActionResult RequestCancel()
        {
            return View();
        }

        public IActionResult Review()
        {
            return View();

        }
        public IActionResult Committee()
        {
            return View();
        }

        public async Task<IActionResult> Imported()
        {

            return View(await PageLoad());

        }

        public async Task<IActionResult> Local()
        {

            return View(await PageLoad());

        }

        public async Task<IActionResult> Dashboard()
        {

            return View();

        }

        #endregion ALL PAGE VIEW


        public async Task<PesticideModel> PageLoad()
        {

            var browserLang = Request.Headers["Accept-Language"].ToString().Split(";").FirstOrDefault()?.Split(",").FirstOrDefault();
            browserLang = Thread.CurrentThread.CurrentCulture.Name;

            model = new PesticideModel();

            #region Certificate Master List

            model.CertificateMaster = new List<SelectListItem>();
            model.CertificateMaster.Add(new SelectListItem());

            var ObjCertificateMaster = await this.getCertificateMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.CertificateMaster.AddRange(ObjCertificateMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.CertificateMaster.AddRange(ObjCertificateMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.CertificateMaster.RemoveAt(0);

            #endregion

            #region Pesticide Use Master

            model.PesticideUseMaster = new List<SelectListItem>();
            model.PesticideUseMaster.Add(new SelectListItem());

            var ObjPesticideUseMaster = await this.getPesticideUseMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.PesticideUseMaster.AddRange(ObjPesticideUseMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PesticideUseMaster.AddRange(ObjPesticideUseMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.PesticideUseMaster.RemoveAt(0);

            #endregion

            #region Type Formulation Master

            model.TypeFormulationMaster = new List<SelectListItem>();
            model.TypeFormulationMaster.Add(new SelectListItem());

            var ObjTypeFormulationMaster = await this.getTypeFormulationMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.TypeFormulationMaster.AddRange(ObjTypeFormulationMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.TypeFormulationMaster.AddRange(ObjTypeFormulationMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.TypeFormulationMaster.RemoveAt(0);

            #endregion

            #region WHO Toxicity Master

            model.WHOToxicityMaster = new List<SelectListItem>();
            model.WHOToxicityMaster.Add(new SelectListItem());

            var ObjWHOToxicityMaster = await this.getWHOToxicityMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.WHOToxicityMaster.AddRange(ObjWHOToxicityMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.WHOToxicityMaster.AddRange(ObjWHOToxicityMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.WHOToxicityMaster.RemoveAt(0);


            #endregion WHO Toxicity Master

            #region Common Name Master

            model.CommonNameMaster = new List<SelectListItem>();
            model.CommonNameMaster.Add(new SelectListItem());

            var ObjCommonNameMaster = await this.getCommonNameMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.CommonNameMaster.AddRange(ObjCommonNameMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.CommonNameMaster.AddRange(ObjCommonNameMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.CommonNameMaster.RemoveAt(0);


            #endregion Common Name Master                   

            #region CASRNMaster

            model.CASRNMaster = new List<SelectListItem>();
            model.CASRNMaster.Add(new SelectListItem());

            var ObjCASRNMaster = await this.getCASRNMasterList();

            if (browserLang.ToLower() == "en-us")
            {
                model.CASRNMaster.AddRange(ObjCASRNMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.CASRNMaster.AddRange(ObjCASRNMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.CASRNMaster.RemoveAt(0);

            #endregion


            #region Chemical Class Master

            model.ChemicalClassMaster = new List<SelectListItem>();
            model.ChemicalClassMaster.Add(new SelectListItem());

            var ObjChemicalClassMaster = await this.getChemicalClassMasterList();

            if (browserLang.ToLower() == "en-us")
            {
                model.ChemicalClassMaster.AddRange(ObjChemicalClassMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.ChemicalClassMaster.AddRange(ObjChemicalClassMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.ChemicalClassMaster.RemoveAt(0);

            #endregion         

            #region Target Pest Master

            model.TargetPestMaster = new List<SelectListItem>();
            model.TargetPestMaster.Add(new SelectListItem());

            var ObjTargetPestMaster = await this.getTargetPestMasterList();

            if (browserLang.ToLower() == "en-us")
            {
                model.TargetPestMaster.AddRange(ObjTargetPestMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.TargetPestMaster.AddRange(ObjTargetPestMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.TargetPestMaster.RemoveAt(0);

            #endregion

            #region Service Master

            model.ServiceMaster = new List<SelectListItem>();
            model.ServiceMaster.Add(new SelectListItem());

            var ObjServiceMaster = await this.getServiceMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.ServiceMaster.AddRange(ObjServiceMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.ServiceMaster.AddRange(ObjServiceMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.ServiceMaster.RemoveAt(0);


            #endregion Service Master                   

            return model;

        }

        #region Analysis Dashboard

        public async Task<List<Common.CertificateAnalysis>> GetCertificateAnalysis()
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Common.CertificateAnalysis>>("API/PesticideCertificate/GetCertificateAnalysis/?userid=" + UserId, "");
                return result;
            }

        }

        public async Task<List<PesticideCertificate>> getReviewPendingCertificate()
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/getReviewPendingCertificate/?userid=" + UserId, "");
                return result;
            }

        }

        public async Task<List<PesticideCertificate>> getApprovalPendingCertificate()
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/getApprovalPendingCertificate/?userid=" + UserId, "");
                return result;
            }

        }


        #endregion

        #region Certification Generation

        public async Task<ActionResult> CertificateDesign_Old(int application_type)
        {
            #region GENERAL

            string webRootPath = Env.WebRootPath;
            string rootPath = "";
            rootPath = Path.Combine(webRootPath, "font\\");

            BaseFont harman = BaseFont.CreateFont(rootPath + "Arial_Italic.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Create a font from the base font 
            iTextSharp.text.Font f_harman = new iTextSharp.text.Font(harman, 12);
            iTextSharp.text.Font f_harman_i = new iTextSharp.text.Font(harman, 12, iTextSharp.text.Font.ITALIC);

            ///////////////////////////////////
            BaseFont bfArialUniCode = BaseFont.CreateFont(rootPath + "Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Create a font from the base font 
            iTextSharp.text.Font font = new iTextSharp.text.Font(bfArialUniCode, 12);
            iTextSharp.text.Font fontB = new iTextSharp.text.Font(bfArialUniCode, 12, BOLD);
            iTextSharp.text.Font fonti = new iTextSharp.text.Font(bfArialUniCode, 12, iTextSharp.text.Font.ITALIC);


            var doc = new iTextSharp.text.Document(PageSize.A4);

            string directoryName = DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss");

            string path = Path.Combine(webRootPath, "pdf\\") + directoryName + "_Voucher.pdf";

            if (System.IO.File.Exists(path + ".pdf"))
            {
                System.IO.File.Copy(path + ".pdf", path + "_temp.pdf", true);
                System.IO.File.Delete(path + ".pdf");
            }

            //path = path + ".pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();


            PdfContentByte cb = writer.DirectContent;

            double docWidth = doc.PageSize.Width;
            double docHeight = doc.PageSize.Height;

            double rateX = 680.0 / docWidth;
            double rateY = 960.0 / docHeight;

            int center = Convert.ToInt32(docWidth / 2);

            //Add the cell to the table 
            int cellHeight = 25;
            int headerHeight = 30;


            //Create a regex expression to detect hebrew or arabic code points 
            const string regex_match_arabic_hebrew = @"[\u0600-\u06FF,\u0590-\u05FF]+";

            #endregion GENERAL

            #region Receipt Details

            try
            {

                using (var objectClient = new ApiClient(AppSettings))
                {

                    lstPesticideCertificate = await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/GetAllCertificate?application_type=" + application_type, "");

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            #endregion Receipt details           

            #region BORDERS

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue start

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(5 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(955 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(675 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(5 / rateY));
            cb.SetLineWidth(1);
            cb.SetColorStroke(new BaseColor(Color.Blue));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue end


            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary green start

            // LEFT SIDE VERTICAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(17 / rateX), (float)(943 / rateY));

            //TOP HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(943 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            // RIGHT SIDE VERTICAL LINE
            cb.MoveTo((float)(663 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            //BOTTOM HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(17 / rateY));

            cb.SetLineWidth(3);
            // cb.SetColorStroke(new BaseColor(174, 47, 45));
            cb.SetColorStroke(new BaseColor(Color.ForestGreen));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary gray end
            ///


            #endregion BORDERS          

            #region Center TOP LOGO

            //////////////////////////////////////////////////////////////////////  png mark center logo

            String imageURL = Path.Combine(webRootPath, "images\\") + "logo_white.png";

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            jpg.ScaleToFit(100f, 100f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            jpg.SetAbsolutePosition((float)(docWidth - jpg.ScaledWidth) / 2, (float)(943 / rateY) - 100);

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(jpg);

            #endregion CENTER TOP LOGO

            #region LEFT SIDE HEADER
            ///////////////////////////////////////////////////////   header Text

            String header_text = "Sultanate of Oman";

            cb.SetColorFill(new BaseColor(0, 255, 0));
            PdfPTable tablehr1 = new PdfPTable(1);
            tablehr1.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr1.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 14;
            font.SetColor(0, 0, 0);
            PdfPCell texthr1 = new PdfPCell(new Phrase(header_text, font));
            texthr1.FixedHeight = (float)(60 / rateY);
            texthr1.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            texthr1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr1.PaddingTop = 0;
            texthr1.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr1.SetLeading((float)1.5, (float)1.3);
            texthr1.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr1.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr1.NoWrap = false;

            //Add the cell to the table 
            tablehr1.AddCell(texthr1);

            //Add the table to the document 
            PdfContentByte pcbhr1 = writer.DirectContent;
            tablehr1.TotalWidth = (float)(docWidth / rateX);
            tablehr1.WriteSelectedRows(0, -1, (float)(36 / rateX), (float)(950 / rateY), pcbhr1); // changed from 255 t 263 by harmanjeet on 7/4/2019
                                                                                                  ///////////////////////////////////////////////////////////


            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehr2 = new PdfPTable(1);
            tablehr2.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr2.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 10;
            font.SetColor(0, 0, 0);
            PdfPCell texthr2 = new PdfPCell(new Phrase("Ministry of Agriculture \n Fisheries Wealth & Water Resources", font));
            texthr2.FixedHeight = (float)(60 / rateY);
            texthr2.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            texthr2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr2.PaddingTop = 0;
            texthr2.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr2.SetLeading((float)1.5, (float)1.3);
            texthr2.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr2.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr2.NoWrap = false;

            //Add the cell to the table 
            tablehr2.AddCell(texthr2);

            //Add the table to the document 
            PdfContentByte pcbhr2 = writer.DirectContent;
            tablehr2.TotalWidth = (float)(docWidth / rateX);
            tablehr2.WriteSelectedRows(0, -1, (float)(36 / rateX), (float)(910 / rateY), pcbhr2); // changed from 255 t 263 by harmanjeet on 7/4/2019
                                                                                                  ///////////////////////////////////////////////////////////
            ///


            String header3_text = "Directorate General for Agriculture Development";

            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehr3 = new PdfPTable(1);
            tablehr3.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr3.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 10;
            font.SetColor(0, 0, 0);
            PdfPCell texthr3 = new PdfPCell(new Phrase(header3_text, font));
            texthr3.FixedHeight = (float)(60 / rateY);
            texthr3.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            texthr3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr3.PaddingTop = 0;
            texthr3.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr3.SetLeading((float)1.5, (float)1.3);
            texthr3.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr3.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr3.NoWrap = false;

            //Add the cell to the table 
            tablehr3.AddCell(texthr3);
            //Add the table to the document 
            PdfContentByte pcbhr3 = writer.DirectContent;
            tablehr3.TotalWidth = (float)(docWidth / rateX);
            tablehr3.WriteSelectedRows(0, -1, (float)(36 / rateX), (float)(875 / rateY), pcbhr3); // changed from 255 t 263 by harmanjeet on 7/4/2019

            /////////////////////////////////////////////////////////////////////////////////// Header End

            #endregion LEFT SIDE HEADER

            #region RIGHT SIDE HEADER
            ///////////////////////////////////////////////////////   header Text

            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehtop = new PdfPTable(1);
            tablehtop.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehtop.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehtop.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 14;  // changed font to italic font fonti by harmanjeet 0n 7/4/2019
            font.SetColor(0, 0, 0);
            PdfPCell texttop = new PdfPCell(new Phrase("سلطنة عمان", font));
            texttop.FixedHeight = (float)(60 / rateY);
            texttop.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            texttop.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texttop.PaddingTop = 0;
            texttop.PaddingRight = 0;
            texttop.BorderColor = new BaseColor(174, 47, 45);
            texttop.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texttop.NoWrap = false;

            //Add the cell to the table 
            tablehtop.AddCell(texttop);

            //Add the table to the document 
            PdfContentByte pcbhtop = writer.DirectContent;
            tablehtop.TotalWidth = (float)(docWidth);
            tablehtop.WriteSelectedRows(0, -1, (float)((-36) / rateX), (float)(950 / rateY), pcbhtop);

            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehr2r = new PdfPTable(1);
            tablehr2r.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr2r.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr2r.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 12;
            font.SetColor(0, 0, 0);
            PdfPCell texthr2r = new PdfPCell(new Phrase("وزارة الثروة الزراعية \n والسمكية وموارد المياه", font));
            texthr2r.FixedHeight = (float)(60 / rateY);
            texthr2r.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            texthr2r.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr2r.PaddingTop = 0;
            texthr2r.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr2r.SetLeading((float)1.5, (float)1.3);
            texthr2r.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr2r.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr2r.NoWrap = false;

            //Add the cell to the table 
            tablehr2r.AddCell(texthr2r);

            //Add the table to the document 
            PdfContentByte pcbhr2r = writer.DirectContent;
            tablehr2r.TotalWidth = (float)(docWidth);
            tablehr2r.WriteSelectedRows(0, -1, (float)((-36) / rateX), (float)(910 / rateY), pcbhr2r); // changed from 255 t 263 by harmanjeet on 7/4/2019
                                                                                                       ///////////////////////////////////////////////////////////
            ///


            String header3r_text = "المديرية العامة للأمن الغذائي";


            PdfPTable tablehr3r = new PdfPTable(1);
            tablehr3r.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr3r.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr3r.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 12;
            font.SetColor(0, 0, 0);
            PdfPCell texthr3r = new PdfPCell(new Phrase(header3r_text, font));
            texthr3r.FixedHeight = (float)(60 / rateY);
            texthr3r.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            texthr3r.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr3r.PaddingTop = 0;
            texthr3r.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr3r.SetLeading((float)1.5, (float)1.3);
            texthr3r.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr3r.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr3r.NoWrap = false;

            //Add the cell to the table 
            tablehr3r.AddCell(texthr3r);

            //Add the table to the document 
            PdfContentByte pcbhr3r = writer.DirectContent;
            tablehr3r.TotalWidth = (float)(docWidth);
            tablehr3r.WriteSelectedRows(0, -1, (float)(-36 / rateX), (float)(875 / rateY), pcbhr3r); // changed from 255 t 263 by harmanjeet on 7/4/2019

            /////////////////////////////////////////////////////////////////////////////////// Header End

            #endregion RIGHT SIDE HEADER

            #region Center TOP TITLE

            //////////////////////////////////////////////////////////////////////  png mark center logo

            String imageURLTitle = Path.Combine(webRootPath, "images\\") + "pesticide_certificate.png";

            iTextSharp.text.Image imageTitle = iTextSharp.text.Image.GetInstance(imageURLTitle);
            imageTitle.ScaleToFit(300f, 50f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            imageTitle.SetAbsolutePosition((float)(docWidth - imageTitle.ScaledWidth) / 2, (float)(943 / rateY) - 150);

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageTitle);

            #endregion CENTER TOP TITLE          

         
            #region RECEIVED FROM

            ////////////////////////////// Second Table right side
            ///
            PdfPTable table_received_from = new PdfPTable(1);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_received_from.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_received_from.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }


            //Create a cell and add text to it 
            font.Size = 11;
            PdfPCell txt_received_from_cell = new PdfPCell(new Phrase("تشهد وزارة الزراعة والثروة السمكية بأن المنتج مسجل ويسمح بتداوله في سلطنة عمان للاستعمال الزراعي طبقا لقانون الأسمدة ومحسنات التربة الزراعية رقم 63, 2006 م ولائحته التنفيذية رقم 128 | 2010م بالمواصفات التالية:", font));
            txt_received_from_cell.FixedHeight = (float)(37f / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
            txt_received_from_cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            txt_received_from_cell.NoWrap = false;
            txt_received_from_cell.PaddingTop = 0;
            //text2.BorderColor = new BaseColor(174, 47, 45);
            txt_received_from_cell.BorderWidth = 0;

            //Add the cell to the table 
            table_received_from.AddCell(txt_received_from_cell);

            //Add the table to the document 
            PdfContentByte pcb2_distibutor = writer.DirectContent;
            table_received_from.TotalWidth = (float)(docWidth - 50);
            table_received_from.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(720 / rateY), pcb2_distibutor); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                      //doc.Add(table2);

            #endregion RECEIVED FROM

            #region Paragraph2

            ////////////////////////////// Second Table right side
            ///
            PdfPTable table_received_from1 = new PdfPTable(1);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_received_from.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_received_from1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }


            //Create a cell and add text to it 
            font.Size = 11;
            PdfPCell txt_received_from_cell1 = new PdfPCell(new Phrase("الاسم العام / الشائع: محسن تربة عضوي يحتوي على ألياف من ثمار جوز الهند (قالب مضغوط) ويستخدم كوسط زراعي.", font));
            txt_received_from_cell1.FixedHeight = (float)(37f / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
            txt_received_from_cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            txt_received_from_cell1.NoWrap = false;
            txt_received_from_cell1.PaddingTop = 0;
            //text2.BorderColor = new BaseColor(174, 47, 45);
            txt_received_from_cell1.BorderWidth = 0;

            //Add the cell to the table 
            table_received_from1.AddCell(txt_received_from_cell1);

            //Add the table to the document 
            PdfContentByte pcb2_distibutor1 = writer.DirectContent;
            table_received_from1.TotalWidth = (float)(docWidth - 50);
            table_received_from1.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(680 / rateY), pcb2_distibutor); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                       //doc.Add(table2);

            #endregion Paragraph2

            #region CoCoZain

            ////////////////////////////// Second Table right side
            ///
            PdfPTable table_amount_letter = new PdfPTable(1);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_amount_letter.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_amount_letter.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }


            //Create a cell and add text to it 
            font.Size = 11;
            PdfPCell txt_amount_letter_cell = new PdfPCell(new Phrase("الاسم التجاري: CoCoZain CcoBlock 5Kg", font));
            txt_amount_letter_cell.FixedHeight = (float)(37f / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
            txt_amount_letter_cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            txt_amount_letter_cell.NoWrap = false;
            txt_amount_letter_cell.PaddingTop = 0;
            //text2.BorderColor = new BaseColor(174, 47, 45);
            txt_amount_letter_cell.BorderWidth = 0;

            //Add the cell to the table 
            table_amount_letter.AddCell(txt_amount_letter_cell);

            //Add the table to the document 
            PdfContentByte pcb2_amount_letter = writer.DirectContent;
            table_amount_letter.TotalWidth = (float)(docWidth - 50);
            table_amount_letter.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(650 / rateY), pcb2_amount_letter); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                         //doc.Add(table2);

            #endregion CoCoZain

            #region CoCoZain1

            ////////////////////////////// Second Table right side
            ///
            PdfPTable table_amount_letter1 = new PdfPTable(1);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_amount_letter1.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_amount_letter1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }


            //Create a cell and add text to it 
            font.Size = 11;
            PdfPCell txt_amount_letter_cell1 = new PdfPCell(new Phrase("طبيعة السماد : صلب", font));
            txt_amount_letter_cell1.FixedHeight = (float)(37f / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
            txt_amount_letter_cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            txt_amount_letter_cell1.NoWrap = false;
            txt_amount_letter_cell1.PaddingTop = 0;
            //text2.BorderColor = new BaseColor(174, 47, 45);
            txt_amount_letter_cell1.BorderWidth = 0;

            //Add the cell to the table 
            table_amount_letter1.AddCell(txt_amount_letter_cell1);

            //Add the table to the document 
            PdfContentByte pcb2_amount_letter1 = writer.DirectContent;
            table_amount_letter1.TotalWidth = (float)(docWidth - 50);
            table_amount_letter1.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(610 / rateY), pcb2_amount_letter1); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                           //doc.Add(table2);

            #endregion CoCoZain1

            #region CoCoZain2

            ////////////////////////////// Second Table right side
            ///
            PdfPTable table_amount_letter2 = new PdfPTable(1);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_amount_letter2.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_amount_letter2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }


            //Create a cell and add text to it 
            font.Size = 11;
            PdfPCell txt_amount_letter_cell2 = new PdfPCell(new Phrase("الشركة المنتجة وعنوانها: Celan Coir Products - سيرلانكا -", font));
            txt_amount_letter_cell2.FixedHeight = (float)(37f / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
            txt_amount_letter_cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            txt_amount_letter_cell2.NoWrap = false;
            txt_amount_letter_cell2.PaddingTop = 0;
            //text2.BorderColor = new BaseColor(174, 47, 45);
            txt_amount_letter_cell2.BorderWidth = 0;

            //Add the cell to the table 
            table_amount_letter2.AddCell(txt_amount_letter_cell2);

            //Add the table to the document 
            PdfContentByte pcb2_amount_letter2 = writer.DirectContent;
            table_amount_letter2.TotalWidth = (float)(docWidth - 50);
            table_amount_letter2.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(570 / rateY), pcb2_amount_letter2); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                           //doc.Add(table2);

            #endregion CoCoZain2

            #region CoCoZain3

            ////////////////////////////// Second Table right side
            ///
            PdfPTable table_amount_letter3 = new PdfPTable(1);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_amount_letter3.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_amount_letter3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }


            //Create a cell and add text to it 
            font.Size = 11;
            PdfPCell txt_amount_letter_cell3 = new PdfPCell(new Phrase("الشركة المستوردة وعنوانها: مؤسسة البحر العربي الحديثة - محافظة مسقط", font));
            txt_amount_letter_cell3.FixedHeight = (float)(37f / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
            txt_amount_letter_cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            txt_amount_letter_cell3.NoWrap = false;
            txt_amount_letter_cell3.PaddingTop = 0;
            //text2.BorderColor = new BaseColor(174, 47, 45);
            txt_amount_letter_cell3.BorderWidth = 0;

            //Add the cell to the table 
            table_amount_letter3.AddCell(txt_amount_letter_cell3);

            //Add the table to the document 
            PdfContentByte pcb2_amount_letter3 = writer.DirectContent;
            table_amount_letter3.TotalWidth = (float)(docWidth - 50);
            table_amount_letter3.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(530 / rateY), pcb2_amount_letter3); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                           //doc.Add(table2);

            #endregion CoCoZain3

            #region CHEQUE SECTION

            PdfPTable table_cheque = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_cheque.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_cheque.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            string cheque_due_date = "تاريخ الانتهاء :1\\11\\2026م";
            string cheque_no = "تاريخ الإصدار: 1\\11\\2021م";

            font.Size = 10;
            font.SetColor(0, 0, 0);

            PdfPCell cheque_due_date_Cell = new PdfPCell(new Phrase(cheque_due_date, font));
            cheque_due_date_Cell.FixedHeight = (float)(cellHeight / rateY);
            cheque_due_date_Cell.NoWrap = false;
            cheque_due_date_Cell.PaddingTop = 0;
            cheque_due_date_Cell.BorderColor = new BaseColor(174, 47, 45);
            cheque_due_date_Cell.BorderWidth = 0;
            cheque_due_date_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cheque_due_date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cheque_due_date_Cell.Colspan = 1;


            PdfPCell cheque_no_cell = new PdfPCell(new Phrase(cheque_no, font));
            cheque_no_cell.FixedHeight = (float)(cellHeight / rateY);
            cheque_no_cell.NoWrap = false;
            cheque_no_cell.PaddingTop = 0;
            cheque_no_cell.BorderColor = new BaseColor(0, 0, 0);
            cheque_no_cell.BorderWidth = 0;
            cheque_no_cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cheque_no_cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cheque_no_cell.Colspan = 1;

            table_cheque.AddCell(cheque_no_cell);
            table_cheque.AddCell(cheque_due_date_Cell);


            //Add the table to the document 
            PdfContentByte pcb_cheque = writer.DirectContent;
            table_cheque.TotalWidth = (float)(630 / rateX);
            table_cheque.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(490 / rateY), pcb_cheque);


            #endregion CHEQUE SECTION

            #region BANK NAME


            PdfPTable table_Bank_Name = new PdfPTable(1);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_Bank_Name.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_Bank_Name.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }


            //Create a cell and add text to it 
            font.Size = 11;
            PdfPCell Bank_Name_cell = new PdfPCell(new Phrase("النسبة المئوية للمكونات (طبقا للذائب في الماء المقطر للجاف وزن / وزن للسوائل أو المعلق وژن احجم:", font));
            Bank_Name_cell.FixedHeight = (float)(37f / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
            Bank_Name_cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            Bank_Name_cell.NoWrap = false;
            Bank_Name_cell.PaddingTop = 0;
            //text2.BorderColor = new BaseColor(174, 47, 45);
            Bank_Name_cell.BorderWidth = 0;

            //Add the cell to the table 
            table_Bank_Name.AddCell(Bank_Name_cell);

            //Add the table to the document 
            PdfContentByte pcb_bank_name = writer.DirectContent;
            table_Bank_Name.TotalWidth = (float)(docWidth - 50);
            table_Bank_Name.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(450 / rateY), pcb_bank_name); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                //doc.Add(table2);

            #endregion BANK NAME

            #region BORDERS

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue start

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(5 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(955 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(675 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(5 / rateY));
            cb.SetLineWidth(1);
            cb.SetColorStroke(new BaseColor(Color.Blue));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue end


            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary gray start

            // LEFT SIDE VERTICAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(17 / rateX), (float)(943 / rateY));

            //TOP HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(943 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            // RIGHT SIDE VERTICAL LINE
            cb.MoveTo((float)(663 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            //BOTTOM HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(17 / rateY));

            cb.SetLineWidth(3);
            // cb.SetColorStroke(new BaseColor(174, 47, 45));
            cb.SetColorStroke(new BaseColor(Color.ForestGreen));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary gray end
            ///


            #endregion BORDERS

            #region ITEMS TABLE

            try
            {

                using (var objectClient = new ApiClient(AppSettings))
                {
                    lstPesticideCertificate = await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/GetAllCertificate?application_type=" + application_type, "");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            // PdfPTable table8 = new PdfPTable(4);
            PdfPTable tbl_Items = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tbl_Items.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tbl_Items.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            if (lstPesticideCertificate.Count > 10)
            {
                cellHeight = 20;
                headerHeight = 25;
            }

            iTextSharp.text.Font headerFont;

            if (lstPesticideCertificate.Count > 10)
                headerFont = new iTextSharp.text.Font(bfArialUniCode, 6);
            else
                headerFont = new iTextSharp.text.Font(bfArialUniCode, 8);

            iTextSharp.text.Font cellFont;

            if (lstPesticideCertificate.Count > 10)
                cellFont = new iTextSharp.text.Font(bfArialUniCode, 5);
            else
                cellFont = new iTextSharp.text.Font(bfArialUniCode, 7);



            string Value = "90%";
            string Element_Description = "المادة العضوية (Organic Matter)";


            PdfPCell Element_Description_Cell = new PdfPCell(new Phrase(Element_Description, headerFont));
            Element_Description_Cell.FixedHeight = (float)(headerHeight / rateY);
            Element_Description_Cell.NoWrap = false;
            Element_Description_Cell.PaddingTop = 0;
            Element_Description_Cell.BorderColor = new BaseColor(0, 0, 0);
            Element_Description_Cell.BorderWidth = 1;
            Element_Description_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Element_Description_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Value_Cell = new PdfPCell(new Phrase(Value, headerFont));
            Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Value_Cell.NoWrap = false;
            Value_Cell.PaddingTop = 0;
            Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Value_Cell.BorderWidth = 1;
            Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;


            tbl_Items.AddCell(Element_Description_Cell);
            tbl_Items.AddCell(Value_Cell);

            string Value1 = "5.5-6.5";
            string Element_Description1 = "الرقم الهيدروجيني(pH)";


            PdfPCell Element_Description_Cell1 = new PdfPCell(new Phrase(Element_Description1, headerFont));
            Element_Description_Cell1.FixedHeight = (float)(headerHeight / rateY);
            Element_Description_Cell1.NoWrap = false;
            Element_Description_Cell1.PaddingTop = 0;
            Element_Description_Cell1.BorderColor = new BaseColor(0, 0, 0);
            Element_Description_Cell1.BorderWidth = 1;
            Element_Description_Cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            Element_Description_Cell1.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Value_Cell1 = new PdfPCell(new Phrase(Value1, headerFont));
            Value_Cell1.FixedHeight = (float)(headerHeight / rateY);
            Value_Cell1.NoWrap = false;
            Value_Cell1.PaddingTop = 0;
            Value_Cell1.BorderColor = new BaseColor(0, 0, 0);
            Value_Cell1.BorderWidth = 1;
            Value_Cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            Value_Cell1.VerticalAlignment = Element.ALIGN_MIDDLE;


            tbl_Items.AddCell(Element_Description_Cell1);
            tbl_Items.AddCell(Value_Cell1);

            string Value2 = "25%";
            string Element_Description2 = "الرطوبة (Moisture Contents)";


            PdfPCell Element_Description_Cell2 = new PdfPCell(new Phrase(Element_Description2, headerFont));
            Element_Description_Cell2.FixedHeight = (float)(headerHeight / rateY);
            Element_Description_Cell2.NoWrap = false;
            Element_Description_Cell2.PaddingTop = 0;
            Element_Description_Cell2.BorderColor = new BaseColor(0, 0, 0);
            Element_Description_Cell2.BorderWidth = 1;
            Element_Description_Cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            Element_Description_Cell2.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Value_Cell2 = new PdfPCell(new Phrase(Value2, headerFont));
            Value_Cell2.FixedHeight = (float)(headerHeight / rateY);
            Value_Cell2.NoWrap = false;
            Value_Cell2.PaddingTop = 0;
            Value_Cell2.BorderColor = new BaseColor(0, 0, 0);
            Value_Cell2.BorderWidth = 1;
            Value_Cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            Value_Cell2.VerticalAlignment = Element.ALIGN_MIDDLE;


            tbl_Items.AddCell(Element_Description_Cell2);
            tbl_Items.AddCell(Value_Cell2);

            string Value3 = "1mS/cm";
            string Element_Description3 = "التوصيل الكهربائي (EG)";


            PdfPCell Element_Description_Cell3 = new PdfPCell(new Phrase(Element_Description3, headerFont));
            Element_Description_Cell3.FixedHeight = (float)(headerHeight / rateY);
            Element_Description_Cell3.NoWrap = false;
            Element_Description_Cell3.PaddingTop = 0;
            Element_Description_Cell3.BorderColor = new BaseColor(0, 0, 0);
            Element_Description_Cell3.BorderWidth = 1;
            Element_Description_Cell3.HorizontalAlignment = Element.ALIGN_LEFT;
            Element_Description_Cell3.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Value_Cell3 = new PdfPCell(new Phrase(Value3, headerFont));
            Value_Cell3.FixedHeight = (float)(headerHeight / rateY);
            Value_Cell3.NoWrap = false;
            Value_Cell3.PaddingTop = 0;
            Value_Cell3.BorderColor = new BaseColor(0, 0, 0);
            Value_Cell3.BorderWidth = 1;
            Value_Cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            Value_Cell3.VerticalAlignment = Element.ALIGN_MIDDLE;


            tbl_Items.AddCell(Element_Description_Cell3);
            tbl_Items.AddCell(Value_Cell3);


            for (int i = 0; i < lstPesticideCertificate.Count; i++)
            {

                Value = Convert.ToString(lstPesticideCertificate[i].Created_date);
                Element_Description = Convert.ToString(lstPesticideCertificate[i].CertificateFee);

                Value_Cell = new PdfPCell(new Phrase(Value, cellFont));
                Value_Cell.FixedHeight = (float)(cellHeight / rateY);
                Value_Cell.NoWrap = false;
                Value_Cell.Padding = 0;
                Value_Cell.BorderColor = new BaseColor(0, 0, 0);
                Value_Cell.BorderWidth = 1;
                Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                Element_Description_Cell = new PdfPCell(new Phrase(Element_Description, cellFont));
                Element_Description_Cell.FixedHeight = (float)(cellHeight / rateY);
                Element_Description_Cell.NoWrap = false;
                Element_Description_Cell.Padding = 0;
                Element_Description_Cell.BorderColor = new BaseColor(0, 0, 0);
                Element_Description_Cell.BorderWidth = 1;
                Element_Description_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                Element_Description_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                tbl_Items.AddCell(Value_Cell);
                tbl_Items.AddCell(Element_Description_Cell);


            }

            //Add the table to the document 
            PdfContentByte pcb8 = writer.DirectContent;
            tbl_Items.TotalWidth = (float)(docWidth - 50);

            if (lstPesticideCertificate.Count > 10)
                tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(360 + cellHeight * lstPesticideCertificate.Count / rateY), pcb8);
            else
                tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(360 + cellHeight * lstPesticideCertificate.Count / rateY), pcb8);

            ////////////////////////////////////////////////////////////////////////////////////////////
            #endregion ITEMS TABLE

            #region Middle Line Divider
            /*
            String imageURL1 = Server.MapPath(".") + "/images/save.png";

            iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(imageURL1);
            jpg1.ScaleToFit(30f, 260f);

            jpg1.Alignment = Element.ALIGN_CENTER;

            jpg1.SetAbsolutePosition((float)(283.0), (float)350.0);
            doc.Add(jpg1);
            */
            ///////////////////////////////////   center logo end
            ///
            #endregion MIddle Line Divider

            #region UNDERLINE


            /////////////////////////////////////////////////////////////////////////////////////////////////////  note underline start

            // Underline for BackSit and Note fields

            // cb.MoveTo((float)((center - 16) / rateX), (float)(820 / rateY));
            //  cb.LineTo((float)((center + 100) / rateX), (float)(820 / rateY));
            /*
            cb.MoveTo((float)(580 / rateX), (float)(522 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(522 / rateY));

            cb.MoveTo((float)(600 / rateX), (float)(476 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(476 / rateY));

            cb.MoveTo((float)(360 / rateX), (float)(445 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(445 / rateY));

            cb.MoveTo((float)(360 / rateX), (float)(420 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(420 / rateY));

            cb.MoveTo((float)(360 / rateX), (float)(400 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(400 / rateY));
            */


            // cb.SetLineWidth(1);
            // cb.SetColorStroke(new BaseColor(255, 0, 0));
            //cb.SetLineDash(0f, 0f);
            // cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  note underline end
            ///
            #endregion UNDERLINE           

            #region SIGNATURE SECTION             

            PdfPTable table_signature_row_2 = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_signature_row_2.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_signature_row_2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            string signature_Date = "  التاريخ" + "08/09/2022" + "    Date";
            string signature_receiver = "توقيع المستلم.................Receiver's Signature";

            font.Size = 10;
            font.SetColor(0, 0, 0);

            PdfPCell signature_date_Cell = new PdfPCell(new Phrase(signature_Date, font));
            signature_date_Cell.FixedHeight = (float)(cellHeight / rateY);
            signature_date_Cell.NoWrap = false;
            signature_date_Cell.PaddingTop = 0;
            signature_date_Cell.BorderColor = new BaseColor(174, 47, 45);
            signature_date_Cell.BorderWidth = 0;
            signature_date_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            signature_date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            signature_date_Cell.Colspan = 1;


            PdfPCell signature_receiver_Cell = new PdfPCell(new Phrase(signature_receiver, font));
            signature_receiver_Cell.FixedHeight = (float)(cellHeight / rateY);
            signature_receiver_Cell.NoWrap = false;
            signature_receiver_Cell.PaddingTop = 0;
            signature_receiver_Cell.BorderColor = new BaseColor(0, 0, 0);
            signature_receiver_Cell.BorderWidth = 0;
            signature_receiver_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            signature_receiver_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            signature_receiver_Cell.Colspan = 1;

            table_signature_row_2.AddCell(signature_receiver_Cell);
            table_signature_row_2.AddCell(signature_date_Cell);

            //Add the table to the document 
            PdfContentByte pcb_signature_row2 = writer.DirectContent;
            table_signature_row_2.TotalWidth = (float)(630 / rateX);
            table_signature_row_2.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(280 / rateY), pcb_signature_row2);

            #endregion SIGNATURE SECTION

            #region Center TOP TITLE

            //////////////////////////////////////////////////////////////////////  png mark center logo

            String imageURLSignature = Path.Combine(webRootPath, "images\\") + "signature.jpg";
            //String imageURLSignature = Path.Combine(webRootPath, "images\\") + "fertilizer_certificate.png";
            iTextSharp.text.Image imageSignature = iTextSharp.text.Image.GetInstance(imageURLSignature);
            imageSignature.ScaleToFit(300f, 150f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            imageSignature.SetAbsolutePosition((float)(docWidth - imageSignature.ScaledWidth) / 2, (float)(100 / rateY));

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageSignature);

            #endregion CENTER TOP TITLE     


            doc.Close();

            string urlPdf = "/pdf/" + directoryName + "_Voucher.pdf";
            return Json(new { url = urlPdf });

        }

        public async Task<ActionResult> CertificateDesign(int application_type, Guid id)
        {
            #region GENERAL

            List<PesticideCertificate> objPesticideCertificate = new List<PesticideCertificate>();
            string webRootPath = Env.WebRootPath;
            string rootPath = "";
            rootPath = Path.Combine(webRootPath, "font\\");

            BaseFont harman = BaseFont.CreateFont(rootPath + "Arial_Italic.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Create a font from the base font 
            iTextSharp.text.Font f_harman = new iTextSharp.text.Font(harman, 12);
            iTextSharp.text.Font f_harman_i = new iTextSharp.text.Font(harman, 12, iTextSharp.text.Font.ITALIC);

            ///////////////////////////////////
            BaseFont bfArialUniCode = BaseFont.CreateFont(rootPath + "Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Create a font from the base font 
            iTextSharp.text.Font font = new iTextSharp.text.Font(bfArialUniCode, 12);
            iTextSharp.text.Font fontB = new iTextSharp.text.Font(bfArialUniCode, 12, BOLD);
            iTextSharp.text.Font fonti = new iTextSharp.text.Font(bfArialUniCode, 12, iTextSharp.text.Font.ITALIC);


            var doc = new iTextSharp.text.Document(PageSize.A4);

            string directoryName = DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss");

            string path = Path.Combine(webRootPath, "pdf\\") + directoryName + "_Certificate.pdf";

            if (System.IO.File.Exists(path + ".pdf"))
            {
                System.IO.File.Copy(path + ".pdf", path + "_temp.pdf", true);
                System.IO.File.Delete(path + ".pdf");
            }

            //path = path + ".pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();


            PdfContentByte cb = writer.DirectContent;

            double docWidth = doc.PageSize.Width;
            double docHeight = doc.PageSize.Height;

            double rateX = 680.0 / docWidth;
            double rateY = 960.0 / docHeight;

            int center = Convert.ToInt32(docWidth / 2);

            //Add the cell to the table 
            int cellHeight = 25;
            int headerHeight = 30;


            //Create a regex expression to detect hebrew or arabic code points 
            const string regex_match_arabic_hebrew = @"[\u0600-\u06FF,\u0590-\u05FF]+";

            #endregion GENERAL

            #region Receipt Details

            try
            {

                using (var objectClient = new ApiClient(AppSettings))
                {
                    objPesticideCertificate = await objectClient.Get<List<PesticideCertificate>>("API/PesticideCertificate/GetCertificateById?id=" + id, "");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            #endregion Receipt details           

            #region BORDERS

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue start

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(5 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(955 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(675 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(5 / rateY));
            cb.SetLineWidth(1);
            cb.SetColorStroke(new BaseColor(Color.Blue));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue end


            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary green start

            // LEFT SIDE VERTICAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(17 / rateX), (float)(943 / rateY));

            //TOP HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(943 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            // RIGHT SIDE VERTICAL LINE
            cb.MoveTo((float)(663 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            //BOTTOM HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(17 / rateY));

            cb.SetLineWidth(3);
            // cb.SetColorStroke(new BaseColor(174, 47, 45));
            cb.SetColorStroke(new BaseColor(Color.ForestGreen));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary gray end
            ///


            #endregion BORDERS          

            #region Center TOP LOGO

            //////////////////////////////////////////////////////////////////////  png mark center logo

            String imageURL = Path.Combine(webRootPath, "images\\") + "logo_white.png";

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            jpg.ScaleToFit(100f, 100f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            jpg.SetAbsolutePosition((float)(docWidth - jpg.ScaledWidth) / 2, (float)(943 / rateY) - 100);

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(jpg);

            #endregion CENTER TOP LOGO

            #region LEFT SIDE HEADER
            ///////////////////////////////////////////////////////   header Text

            String header_text = "Sultanate of Oman";

            cb.SetColorFill(new BaseColor(0, 255, 0));
            PdfPTable tablehr1 = new PdfPTable(1);
            tablehr1.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr1.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 14;
            font.SetColor(0, 0, 0);
            PdfPCell texthr1 = new PdfPCell(new Phrase(header_text, font));
            texthr1.FixedHeight = (float)(60 / rateY);
            texthr1.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            texthr1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr1.PaddingTop = 0;
            texthr1.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr1.SetLeading((float)1.5, (float)1.3);
            texthr1.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr1.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr1.NoWrap = false;

            //Add the cell to the table 
            tablehr1.AddCell(texthr1);

            //Add the table to the document 
            PdfContentByte pcbhr1 = writer.DirectContent;
            tablehr1.TotalWidth = (float)(docWidth / rateX);
            tablehr1.WriteSelectedRows(0, -1, (float)(36 / rateX), (float)(950 / rateY), pcbhr1); // changed from 255 t 263 by harmanjeet on 7/4/2019
                                                                                                  ///////////////////////////////////////////////////////////


            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehr2 = new PdfPTable(1);
            tablehr2.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr2.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 10;
            font.SetColor(0, 0, 0);
            PdfPCell texthr2 = new PdfPCell(new Phrase("Ministry of Agriculture \n Fisheries Wealth & Water Resources", font));
            texthr2.FixedHeight = (float)(60 / rateY);
            texthr2.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            texthr2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr2.PaddingTop = 0;
            texthr2.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr2.SetLeading((float)1.5, (float)1.3);
            texthr2.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr2.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr2.NoWrap = false;

            //Add the cell to the table 
            tablehr2.AddCell(texthr2);

            //Add the table to the document 
            PdfContentByte pcbhr2 = writer.DirectContent;
            tablehr2.TotalWidth = (float)(docWidth / rateX);
            tablehr2.WriteSelectedRows(0, -1, (float)(36 / rateX), (float)(910 / rateY), pcbhr2); // changed from 255 t 263 by harmanjeet on 7/4/2019
                                                                                                  ///////////////////////////////////////////////////////////
            ///


            String header3_text = "Directorate General for Agriculture Development";

            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehr3 = new PdfPTable(1);
            tablehr3.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr3.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 10;
            font.SetColor(0, 0, 0);
            PdfPCell texthr3 = new PdfPCell(new Phrase(header3_text, font));
            texthr3.FixedHeight = (float)(60 / rateY);
            texthr3.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            texthr3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr3.PaddingTop = 0;
            texthr3.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr3.SetLeading((float)1.5, (float)1.3);
            texthr3.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr3.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr3.NoWrap = false;

            //Add the cell to the table 
            tablehr3.AddCell(texthr3);
            //Add the table to the document 
            PdfContentByte pcbhr3 = writer.DirectContent;
            tablehr3.TotalWidth = (float)(docWidth / rateX);
            tablehr3.WriteSelectedRows(0, -1, (float)(36 / rateX), (float)(875 / rateY), pcbhr3); // changed from 255 t 263 by harmanjeet on 7/4/2019

            /////////////////////////////////////////////////////////////////////////////////// Header End

            #endregion LEFT SIDE HEADER

            #region RIGHT SIDE HEADER
            ///////////////////////////////////////////////////////   header Text

            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehtop = new PdfPTable(1);
            tablehtop.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehtop.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehtop.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 14;  // changed font to italic font fonti by harmanjeet 0n 7/4/2019
            font.SetColor(0, 0, 0);
            PdfPCell texttop = new PdfPCell(new Phrase("سلطنة عمان", font));
            texttop.FixedHeight = (float)(60 / rateY);
            texttop.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            texttop.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texttop.PaddingTop = 0;
            texttop.PaddingRight = 0;
            texttop.BorderColor = new BaseColor(174, 47, 45);
            texttop.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texttop.NoWrap = false;

            //Add the cell to the table 
            tablehtop.AddCell(texttop);

            //Add the table to the document 
            PdfContentByte pcbhtop = writer.DirectContent;
            tablehtop.TotalWidth = (float)(docWidth);
            tablehtop.WriteSelectedRows(0, -1, (float)((-36) / rateX), (float)(950 / rateY), pcbhtop);

            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehr2r = new PdfPTable(1);
            tablehr2r.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr2r.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr2r.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 12;
            font.SetColor(0, 0, 0);
            PdfPCell texthr2r = new PdfPCell(new Phrase("وزارة الثروة الزراعية \n والسمكية وموارد المياه", font));
            texthr2r.FixedHeight = (float)(60 / rateY);
            texthr2r.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            texthr2r.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr2r.PaddingTop = 0;
            texthr2r.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr2r.SetLeading((float)1.5, (float)1.3);
            texthr2r.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr2r.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr2r.NoWrap = false;

            //Add the cell to the table 
            tablehr2r.AddCell(texthr2r);

            //Add the table to the document 
            PdfContentByte pcbhr2r = writer.DirectContent;
            tablehr2r.TotalWidth = (float)(docWidth);
            tablehr2r.WriteSelectedRows(0, -1, (float)((-36) / rateX), (float)(910 / rateY), pcbhr2r); // changed from 255 t 263 by harmanjeet on 7/4/2019
                                                                                                       ///////////////////////////////////////////////////////////
            ///


            String header3r_text = "المديرية العامة للأمن الغذائي";


            PdfPTable tablehr3r = new PdfPTable(1);
            tablehr3r.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr3r.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr3r.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 12;
            font.SetColor(0, 0, 0);
            PdfPCell texthr3r = new PdfPCell(new Phrase(header3r_text, font));
            texthr3r.FixedHeight = (float)(60 / rateY);
            texthr3r.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            texthr3r.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr3r.PaddingTop = 0;
            texthr3r.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr3r.SetLeading((float)1.5, (float)1.3);
            texthr3r.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr3r.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr3r.NoWrap = false;

            //Add the cell to the table 
            tablehr3r.AddCell(texthr3r);

            //Add the table to the document 
            PdfContentByte pcbhr3r = writer.DirectContent;
            tablehr3r.TotalWidth = (float)(docWidth);
            tablehr3r.WriteSelectedRows(0, -1, (float)(-36 / rateX), (float)(875 / rateY), pcbhr3r); // changed from 255 t 263 by harmanjeet on 7/4/2019

            /////////////////////////////////////////////////////////////////////////////////// Header End

            #endregion RIGHT SIDE HEADER

            #region Center TOP TITLE

            //////////////////////////////////////////////////////////////////////  png mark center logo

            String imageURLTitle = Path.Combine(webRootPath, "images\\") + "pesticide_certificate.png";

            iTextSharp.text.Image imageTitle = iTextSharp.text.Image.GetInstance(imageURLTitle);
            imageTitle.ScaleToFit(300f, 50f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            imageTitle.SetAbsolutePosition((float)(docWidth - imageTitle.ScaledWidth) / 2, (float)(943 / rateY) - 150);

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageTitle);

            #endregion CENTER TOP TITLE          

            #region CERTIFICATE NUMBER

            PdfPTable table_distibutor = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_distibutor.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_distibutor.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Added by Harmanjeet on sept 12, 2022


            fontB.Size = 12;
            fontB.SetColor(0, 0, 255);

            font.Size = 10;
            font.SetColor(0, 0, 0);


            string created_date = Convert.ToDateTime(objPesticideCertificate[0].Created_date).ToShortDateString();

            Font regular = new Font(FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.DARK_GRAY);
            Font bold = new Font(FontFamily.HELVETICA, 10, Font.BOLD);

            PdfPCell receipt_Date_Cell = new PdfPCell(new Phrase("رقم: Date: " + created_date, font));

            receipt_Date_Cell.FixedHeight = (float)(cellHeight / rateY);
            receipt_Date_Cell.NoWrap = false;
            receipt_Date_Cell.PaddingTop = 0;
            receipt_Date_Cell.BorderColor = new BaseColor(174, 47, 45);
            receipt_Date_Cell.BorderWidth = 0;
            receipt_Date_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            receipt_Date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            receipt_Date_Cell.Colspan = 1;

            string Local_Certificate_Registration_No = "الرقم: Number: " + objPesticideCertificate[0].Local_Registration_No;

            PdfPCell distibutor_NO_Cell = new PdfPCell(new Phrase(Local_Certificate_Registration_No, font));
            distibutor_NO_Cell.FixedHeight = (float)(cellHeight / rateY);
            distibutor_NO_Cell.NoWrap = false;
            distibutor_NO_Cell.PaddingTop = 0;
            distibutor_NO_Cell.BorderColor = new BaseColor(0, 0, 0);
            distibutor_NO_Cell.BorderWidth = 0;
            distibutor_NO_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            distibutor_NO_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            distibutor_NO_Cell.Colspan = 1;

            table_distibutor.AddCell(distibutor_NO_Cell);
            table_distibutor.AddCell(receipt_Date_Cell);


            //Add the table to the document 
            PdfContentByte pcb_distibutor = writer.DirectContent;
            table_distibutor.TotalWidth = (float)(630 / rateX);
            table_distibutor.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(750 / rateY), pcb_distibutor);


            #endregion CERTIFICATE NUMBER

          
            #region BORDERS

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue start

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(5 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(955 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(675 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(5 / rateY));
            cb.SetLineWidth(1);
            cb.SetColorStroke(new BaseColor(Color.Blue));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue end


            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary gray start

            // LEFT SIDE VERTICAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(17 / rateX), (float)(943 / rateY));

            //TOP HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(943 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            // RIGHT SIDE VERTICAL LINE
            cb.MoveTo((float)(663 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            //BOTTOM HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(17 / rateY));

            cb.SetLineWidth(3);
            // cb.SetColorStroke(new BaseColor(174, 47, 45));
            cb.SetColorStroke(new BaseColor(Color.ForestGreen));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary gray end
            ///


            #endregion BORDERS

            #region ITEMS TABLE

            
            PdfPTable tbl_Items = new PdfPTable(3);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tbl_Items.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tbl_Items.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }else
            {
                tbl_Items.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
            }

          

            iTextSharp.text.Font headerFont;

          
                headerFont = new iTextSharp.text.Font(bfArialUniCode, 8);

            iTextSharp.text.Font cellFont;

            cellFont = new iTextSharp.text.Font(bfArialUniCode, 7);



            string Local_Reg_No_Value = objPesticideCertificate[0].Local_Registration_No;
            string Local_Reg_No_En = ":Local Reg. No";
            string Local_Reg_No_Ar = "رقم التسجيل المحلي:";


            PdfPCell Local_Reg_No_En_Cell = new PdfPCell(new Phrase(Local_Reg_No_En, headerFont));
            Local_Reg_No_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Local_Reg_No_En_Cell.NoWrap = false;
            Local_Reg_No_En_Cell.PaddingTop = 0;
            Local_Reg_No_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Local_Reg_No_En_Cell.BorderWidth = 1;
            Local_Reg_No_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Local_Reg_No_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Local_Reg_No_Value_Cell = new PdfPCell(new Phrase(Local_Reg_No_Value, headerFont));
            Local_Reg_No_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Local_Reg_No_Value_Cell.NoWrap = false;
            Local_Reg_No_Value_Cell.PaddingTop = 0;
            Local_Reg_No_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Local_Reg_No_Value_Cell.BorderWidth = 1;
            Local_Reg_No_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Local_Reg_No_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Local_Reg_No_Ar_Cell = new PdfPCell(new Phrase(Local_Reg_No_Ar, headerFont));
            Local_Reg_No_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Local_Reg_No_Ar_Cell.NoWrap = false;
            Local_Reg_No_Ar_Cell.PaddingTop = 0;
            Local_Reg_No_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Local_Reg_No_Ar_Cell.BorderWidth = 1;
            Local_Reg_No_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Local_Reg_No_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Local_Reg_No_Ar_Cell);           
            tbl_Items.AddCell(Local_Reg_No_Value_Cell);
            tbl_Items.AddCell(Local_Reg_No_En_Cell);

            string Trade_Name_Value = objPesticideCertificate[0].Local_Registration_No;
            string Trade_Name_En = ":Trade Name";
            string Trade_Name_Ar = "الاسم التجاري:";


            PdfPCell Trade_Name_En_Cell = new PdfPCell(new Phrase(Trade_Name_En, headerFont));
            Trade_Name_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Trade_Name_En_Cell.NoWrap = false;
            Trade_Name_En_Cell.PaddingTop = 0;
            Trade_Name_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Trade_Name_En_Cell.BorderWidth = 1;
            Trade_Name_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Trade_Name_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Trade_Name_Value_Cell = new PdfPCell(new Phrase(Trade_Name_Value, headerFont));
            Trade_Name_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Trade_Name_Value_Cell.NoWrap = false;
            Trade_Name_Value_Cell.PaddingTop = 0;
            Trade_Name_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Trade_Name_Value_Cell.BorderWidth = 1;
            Trade_Name_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Trade_Name_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Trade_Name_Ar_Cell = new PdfPCell(new Phrase(Trade_Name_Ar, headerFont));
            Trade_Name_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Trade_Name_Ar_Cell.NoWrap = false;
            Trade_Name_Ar_Cell.PaddingTop = 0;
            Trade_Name_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Trade_Name_Ar_Cell.BorderWidth = 1;
            Trade_Name_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Trade_Name_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Trade_Name_Ar_Cell);
            tbl_Items.AddCell(Trade_Name_Value_Cell);
            tbl_Items.AddCell(Trade_Name_En_Cell);

            string Common_Name_Value = objPesticideCertificate[0].Local_Registration_No;
            string Common_Name_En = ":Common Name";
            string Common_Name_Ar = "الاسم الشائع:";


            PdfPCell Common_Name_En_Cell = new PdfPCell(new Phrase(Common_Name_En, headerFont));
            Common_Name_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Common_Name_En_Cell.NoWrap = false;
            Common_Name_En_Cell.PaddingTop = 0;
            Common_Name_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Common_Name_En_Cell.BorderWidth = 1;
            Common_Name_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Common_Name_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Common_Name_Value_Cell = new PdfPCell(new Phrase(Common_Name_Value, headerFont));
            Common_Name_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Common_Name_Value_Cell.NoWrap = false;
            Common_Name_Value_Cell.PaddingTop = 0;
            Common_Name_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Common_Name_Value_Cell.BorderWidth = 1;
            Common_Name_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Common_Name_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Common_Name_Ar_Cell = new PdfPCell(new Phrase(Common_Name_Ar, headerFont));
            Common_Name_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Common_Name_Ar_Cell.NoWrap = false;
            Common_Name_Ar_Cell.PaddingTop = 0;
            Common_Name_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Common_Name_Ar_Cell.BorderWidth = 1;
            Common_Name_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Common_Name_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Common_Name_Ar_Cell);
            tbl_Items.AddCell(Common_Name_Value_Cell);
            tbl_Items.AddCell(Common_Name_En_Cell);

            string CAS_RN_Value = objPesticideCertificate[0].Local_Registration_No;
            string CAS_RN_En = ":CAS RN";
            string CAS_RN_Ar = "رقم التعريف  الكيميائي:";


            PdfPCell CAS_RN_En_Cell = new PdfPCell(new Phrase(CAS_RN_En, headerFont));
            CAS_RN_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            CAS_RN_En_Cell.NoWrap = false;
            CAS_RN_En_Cell.PaddingTop = 0;
            CAS_RN_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            CAS_RN_En_Cell.BorderWidth = 1;
            CAS_RN_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            CAS_RN_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell CAS_RN_Value_Cell = new PdfPCell(new Phrase(CAS_RN_Value, headerFont));
            CAS_RN_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            CAS_RN_Value_Cell.NoWrap = false;
            CAS_RN_Value_Cell.PaddingTop = 0;
            CAS_RN_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            CAS_RN_Value_Cell.BorderWidth = 1;
            CAS_RN_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            CAS_RN_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell CAS_RN_Ar_Cell = new PdfPCell(new Phrase(CAS_RN_Ar, headerFont));
            CAS_RN_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            CAS_RN_Ar_Cell.NoWrap = false;
            CAS_RN_Ar_Cell.PaddingTop = 0;
            CAS_RN_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            CAS_RN_Ar_Cell.BorderWidth = 1;
            CAS_RN_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            CAS_RN_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(CAS_RN_Ar_Cell);
            tbl_Items.AddCell(CAS_RN_Value_Cell);
            tbl_Items.AddCell(CAS_RN_En_Cell);

            string Chemical_Class_Value = objPesticideCertificate[0].Chemical_Class;
            string Chemical_Class_En = ":Chemical Class";
            string Chemical_Class_Ar = "المجموعة الكيميائية:";


            PdfPCell Chemical_Class_En_Cell = new PdfPCell(new Phrase(Chemical_Class_En, headerFont));
            Chemical_Class_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Chemical_Class_En_Cell.NoWrap = false;
            Chemical_Class_En_Cell.PaddingTop = 0;
            Chemical_Class_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Chemical_Class_En_Cell.BorderWidth = 1;
            Chemical_Class_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Chemical_Class_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Chemical_Class_Value_Cell = new PdfPCell(new Phrase(Chemical_Class_Value, headerFont));
            Chemical_Class_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Chemical_Class_Value_Cell.NoWrap = false;
            Chemical_Class_Value_Cell.PaddingTop = 0;
            Chemical_Class_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Chemical_Class_Value_Cell.BorderWidth = 1;
            Chemical_Class_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Chemical_Class_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Chemical_Class_Ar_Cell = new PdfPCell(new Phrase(Chemical_Class_Ar, headerFont));
            Chemical_Class_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Chemical_Class_Ar_Cell.NoWrap = false;
            Chemical_Class_Ar_Cell.PaddingTop = 0;
            Chemical_Class_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Chemical_Class_Ar_Cell.BorderWidth = 1;
            Chemical_Class_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Chemical_Class_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Chemical_Class_Ar_Cell);
            tbl_Items.AddCell(Chemical_Class_Value_Cell);
            tbl_Items.AddCell(Chemical_Class_En_Cell);

            string Concentration_Ingredients_Value = objPesticideCertificate[0].Local_Registration_No;
            string Concentration_Ingredients_En = ":Conc. Of Active Ingredients";
            string Concentration_Ingredients_Ar = "تركيز المادة الفعالة:";


            PdfPCell Concentration_Ingredients_En_Cell = new PdfPCell(new Phrase(Concentration_Ingredients_En, headerFont));
            Concentration_Ingredients_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Concentration_Ingredients_En_Cell.NoWrap = false;
            Concentration_Ingredients_En_Cell.PaddingTop = 0;
            Concentration_Ingredients_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Concentration_Ingredients_En_Cell.BorderWidth = 1;
            Concentration_Ingredients_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Concentration_Ingredients_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Concentration_Ingredients_Value_Cell = new PdfPCell(new Phrase(Concentration_Ingredients_Value, headerFont));
            Concentration_Ingredients_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Concentration_Ingredients_Value_Cell.NoWrap = false;
            Concentration_Ingredients_Value_Cell.PaddingTop = 0;
            Concentration_Ingredients_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Concentration_Ingredients_Value_Cell.BorderWidth = 1;
            Concentration_Ingredients_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Concentration_Ingredients_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Concentration_Ingredients_Ar_Cell = new PdfPCell(new Phrase(Concentration_Ingredients_Ar, headerFont));
            Concentration_Ingredients_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Concentration_Ingredients_Ar_Cell.NoWrap = false;
            Concentration_Ingredients_Ar_Cell.PaddingTop = 0;
            Concentration_Ingredients_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Concentration_Ingredients_Ar_Cell.BorderWidth = 1;
            Concentration_Ingredients_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Concentration_Ingredients_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Concentration_Ingredients_Ar_Cell);
            tbl_Items.AddCell(Concentration_Ingredients_Value_Cell);
            tbl_Items.AddCell(Concentration_Ingredients_En_Cell);

            string Pesticide_use_Value = objPesticideCertificate[0].Pesticide_Use;
            string Pesticide_use_En = ":Pesticide use";
            string Pesticide_use_Ar = "نوع الاستخدام:";


            PdfPCell Pesticide_use_En_Cell = new PdfPCell(new Phrase(Pesticide_use_En, headerFont));
            Pesticide_use_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Pesticide_use_En_Cell.NoWrap = false;
            Pesticide_use_En_Cell.PaddingTop = 0;
            Pesticide_use_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Pesticide_use_En_Cell.BorderWidth = 1;
            Pesticide_use_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Pesticide_use_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Pesticide_use_Value_Cell = new PdfPCell(new Phrase(Pesticide_use_Value, headerFont));
            Pesticide_use_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Pesticide_use_Value_Cell.NoWrap = false;
            Pesticide_use_Value_Cell.PaddingTop = 0;
            Pesticide_use_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Pesticide_use_Value_Cell.BorderWidth = 1;
            Pesticide_use_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Pesticide_use_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Pesticide_use_Ar_Cell = new PdfPCell(new Phrase(Pesticide_use_Ar, headerFont));
            Pesticide_use_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Pesticide_use_Ar_Cell.NoWrap = false;
            Pesticide_use_Ar_Cell.PaddingTop = 0;
            Pesticide_use_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Pesticide_use_Ar_Cell.BorderWidth = 1;
            Pesticide_use_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Pesticide_use_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Pesticide_use_Ar_Cell);
            tbl_Items.AddCell(Pesticide_use_Value_Cell);
            tbl_Items.AddCell(Pesticide_use_En_Cell);

            string Type_of_Formulation_Value = objPesticideCertificate[0].Type_Formulation;
            string Type_of_Formulation_En = ":Type of Formulation";
            string Type_of_Formulation_Ar = "نوع المستحضر:";


            PdfPCell Type_of_Formulation_En_Cell = new PdfPCell(new Phrase(Type_of_Formulation_En, headerFont));
            Type_of_Formulation_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Type_of_Formulation_En_Cell.NoWrap = false;
            Type_of_Formulation_En_Cell.PaddingTop = 0;
            Type_of_Formulation_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Type_of_Formulation_En_Cell.BorderWidth = 1;
            Type_of_Formulation_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Type_of_Formulation_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Type_of_Formulation_Value_Cell = new PdfPCell(new Phrase(Type_of_Formulation_Value, headerFont));
            Type_of_Formulation_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Type_of_Formulation_Value_Cell.NoWrap = false;
            Type_of_Formulation_Value_Cell.PaddingTop = 0;
            Type_of_Formulation_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Type_of_Formulation_Value_Cell.BorderWidth = 1;
            Type_of_Formulation_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Type_of_Formulation_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Type_of_Formulation_Ar_Cell = new PdfPCell(new Phrase(Type_of_Formulation_Ar, headerFont));
            Type_of_Formulation_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Type_of_Formulation_Ar_Cell.NoWrap = false;
            Type_of_Formulation_Ar_Cell.PaddingTop = 0;
            Type_of_Formulation_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Type_of_Formulation_Ar_Cell.BorderWidth = 1;
            Type_of_Formulation_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Type_of_Formulation_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Type_of_Formulation_Ar_Cell);
            tbl_Items.AddCell(Type_of_Formulation_Value_Cell);
            tbl_Items.AddCell(Type_of_Formulation_En_Cell);

            string Target_Pest_Value = objPesticideCertificate[0].Target_Pest;
            string Target_Pest_En = ":Target Pest";
            string Target_Pest_Ar = "الآفة المستهدفة:";


            PdfPCell Target_Pest_En_Cell = new PdfPCell(new Phrase(Target_Pest_En, headerFont));
            Target_Pest_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Target_Pest_En_Cell.NoWrap = false;
            Target_Pest_En_Cell.PaddingTop = 0;
            Target_Pest_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Target_Pest_En_Cell.BorderWidth = 1;
            Target_Pest_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Target_Pest_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Target_Pest_Value_Cell = new PdfPCell(new Phrase(Target_Pest_Value, headerFont));
            Target_Pest_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Target_Pest_Value_Cell.NoWrap = false;
            Target_Pest_Value_Cell.PaddingTop = 0;
            Target_Pest_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Target_Pest_Value_Cell.BorderWidth = 1;
            Target_Pest_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Target_Pest_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Target_Pest_Ar_Cell = new PdfPCell(new Phrase(Target_Pest_Ar, headerFont));
            Target_Pest_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Target_Pest_Ar_Cell.NoWrap = false;
            Target_Pest_Ar_Cell.PaddingTop = 0;
            Target_Pest_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Target_Pest_Ar_Cell.BorderWidth = 1;
            Target_Pest_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Target_Pest_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Target_Pest_Ar_Cell);
            tbl_Items.AddCell(Target_Pest_Value_Cell);
            tbl_Items.AddCell(Target_Pest_En_Cell);

            string WHO_Toxicity_Classification_Value = objPesticideCertificate[0].WHO_Toxicity_Classification;
            string WHO_Toxicity_Classification_En = ":WHO Toxicity Classification";
            string WHO_Toxicity_Classification_Ar = "تصنيف السمية طبقا لمنظمة الصحة العالمية:";


            PdfPCell WHO_Toxicity_Classification_En_Cell = new PdfPCell(new Phrase(WHO_Toxicity_Classification_En, headerFont));
            WHO_Toxicity_Classification_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            WHO_Toxicity_Classification_En_Cell.NoWrap = false;
            WHO_Toxicity_Classification_En_Cell.PaddingTop = 0;
            WHO_Toxicity_Classification_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            WHO_Toxicity_Classification_En_Cell.BorderWidth = 1;
            WHO_Toxicity_Classification_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            WHO_Toxicity_Classification_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell WHO_Toxicity_Classification_Value_Cell = new PdfPCell(new Phrase(WHO_Toxicity_Classification_Value, headerFont));
            WHO_Toxicity_Classification_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            WHO_Toxicity_Classification_Value_Cell.NoWrap = false;
            WHO_Toxicity_Classification_Value_Cell.PaddingTop = 0;
            WHO_Toxicity_Classification_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            WHO_Toxicity_Classification_Value_Cell.BorderWidth = 1;
            WHO_Toxicity_Classification_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            WHO_Toxicity_Classification_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell WHO_Toxicity_Classification_Ar_Cell = new PdfPCell(new Phrase(WHO_Toxicity_Classification_Ar, headerFont));
            WHO_Toxicity_Classification_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            WHO_Toxicity_Classification_Ar_Cell.NoWrap = false;
            WHO_Toxicity_Classification_Ar_Cell.PaddingTop = 0;
            WHO_Toxicity_Classification_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            WHO_Toxicity_Classification_Ar_Cell.BorderWidth = 1;
            WHO_Toxicity_Classification_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            WHO_Toxicity_Classification_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(WHO_Toxicity_Classification_Ar_Cell);
            tbl_Items.AddCell(WHO_Toxicity_Classification_Value_Cell);
            tbl_Items.AddCell(WHO_Toxicity_Classification_En_Cell);

            string Manufacturer_of_Technicals_Value = objPesticideCertificate[0].Manufacturer_Company;
            string Manufacturer_of_Technicals_En = ":Manufacturer of Technicals";
            string Manufacturer_of_Technicals_Ar = "الشركة المنتجة للمادة الخام:";


            PdfPCell Manufacturer_of_Technicals_En_Cell = new PdfPCell(new Phrase(Manufacturer_of_Technicals_En, headerFont));
            Manufacturer_of_Technicals_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Manufacturer_of_Technicals_En_Cell.NoWrap = false;
            Manufacturer_of_Technicals_En_Cell.PaddingTop = 0;
            Manufacturer_of_Technicals_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Manufacturer_of_Technicals_En_Cell.BorderWidth = 1;
            Manufacturer_of_Technicals_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Manufacturer_of_Technicals_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Manufacturer_of_Technicals_Value_Cell = new PdfPCell(new Phrase(Manufacturer_of_Technicals_Value, headerFont));
            Manufacturer_of_Technicals_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Manufacturer_of_Technicals_Value_Cell.NoWrap = false;
            Manufacturer_of_Technicals_Value_Cell.PaddingTop = 0;
            Manufacturer_of_Technicals_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Manufacturer_of_Technicals_Value_Cell.BorderWidth = 1;
            Manufacturer_of_Technicals_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Manufacturer_of_Technicals_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Manufacturer_of_Technicals_Ar_Cell = new PdfPCell(new Phrase(Manufacturer_of_Technicals_Ar, headerFont));
            Manufacturer_of_Technicals_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Manufacturer_of_Technicals_Ar_Cell.NoWrap = false;
            Manufacturer_of_Technicals_Ar_Cell.PaddingTop = 0;
            Manufacturer_of_Technicals_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Manufacturer_of_Technicals_Ar_Cell.BorderWidth = 1;
            Manufacturer_of_Technicals_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Manufacturer_of_Technicals_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Manufacturer_of_Technicals_Ar_Cell);
            tbl_Items.AddCell(Manufacturer_of_Technicals_Value_Cell);
            tbl_Items.AddCell(Manufacturer_of_Technicals_En_Cell);

            string Manufacturer_Company_Value = objPesticideCertificate[0].Manufacturer_Company;
            string Manufacturer_Company_En = ":Manufacturer Company";
            string Manufacturer_Company_Ar = "الشركة المنتجة للمادة الخام:";


            PdfPCell Manufacturer_Company_En_Cell = new PdfPCell(new Phrase(Manufacturer_Company_En, headerFont));
            Manufacturer_Company_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Manufacturer_Company_En_Cell.NoWrap = false;
            Manufacturer_Company_En_Cell.PaddingTop = 0;
            Manufacturer_Company_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Manufacturer_Company_En_Cell.BorderWidth = 1;
            Manufacturer_Company_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Manufacturer_Company_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Manufacturer_Company_Value_Cell = new PdfPCell(new Phrase(Manufacturer_Company_Value, headerFont));
            Manufacturer_Company_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Manufacturer_Company_Value_Cell.NoWrap = false;
            Manufacturer_Company_Value_Cell.PaddingTop = 0;
            Manufacturer_Company_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Manufacturer_Company_Value_Cell.BorderWidth = 1;
            Manufacturer_Company_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Manufacturer_Company_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Manufacturer_Company_Ar_Cell = new PdfPCell(new Phrase(Manufacturer_Company_Ar, headerFont));
            Manufacturer_Company_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Manufacturer_Company_Ar_Cell.NoWrap = false;
            Manufacturer_Company_Ar_Cell.PaddingTop = 0;
            Manufacturer_Company_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Manufacturer_Company_Ar_Cell.BorderWidth = 1;
            Manufacturer_Company_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Manufacturer_Company_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Manufacturer_Company_Ar_Cell);
            tbl_Items.AddCell(Manufacturer_Company_Value_Cell);
            tbl_Items.AddCell(Manufacturer_Company_En_Cell);

            string Exporter_Company_Value = objPesticideCertificate[0].Local_Company;
            string Exporter_Company_En = ":Exporter Company";
            string Exporter_Company_Ar = "الشركة المصدرة:";


            PdfPCell Exporter_Company_En_Cell = new PdfPCell(new Phrase(Exporter_Company_En, headerFont));
            Exporter_Company_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Exporter_Company_En_Cell.NoWrap = false;
            Exporter_Company_En_Cell.PaddingTop = 0;
            Exporter_Company_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Exporter_Company_En_Cell.BorderWidth = 1;
            Exporter_Company_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Exporter_Company_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Exporter_Company_Value_Cell = new PdfPCell(new Phrase(Exporter_Company_Value, headerFont));
            Exporter_Company_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Exporter_Company_Value_Cell.NoWrap = false;
            Exporter_Company_Value_Cell.PaddingTop = 0;
            Exporter_Company_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Exporter_Company_Value_Cell.BorderWidth = 1;
            Exporter_Company_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Exporter_Company_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Exporter_Company_Ar_Cell = new PdfPCell(new Phrase(Exporter_Company_Ar, headerFont));
            Exporter_Company_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Exporter_Company_Ar_Cell.NoWrap = false;
            Exporter_Company_Ar_Cell.PaddingTop = 0;
            Exporter_Company_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Exporter_Company_Ar_Cell.BorderWidth = 1;
            Exporter_Company_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Exporter_Company_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Exporter_Company_Ar_Cell);
            tbl_Items.AddCell(Exporter_Company_Value_Cell);
            tbl_Items.AddCell(Exporter_Company_En_Cell);

            string Importer_Company_Value = objPesticideCertificate[0].Local_Company;
            string Importer_Company_En = ":Importer Company";
            string Importer_Company_Ar = "الشركة المستوردة:";


            PdfPCell Importer_Company_En_Cell = new PdfPCell(new Phrase(Importer_Company_En, headerFont));
            Importer_Company_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Importer_Company_En_Cell.NoWrap = false;
            Importer_Company_En_Cell.PaddingTop = 0;
            Importer_Company_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Importer_Company_En_Cell.BorderWidth = 1;
            Importer_Company_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Importer_Company_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Importer_Company_Value_Cell = new PdfPCell(new Phrase(Importer_Company_Value, headerFont));
            Importer_Company_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Importer_Company_Value_Cell.NoWrap = false;
            Importer_Company_Value_Cell.PaddingTop = 0;
            Importer_Company_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Importer_Company_Value_Cell.BorderWidth = 1;
            Importer_Company_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Importer_Company_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Importer_Company_Ar_Cell = new PdfPCell(new Phrase(Importer_Company_Ar, headerFont));
            Importer_Company_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Importer_Company_Ar_Cell.NoWrap = false;
            Importer_Company_Ar_Cell.PaddingTop = 0;
            Importer_Company_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Importer_Company_Ar_Cell.BorderWidth = 1;
            Importer_Company_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Importer_Company_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Importer_Company_Ar_Cell);
            tbl_Items.AddCell(Importer_Company_Value_Cell);
            tbl_Items.AddCell(Importer_Company_En_Cell);

            string Address_of_Importer_Company_Value = objPesticideCertificate[0].Address;
            string Address_of_Importer_Company_En = ":Address of Importer Company";
            string Address_of_Importer_Company_Ar = "عنوان الشركة المستوردة:";


            PdfPCell Address_of_Importer_Company_En_Cell = new PdfPCell(new Phrase(Address_of_Importer_Company_En, headerFont));
            Address_of_Importer_Company_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Address_of_Importer_Company_En_Cell.NoWrap = false;
            Address_of_Importer_Company_En_Cell.PaddingTop = 0;
            Address_of_Importer_Company_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Address_of_Importer_Company_En_Cell.BorderWidth = 1;
            Address_of_Importer_Company_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Address_of_Importer_Company_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Address_of_Importer_Company_Value_Cell = new PdfPCell(new Phrase(Address_of_Importer_Company_Value, headerFont));
            Address_of_Importer_Company_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Address_of_Importer_Company_Value_Cell.NoWrap = false;
            Address_of_Importer_Company_Value_Cell.PaddingTop = 0;
            Address_of_Importer_Company_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Address_of_Importer_Company_Value_Cell.BorderWidth = 1;
            Address_of_Importer_Company_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Address_of_Importer_Company_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Address_of_Importer_Company_Ar_Cell = new PdfPCell(new Phrase(Address_of_Importer_Company_Ar, headerFont));
            Address_of_Importer_Company_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Address_of_Importer_Company_Ar_Cell.NoWrap = false;
            Address_of_Importer_Company_Ar_Cell.PaddingTop = 0;
            Address_of_Importer_Company_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Address_of_Importer_Company_Ar_Cell.BorderWidth = 1;
            Address_of_Importer_Company_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Address_of_Importer_Company_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Address_of_Importer_Company_Ar_Cell);
            tbl_Items.AddCell(Address_of_Importer_Company_Value_Cell);
            tbl_Items.AddCell(Address_of_Importer_Company_En_Cell);

            string Validation_Value = objPesticideCertificate[0].Local_Registration_No;
            string Validation_En = ":Validation";
            string Validation_Ar = "صلاحية الشهادة:";


            PdfPCell Validation_En_Cell = new PdfPCell(new Phrase(Validation_En, headerFont));
            Validation_En_Cell.FixedHeight = (float)(headerHeight / rateY);
            Validation_En_Cell.NoWrap = false;
            Validation_En_Cell.PaddingTop = 0;
            Validation_En_Cell.BorderColor = new BaseColor(0, 0, 0);
            Validation_En_Cell.BorderWidth = 1;
            Validation_En_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            Validation_En_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Validation_Value_Cell = new PdfPCell(new Phrase(Validation_Value, headerFont));
            Validation_Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Validation_Value_Cell.NoWrap = false;
            Validation_Value_Cell.PaddingTop = 0;
            Validation_Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Validation_Value_Cell.BorderWidth = 1;
            Validation_Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Validation_Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Validation_Ar_Cell = new PdfPCell(new Phrase(Validation_Ar, headerFont));
            Validation_Ar_Cell.FixedHeight = (float)(headerHeight / rateY);
            Validation_Ar_Cell.NoWrap = false;
            Validation_Ar_Cell.PaddingTop = 0;
            Validation_Ar_Cell.BorderColor = new BaseColor(0, 0, 0);
            Validation_Ar_Cell.BorderWidth = 1;
            Validation_Ar_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Validation_Ar_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            tbl_Items.AddCell(Validation_Ar_Cell);
            tbl_Items.AddCell(Validation_Value_Cell);
            tbl_Items.AddCell(Validation_En_Cell);

            //Add the table to the document 
            PdfContentByte pcb8 = writer.DirectContent;
            tbl_Items.TotalWidth = (float)(docWidth - 50);

             tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(700 / rateY), pcb8);

            ////////////////////////////////////////////////////////////////////////////////////////////
            #endregion ITEMS TABLE

            #region Middle Line Divider
            /*
            String imageURL1 = Server.MapPath(".") + "/images/save.png";

            iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(imageURL1);
            jpg1.ScaleToFit(30f, 260f);

            jpg1.Alignment = Element.ALIGN_CENTER;

            jpg1.SetAbsolutePosition((float)(283.0), (float)350.0);
            doc.Add(jpg1);
            */
            ///////////////////////////////////   center logo end
            ///
            #endregion MIddle Line Divider

            #region UNDERLINE


            /////////////////////////////////////////////////////////////////////////////////////////////////////  note underline start

            // Underline for BackSit and Note fields

            // cb.MoveTo((float)((center - 16) / rateX), (float)(820 / rateY));
            //  cb.LineTo((float)((center + 100) / rateX), (float)(820 / rateY));
            /*
            cb.MoveTo((float)(580 / rateX), (float)(522 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(522 / rateY));

            cb.MoveTo((float)(600 / rateX), (float)(476 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(476 / rateY));

            cb.MoveTo((float)(360 / rateX), (float)(445 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(445 / rateY));

            cb.MoveTo((float)(360 / rateX), (float)(420 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(420 / rateY));

            cb.MoveTo((float)(360 / rateX), (float)(400 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(400 / rateY));
            */


            // cb.SetLineWidth(1);
            // cb.SetColorStroke(new BaseColor(255, 0, 0));
            //cb.SetLineDash(0f, 0f);
            // cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  note underline end
            ///
            #endregion UNDERLINE           

            #region SIGNATURE SECTION             

            PdfPTable table_signature_row_2 = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_signature_row_2.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_signature_row_2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            string signature_Date = "  التاريخ" + DateTime.Now.ToShortDateString() + "    Date";
            string signature_receiver = "توقيع المستلم.................Receiver's Signature";

            font.Size = 10;
            font.SetColor(0, 0, 0);

            PdfPCell signature_date_Cell = new PdfPCell(new Phrase(signature_Date, font));
            signature_date_Cell.FixedHeight = (float)(cellHeight / rateY);
            signature_date_Cell.NoWrap = false;
            signature_date_Cell.PaddingTop = 0;
            signature_date_Cell.BorderColor = new BaseColor(174, 47, 45);
            signature_date_Cell.BorderWidth = 0;
            signature_date_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            signature_date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            signature_date_Cell.Colspan = 1;


            PdfPCell signature_receiver_Cell = new PdfPCell(new Phrase(signature_receiver, font));
            signature_receiver_Cell.FixedHeight = (float)(cellHeight / rateY);
            signature_receiver_Cell.NoWrap = false;
            signature_receiver_Cell.PaddingTop = 0;
            signature_receiver_Cell.BorderColor = new BaseColor(0, 0, 0);
            signature_receiver_Cell.BorderWidth = 0;
            signature_receiver_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            signature_receiver_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            signature_receiver_Cell.Colspan = 1;

            table_signature_row_2.AddCell(signature_receiver_Cell);
            table_signature_row_2.AddCell(signature_date_Cell);

            //Add the table to the document 
            PdfContentByte pcb_signature_row2 = writer.DirectContent;
            table_signature_row_2.TotalWidth = (float)(630 / rateX);
            table_signature_row_2.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(200 / rateY), pcb_signature_row2);

            #endregion SIGNATURE SECTION

            #region Center TOP TITLE

            //////////////////////////////////////////////////////////////////////  png mark center logo

            String imageURLSignature = Path.Combine(webRootPath, "images\\") + "signature.jpg";
            //String imageURLSignature = Path.Combine(webRootPath, "images\\") + "fertilizer_certificate.png";
            iTextSharp.text.Image imageSignature = iTextSharp.text.Image.GetInstance(imageURLSignature);
            imageSignature.ScaleToFit(125f, 90f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            imageSignature.SetAbsolutePosition((float)(docWidth - imageSignature.ScaledWidth) / 2, (float)(50 / rateY));

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageSignature);

            #endregion CENTER TOP TITLE     


            doc.Close();

            string urlPdf = "/pdf/" + directoryName + "_Certificate.pdf";
            return Json(new { url = urlPdf });

        }

        #endregion Certification Generation

        public async Task<Fertilizer_Model> GetMociCompany(string CRNumber)
        {
            //string email = Convert.ToString(@TempData.Peek("LoggedInEmail"));

            //try
            //{ 

            //    if (!email.Equals(CRNumber))
            //    {
            //        MOCICompany.State mociState = new MOCICompany.State();

            //        MOCICompany.Address mociAddress = new MOCICompany.Address();
            //        mociAddress.state = mociState;

            //        MOCICompany.CompanyOverview mociOview = new MOCICompany.CompanyOverview();

            //        mociOview.address = mociAddress;

            //        MOCICompany.WsResponseBody mociBody = new MOCICompany.WsResponseBody();
            //        mociBody.companyOverview = mociOview;

            //        MOCICompany.Root mociRoot = new MOCICompany.Root();
            //        mociRoot.wsResponseBody = mociBody;

            //        Fertilizer_Model objError = new Fertilizer_Model();

            //        objError.MOCICompanyRoot = mociRoot;

            //        string error = "Error - Not a valid CR Number. enter valid CR.";
            //        objError.MOCICompanyRoot.wsResponseBody.companyOverview.address.state.nameEn = error;
            //        return objError;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<Fertilizer_Model>("API/User/GetMociCompany?CRNo=" + CRNumber, "");

                return result;
            }

        }


        public async Task<string> SavePaymentPesticide(PaymentPesticide obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<string>("API/FertilizerCertificate/SavePaymentPesticide", stringContent, "");
                return result;

            }
        }

        public async Task<List<PaymentPesticide>> GetPaymentPesticideByCertificateID(Guid id)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<PaymentPesticide>>("API/FertilizerCertificate/GetPaymentPesticideByCertificateID/?id=" + id, "");
                return result;
            }
        }

    }
}

