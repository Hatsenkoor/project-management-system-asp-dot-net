using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using PCVM.Web.Helpers;
using PCVMS.Model.Web;
using PCVMS.Model.BusinessModel;
using System.Collections;
using System.Threading;
using Microsoft.Extensions.Logging;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.IO;

using Microsoft.Extensions.Configuration;


namespace PCVM.Web.Controllers
{
    public class LoginController : Controller
    {
        IConfiguration configuration;
        public IOptions<Helpers.AppSettings> AppSettings { get; }
        public string CurrentUser { get; set; }

        [TempData]
        public string LoggedInUser { get; set; }

        [TempData]
        public string LoggedInEmail { get; set; }


        public LoginController(IConfiguration configuration, IOptions<PCVM.Web.Helpers.AppSettings> appSettings, IMemoryCache _Cache, ILoggerFactory loggerFactory)
        {
            this.configuration = configuration;

            AppSettings = appSettings;
            Cache = _Cache;
            _logger = loggerFactory.CreateLogger(typeof(LoginController));
        }

        public IMemoryCache Cache { get; }
        private ILogger _logger;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

         [AllowAnonymous] 
         [HttpPost]
        public async Task<IActionResult> Index(UserModel model)
        {
            try
            {
                _logger.LogTrace("Index called");
                if (model.Username.Contains("@"))
                {
                    var passwordHash = SecurePasswordHasherHelper.Hash(model.Password);
                    model.Password = passwordHash;
                }
              
                var result =await this.IsValidUser(model);
                _logger.LogTrace("IsValidUser called");

                if (result != null)
                {

                    LoggedInUser = result.NameEn;
                    LoggedInEmail = result.Email;


                    //  var verify = SecurePasswordHasherHelper.Verify(model.Password, passwordHash);
                    var claims = new List<Claim>
                    {
                      new Claim("UserId",result.UserId.ToString())
                    };

                    CurrentUserSettings.SetUserInCookies(HttpContext, result.UserId);
                  
                    if (Cache.Get("Permission")==null)
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add(result.UserId.ToString(), result);
                        Cache.Set<Hashtable>("Permission", ht);
                    }
                    else
                    {
                        var ht = Cache.Get<Hashtable>("Permission");
                        if (!ht.ContainsKey(result.UserId))
                        {
                            ht.Add(result.UserId, result);
                            Cache.Set<Hashtable>("Permission", ht);
                        }
                        else
                        {
                            ht.Remove(result.UserId);
                            ht.Add(result.UserId, result);
                            Cache.Set<Hashtable>("Permission", ht);
                        }
                    }
                    var claimsIdentity = new ClaimsIdentity(
                      claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(
                      CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(claimsIdentity),authProperties);

                   /*  if (result.Email.Equals("ea@mrmwr.gov.om"))
                        return RedirectToAction("Create", "Project");
                    else if (result.Email.Equals("cf@mrmwr.gov.om"))
                        return RedirectToAction("Property", "Property");
                    else if (result.Email.Equals("director@mrmwr.gov.om"))
                        return RedirectToAction("Create", "ProjectApproval");
                    else if (result.Email.Equals("engineer@mrmwr.gov.om"))
                        return RedirectToAction("SiteSurvey", "PCVDEngineer");
                    else if (result.Email.Equals("pcvc@mrmwr.gov.om"))
                        return RedirectToAction("SiteSurvey", "PCVCCommittee", new { extent = 100 });
                    else if (result.Email.Equals("inventory@mrmwr.gov.om"))
                        return RedirectToAction("ValuationApproval", "Inventory");
                    else if (result.Email.Equals("executiveinventory@mrmwr.gov.om"))
                        return RedirectToAction("Valuation", "Inventory");
                    if (result.Email.Equals("finance@mrmwr.gov.om"))
                     return RedirectToAction("DecisionApproval", "Finance");
                    if (result.Email.Equals("executivefinance@mrmwr.gov.om"))
                        return RedirectToAction("Decision", "Finance");
                    else if (result.Email.Equals("followup@mrmwr.gov.om"))
                        return RedirectToAction("Index", "Objection");
                    else if (result.Email.Equals("wo@mrmwr.gov.om"))
                        return RedirectToAction("Index", "Objection");
                    else if (result.Email.Equals("po@mrmwr.gov.om"))
                        return RedirectToAction("Index", "Objection");
                    else if (result.Email.Equals("court@mrmwr.gov.om"))
                        return RedirectToAction("Index", "StopPayment");

                    else
                        */
                        return RedirectToAction("index", "Hierarchy");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or Password");
                    return View(); 
                }
            }
            catch(Exception ex)
            {
                _logger.LogTrace("ex called");
                _logger.LogTrace(ex.Message);
                _logger.LogTrace(ex.StackTrace.ToString());
                return View();
            }
        }

        public IActionResult pki()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
  CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(("Index"));
        }

        [HttpPost]
        public async Task<PCVMS_User> IsValidUser(UserModel obj)
        {
          

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_User>("API/Login/IsValidUser", stringContent, "");
                return result;
            }
           
        }


        public async Task<string> GetMociMobile(string CRNo, string OTP)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
               var result = await objectClient.Get<string>("API/User/GetMociMobile?CRNo=" +CRNo+"&OTP="+OTP,"");
              
                return result;
            }

        }

        public async Task<bool> saveCustomer(UserModel model)
        {
            try
            {
                string OTP = GenerateRandomNo().ToString();
                //Call MOCI to get the Company Details
                string company =  await GetMociMobile(model.Username, OTP);

                await SendSMS(company,OTP);
            }
            catch (Exception ex)
            {
                _logger.LogTrace("ex called");
                _logger.LogTrace(ex.Message);
                _logger.LogTrace(ex.StackTrace.ToString());
                return false;
            }

            return true;
        }


        private async Task<bool> SendSMS(string mobile, string OTP)
        {
            //Generate Random OTP

            SMS objSMS = new SMS();
            objSMS.UserID = configuration.GetSection("AppSettings:UserID").Value;
            objSMS.Password = configuration.GetSection("AppSettings:Password").Value;
            objSMS.MobileNo = mobile;  // "96893894475"; // mobile;
            objSMS.Message = OTP;
            objSMS.Language = configuration.GetSection("AppSettings:Language").Value;
            objSMS.RecipientType = configuration.GetSection("AppSettings:RecipientType").Value;
            objSMS.ScheddateTime = DateTime.Now.ToString();

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(objSMS);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/User/SendSMS", stringContent, "");
                return result;
            }

        }

        //Generate RandomNo
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}