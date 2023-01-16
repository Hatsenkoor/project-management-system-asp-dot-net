using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace PCVM.Web.Helpers
{
    public class CurrentUserSettings
    {
        public static Guid GetCurrentUser(HttpContext context)
        {
            Guid res = Guid.Empty;
            if (context.Request.Query["CurrentEmployee"].FirstOrDefault() != null)
            {
                Guid.TryParse(context.Request.Query["CurrentEmployee"].FirstOrDefault(), out res);
                SetUserInCookies(context, res);
            }
            else if (context.Request.Cookies["CurrentEmployee"] != null)
            {
                Guid.TryParse(context.Request.Cookies["CurrentEmployee"], out res);
            }
            return res;
        }
        public static string UserName(HttpContext context)
        {
            var u = context.User.Identity as ClaimsIdentity;


            var userPrincipal = context.User;

            // Look for the LastChanged claim.
            var lastChanged = (from c in userPrincipal.Claims
                              // where c.Type == "UserId"
                               select c.Value).FirstOrDefault();
            return lastChanged;
        }
        public static void SetUserInCookies(HttpContext context, Guid userId)
        {
            context.Response.Cookies.Append("CurrentEmployee", userId.ToString());
        }
    }
}