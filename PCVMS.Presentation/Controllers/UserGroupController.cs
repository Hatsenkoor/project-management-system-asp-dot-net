using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using PCVM.Web.Helpers;
using PCVMS.Model.BusinessModel;
using PCVMS.Model.Web;

namespace PCVM.Web.Controllers
{
    [Authorize]
    public class UserGroupController : Controller
    {
        public PCVMS_User_Group_Name_Model model { get; set; }
        public IOptions<Helpers.AppSettings> AppSettings { get; }
        public UserGroupController(IOptions<PCVM.Web.Helpers.AppSettings> appSettings)
        {
            AppSettings = appSettings;
        }

       

        public async Task<IActionResult> Index()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                model = await objectClient.Get<PCVMS_User_Group_Name_Model>("API/UserGroup/", "");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(PCVMS_User_Group_Name_Model PCVMS_User_Group_Name_Model)
        {
            if(ModelState.IsValid)
            {

                var values = Newtonsoft.Json.JsonConvert.SerializeObject(PCVMS_User_Group_Name_Model);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/UserGroup/AddUserGrupName", stringContent, "");
                }
              //  await UserRepository.AddUserGrupName(PCVMS_User_Group_Name_Model.NameEn);
            }
            return RedirectToAction("Index", "UserGroup");
        }

        [HttpPost]
        public async Task<List<PCVMS_User_Group_Name>> CreaseUserGroup(PCVMS_User_Group_Name_Model PCVMS_User_Group_Name_Model)
        {
            if (ModelState.IsValid)
            {

                var values = Newtonsoft.Json.JsonConvert.SerializeObject(PCVMS_User_Group_Name_Model);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/UserGroup/AddUserGrupName", stringContent, "");
                }
               
            }
         return await  this.GetAllUserGroupName();
        }

        [HttpPost]
        public async Task<IActionResult> AssignGroup(PCVMS_User_Group_Name_Model PCVMS_User_Group_Name_Model)
        {
            if (ModelState.IsValid)
            {
               
                var values = Newtonsoft.Json.JsonConvert.SerializeObject(PCVMS_User_Group_Name_Model);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/UserGroup/AssignUserGroup", stringContent, "");
                }
               // await UserRepository.AssignUserGroup(PCVMS_User_Group_Name_Model.GroupId, PCVMS_User_Group_Name_Model.UserId);
            }

            return RedirectToAction("Index", "UserGroup");
        }
        [HttpPost]
        public async Task<List<PCVMS_User_Group_Name>> AssignUserGroup(PCVMS_User_Group_Name_Model PCVMS_User_Group_Name_Model)
        {
           

                var values = Newtonsoft.Json.JsonConvert.SerializeObject(PCVMS_User_Group_Name_Model);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/UserGroup/AssignUserGroup", stringContent, "");
                }
                // await UserRepository.AssignUserGroup(PCVMS_User_Group_Name_Model.GroupId, PCVMS_User_Group_Name_Model.UserId);
            
            return await this.GetUserGroupName(PCVMS_User_Group_Name_Model.UserId);

           
        }

        [HttpGet]
        public async Task<List<PCVMS_User_Group_Name>> GetAllUserGroupName()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return  await objectClient.Get<List<PCVMS_User_Group_Name>>("API/UserGroup/GetAllUserGroupName", "");
            }



        }
        [HttpGet]
        public async Task<List<PCVMS_User_Group_Name>> GetUserGroupName(Guid UserId)
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_User_Group_Name>>("API/UserGroup/GetUserGroupName?UserId="+ UserId.ToString(), "");
            }



        }
    }
}