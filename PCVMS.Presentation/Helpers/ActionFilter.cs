using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCVM.Web.Helpers
{
    public class ActionFilter : IActionFilter
    {
        public IMemoryCache cache { get; set; }
        public ActionFilter(IMemoryCache _cache)
        {
            cache = _cache;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string ministry = "mrmwroman";
            string company = "stormingsoft";
            List<string> list = new List<string>();
            list.Add("UnauthorizedRequest".ToLower());
            list.Add("Login".ToLower());
            list.Add("Dashboard".ToLower());
            list.Add("User".ToLower());
            
            string Controlername = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName.ToLower();
            if (!list.Any(f=>f== Controlername))
            {
                string contoller = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
                var ht = cache.Get<Hashtable>("Permission");
         //       if (ht != null)
         //       {
         //           var UserId = CurrentUserSettings.UserName(context.HttpContext);
         //           var User = (PCVMS_User)ht[UserId];
         //           if (User == null || !User.PermissionList.Any(p => p.ControllerName == contoller))
         //           {

         //               //context.Result = new BadRequestObjectResult(context.ModelState);
         //               //return;
         //               context.Result =
         //new RedirectToRouteResult(
         //    new RouteValueDictionary{{ "controller", "UnauthorizedRequest" },
         //                                 { "action", "Index" }

         //                                  });
         //           }
         //       }
            }
            var Language = cache.Get<String>("Language");
            if(!String.IsNullOrEmpty(Language))
            {
                var culture = new System.Globalization.CultureInfo(Language);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
               

                    cache.Remove("Resource");
                  

                
            }
            string SECRET_KEY = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}{1}", ministry, company)));
            //   var uname = CurrentUserSettings.UserName(context.HttpContext );
            //string data = "app=" + appID + ",actn=" + actnID + ",username=" + uname;
            // our code before action executes
            //if (!context.ModelState.IsValid)
            //{
            //    context.Result = new BadRequestObjectResult(context.ModelState);
            //    return;
            //}
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }


    }
}


