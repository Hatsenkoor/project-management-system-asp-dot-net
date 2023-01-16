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

namespace PCVM.Web.Controllers
{
    [Authorize]
    public class AssignRoleController : Controller
    {
        public AssignRoleModel model { get; set; }
      
        public IOptions<AppSettings> AppSettings { get; }

        public AssignRoleController(IOptions<PCVM.Web.Helpers.AppSettings> appSettings)
        {
            
            AppSettings = appSettings;
        }
        public async Task<IActionResult> Index()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                model = await objectClient.Get<AssignRoleModel>("API/AssignRole/", "");
            }
            #region direct call
            //model = new AssignRoleModel();

            //model.UserList = new List<SelectListItem>();
            //var userlist = await UserRepositor.GetAllUsers();
            //model.UserList.Add(new SelectListItem());
            //model.UserList.AddRange(userlist.Select(item => new SelectListItem()
            //{
            //    Text = string.Format("{0}", item.NameEn),
            //    Value = item.UserId.ToString()
            //}).ToList());
            //model.RoleList = new List<SelectListItem>();
            //var rolelist = await RoleRepository.GetAllRoles();
            //model.RoleList.Add(new SelectListItem());
            //model.RoleList.AddRange(rolelist.Select(item => new SelectListItem()
            //{
            //    Text = string.Format("{0}", item.NameEn),
            //    Value = item.ID.ToString()
            //}).ToList());
            //var RoleGroupList = await RoleRepository.GetAllRoleGroups();
            //model.RoleGroupList = new List<SelectListItem>();
            //model.RoleGroupList.Add(new SelectListItem());
            //model.RoleGroupList.AddRange(RoleGroupList.Select(item => new SelectListItem()
            //{
            //    Text = string.Format("{0}", item.RoleGroupNameEn),
            //    Value = item.ID.ToString()
            //}).ToList());


            //var UserGroupList = await UserRepositor.GetAllUserGroupName();
            //model.UserGroupList = new List<SelectListItem>();
            //model.UserGroupList.Add(new SelectListItem());
            //model.UserGroupList.AddRange(UserGroupList.Select(item => new SelectListItem()
            //{
            //    Text = string.Format("{0}", item.NameEn),
            //    Value = item.ID.ToString()
            //}).ToList());
            #endregion
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AssignRoleModel objModel)
        {

            var values = Newtonsoft.Json.JsonConvert.SerializeObject(objModel);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/AssignRole/AssignRole", stringContent, "");
            }
           
            return RedirectToAction("Index", "Project");
        }
        [HttpPost]
        public async Task<IActionResult> AssingUserGroup(AssignRoleModel objModel)
        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(objModel);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/AssignRole/AssingUserGroup", stringContent, "");
            }

            return RedirectToAction("Index", "AssignRole");
        }
    }
}