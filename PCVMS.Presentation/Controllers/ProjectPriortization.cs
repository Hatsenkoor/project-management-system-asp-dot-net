using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Presentation.Controllers
{
    public class ProjectPriortization : Controller
    {
        public IActionResult Priority()
        {
            return View();
        }

        public IActionResult Ranking()
        {
            return View();
        }
        public IActionResult Weight()
        {
            return View();
        }
        public IActionResult ExcelUpload()
        {
            return View();
        }
    }
}

