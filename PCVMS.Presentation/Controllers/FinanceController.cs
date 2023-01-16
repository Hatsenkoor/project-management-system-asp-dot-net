using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCVMS.Presentation.Controllers
{
    public class FinanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Decision()
        {
            return View();
        }

        public IActionResult DecisionApproval()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ValuationApproval()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ValuationApprovalReview()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DecisionView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PaymentView()
        {
            return View();
        }

        [HttpGet]
        public  IActionResult Reissuecheque()
        {
            return View();
        }

    }
}