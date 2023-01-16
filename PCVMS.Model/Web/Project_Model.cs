using Microsoft.AspNetCore.Mvc.Rendering;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class PCVMS_Project_Model
    {
        public Guid ID { get; set; }
        public string ProjectName { get; set; }
        public string RoyalDecree { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public DateTime RoyalDecreeDate { get; set; }
        public string ProjectStartDate { get; set; }
        public string Remark { get; set; }
        public bool Deleted { get; set; }
        public Guid ProjectId { get; set; }
        public Guid GovernetId { get; set; }
        public Guid SchemeId { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public Guid PermissionSchemeId { get; set; }
        public Guid GeometryId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid PropertyType { get; set; }
        public Guid ProjectType { get; set; }

        public List<SelectListItem> ProfileList { get; set; }
        public List<SelectListItem> ProjectTypeList { get; set; }
        public List<SelectListItem> PropertyTypeList { get; set; }
        public List<SelectListItem> GeometryList { get; set; }
        public List<SelectListItem> ProjectList { get; set; }
        public List<SelectListItem> GovernoratesList { get; set; }
        public List<SelectListItem> SchemeList { get; set; }
        public List<SelectListItem> PermissionList { get; set; }

        public List<SelectListItem> RoleList { get; set; }
        public Dictionary<string,string> Resource { get; set; }
    }
    public class ProjectProfileViewModel
    {
        public Guid ID { get; set; }
        public string CardId { get; set; }
        public string Name { get; set; }
        public string RegistrationHQ { get; set; }

    }
    public class PCVMS_ProjectProfileModle
    {

        public Guid ID { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ProfileId { get; set; }
        public bool? Deleted { get; set; }
    }

    public class ProjectPropertyModel
    {
        public Guid ID { get; set; }

        public Guid PropertyId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Name { get; set; }
        public string CardId { get; set; }
        public string PropertyNumber { get; set; }
        public string Email { get; set; }
        public string Landline { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Remark { get; set; }

    }
    public class ProjectSchemeGrid
    {
        public Guid ID { get; set; }
        public string ProjectName { get; set; }
        public string SchemeName { get; set; }
        public String RoleName { get; set; }

    }

}
