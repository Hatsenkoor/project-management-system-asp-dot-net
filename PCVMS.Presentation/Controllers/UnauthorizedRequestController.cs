using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCVM.Web.Controllers
{
    public class UnauthorizedRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}