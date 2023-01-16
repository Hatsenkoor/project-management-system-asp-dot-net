using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using PCVM.Web.Helpers;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCVMS.Presentation.Helpers
{
    public class CacheHelper    : ICacheHelper
    {
        public List<PCVMS_Resource> Resource { get; set; }
        public IMemoryCache Cache { get; }
        IOptions<PCVM.Web.Helpers.AppSettings> appSettings;
        public IOptions<PCVM.Web.Helpers.AppSettings> AppSettings { get; }

        public  CacheHelper(IOptions<PCVM.Web.Helpers.AppSettings> appSettings, IMemoryCache _Cache)
        {
            AppSettings = appSettings;
            Cache = _Cache;
           
        }
        public async Task<Dictionary<string, string>> GetAllResource()
        {
            var browserLang = Thread.CurrentThread.CurrentCulture.Name;
            var Resource = new Dictionary<string, string>();
            using (var objectClient = new ApiClient(AppSettings))
            {
                var Resourcelist = Cache.Get<List<PCVMS_Resource>>("Resource");
                if (Resourcelist == null)
                {
                    var list = await objectClient.Get<List<PCVMS_Resource>>("API/Resource/GetAllResource", "");
                    Cache.Set<List<PCVMS_Resource>>("Resource", list);
                    if ((browserLang.ToLower() == "en-us"))
                    {
                        foreach (var a in list)
                        {
                            a.Value = a.Name;
                        }
                    }
                    try
                    {
                        foreach (var a in list)
                        {
                            Resource.Add(a.Key.ToLower(), a.Value);

                        }
                    }
                    catch(Exception ex)
                    {

                    }
                   
                    return Resource;
                }
                else
                {
                    if ((browserLang.ToLower() == "en-us"))
                    {
                        foreach (var a in Resourcelist)
                        {
                            a.Value = a.Name;
                        }
                    }
                    foreach (var a in Resourcelist)
                    {
                        Resource.Add(a.Key.ToLower(), a.Value);

                    }
                    return Resource;
                }
            }

        }


    }
    public interface ICacheHelper
    {
        Task<Dictionary<string, string>> GetAllResource();
    }
}
