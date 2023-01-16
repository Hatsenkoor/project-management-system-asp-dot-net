using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCVMS.Presentation.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Manual()
        {
            return View();
        }

        public IActionResult guide()
        {
            return View();
        }

        public IActionResult troubleshoot()
        {
            return View();
        }

        public IActionResult video()
        {
            return View();
        }
    }
}