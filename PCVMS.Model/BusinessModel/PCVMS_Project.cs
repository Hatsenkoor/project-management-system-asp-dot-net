using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class PCVMS_Project
    {
        public Guid ID { get; set; }
        public string ProjectName { get; set; }
        public string RoyalDecree { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public DateTime RoyalDecreeDate { get; set; }
        public string ProjectStartDate { get; set; }
        public string Remark { get; set; }
        public bool Deleted { get; set; }
    }
    public class PCVMS_Project_Scheme
    {
        public Guid ID { get; set; }
        public Guid Project_ID { get; set; }

        public Guid Permission_Scheme_ID { get; set; }
    }
    public class PCVMS_Project_Role
    {
        public Guid ID { get; set; }
        public Guid ProjectId { get; set; }
        public Guid RoleId { get; set; }
        public Guid SchemeId { get; set; }
        public bool Deleted { get; set; }
    }
    public class PCVMS_ProjectLocation
    {
        public Guid ID { get; set; }
        public Guid ProjectID { get; set; }

        public Guid GovernorateID { get; set; }

        public string GovernorateName { get; set; }
        public string WilayatName { get; set; }
        public string VillageName { get; set; }
        public Guid Wilayat { get; set; }
        public Guid Village { get; set; }
        public string Remark { get; set; }
        public bool? deleted { get; set; }
    }
    public class PCVMS_ProjectProfile
    {

        public Guid ID { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ProfileId { get; set; }
        public bool? Deleted { get; set; }
    }
}
