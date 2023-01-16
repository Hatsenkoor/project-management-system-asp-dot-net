using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

using System.Resources;
using System.Collections;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using Microsoft.AspNetCore.Authorization;

using System.Threading;
using PCVM.Web.Helpers;
using Microsoft.Extensions.Options;
using PCVMS.Model.BusinessModel;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;

using System.Net.Http.Headers;

namespace PCVM.Web.Controllers
{
    [Authorize]
    public class ResourceController : Controller
    {

        public List<PCVMS_Resource> list = new List<PCVMS_Resource>();

        public PCVMS_Resource Model { get; set; }


        public IOptions<PCVM.Web.Helpers.AppSettings> AppSettings { get; }
        public IMemoryCache Cache { get; }
        public ResourceController(IMemoryCache _Cache, IOptions<PCVM.Web.Helpers.AppSettings> appSettings)
        {

            Cache = _Cache;
            AppSettings = appSettings;
        }

        public IWebHostEnvironment Env { get; }

        public IActionResult Index()
        {
            
            return View();

        }
        public async Task<List<PCVMS_Resource>> SaveResource(PCVMS_Resource obj)
        {
            Model = new PCVMS_Resource();


            var values = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(values.ToString());

            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var result = await objectClient.Post<string>("API/Resource/UpdateResource", stringContent, "");
            }

            Cache.Remove("Resource");
          return await this.GetAllResource();

          
        }

        public async Task<List<PCVMS_Resource>> getResourceList()
        {
            Model = new PCVMS_Resource();
            

            return  await this.GetAllResource();

            //foreach (var a in listofResource)
            //{
            //    var l = new PCVMS_Resource();

            //    l.Name = a.Name;
            //    l.Value = a.Value;
            //    list.Add(l);
            //}


            return (list);

        }
        public async Task<List<PCVMS_Resource>> GetAllResource()
        {
            try
            {
                var browserLang = Thread.CurrentThread.CurrentCulture.Name;
                Model.Resource = new Dictionary<string, string>();
                using (var objectClient = new ApiClient(AppSettings))
                {

                    var list = await objectClient.Get<List<PCVMS_Resource>>("API/Resource/GetAllResource", "");

                    foreach (var a in list)
                    {
                        Model.Resource.Add(a.Key.ToLower(), a.Value);

                    }
                    return list;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}