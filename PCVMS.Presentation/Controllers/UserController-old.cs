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
using PCVMS.Model.BusinessModel;
using AppSettings = PCVM.Web.Helpers.AppSettings;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;
using System.Runtime.CompilerServices;
using PCVMS.Presentation.Helpers;

namespace PCVM.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IOptions<AppSettings> AppSettings { get; }
        public IMemoryCache Cache { get; }
        public ICacheHelper ObjCasheHelper { get; }
        public RoleModel Roles_Modle { get; set; }
        public PCVMS_User_Model Model { get; set; }

        public UserController(IOptions<PCVM.Web.Helpers.AppSettings> appSettings, IMemoryCache _Cache, ICacheHelper objCasheHelper)
        {
            AppSettings = appSettings;
            Cache = _Cache;
            ObjCasheHelper = objCasheHelper;
        }

       

        public async Task<IActionResult> Index()
        {
            Model = new PCVMS_User_Model();
            using (var objectClient = new ApiClient(AppSettings))
            {
                Model.Roles_Modle = await objectClient.Get<Roles_Modle>("API/Role/", "");
            }
            using (var objectClient = new ApiClient(AppSettings))
            {
                Model.AssignRoleModel = await objectClient.Get<AssignRoleModel>("API/AssignRole/", "");
            }

            using (var objectClient = new ApiClient(AppSettings))
            {
                Model.RolePermissionModel = await objectClient.Get<RolePermissionModel>("API/RolePermission/", "");
            }
            using (var objectClient = new ApiClient(AppSettings))
            {
                Model.PCVMS_Project_Model = await objectClient.Get<PCVMS_Project_Model>("API/Project/", "");
            }
            using (var objectClient = new ApiClient(AppSettings))
            {
                Model.PCVMS_User_Group_Name_Model = await objectClient.Get<PCVMS_User_Group_Name_Model>("API/UserGroup/", "");
            }
            return View(Model);
        }
        [HttpPost]
        public async Task<List<PCVMS_User_Model>> CreateUser(PCVMS_User_Model PCVMS_User_Model)
        {
            if(ModelState.IsValid)
            {

                PCVMS_User obj = new PCVMS_User();
                
                obj.NameEn = PCVMS_User_Model.NameEn;
                obj.Password = PCVMS_User_Model.Password;
                obj.Active = true;
                obj.Email = PCVMS_User_Model.Email;
                obj.Mobile = PCVMS_User_Model.Mobile;

                obj.CardID = PCVMS_User_Model.CardID;
                obj.JobTitle = PCVMS_User_Model.JobTitle;


                obj.Department = PCVMS_User_Model.Department;
                obj.LandLine = PCVMS_User_Model.LandLine;

                obj.Fax = PCVMS_User_Model.Fax;
                obj.Remark = PCVMS_User_Model.Remark;
                obj.ProfileId = PCVMS_User_Model.ProfileId;
                var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/User/AddUser", stringContent, "");
                }

            
            }
            return await this.GetAllUsersForGrid();

        }
        [HttpGet]
        public async Task<List<PCVMS_User_Model>> GetAllUsersForGrid()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
              var list   = await objectClient.Get<List<PCVMS_User_Model>>("API/User/GetAllUsersForGrid", "");
                return list;
            }
        }

        [HttpGet]
        public async Task<PCVMS_User> GetUserById(Guid UserId)
        {
            var PCVMS_User = new PCVMS_User();
            using (var objectClient = new ApiClient(AppSettings))
            {
                PCVMS_User = await objectClient.Get<PCVMS_User>("API/User/GetUserById?UserId=", UserId.ToString());
            }
            return PCVMS_User;

           
        }
        [HttpGet]
        public async Task<List<PCVMS_Permission>> GetUserPermission()
        {
            var UserId = CurrentUserSettings.UserName(HttpContext);
            var PCVMS_UserPermission = new List<PCVMS_Permission>();
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            if (User == null)
                return PCVMS_UserPermission;
           
            using (var objectClient = new ApiClient(AppSettings))
            {
                PCVMS_UserPermission = await objectClient.Get<List<PCVMS_Permission>>("API/User/GetUserPermission?UserId=",UserId.ToString());
            }
            var Resorce =await ObjCasheHelper.GetAllResource();
            foreach (var p in PCVMS_UserPermission)
            {


                if (Resorce.ContainsKey(p.NameEn))
                {
                    p.NameEn = Resorce[p.NameEn];
                }
                


                
                p.Url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + p.Url;
            }
            return PCVMS_UserPermission;


        }
        [HttpGet]
        public async Task<List<PCVMS_User>> GetAllUsersByProfile(Guid UserId)
        {

            var PCVMS_User = new List<PCVMS_User>();
            using (var objectClient = new ApiClient(AppSettings))
            {
                PCVMS_User = await objectClient.Get<List<PCVMS_User>>("API/User/GetAllUsersByProfile?ProfileId=", UserId.ToString());
            }
            return PCVMS_User;


        }
        [HttpGet]
        public async Task<List<UserRole>> GetUserRole(Guid UserId)
        {

            var PCVMS_UserRole = new List<UserRole>();
            using (var objectClient = new ApiClient(AppSettings))
            {
                PCVMS_UserRole = await objectClient.Get<List<UserRole>>("API/User/GetUserRole?UserId=", UserId.ToString());
            }
            return PCVMS_UserRole;


        }
        [HttpGet]
        public async Task<List<UserRole>> GetUserRoleGroup(Guid UserId)
        {

            var PCVMS_UserRoleGroup = new List<UserRole>();
            using (var objectClient = new ApiClient(AppSettings))
            {
                PCVMS_UserRoleGroup = await objectClient.Get<List<UserRole>>("API/User/GetUserRoleGroup?UserId=", UserId.ToString());
            }
            return PCVMS_UserRoleGroup;


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