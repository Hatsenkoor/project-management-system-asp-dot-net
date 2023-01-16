using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace PCVMS.Presentation.Controllers
{
    public class GisController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult buffer(string extent)
        {
            return View();
        }

    }
}