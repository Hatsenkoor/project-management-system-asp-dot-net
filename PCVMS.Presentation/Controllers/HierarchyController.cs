using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace PCVMS.Presentation.Controllers
{
    public class HierarchyController : Controller
    {

        public HierarchyController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public string GetJsonData(string path)
        {
            string json = "";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            json = (new WebClient()).DownloadString(path);

            return json;
        }
    }
}
