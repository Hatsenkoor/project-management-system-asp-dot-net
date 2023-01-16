using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCVMS.Model.Web;
using PCVM.Web.Helpers;
using PCVMS.Model.BusinessModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace PCVM.Web.Controllers
{
    [Authorize]
    public class SchemeMappingController : Controller
    {
      
        public IMapper Mapper { get; }
        public SchemeMappingModle SchemeMappingModle { get; set; }

        public SchemeMappingController(IMapper mapper)
        {
           
            Mapper = mapper;
            SchemeMappingModle = new SchemeMappingModle();

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var SchemeMappingModle =await this.get();
            return View(SchemeMappingModle);
        }
        public async Task<SchemeMappingModle> get()
        {
            SchemeMappingModle.AllForms = new List<string>();
            SchemeMappingModle.AllSchemes = new List<string>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8077/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  


                var response = await client.GetAsync("/workflowapi/getschemelist/");
                //if (response.IsSuccessStatusCode)
                //{
                //    var r =await response.Content.ReadAsAsync<MainResponse<string>>();
                //    SchemeMappingModle.AllSchemes = r.data;
                //    for (int i=0;i< SchemeMappingModle.AllSchemes.Count;i++)
                //    {
                //        SchemeMappingModle.AllSchemes[i] = System.Web.HttpUtility.UrlEncode(SchemeMappingModle.AllSchemes[i]);
                //    }
                //    SchemeMappingModle.AllForms.Add("Request form");
                //    try
                //    {
                //        //var commands1 = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ClassHistory>>(result);


                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Internal server Error");
                //}
            }
            return SchemeMappingModle;
        }
        
        public async Task<ActionResult> Edit(SchemeMappingModle obj)
        {
            if (ModelState.IsValid)
            {
                FormSchemeMapping objFormSchemeMapping = new FormSchemeMapping();
                objFormSchemeMapping.SchemeName = obj.SchemeName;
                objFormSchemeMapping.FormName = obj.FormName;
              // await SchemeMappingRepository.Update(objFormSchemeMapping);
            }
            var FillObject = await this.get();
            obj.AllForms = FillObject.AllForms;
            obj.AllSchemes  = FillObject.AllSchemes;

            return View(obj);
        }
    }
}