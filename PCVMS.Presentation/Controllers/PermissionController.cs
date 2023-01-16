using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    public class PermissionController : Controller
    {

        public RolePermissionModel RolePermissionModel { get; set; }
        public IOptions<AppSettings> AppSettings { get; }

        public PermissionController(IOptions<PCVM.Web.Helpers.AppSettings> appSettings)
        {

            AppSettings = appSettings;
        }



        public async Task<IActionResult> Index()
        {
            var PermssionList = await this.GetPermissionMaster();
            RolePermissionModel = new RolePermissionModel();
            RolePermissionModel.PermissionList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            RolePermissionModel.PermissionList.AddRange( PermssionList.Select(item => new SelectListItem()
            {
                Text = string.Format("{0}", item.NameEn),
                Value = item.ID.ToString()
            }).ToList());
            RolePermissionModel.RoleList = new List<SelectListItem>();
            var RoleList = await this.GetAllRoles();
            RolePermissionModel.RoleList.AddRange(RoleList.Select(item => new SelectListItem()
            {
                Text = string.Format("{0}", item.NameEn),
                Value = item.ID.ToString()
            }).ToList());

            return View(RolePermissionModel);
        }
        public async Task<List<PCVMS_Permission_Master>> GetPermissionMaster()
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var list = await objectClient.Get<List<PCVMS_Permission_Master>>("API/Permission/GetPermissionMaster", "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var l in list)
                    {
                        l.NameEn = l.NameAr;
                    }
                }
                return list;
            }
        }
        public async Task<List<PCVMS_Roles>> GetAllRoles()
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var list = await objectClient.Get<List<PCVMS_Roles>>("API/Permission/GetAllRoles", "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var l in list)
                    {
                        l.NameEn = l.NameAr;
                    }
                }
                return list;
            }
        }
    }
}