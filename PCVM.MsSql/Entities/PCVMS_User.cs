using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_User")]
    public  class PCVMS_User
    {
        
        public Guid UserId { get; set; }
        public string NameEn { get; set; }
        public string nameAr { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public string CardID { get; set; }

        public string JobTitle { get; set; }

        public string Department { get; set; }

        public string LandLine { get; set; }

        public string Fax { get; set; }

        public string Remark { get; set; }

        public Guid? ProfileId { get; set; }
       //public List<PCVMS_User_Role> UserRoles { get; set; }

        // public List<PCVMS_User_RoleGroups> PCVMS_User_RoleGroups { get; set; }







    }
}
