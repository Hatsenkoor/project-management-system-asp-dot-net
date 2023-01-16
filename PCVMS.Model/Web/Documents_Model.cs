using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace PCVMS.Model.Web
{
    public class Documents_Model
    {

        public Guid ID { get; set; }
        public Guid GroupID { get; set; }
        public Guid ParentId { get; set; }
        public string Description { get; set; }

        public string DocumentType { get; set; }

        public string DocumentName { get; set; }

        public string DocumentPath { get; set; }

        public bool Deleted { get; set; }

        public byte[] file { get; set; }
    }
}
