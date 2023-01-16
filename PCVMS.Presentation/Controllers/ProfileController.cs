using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PCVM.Web.Helpers;
using PCVMS.Model.Web;
using PCVMS.Model;
using PCVMS.Model.BusinessModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using PCVMS.Presentation.Helpers;

namespace PCVM.Web.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        

        public ProfileModel Model { get; set; }

        public IOptions<Helpers.AppSettings> AppSettings { get; }
        public IMemoryCache Cache { get; }

        public ProfileController(IOptions<Helpers.AppSettings> appSettings, IMemoryCache _Cache)
        {

            AppSettings = appSettings;
            Cache = _Cache;
           
        }
       
        public  IActionResult Index()
        {
            Model = new ProfileModel();
            Model.RegistrationDate = System.DateTime.Today.ToShortDateString();
           
            return View(Model);
        }
        //public async Task<PCVMS_Profile> AddProfile(ProfileModel obj)
        //{
        //    var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        //    var stringContent = new StringContent(values.ToString());
        //    PCVMS_Profile ObjProfile = new PCVMS_Profile();
        //    using (var objectClient = new ApiClient(AppSettings))
        //    {

        //            stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
        //        try
        //        {
        //            ObjProfile = await objectClient.Post<PCVMS_Profile>("API/Profile/AddProfile", stringContent, "");
        //        }
        //        catch(Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    Dictionary<string, string> document = new Dictionary<string, string>();
        //    document.Add("GroupID", obj.GroupId.ToString());
        //    document.Add("ParentId", ObjProfile.ID.ToString());

        //     values = Newtonsoft.Json.JsonConvert.SerializeObject(document);
        //     stringContent = new StringContent(values.ToString());

        //    using (var objectClient = new ApiClient(AppSettings))
        //    {
        //        stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
        //        var r = await objectClient.Post<bool>("API/Upload/UpdateDocumentParent", stringContent, "");
        //    }
        //    return ObjProfile;
        //}

        public async Task<PCVMS_Profile> AddProfile(ProfileModel obj)
        {
            var UserId = CurrentUserSettings.UserName(HttpContext);
            PCVMS_Profile ObjProfile = new PCVMS_Profile();
            ObjProfile.ID = obj.ID;
            ObjProfile.CreatedUserid = new Guid(UserId);
            ObjProfile.CardId = obj.CardId;
            ObjProfile.Fax = obj.Fax;
            ObjProfile.LandLine = obj.LandLine;
            ObjProfile.Mobile = obj.Mobile;
            ObjProfile.Name = obj.Name;
            ObjProfile.PoBox = obj.PoBox;
            ObjProfile.PostalCode = obj.PostalCode;
            ObjProfile.ProfileId = obj.ProfileId;
            ObjProfile.RegistrationDate = Convert.ToDateTime(obj.RegistrationDate);

            ObjProfile.RegistrationHQ = obj.RegistrationHQ;
            ObjProfile.Remark = obj.Remark;
            ObjProfile.Email = obj.Email;
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(ObjProfile);
            var stringContent = new StringContent(values.ToString());

            try
            {
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    ObjProfile = await objectClient.Post<PCVMS_Profile>("API/Profile/AddProfile", stringContent, "");
                }
            }
            catch (Exception ex)
            {

            }
            Dictionary<string, string> document = new Dictionary<string, string>();
            document.Add("GroupID", obj.GroupId.ToString());
            document.Add("ParentId", ObjProfile.ID.ToString());

            values = Newtonsoft.Json.JsonConvert.SerializeObject(document);
            stringContent = new StringContent(values.ToString());

            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var r = await objectClient.Post<bool>("API/Upload/UpdateDocumentParent", stringContent, "");
            }
            return ObjProfile;
        }
        public async Task<List<PCVMS_User>> AddUserProfile(PCVMS_User_Model obj)
        {
            obj.Password = "PCVMS";
            List<PCVMS_User> objResult = new List<PCVMS_User>();
            obj.Password = obj.Password = SecurePasswordHasherHelper.Hash(obj.Password);
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                objResult = await objectClient.Post<List<PCVMS_User>>("API/Profile/AddUserProfile", stringContent, "");
            }
            return objResult;
        }
        public async Task<List<ProfileUser>> GetProfileUser(Guid ProfileId)
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                var locationlist = await objectClient.Get<List<ProfileUser>>("API/Profile/GetProfileUser?ProfileId=" + ProfileId.ToString(), "");
                return locationlist;
            }
        }
        [HttpPost]
        public async Task<bool> SubmitProfile( string ProfileId, string Comment)
        {

            SubmitProfileModel obj = new SubmitProfileModel();
            //obj.UserId =new Guid UserId;
            obj.ProfileId = ProfileId;
            obj.Comment = Comment;
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var retult = await objectClient.Post<bool>("API/Profile/SubmitProfile", stringContent, "");
            }
            return true;
        }
        [HttpPost]
        public async Task<bool> AcceptProfile(string ProfileId, string Comment)
        {

            SubmitProfileModel obj = new SubmitProfileModel();
            //obj.UserId =new Guid UserId;
            obj.ProfileId = ProfileId;
            obj.Comment = Comment;
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var retult = await objectClient.Post<bool> ("API/Profile/AcceptProfile", stringContent, "");
            }
            return true;
        }
    

    }
}