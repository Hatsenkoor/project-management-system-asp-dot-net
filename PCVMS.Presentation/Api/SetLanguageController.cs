using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace PCVM.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetLanguageController : ControllerBase
    {

        public SetLanguageController(IMemoryCache _cache)
        {
            Cache = _cache;
            
        }

        public IMemoryCache Cache { get; }
        [HttpGet]
        [Route("SetLanguage")]
        public void SetLanguage(string Language)
        {
            if(Language.ToLower()== "ar-om")
            {
                Cache.Set<string>("Language", "ar-OM");
            }
            else

            {
                Cache.Set<string>("Language", "en-US");
            }

        }
    }
}