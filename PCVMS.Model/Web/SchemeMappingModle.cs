using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class SchemeMappingModle
    {
        public List<string> AllSchemes { get; set; }
        public List<string> AllForms { get; set; }
        [Required]
        public string FormName { get; set; }
        [Required]
        public string SchemeName { get; set; }
    }
}
