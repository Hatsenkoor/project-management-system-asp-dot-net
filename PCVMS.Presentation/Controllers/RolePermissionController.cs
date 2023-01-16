using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using PCVM.Web.Helpers;
using PCVMS.Model.Web;
using PCVMS.Model.BusinessModel;
using AppSettings = PCVM.Web.Helpers.AppSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace PCVM.Web.Controllers
{
    [Authorize]
    public class RolePermissionController : Controller
    {
        public RolePermissionModel model { get; set; }

        public IOptions<AppSettings> AppSettings { get; }
        public RolePermissionController(IOptions<PCVM.Web.Helpers.AppSettings> appSettings)
        {
            AppSettings = appSettings;
        }
        public async Task<IActionResult> Index()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                model = await objectClient.Get<RolePermissionModel>("API/RolePermission/", "");
            }

            return View(model);
           
        }
        [HttpPost]
        public async Task<IActionResult> Index(RolePermissionModel RolePermissionModel)
        {
          
           
            if(ModelState.IsValid)
            {
                PCVMS_Role_Permission obj = new PCVMS_Role_Permission();

                obj.RoleId = RolePermissionModel.RoleId;
                obj.PermissionId = RolePermissionModel.PermissionId;

                var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/RolePermission/AddRolePermission", stringContent, "");
                }
            }
            return RedirectToAction("Index", "RolePermission");

        }
        [HttpPost]
        public async Task<List<PCVMS_Permission>> SaveRolePermission(RolePermissionModel RolePermissionModel)
        {


            if (ModelState.IsValid)
            {
                PCVMS_Role_Permission obj = new PCVMS_Role_Permission();

                obj.RoleId = RolePermissionModel.RoleId;
                obj.PermissionId = RolePermissionModel.PermissionId;

                var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/RolePermission/AddRolePermission", stringContent, "");
                  return await this.GetRolePermission(RolePermissionModel.RoleId);
                }

            }
            else

            {
                return new List<PCVMS_Permission>();
            }
            

        }
        [HttpGet]
        public async Task<List<PCVMS_Permission>> GetRolePermission(Guid RoleId)
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
            var  Permission = await objectClient.Get<List<PCVMS_Permission>>("API/RolePermission/GetRolePermission?RoleId="+ RoleId.ToString(), "");
                return Permission;
            }
        }
    }
}