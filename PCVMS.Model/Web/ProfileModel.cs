using Microsoft.AspNetCore.Mvc.Rendering;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class ProfileModel
    {
        public Guid ID { get; set; }
        public Guid ProfileId { get; set; }

        public string Name { get; set; }

        public string CardId { get; set; }
        public string RegistrationDate { get; set; }
        [MaxLength(500)]
        public string RegistrationHQ { get; set; }

        public string PoBox { get; set; }

        [Required]

        public string PostalCode { get; set; }

        public string LandLine { get; set; }

        public string Mobile { get; set; }
        public string Fax { get; set; }

        public string Remark { get; set; }

        public bool Deleted { get; set; }


        public Guid GroupId { get; set; }
        public string Email { get; set; }

        public List<SelectListItem> PCVMS_ProfileType { get; set; }
        public Guid ProfileTypeId { get; set; }


    }
    public class SubmitProfileModel
    {
        public Guid UserId { get; set; }
        public string ProfileId { get; set; }
        public string Comment { get; set; }
    }
    public class ProfileUser
    {
        public Guid UserId { get; set; }

        public string CardID { get; set; }

        public string NameEn { get; set; }
        public string nameAr { get; set; }

        public Guid ProfileId { get; set; }
    }
    public class SubmitProfileClass
    {
        public Guid UserId { get; set; }
        public string ProfileId { get; set; }
        public string Comment { get; set; }

    }

}
