using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class PermissionModel
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string nameAr { get; set; }


        public Guid Permission_Category_ID { get; set; }

        
    }
}
