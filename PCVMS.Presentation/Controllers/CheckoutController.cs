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
//using CCAV.Util;
using System.Collections.Specialized;

namespace PCVM.Web.Controllers
{
    public class CheckoutController : Controller
    {
        
        IConfiguration configuration;
        string url;

       
        public IWebHostEnvironment Env { get; }
        public IOptions<Helpers.AppSettings> AppSettings { get; }

        public CheckoutController(IConfiguration configuration, IOptions<Helpers.AppSettings> appSettings, IWebHostEnvironment web)
        {
            AppSettings = appSettings;
            Env = web;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            this.configuration = configuration;
            url = this.configuration.GetSection("AppSettings:ApiUrl.Finance").Value;
        }

        public IActionResult Index(string id, string AppID, string amount, string paymentType)
        {
            //string workingKey = "2D8A6F83BCBA23D3EA8259783A6E4BDA";//put in the 32bit alpha numeric key in the quotes provided here 	
            string workingKey = "B3EEEF17F399603220440539F0C65C6B"; // for production pf.maf.gov.om
            string ccaRequest = "merchant_id=99&order_id=" +id;
            ccaRequest += "&amount=" + amount;
            ccaRequest += "&merchant_param1=" + paymentType;
            ccaRequest += "&merchant_param2=" + AppID;
            //ccaRequest += "&currency=OMR&redirect_url=http://localhost:55181/checkout/payment&cancel_url=http://localhost:55181/ccavResponseHandler.aspx&customer_identifier=&"; //for local
            ccaRequest += "&currency=OMR&redirect_url=https://pf.maf.gov.om/checkout/payment&cancel_url=https://pf.maf.gov.om/checkout/payment&customer_identifier=&"; //for pf.maf.gov.om
            string strEncRequest = "";

            Checkout rec = new Checkout();

            //CCACrypto ccaCrypto = new CCACrypto();

            //strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);


            //rec.AccessCode = "AVRD00JI15BD61DRDB";  //for localhost:55181
            rec.AccessCode = "AVNU00JI15AJ46UNJA"; //for pf.maf.gov.om
            //rec.EncRequest = strEncRequest;


            return View(rec);
        }

        public async Task<IActionResult> Payment(string encResp)
        {
           return View("Payment", await SavePayment(encResp));
        }

        private async Task<Payment> SavePayment(string encResp)
        {

            //string workingKey = "2D8A6F83BCBA23D3EA8259783A6E4BDA";//put in the 32bit alpha numeric key in the quotes provided here
            /*string workingKey = "B3EEEF17F399603220440539F0C65C6B"; // for production pf.maf.gov.om
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = ccaCrypto.Decrypt(encResp, workingKey);
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }

            Payment obj = new Payment();
            for (int i = 0; i < Params.Count; i++)
            {
                // Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");

                if (Params.Keys[i].Equals("order_id"))
                    obj.Id = Convert.ToInt64(Params[i]);

                if (Params.Keys[i].Equals("merchant_param1"))
                    obj.PaymentType = Params[i];

                if (Params.Keys[i].Equals("tracking_id"))
                    obj.tracking_id = Params[i];

                if (Params.Keys[i].Equals("bank_ref_no"))
                    obj.bank_ref_no = Params[i];

                if (Params.Keys[i].Equals("order_status"))
                    obj.order_status = Params[i];

                if (Params.Keys[i].Equals("failure_message"))
                    obj.failure_message = Params[i];

                if (Params.Keys[i].Equals("payment_mode"))
                    obj.payment_mode = Params[i];

                if (Params.Keys[i].Equals("card_name"))
                    obj.card_name = Params[i];

                if (Params.Keys[i].Equals("status_code"))
                    obj.status_code = Params[i];

                if (Params.Keys[i].Equals("status_message"))
                    obj.status_message = Params[i];

                if (Params.Keys[i].Equals("currency"))
                    obj.currency = Params[i];

                if (Params.Keys[i].Equals("amount"))
                    obj.amount = Convert.ToDecimal(Params[i]);

                if (Params.Keys[i].Equals("trans_date"))
                    obj.trans_date = DateTime.ParseExact(Params[i], "dd/MM/yyyy HH:mm:ss", null);

                if (Params.Keys[i].Equals("merchant_param6"))
                    obj.card_no = Params[i];

                if (Params.Keys[i].Equals("merchant_param2"))
                    obj.AppID = new Guid(Params[i]);


            }

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<string>("API/FertilizerCertificate/SavePayment", stringContent, "");               
            }

            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            if (obj.PaymentType.StartsWith("Fertilizer"))
            {

                FertilizerCertificate objFertilizer = new FertilizerCertificate();

                objFertilizer.ID = obj.AppID;

                if (obj.PaymentType.Contains("Registration_Fee"))
                {
                    objFertilizer.RegistrationFee = true;
                    objFertilizer.StatusId = "Review Application";
                }
                if (obj.PaymentType.Contains("Certificate_Fee"))
                {
                    objFertilizer.CertificateFee = true;
                    objFertilizer.StatusId = "Issued";
                }
                objFertilizer.Updated_by = UserId.ToString();
                objFertilizer.Updated_date = DateTime.Now;

                var valuesFertilizer = Newtonsoft.Json.JsonConvert.SerializeObject(objFertilizer);
                var stringContentFertilizer = new StringContent(valuesFertilizer.ToString());

                if (obj.PaymentType.Contains("Registration_Fee"))
                {
                    using (var objectClient = new ApiClient(AppSettings))
                    {
                        stringContentFertilizer.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                        var result = await objectClient.Post<List<FertilizerCertificate>>("API/FertilizerCertificate/RegistrationFee", stringContentFertilizer, "");
                         
                    }
                }
                if (obj.PaymentType.Contains("Certificate_Fee"))
                {
                    using (var objectClient = new ApiClient(AppSettings))
                    {
                        stringContentFertilizer.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");                      
                        var result = await objectClient.Post<List<FertilizerCertificate>>("API/FertilizerCertificate/CertificateFee", stringContentFertilizer, "");
                    }
                }

            }
            else if(obj.PaymentType.StartsWith("Pesticide"))
                {

                    PesticideCertificate objPesticide = new PesticideCertificate();

                    objPesticide.ID = obj.AppID;

                    if (obj.PaymentType.Contains("Registration_Fee"))
                    {
                        objPesticide.RegistrationFee = true;
                        objPesticide.StatusId = "Review Application";
                    }
                    if (obj.PaymentType.Contains("Certificate_Fee"))
                    {
                        objPesticide.CertificateFee = true;
                        objPesticide.StatusId = "Issued";
                    }

                    objPesticide.Updated_by = UserId.ToString();
                    objPesticide.Updated_date = DateTime.Now;

                    var valuesPesticide = Newtonsoft.Json.JsonConvert.SerializeObject(objPesticide);
                    var stringContentPesticide= new StringContent(valuesPesticide.ToString());
                   

                    if (obj.PaymentType.Contains("Registration_Fee"))
                    {
                        using (var objectClient = new ApiClient(AppSettings))
                        {
                            stringContentPesticide.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                            var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/RegistrationFee", stringContentPesticide, "");

                        }
                    }
                    if (obj.PaymentType.Contains("Certificate_Fee"))
                    {
                        using (var objectClient = new ApiClient(AppSettings))
                        {
                            stringContentPesticide.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                            var result = await objectClient.Post<List<PesticideCertificate>>("API/PesticideCertificate/CertificateFee", stringContentPesticide, "");
                        }
                    }
            }

            return obj;*/

            return null;
        }

    }
}

