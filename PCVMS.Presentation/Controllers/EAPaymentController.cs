﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCVMS.Presentation.Controllers
{
    public class EAPaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult view()
        {
            return View();
        }
    }
}