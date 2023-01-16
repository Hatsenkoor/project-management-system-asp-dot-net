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

using iTextSharp.text;
using iTextSharp.text.pdf;
using static iTextSharp.text.Font;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace PCVM.Web.Controllers
{
    public class FertilizerCertificateController : Controller
    {
        public Fertilizer_Model model { get; set; }
        IConfiguration configuration;
        string url;

        public Receipt receiptObj = new Receipt();

        public List<FertilizerCertificate> lstFertilizerCertificate = new List<FertilizerCertificate>();

        public IWebHostEnvironment Env { get; }
        public IOptions<Helpers.AppSettings> AppSettings { get; }
     
        public FertilizerCertificateController(IConfiguration configuration, IOptions<Helpers.AppSettings> appSettings, IWebHostEnvironment web)
        {
            AppSettings = appSettings;
            Env = web;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            this.configuration = configuration;
            url = this.configuration.GetSection("AppSettings:ApiUrl.Finance").Value;
        }

        #region SAVE UPDATE CANCEL METHOD
        public async Task<string> SaveCertificate(FertilizerCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);            
           
            obj.Created_by = UserId.ToString();
            obj.Updated_by = UserId.ToString();
            obj.Created_date = DateTime.Now;
            obj.Updated_date = DateTime.Now;
            obj.expiry_date = DateTime.Now;

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<string>("API/FertilizerCertificate/SaveCertificate", stringContent, "");
                return result;

            }
        }

        public async Task<List<FertilizerCertificate>> SubmitCertificate(FertilizerCertificate obj)
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
                var result = await objectClient.Post<List<FertilizerCertificate>>("API/FertilizerCertificate/SubmitCertificate", stringContent, "");
                return result;

            }
        }

        public async Task<List<Organic_Analysis>> SaveOrganicAnalysis(Organic_Analysis obj)
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
                var result = await objectClient.Post<string>("API/FertilizerCertificate/SaveOrganicAnalysis", stringContent, "");

            }

            return await GetOrganicAnalysisByCertificateID(obj.CertificateID);
        }
        public async Task<List<Chemical_Analysis>> SaveChemicalAnalysis(Chemical_Analysis obj)
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
                var result = await objectClient.Post<string>("API/FertilizerCertificate/SaveChemicalAnalysis", stringContent, "");

            }

            return await GetChemicalAnalysisByCertificateID(obj.CertificateID);
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
       
     
        public async Task<List<FertilizerCertificate>> RequestCertificateCancel(FertilizerCertificate obj)
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
                var result = await objectClient.Post<List<FertilizerCertificate>>("API/FertilizerCertificate/RequestCertificateCancel", stringContent, "");
                return result;

            }
        }

        public async Task<List<FertilizerCertificate>> CancelCertificate(FertilizerCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // To Add Remark in case Approver want to approve with remark

            if (obj.Remark != null && obj.Remark.Length > 0)
            {
                Review_History review_History = new Review_History();
                review_History.CertificateID = obj.ID;
                review_History.Remark = obj.Remark;
                // we are using Application_Type for Remark_Type
                review_History.Remark_Type = obj.Application_Type;
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
                var result = await objectClient.Post<List<FertilizerCertificate>>("API/FertilizerCertificate/CancelCertificate", stringContent, "");
                return result;

            }
        }

        #endregion

        #region Approval Method

        public async Task<List<FertilizerCertificate>> SectionHeadApproval(FertilizerCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // To Add Remark in case Approver want to approve with remark

            if (obj.Remark != null && obj.Remark.Length > 0)
            {
                Review_History review_History = new Review_History();
                review_History.CertificateID = obj.ID;
                review_History.Remark = obj.Remark;
                // we are using Application_Type for Remark_Type
                review_History.Remark_Type = obj.Application_Type;
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
                var result = await objectClient.Post<List<FertilizerCertificate>>("API/FertilizerCertificate/SectionHeadApproval", stringContent, "");
                return result;

            }
        }
        public async Task<List<FertilizerCertificate>> DirectorApproval(FertilizerCertificate obj)
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            // To Add Remark in case Approver want to approve with remark

            if (obj.Remark != null && obj.Remark.Length > 0)
            {
                Review_History review_History = new Review_History();
                review_History.CertificateID = obj.ID;
                review_History.Remark = obj.Remark;
                // we are using Application_Type for Remark_Type
                review_History.Remark_Type = obj.Application_Type;
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
                var result = await objectClient.Post<List<FertilizerCertificate>>("API/FertilizerCertificate/DirectorApproval", stringContent, "");
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

      
        public async Task<List<FertilizerCertificate>> RegistrationFee(FertilizerCertificate obj)
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
                var result = await objectClient.Post<List<FertilizerCertificate>>("API/FertilizerCertificate/RegistrationFee", stringContent, "");
                return result;

            }

        }
       
        public async Task<List<FertilizerCertificate>> CertificateFee(FertilizerCertificate obj)
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
                var result = await objectClient.Post<List<FertilizerCertificate>>("API/FertilizerCertificate/CertificateFee", stringContent, "");
                return result;

            }
        }

        #endregion

        #region GET LIST

        

        public async Task<List<FertilizerCertificate>> GetAllCertificateDefault()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/GetAllCertificateDefault", "");
            }
        }

        public async Task<List<FertilizerCertificate>> GetAllCertificate(string application_type)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/GetAllCertificate?application_type=" + application_type, "");
            }
        }
        public async Task<List<FertilizerCertificate>> getAllSectionHeadCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/getAllSectionHeadCertificate", "");
            }
        }
        public async Task<List<FertilizerCertificate>> getAllApprovedCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/getAllApprovedCertificate", "");
            }
        }
        public async Task<List<FertilizerCertificate>> getAllPaymentCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/getAllPaymentCertificate", "");
            }
        }
        public async Task<List<FertilizerCertificate>> getAllIssuedCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/getAllIssuedCertificate", "");
            }
        }
        public async Task<List<FertilizerCertificate>> getAllCancelCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/getAllCancelCertificate", "");
            }
        }

        public async Task<List<FertilizerCertificate>> getAllCancelledCertificate()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/getAllCancelledCertificate", "");
            }
        }
        
        public async Task<List<Review_History>> GetAllRemark(Guid CertificateID, string Remark_Type)
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<Review_History>>("API/FertilizerCertificate/GetAllRemark?CertificateID= " + CertificateID + "&Remark_Type=" + Remark_Type, "");
            }
        }
        public async Task<List<Organic_Analysis>> GetOrganicAnalysisByCertificateID(Guid CertificateID)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Organic_Analysis>>("API/FertilizerCertificate/GetOrganicAnalysisByCertificateID?ID=" + CertificateID.ToString(), "");
                return result;
            }
        }

        public async Task<List<Chemical_Analysis>> GetChemicalAnalysisByCertificateID(Guid CertificateID)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Chemical_Analysis>>("API/FertilizerCertificate/GetChemicalAnalysisByCertificateID?ID=" + CertificateID.ToString(), "");
                return result;
            }
        }

        #endregion

        #region MASTER LIST
        public async Task<List<Lookup_Master>> GetMajorElementFormMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetMajorElementFormMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetMajorElementMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetMajorElementMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetNatureMaster()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetNatureMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetOrganicAnalysisMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetOrganicAnalysisMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetSecondaryElementMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetSecondaryElementMaster/", "");
                return result;
            }

        }

        public async Task<List<Lookup_Master>> GetShapeMaster()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetShapeMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetSubCategoryMaster()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetSubCategoryMaster/", "");
                return result;
            }
        }

        public async Task<List<Lookup_Master>> GetTraceElementFormMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetTraceElementFormMaster/", "");
                return result;
            }

        }

        public async Task<List<Lookup_Master>> GetTraceElementMaster()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetTraceElementMaster/", "");
                return result;
            }

        }

        public async Task<List<Lookup_Master>> GetFertilizerTypeMaster()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Lookup_Master>>("API/FertilizerCertificate/GetFertilizerTypeMaster/", "");
                return result;
            }
        }

        #endregion

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
        public IActionResult Payment()
        {
            return View();
        }
      
        public IActionResult RequestCancel()
        {
            return View();
        }

        public IActionResult Review(string CertificateId )
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

        public IActionResult Dashboard(string id)
        {
            string ID = id;
            return View();

        }

        #endregion ALL PAGE VIEW


        #region CERTIFICATE GENERATION

        public async Task<ActionResult> PesticideReceiptDesign(string application_type)
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
                    List<FertilizerCertificate> receiptObj = new List<FertilizerCertificate>();
                    receiptObj = await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/GetAllCertificate?application_type=" + application_type, "");

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
            jpg.SetAbsolutePosition((float)(docWidth - jpg.ScaledWidth) / 2, (float)(943 / rateY)-100);

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(jpg);

            #endregion CENTER TOP LOGO

            #region LEFT SIDE HEADER
            ///////////////////////////////////////////////////////   header Text

            String header_text = "Sultanate of Oman";

            cb.SetColorFill(new BaseColor(0, 0, 0));
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

            cb.SetColorFill(new BaseColor(0, 0, 0));
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

            String imageURLTitle = Path.Combine(webRootPath, "images\\") + "title.png";

            iTextSharp.text.Image imageTitle = iTextSharp.text.Image.GetInstance(imageURLTitle);
            imageTitle.ScaleToFit(300f, 50f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            imageTitle.SetAbsolutePosition((float)(docWidth - imageTitle.ScaledWidth) / 2, (float)(943 / rateY)-150);

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageTitle);

            #endregion CENTER TOP TITLE

            #region ITEMS TABLE

            try
            {

                using (var objectClient = new ApiClient(AppSettings))
                {
                    // lstReceiptInvoice = await objectClient.Get<List<Receipt_Invoice>>("?actn=18&receiptid=" + receiptid, "");

                    List<FertilizerCertificate> lstReceiptInvoice = new List<FertilizerCertificate>();
                    lstFertilizerCertificate = await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/GetAllCertificate?application_type=" + application_type, "");

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

           
            PdfPTable tbl_Items = new PdfPTable(4);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tbl_Items.DefaultCell.NoWrap = false;

          

            if (lstFertilizerCertificate.Count > 10)
            {
                cellHeight = 20;
                headerHeight = 25;
            }

            iTextSharp.text.Font headerFont;

            if (lstFertilizerCertificate.Count > 10)
                headerFont = new iTextSharp.text.Font(bfArialUniCode, 6);
            else
                headerFont = new iTextSharp.text.Font(bfArialUniCode, 8);

            iTextSharp.text.Font cellFont;

            if (lstFertilizerCertificate.Count > 10)
                cellFont = new iTextSharp.text.Font(bfArialUniCode, 5);
            else
                cellFont = new iTextSharp.text.Font(bfArialUniCode, 7);

            string NameEn = "Name";
            string ValueEn = "Value";
            string NameAr = "Arabic";
            string ValueAr = "قيمة";

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tbl_Items.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }


            PdfPCell NameEn_Cell = new PdfPCell(new Phrase(NameEn, headerFont));
            NameEn_Cell.FixedHeight = (float)(headerHeight / rateY);
            NameEn_Cell.NoWrap = false;
            NameEn_Cell.PaddingTop = 0;
            NameEn_Cell.BorderColor = new BaseColor(0, 0, 0);
            NameEn_Cell.BorderWidth = 1;
            NameEn_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            NameEn_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell ValueEn_Cell = new PdfPCell(new Phrase(ValueEn, headerFont));
            ValueEn_Cell.FixedHeight = (float)(headerHeight / rateY);
            ValueEn_Cell.NoWrap = false;
            ValueEn_Cell.PaddingTop = 0;
            ValueEn_Cell.BorderColor = new BaseColor(0, 0, 0);
            ValueEn_Cell.BorderWidth = 1;
            ValueEn_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            ValueEn_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell ValueAr_Cell = new PdfPCell(new Phrase(ValueAr, headerFont));
            ValueAr_Cell.FixedHeight = (float)(headerHeight / rateY);
            ValueAr_Cell.NoWrap = false;
            ValueAr_Cell.PaddingTop = 0;
            ValueAr_Cell.BorderColor = new BaseColor(0, 0, 0);
            ValueAr_Cell.BorderWidth = 1;
            ValueAr_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            ValueAr_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell NameAr_Cell = new PdfPCell(new Phrase(NameAr, headerFont));
            NameAr_Cell.FixedHeight = (float)(headerHeight / rateY);
            NameAr_Cell.NoWrap = false;
            NameAr_Cell.PaddingTop = 0;
            NameAr_Cell.BorderColor = new BaseColor(0, 0, 0);
            NameAr_Cell.BorderWidth = 1;
            NameAr_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            NameAr_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

           
            tbl_Items.AddCell(NameEn);
            tbl_Items.AddCell(ValueEn);
            tbl_Items.AddCell(ValueAr);
            tbl_Items.AddCell(NameAr);


            #region POPULATE THE CERTIFICATE DETAILS
            /*
            Date = Convert.ToString(lstReceiptInvoice[i].Invoice_Date);
            Amount = Convert.ToString(lstReceiptInvoice[i].Amount);
            Invoice_Number = Convert.ToString(lstReceiptInvoice[i].Invoice_ID);

            Amount_Cell = new PdfPCell(new Phrase(Amount, cellFont));
            Amount_Cell.FixedHeight = (float)(cellHeight / rateY);
            Amount_Cell.NoWrap = false;
            Amount_Cell.Padding = 0;
            Amount_Cell.BorderColor = new BaseColor(0, 0, 0);
            Amount_Cell.BorderWidth = 1;
            Amount_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Amount_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            Date_Cell = new PdfPCell(new Phrase(Date, cellFont));
            Date_Cell.FixedHeight = (float)(cellHeight / rateY);
            Date_Cell.NoWrap = false;
            Date_Cell.Padding = 0;
            Date_Cell.BorderColor = new BaseColor(0, 0, 0);
            Date_Cell.BorderWidth = 1;
            Date_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            Invoice_Number_Cell = new PdfPCell(new Phrase(Invoice_Number, cellFont));
            Invoice_Number_Cell.FixedHeight = (float)(cellHeight / rateY);
            Invoice_Number_Cell.NoWrap = false;
            Invoice_Number_Cell.Padding = 0;
            Invoice_Number_Cell.BorderColor = new BaseColor(0, 0, 0);
            Invoice_Number_Cell.BorderWidth = 1;
            Invoice_Number_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Invoice_Number_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;


            
            tbl_Items.AddCell(Amount_Cell);
            tbl_Items.AddCell(Date_Cell);
            tbl_Items.AddCell(Invoice_Number_Cell);
            
            */
            #endregion POPULATE THE CERTIFICATE DETAILS



            //Add the table to the document 
            PdfContentByte pcb8 = writer.DirectContent;
            tbl_Items.TotalWidth = (float)(docWidth - 50);

            if (lstFertilizerCertificate.Count > 10)
                tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(400 + cellHeight * lstFertilizerCertificate.Count / rateY), pcb8);
            else
                tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(400 + cellHeight * lstFertilizerCertificate.Count / rateY), pcb8);

            ////////////////////////////////////////////////////////////////////////////////////////////
            #endregion ITEMS TABLE


            doc.Close();

            string urlPdf = "/pdf/" + directoryName + "_Voucher.pdf";
            return Json(new { url = urlPdf });

        }

        public async Task<ActionResult> CertificateDesign(int application_type, Guid id)
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
                    lstFertilizerCertificate = await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/GetCertificateById?id=" + id, "");
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

            String imageURLTitle = Path.Combine(webRootPath, "images\\") + "fertilizer_certificate.png";

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

            
            string created_date = Convert.ToDateTime(lstFertilizerCertificate[0].Created_date).ToShortDateString();

            Font regular = new Font(FontFamily.HELVETICA,10,Font.NORMAL, BaseColor.DARK_GRAY);
            Font bold = new Font(FontFamily.HELVETICA, 10, Font.BOLD);
           
            PdfPCell receipt_Date_Cell = new PdfPCell(new Phrase("رقم: Date: " + created_date, font));
           
            receipt_Date_Cell.FixedHeight = (float)(cellHeight / rateY);
            receipt_Date_Cell.NoWrap = false;
            receipt_Date_Cell.PaddingTop = 0;
            receipt_Date_Cell.BorderColor = new BaseColor(174, 47, 45);
            receipt_Date_Cell.BorderWidth =0;
            receipt_Date_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            receipt_Date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            receipt_Date_Cell.Colspan = 1;

            string Local_Certificate_Registration_No =  "الرقم: Number: " + lstFertilizerCertificate[0].Local_Certificate_Registration_No;

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
            txt_received_from_cell.FixedHeight = (float)(cellHeight+20 / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
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

            #region Scientific Name

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

            string Scientific_Name = "الاسم العام / الشائع: Scientific Name: " + lstFertilizerCertificate[0].Scientific_Name;

            //Create a cell and add text to it 
            font.Size = 11;
            PdfPCell txt_received_from_cell1 = new PdfPCell(new Phrase(Scientific_Name, font));
            txt_received_from_cell1.FixedHeight = (float)(cellHeight / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
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

            #endregion Scientific Name

            #region Trade Name

            ////////////////////////////// Second Table right side
            ///
            PdfPTable table_amount_letter = new PdfPTable(1);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_amount_letter.DefaultCell.NoWrap = false;

            // Create a regex expression to detect hebrew or arabic code points
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_amount_letter.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            string Trade_Name = "الاسم التجاري: Trade Name: " + lstFertilizerCertificate[0].Trade_Name;


            //Create a cell and add text to it 
            font.Size = 11;
            PdfPCell txt_amount_letter_cell = new PdfPCell(new Phrase(Trade_Name, font));
            txt_amount_letter_cell.FixedHeight = (float)(cellHeight / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
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
            table_amount_letter.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(660 / rateY), pcb2_amount_letter); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                         //doc.Add(table2);

            #endregion Trade Name

          
            #region Nature

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
            PdfPCell txt_amount_letter_cell1 = new PdfPCell(new Phrase("طبيعة السماد : Nature: " + lstFertilizerCertificate[0].Nature, font));
            txt_amount_letter_cell1.FixedHeight = (float)(cellHeight / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
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
            table_amount_letter1.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(640 / rateY), pcb2_amount_letter1); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                          //doc.Add(table2);

            #endregion Nature

            #region Manufacturing and Address

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
            string Manufacturer = lstFertilizerCertificate[0].Manufacturer + " " + lstFertilizerCertificate[0].Manufacturer_Address;
            font.Size = 11;
            PdfPCell txt_amount_letter_cell2 = new PdfPCell(new Phrase("الشركة المنتجة وعنوانها: Company: " + Manufacturer, font));
            txt_amount_letter_cell2.FixedHeight = (float)(cellHeight / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
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
            table_amount_letter2.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(620 / rateY), pcb2_amount_letter2); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                           //doc.Add(table2);

            #endregion Manufacturing and Address

            #region Imported and Address

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
            string imported = lstFertilizerCertificate[0].Company_Licensed_Import_Export_Trade + " " + lstFertilizerCertificate[0].Address;
            font.Size = 11;
            PdfPCell txt_amount_letter_cell3 = new PdfPCell(new Phrase("الشركة المستوردة وعنوانها: Importing Company: " + imported, font));
            txt_amount_letter_cell3.FixedHeight = (float)(cellHeight / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
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
            table_amount_letter3.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(600 / rateY), pcb2_amount_letter3); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                           //doc.Add(table2);

            #endregion Imported and Address

            #region Expiry Date

            PdfPTable table_cheque = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_cheque.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_cheque.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            string expiry_date = "تاريخ الانتهاء : Expiry Date: " + Convert.ToDateTime(lstFertilizerCertificate[0].expiry_date).ToShortDateString();
            string release_date = "تاريخ الإصدار: Issued Date: " + Convert.ToDateTime(lstFertilizerCertificate[0].Created_date).ToShortDateString();

            font.Size = 10;
            font.SetColor(0, 0, 0);

            PdfPCell cheque_due_date_Cell = new PdfPCell(new Phrase(expiry_date, font));
            cheque_due_date_Cell.FixedHeight = (float)(cellHeight / rateY);
            cheque_due_date_Cell.NoWrap = false;
            cheque_due_date_Cell.PaddingTop = 0;
            cheque_due_date_Cell.BorderColor = new BaseColor(174, 47, 45);
            cheque_due_date_Cell.BorderWidth = 0;
            cheque_due_date_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cheque_due_date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cheque_due_date_Cell.Colspan = 1;


            PdfPCell cheque_no_cell = new PdfPCell(new Phrase(release_date, font));
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
            table_cheque.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(580 / rateY), pcb_cheque);


            #endregion Expiry Date

            #region Table Description


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
            Bank_Name_cell.FixedHeight = (float)(cellHeight / rateY); // change from 37f to 45 f by harmanjeet on 7/4/2019
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
            table_Bank_Name.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(550 / rateY), pcb_bank_name); // change from 722 to 732 f by harmanjeet on 7/4/2019
                                                                                                                //doc.Add(table2);

            #endregion Table Description

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

            List<Print> lstPrint = new List<Print>();
            try
            {

                using (var objectClient = new ApiClient(AppSettings))
                {
                    lstPrint = await objectClient.Get<List<Print>>("API/FertilizerCertificate/GetCertificatePrint?id=" + id, "");
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

            if (lstPrint.Count > 10)
            {
                cellHeight = 20;
                headerHeight = 25;
            }

            iTextSharp.text.Font headerFont;

            if (lstPrint.Count > 10)
                headerFont = new iTextSharp.text.Font(bfArialUniCode, 6);
            else
                headerFont = new iTextSharp.text.Font(bfArialUniCode, 8);

            iTextSharp.text.Font cellFont;

            if (lstPrint.Count > 10)
                cellFont = new iTextSharp.text.Font(bfArialUniCode, 5);
            else
                cellFont = new iTextSharp.text.Font(bfArialUniCode, 7);


            for (int i = 0; i < lstPrint.Count; i++)
            {

                string Value = Convert.ToString(lstPrint[i].Value);
                string Element_Description = Convert.ToString(lstPrint[i].Text);

                PdfPCell Value_Cell = new PdfPCell(new Phrase(Value, cellFont));
                Value_Cell.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                Value_Cell.FixedHeight = (float)(cellHeight / rateY);
                Value_Cell.NoWrap = false;
                Value_Cell.Padding = 0;
                Value_Cell.BorderColor = new BaseColor(0, 0, 0);
                Value_Cell.BorderWidth = 1;
                Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                PdfPCell Element_Description_Cell = new PdfPCell(new Phrase(Element_Description, cellFont));
                Element_Description_Cell.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
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

            if (lstPrint.Count > 10)
               // tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(400 - cellHeight * lstPrint.Count / rateY), pcb8);
               tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(525 / rateY), pcb8);
                    else
                //  tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(400 - cellHeight * lstPrint.Count / rateY), pcb8);
               tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(525 / rateY), pcb8);

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

            string signature_Date = "  التاريخ"    + DateTime.Now.ToShortDateString() + "    Date"; 
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
            imageSignature.ScaleToFit(125f, 90f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            imageSignature.SetAbsolutePosition((float)(docWidth - imageSignature.ScaledWidth) / 2, (float)(100 / rateY));

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageSignature);

            #endregion CENTER TOP TITLE     


            doc.Close();

            string urlPdf = "/pdf/" + directoryName + "_Certificate.pdf";
            return Json(new { url = urlPdf });
          
        }

        public async Task<ActionResult> CertificateDesign_copy(int application_type)
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

                    lstFertilizerCertificate = await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/GetAllCertificate?application_type=" + application_type, "");

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

            cb.SetColorFill(new BaseColor(0, 0, 0));
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

            cb.SetColorFill(new BaseColor(0, 0, 0));
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

            String imageURLTitle = Path.Combine(webRootPath, "images\\") + "title.png";

            iTextSharp.text.Image imageTitle = iTextSharp.text.Image.GetInstance(imageURLTitle);
            imageTitle.ScaleToFit(300f, 50f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            imageTitle.SetAbsolutePosition((float)(docWidth - imageTitle.ScaledWidth) / 2, (float)(943 / rateY) - 150);

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageTitle);

            #endregion CENTER TOP TITLE 

            #region RECEIPT NUMBER

            PdfPTable table_receipt = new PdfPTable(1);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_receipt.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_receipt.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }


            string Receipt_NO = "       رقم" + receiptObj.ID + "       Receipt No";

            font.Size = 10;
            font.SetColor(0, 0, 0);

            PdfPCell Receipt_NO_Cell = new PdfPCell(new Phrase(Receipt_NO, font));
            Receipt_NO_Cell.FixedHeight = (float)(cellHeight / rateY);
            Receipt_NO_Cell.NoWrap = false;
            Receipt_NO_Cell.PaddingTop = 0;
            Receipt_NO_Cell.BorderColor = new BaseColor(0, 0, 0);
            Receipt_NO_Cell.BorderWidth = 0;
            Receipt_NO_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Receipt_NO_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            Receipt_NO_Cell.Colspan = 2;


            table_receipt.AddCell(Receipt_NO_Cell);

            //Add the table to the document 
            PdfContentByte pcb_receipt = writer.DirectContent;
            table_receipt.TotalWidth = (float)(630 / rateX);
            table_receipt.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(790 / rateY), pcb_receipt);


            #endregion RECEIPT NUMBER

            #region DISTIBUTOR SECTION

            PdfPTable table_distibutor = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_distibutor.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_distibutor.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            string receipt_Date = "       التاريخ" + receiptObj.Receipt_Date + "       Date";
            string distibutor_NO = "       رقم الموزع" + receiptObj.Distibutor_No + "       Distibutor No";

            font.Size = 10;
            font.SetColor(0, 0, 0);

            PdfPCell receipt_Date_Cell = new PdfPCell(new Phrase(receipt_Date, font));
            receipt_Date_Cell.FixedHeight = (float)(cellHeight / rateY);
            receipt_Date_Cell.NoWrap = false;
            receipt_Date_Cell.PaddingTop = 0;
            receipt_Date_Cell.BorderColor = new BaseColor(174, 47, 45);
            receipt_Date_Cell.BorderWidth = 0;
            receipt_Date_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            receipt_Date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            receipt_Date_Cell.Colspan = 1;


            PdfPCell distibutor_NO_Cell = new PdfPCell(new Phrase(distibutor_NO, font));
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


            #endregion DISTIBUTOR SECTION

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
            PdfPCell txt_received_from_cell = new PdfPCell(new Phrase("استلمنا من        " + receiptObj.Customer_Name + "       Received from", font));
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

            #region AMOUNT SECTION

            PdfPTable table_amount = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_amount.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_amount.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            string amount_en = "Amount       " + receiptObj.Total_Amount_Number + "       OMR";
            string amount_ar = "رمبلغ وقدره       " + receiptObj.Total_Amount_Number + "       ريال عماني";

            font.Size = 10;
            font.SetColor(0, 0, 0);

            PdfPCell amount_en_Cell = new PdfPCell(new Phrase(amount_en, font));
            amount_en_Cell.FixedHeight = (float)(cellHeight / rateY);
            amount_en_Cell.NoWrap = false;
            amount_en_Cell.PaddingTop = 0;
            amount_en_Cell.BorderColor = new BaseColor(174, 47, 45);
            amount_en_Cell.BorderWidth = 0;
            amount_en_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            amount_en_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            amount_en_Cell.Colspan = 1;


            PdfPCell amount_ar_cell = new PdfPCell(new Phrase(amount_ar, font));
            amount_ar_cell.FixedHeight = (float)(cellHeight / rateY);
            amount_ar_cell.NoWrap = false;
            amount_ar_cell.PaddingTop = 0;
            amount_ar_cell.BorderColor = new BaseColor(0, 0, 0);
            amount_ar_cell.BorderWidth = 0;
            amount_ar_cell.HorizontalAlignment = Element.ALIGN_LEFT;
            amount_ar_cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            amount_ar_cell.Colspan = 1;


            table_amount.AddCell(amount_ar_cell);
            table_amount.AddCell(amount_en_Cell);

            //Add the table to the document 
            PdfContentByte pcb_amount = writer.DirectContent;
            table_amount.TotalWidth = (float)(630 / rateX);
            table_amount.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(680 / rateY), pcb_amount);


            #endregion AMOUNT SECTION

            #region AMOUNT WORDS

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
            PdfPCell txt_amount_letter_cell = new PdfPCell(new Phrase("الملبغ بالحروف " + receiptObj.Total_Amount_Words + "Amount in letters", font));
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

            #endregion AMOUNT WORDS

            #region CHEQUE SECTION

            PdfPTable table_cheque = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_cheque.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_cheque.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            string cheque_due_date = "تاريخ الاستحقاق       " + receiptObj.Cheque_Date + "       Due Date";
            string cheque_no = "       رقم الشيك" + receiptObj.Cheque_Number + "       Cheque No";

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
            table_cheque.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(610 / rateY), pcb_cheque);


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
            PdfPCell Bank_Name_cell = new PdfPCell(new Phrase("Bank Name: \n مسحوب على بنك:" + receiptObj.Bank_Name, font));
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
            table_Bank_Name.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(580 / rateY), pcb_bank_name); // change from 722 to 732 f by harmanjeet on 7/4/2019
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
                    lstFertilizerCertificate = await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/GetAllCertificate?application_type=" + application_type, "");
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

            if (lstFertilizerCertificate.Count > 10)
            {
                cellHeight = 20;
                headerHeight = 25;
            }

            iTextSharp.text.Font headerFont;

            if (lstFertilizerCertificate.Count > 10)
                headerFont = new iTextSharp.text.Font(bfArialUniCode, 6);
            else
                headerFont = new iTextSharp.text.Font(bfArialUniCode, 8);

            iTextSharp.text.Font cellFont;

            if (lstFertilizerCertificate.Count > 10)
                cellFont = new iTextSharp.text.Font(bfArialUniCode, 5);
            else
                cellFont = new iTextSharp.text.Font(bfArialUniCode, 7);



            string Value = "القيمة \n\n Value";
            string Element_Description = "وصف العنصر \n\n Element Description";


            PdfPCell Element_Description_Cell = new PdfPCell(new Phrase(Element_Description, headerFont));
            Element_Description_Cell.FixedHeight = (float)(headerHeight / rateY);
            Element_Description_Cell.NoWrap = false;
            Element_Description_Cell.PaddingTop = 0;
            Element_Description_Cell.BorderColor = new BaseColor(0, 0, 0);
            Element_Description_Cell.BorderWidth = 1;
            Element_Description_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
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


            for (int i = 0; i < lstFertilizerCertificate.Count; i++)
            {

                Value = Convert.ToString(lstFertilizerCertificate[i].Created_date);
                Element_Description = Convert.ToString(lstFertilizerCertificate[i].CertificateFee);

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

            if (lstFertilizerCertificate.Count > 10)
                tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(400 + cellHeight * lstFertilizerCertificate.Count / rateY), pcb8);
            else
                tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(400 + cellHeight * lstFertilizerCertificate.Count / rateY), pcb8);

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

            string signature_Date = "التاريخ...........................................Date";
            string signature_receiver = "توقيع المستلم......................................................Receiver's Signature";

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
            table_signature_row_2.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(375 / rateY), pcb_signature_row2);

            #endregion SIGNATURE SECTION

            doc.Close();

            string urlPdf = "/pdf/" + directoryName + "_Voucher.pdf";
            return Json(new { url = urlPdf });

        }


        #endregion CERTIFICATE GENERATION


        public async Task<Fertilizer_Model> PageLoad()
        {

            var browserLang = Request.Headers["Accept-Language"].ToString().Split(";").FirstOrDefault()?.Split(",").FirstOrDefault();
            browserLang = Thread.CurrentThread.CurrentCulture.Name;

            model = new Fertilizer_Model();

            #region Organic Analysis List

            model.OrganicAnalysisMaster = new List<SelectListItem>();
            model.OrganicAnalysisMaster.Add(new SelectListItem());

            var ObjOrganicAnalysisMaster = await this.GetOrganicAnalysisMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.OrganicAnalysisMaster.AddRange(ObjOrganicAnalysisMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.OrganicAnalysisMaster.AddRange(ObjOrganicAnalysisMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.OrganicAnalysisMaster.RemoveAt(0);

            #endregion

            #region Major Element Master

            model.MajorElementMaster = new List<SelectListItem>();
            model.MajorElementMaster.Add(new SelectListItem());

            var ObjMajorElementMaster = await this.GetMajorElementMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.MajorElementMaster.AddRange(ObjMajorElementMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.MajorElementMaster.AddRange(ObjMajorElementMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.MajorElementMaster.RemoveAt(0);

            #endregion

            #region Major Element Form Master

            model.MajorElementFormMaster = new List<SelectListItem>();
            model.MajorElementFormMaster.Add(new SelectListItem());

            var ObjMajorElementFormMaster = await this.GetMajorElementFormMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.MajorElementFormMaster.AddRange(ObjMajorElementFormMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.MajorElementFormMaster.AddRange(ObjMajorElementFormMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.MajorElementFormMaster.RemoveAt(0);

            #endregion

            #region Secondary Element Master

            model.SecondaryElementMaster = new List<SelectListItem>();
            model.SecondaryElementMaster.Add(new SelectListItem());

            var ObjSecondaryElementMaster = await this.GetSecondaryElementMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.SecondaryElementMaster.AddRange(ObjSecondaryElementMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.SecondaryElementMaster.AddRange(ObjSecondaryElementMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.SecondaryElementMaster.RemoveAt(0);


            #endregion Secondary Element Master

            #region Trace Element Master

            model.TraceElementMaster = new List<SelectListItem>();
            model.TraceElementMaster.Add(new SelectListItem());

            var ObjTraceElementMaster = await this.GetTraceElementMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.TraceElementMaster.AddRange(ObjTraceElementMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.TraceElementMaster.AddRange(ObjTraceElementMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.TraceElementMaster.RemoveAt(0);


            #endregion Trace Element Master          

            #region Trace Element Form Master

            model.TraceElementFormMaster = new List<SelectListItem>();
            model.TraceElementFormMaster.Add(new SelectListItem());

            var ObjTraceElementFormMaster = await this.GetTraceElementFormMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.TraceElementFormMaster.AddRange(ObjTraceElementFormMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.TraceElementFormMaster.AddRange(ObjTraceElementFormMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.TraceElementFormMaster.RemoveAt(0);


            #endregion Form Element Master

            #region Nature Master

            model.NatureMaster = new List<SelectListItem>();
            model.NatureMaster.Add(new SelectListItem());

            var ObjNatureMaster = await this.GetNatureMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.NatureMaster.AddRange(ObjNatureMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.NatureMaster.AddRange(ObjNatureMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.NatureMaster.RemoveAt(0);


            #endregion Nature Master

            #region Shape Master

            model.ShapeMaster = new List<SelectListItem>();
            model.ShapeMaster.Add(new SelectListItem());

            var ObjShapeMaster = await this.GetShapeMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.ShapeMaster.AddRange(ObjShapeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.ShapeMaster.AddRange(ObjShapeMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.ShapeMaster.RemoveAt(0);


            #endregion Shape Master

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


            #endregion Fertilizer Type Master

            #region Fertilizer Subcategory Master

            model.SubCategoryMaster = new List<SelectListItem>();
            model.SubCategoryMaster.Add(new SelectListItem());

            var ObjSubCategoryMaster = await this.GetSubCategoryMaster();

            if (browserLang.ToLower() == "en-us")
            {
                model.SubCategoryMaster.AddRange(ObjSubCategoryMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.SubCategoryMaster.AddRange(ObjSubCategoryMaster.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.SubCategoryMaster.RemoveAt(0);


            #endregion Fertilizer Subcategory Master

            return model;

        }

        #region Analysis Dashboard

        public async Task<List<Common.CertificateAnalysis>> GetCertificateAnalysis()
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<Common.CertificateAnalysis>>("API/FertilizerCertificate/GetCertificateAnalysis/?userid=" + UserId, "");
                return result;
            }
            
        }      

        public async Task<List<FertilizerCertificate>> getReviewPendingCertificate()
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/getReviewPendingCertificate/?userid=" + UserId, "");
                return result;
            }

        }

        public async Task<List<FertilizerCertificate>> getApprovalPendingCertificate()
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<FertilizerCertificate>>("API/FertilizerCertificate/getApprovalPendingCertificate/?userid=" + UserId, "");
                return result;
            }

        }


        #endregion


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
    }
}

