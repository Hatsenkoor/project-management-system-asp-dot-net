using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


using PCVMS.Model.Web;

namespace PCVM.Web.Api
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
       // public IUserService UserRepository { get; }

        public AuthenticateController( )
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(UserModel model)
        {
            //    UserRepository obj = new UserRepository();
            //    var user = obj.Authenticate(model.Username, model.Password);

            //if (user == null)
            //    return BadRequest(new { message = "Username or password is incorrect" });

            //return Ok(user);
            return View();
        }
    }
}