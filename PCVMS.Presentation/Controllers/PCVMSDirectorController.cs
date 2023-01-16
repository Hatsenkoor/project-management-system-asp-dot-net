using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCVMS.Presentation.Controllers
{
    public class PCVMSDirectorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Valuation()
        {
            return View();
        }

        public IActionResult Decision()
        {
            return View();
        }
    }
}