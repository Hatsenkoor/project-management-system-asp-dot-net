using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

using PCVM.Web.Helpers;
using PCVMS.Model.BusinessModel;
using PCVMS.Model.Web;

namespace PCVM.Web.Controllers
{
    [Authorize]
    public class SiteVisitApprovalController : Controller
    {
        public PCVMS_Project_Model model { get; set; }

        private readonly IStringLocalizer<ProjectController> _localizer;
        private readonly IMemoryCache cache;

        public IOptions<PCVM.Web.Helpers.AppSettings> AppSettings { get; }

        public SiteVisitApprovalController(IOptions<Helpers.AppSettings> appSettings, IStringLocalizer<ProjectController> localizer, IMemoryCache _Cache)
        {

            AppSettings = appSettings;

            _localizer = localizer;
            cache = _Cache;
        }
        public async Task<IActionResult> Index()
        {

            var browserLang = Request.Headers["Accept-Language"].ToString().Split(";").FirstOrDefault()?.Split(",").FirstOrDefault();
            browserLang = Thread.CurrentThread.CurrentCulture.Name;
            model = new PCVMS_Project_Model();

            #region Project List

            model.ProjectList = new List<SelectListItem>();
            model.ProjectList.Add(new SelectListItem());
            var ObjProjectList = await this.GetAllProject();
            if (browserLang.ToLower() == "en-us")
            {
                model.ProjectList.AddRange(ObjProjectList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.ProjectName),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.ProjectList.AddRange(ObjProjectList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.ProjectName),
                    Value = item.ID.ToString()
                }).ToList());

            }

            #endregion
            model.GovernoratesList = new List<SelectListItem>();
            model.GovernoratesList.Add(new SelectListItem());
            var GovList = await this.GetAllGovernorates();
            if (browserLang.ToLower() == "en-us")
            {
                model.GovernoratesList.AddRange(GovList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.GovernoratesList.AddRange(GovList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }

            model.GeometryList = new List<SelectListItem>();
            model.GeometryList.Add(new SelectListItem());
            var GeometryList = await this.GetAllGeometry();
            if (browserLang.ToLower() == "en-us")
            {
                model.GeometryList.AddRange(GeometryList.Select(item => new SelectListItem()
                {

                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else

            {
                model.GeometryList.AddRange(GeometryList.Select(item => new SelectListItem()
                {

                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.ProfileList = new List<SelectListItem>();
            model.ProfileList.Add(new SelectListItem());
            var ProfileList = await this.GetProfile();

            model.ProfileList.AddRange(ProfileList.Select(item => new SelectListItem()
            {
                Text = string.Format("{0}", item.Name),
                Value = item.ID.ToString()
            }).ToList());

            model.PropertyTypeList = new List<SelectListItem>();
            model.PropertyTypeList.Add(new SelectListItem());
            var PropertyTypeList = await this.GetPropertyType();
            if (browserLang.ToLower() == "en-us")
            {
                model.PropertyTypeList.AddRange(PropertyTypeList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.PropertyTypeList.AddRange(PropertyTypeList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
            model.ProjectTypeList = new List<SelectListItem>();
            model.ProjectTypeList.Add(new SelectListItem());
            var ProjectTypeList = await this.GetAllProjectType();
            if (browserLang.ToLower() == "en-us")
            {
                model.ProjectTypeList.AddRange(ProjectTypeList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameEn),
                    Value = item.ID.ToString()
                }).ToList());
            }
            else
            {
                model.ProjectTypeList.AddRange(ProjectTypeList.Select(item => new SelectListItem()
                {
                    Text = string.Format("{0}", item.NameAr),
                    Value = item.ID.ToString()
                }).ToList());

            }
         
            return View(model);
        }
        public async Task<List<PCVMS_Governorates>> GetAllGovernorates()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_Governorates>>("API/LookUp/GetAllGovernorates", "");
            }


        }
        public async Task<List<PCVMS_CommonLookUp>> GetPropertyType()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_CommonLookUp>>("API/LookUp/GetPropertyType", "");
            }


        }
        public async Task<List<PCVMS_CommonLookUp>> GetAllProjectType()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_CommonLookUp>>("API/LookUp/GetAllProjectType", "");
            }


        }
        public async Task<List<PCVMS_CommonLookUp>> GetAllGeometry()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_CommonLookUp>>("API/LookUp/GetAllGeometry", "");
            }


        }
        public async Task<List<PCVMS_Profile>> GetProfile()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_Profile>>("API/Profile/GetProfilebyType?TypeId=BF47C85F-468B-43E7-14E3-08D7E057EEEA", "");
            }


        }
       [HttpPost]
        public async Task<List<PCVMS_ProjectLocation>> AddProjectLocation(PCVMS_ProjectLocation Object)

        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(Object);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/Project/AddProjectLocation", stringContent, "");
            }
            using (var objectClient = new ApiClient(AppSettings))
            {
                var locationlist = await objectClient.Get<List<PCVMS_ProjectLocation>>("API/Project/GetProjectLocation?ProjectId=" + Object.ProjectID.ToString(), "");
                return locationlist;
            }

        }

        [HttpPost]
        public async Task<List<ProjectPropertyModel>> AddProjectProperty(PCVMS_Property obj)

        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/Project/AddProjectProperty", stringContent, "");
            }
            using (var objectClient = new ApiClient(AppSettings))
            {
                var locationlist = await objectClient.Get<List<ProjectPropertyModel>>("API/Project/GetProjectProperty?ProjectId=" + obj.ProjectId.ToString(), "");
                return locationlist;
            }

        }

        [HttpPost]
        public async Task<List<ProjectProfileViewModel>> AddProjecProfile(PCVMS_ProjectProfile obj)

        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/Project/AddProjecProfile", stringContent, "");
            }
            using (var objectClient = new ApiClient(AppSettings))
            {
                var locationlist = await objectClient.Get<List<ProjectProfileViewModel>>("API/Project/GetProjectProfile?ProjectId=" + obj.ProjectId.ToString(), "");
                return locationlist;
            }

        }
        [HttpPost]
        public async Task<List<PCVMS_GeometryDetails>> AddProjectGeometry(PCVMS_GeometryDetails Object)

        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(Object);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/Project/AddProjectGeometry", stringContent, "");
            }
            using (var objectClient = new ApiClient(AppSettings))
            {
                var locationlist = await objectClient.Get<List<PCVMS_GeometryDetails>>("API/Project/GetProjectGeometry?ProjectId=" + Object.ProjectID.ToString(), "");
                return locationlist;
            }

        }
        [HttpPost]
        public async Task<PCVMS_Project_Model> CreateProject(PCVMS_Project_Model PCVMS_Project_Model)

        {
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(PCVMS_Project_Model);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<PCVMS_Project_Model>("API/Project/CreateProject", stringContent, "");
             return result;
            }

           
        }

        [HttpPost]
        public async Task<List<PCVMS_Scheme>> CreateScheme(string NameEn)

        {
         
           
            var stringContent = new StringContent("");
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/Project/CreateScheme?NameEn="+ NameEn, stringContent, "");
                return await this.GetAllScheme();
            }


           
        }
        [HttpPost]
        public async Task<List<ProjectSchemeGrid>> AssignScheme(PCVMS_Project_Model PCVMS_Project_Model)
        {

            PCVMS_Project_Model.Deleted = false;
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(PCVMS_Project_Model);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<bool>("API/Project/AssignScheme", stringContent, "");
             return await     this.GetProjectSchema(PCVMS_Project_Model.ProjectId);
            }

            
        }
        [HttpGet]
        public async Task<List<ProjectSchemeGrid>> GetProjectSchema(Guid ProjectId)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<ProjectSchemeGrid>>("API/Project/GetProjectSchema?ProjectId="+ ProjectId.ToString(), "");
                return result;
            }
        }

        [HttpPost]
        public async Task<List<PCVMS_Permission>> AssignSchemePermission(PCVMS_Project_Model PCVMS_Project_Model)
        {

            List<PCVMS_Permission> obj = new List<PCVMS_Permission>();

            if (PCVMS_Project_Model.PermissionSchemeId != new Guid("00000000-0000-0000-0000-000000000000") && PCVMS_Project_Model.PermissionId != new Guid("00000000-0000-0000-0000-000000000000"))
            {

                //  await SchemeRepository.AddSchemePermission(PCVMS_Project_Model.PermissionId, PCVMS_Project_Model.PermissionSchemeId);


                var values = Newtonsoft.Json.JsonConvert.SerializeObject(PCVMS_Project_Model);
                var stringContent = new StringContent(values.ToString());
                using (var objectClient = new ApiClient(AppSettings))
                {
                    stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var result = await objectClient.Post<bool>("API/Project/AssignSchemePermission", stringContent, "");
                 return await   this.GetSchemaPermission(PCVMS_Project_Model.PermissionSchemeId);
                }
            }
            {
                return obj;
            }
           // return RedirectToAction("Index", "Project");
        }
        [HttpGet]
        public async Task<List<PCVMS_Permission>> GetSchemaPermission(Guid SchemaId)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<PCVMS_Permission>>("API/Project/GetSchemaPermission?SchemaId="+ SchemaId.ToString(), "");
                return result;
            }
        }

        [HttpPost]
        public async Task<bool> SubmitProject(string ProjectId, string Comment)
        {

            SubmitProfileModel obj = new SubmitProfileModel();
            //obj.UserId =new Guid UserId;
            obj.ProfileId = ProjectId;
            obj.Comment = Comment;
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var retult = await objectClient.Post<bool>("API/Project/SubmitProject", stringContent, "");
            }
            return true;
        }
        [HttpPost]
        public async Task<bool> AcceptProject(string ProjectId, string Comment)
        {

            SubmitProfileModel obj = new SubmitProfileModel();
            //obj.UserId =new Guid UserId;
            obj.ProfileId = ProjectId;
            obj.Comment = Comment;
            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var retult = await objectClient.Post<bool>("API/Project/AcceptProject", stringContent, "");
            }
            return true;
        }


        public async Task<List<PCVMS_Scheme>> GetAllScheme()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result= await objectClient.Get<List<PCVMS_Scheme>>("API/Project/GetAllScheme/", "");
                return result;
            }
        }
        public async Task<List<PCVMS_Project>> GetAllProject()
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<PCVMS_Project>>("API/Project/GetAllProject/", "");
                return result;
            }
        }

       


    }
}