using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PCVM.Web.Helpers;
using PCVMS.Model.BusinessModel;

namespace PCVM.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookUpController : ControllerBase
    {
        public IOptions<Helpers.AppSettings> AppSettings { get; }

        public LookUpController(IOptions<PCVM.Web.Helpers.AppSettings> appSettings)
        {

            AppSettings = appSettings;
        }
        [HttpGet]
        [Route("GetAllGovernorates")]
        public async Task<List<PCVMS_Governorates>> GetAllGovernorates()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_Governorates>>("API/LookUp/GetAllGovernorates", "");
            }
           
            
        }
        [HttpGet]
        [Route("GetPropertyType")]
        public async Task<List<PCVMS_Governorates>> GetPropertyType()
        {

            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_Governorates>>("API/LookUp/GetPropertyType", "");
            }


        }
        [HttpGet]
        [Route("GetAllWilayat")]
        public  async Task<List<PCVMS_Wilayat>> GetAllWilayat(Guid Governorate)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
               return await objectClient.Get<List<PCVMS_Wilayat>>("API/LookUp/GetAllWilayat?Governorate="+ Governorate.ToString(), "");
            }

        }
        [HttpGet]
        [Route("GetAllVillage")]
        public async Task<List<PCVMS_Wilayat>> GetAllVillage(Guid Wilayat)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                return await objectClient.Get<List<PCVMS_Wilayat>>("API/LookUp/GetAllVillage?Wilayat=" + Wilayat.ToString(), "");
            }


        }
             [HttpGet]
        [Route("GetSubLandUse")]
        public async Task<List<PCVMS_CommonLookUp>> GetSubLandUse(Guid LandUse)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var list= await objectClient.Get<List<PCVMS_CommonLookUp>>("API/LookUp/GetSubLandUse?LandUse=" + LandUse.ToString(), "");
                 if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach( var c in list)
                    {
                        c.NameEn = c.NameAr;
                    }
                }
                return list;

            }

        }
        [HttpGet]
        [Route("GetActualLandUse")]
        public async Task<List<PCVMS_CommonLookUp>> GetActualLandUse(Guid SubLandUse)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var list = await objectClient.Get<List<PCVMS_CommonLookUp>>("API/LookUp/GetActualLandUse?SubLandUse=" + SubLandUse.ToString(), "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var c in list)
                    {
                        c.NameEn = c.NameAr;
                    }
                }
                return list;

            }

        }

        [HttpGet]
        [Route("GetBuilindMaterialList")]
        public async Task<List<PCVMS_CommonLookUp>> GetBuilindMaterialList(string Screen)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var list = await objectClient.Get<List<PCVMS_CommonLookUp>>("API/LookUp/GetBuilindMaterialList?Screen="+ Screen, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var c in list)
                    {
                        c.NameEn = c.NameAr;
                    }
                }
                return list;

            }

        }
        [HttpGet]
        [Route("GetLookUpList")]
        public async Task<List<PCVMS_CommonLookUp>> GetLookUpList(Guid Item)
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            using (var objectClient = new ApiClient(AppSettings))
            {
                var list = await objectClient.Get<List<PCVMS_CommonLookUp>>("API/LookUp/GetLookUpList?Item=" + Item, "");
                if (!(browserLang.ToLower() == "en-us"))
                {
                    foreach (var c in list)
                    {
                        c.NameEn = c.NameAr;
                    }
                }
                return list;

            }

        }
    }
}