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
using PCVMS.Model.Web;
using PCVMS.Model.BusinessModel;
using AppSettings = PCVM.Web.Helpers.AppSettings;

namespace PCVM.Web.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        public Roles_Modle model { get; set; }
        public IOptions<AppSettings> AppSettings { get; }

        public RoleController(IOptions<PCVM.Web.Helpers.AppSettings> appSettings)
        {

            AppSettings = appSettings;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                model = await objectClient.Get<Roles_Modle>("API/Role/", "");
            }

            return View(model);
        }
        [HttpPost]
        public async  Task<IActionResult> Index(Roles_Modle objRoles)
        {
            if (ModelState.IsValid)
            {
                PCVMS_Roles NewRole = new PCVMS_Roles();
                NewRole.Deleted = false; ;
                NewRole.NameAr = objRoles.NameAr;
                NewRole.NameEn = objRoles.NameEn;
                NewRole.Permission_Master_ID = new Guid( objRoles.PCVMS_Permission_MasterID);

                var values = Newtonsoft.Json.JsonConvert.SerializeObject(NewRole);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/Role/AddRoles", stringContent, "");
                }
            }
          
            return RedirectToAction("Index", "Role");
        }
        [HttpPost]
        public async Task<List<PCVMS_Roles>> SaveRole(Roles_Modle objRoles)
        {
           Roles_Modle RoleList = new Roles_Modle();
            if (ModelState.IsValid)
            {
                PCVMS_Roles NewRole = new PCVMS_Roles();
                NewRole.Deleted = false; ;
                NewRole.NameAr = objRoles.NameAr;
                NewRole.NameEn = objRoles.NameEn;
                NewRole.Permission_Master_ID = new Guid(objRoles.PCVMS_Permission_MasterID);

                var values = Newtonsoft.Json.JsonConvert.SerializeObject(NewRole);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/Role/AddRoles", stringContent, "");
                }
                using (var objectClient = new ApiClient(AppSettings))
                {
                var role   = await objectClient.Get<Roles_Modle>("API/Role/", "");
                    RoleList.RoleList = role.RoleList;
                }

            }
            return RoleList.RoleList;

        }
        [HttpGet]
        public async Task<List<PCVMS_Roles>> GetAllRoles()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var role = await objectClient.Get<Roles_Modle>("API/Role/", "");
                return role.RoleList;
            }

        }
    }
}