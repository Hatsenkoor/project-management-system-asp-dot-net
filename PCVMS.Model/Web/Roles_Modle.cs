using Microsoft.AspNetCore.Mvc.Rendering;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class Roles_Modle
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }

        public string NameAr { get; set; }
        public bool Deleted { get; set; }

        public List<PCVMS_Roles> RoleList { get; set; }
        public List <SelectListItem> PCVMS_Permission_MasterList { get; set; }

        public string   PCVMS_Permission_MasterID{ get; set; }
    }
    public class PCVMS_Roles_Modle
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }

        public string NameAr { get; set; }
        public bool Deleted { get; set; }

        public List<PCVMS_Roles> RoleList { get; set; }
        public List<SelectListItem> PCVMS_Permission_MasterList { get; set; }

        public string PCVMS_Permission_MasterID { get; set; }
    }
}
