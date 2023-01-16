using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class PCVMS_CommonLookUp
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public bool Deleted { get; set; }
        public string TypeName { get; set; }
    }
    public class PCVMS_Governorates
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public bool Deleted { get; set; }
    }
    public class PCVMS_Villages
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public Guid WilayatID { get; set; }
        public bool Deleted { get; set; }
    }
    public class PCVMS_Wilayat
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public Guid GovernorateID { get; set; }
        public bool Deleted { get; set; }
    }
    public class PCVMS_Permission
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string nameAr { get; set; }
        public string Url { get; set; }
        public string ControllerName { get; set; }
        public string ParentId { get; set; }
        public string MenuId { get; set; }        
        public int OrderNo { get; set; }
        public int MenuOrderNo { get; set; }
        public string MenuName { get; set; }
        public int Level { get; set; }
    }
    public class PCVMS_Permission_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
    }
}
