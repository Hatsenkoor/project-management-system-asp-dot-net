using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class UserModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Token { get; set; }

        public string NameEn { get; set; }

        public bool  Active { get; set; }
        
        public string Email { get; set; }

        public string Mobile { get; set; }
        public string CardID { get; set; }
        public string JobTitle { get; set; }

        public string Department { get; set; }
        public string LandLine { get; set; }

        public string Fax { get; set; }
        public string Remark { get; set; }

        public Guid ProfileId { get; set; }

        public Dictionary<string, string> Resource { get; set; }
    }
}
