using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("FormSchemeMapping")]
    public partial class FormSchemeMapping
    {
        
        public int nId { get; set; }
        public string FormName { get; set; }
        public string SchemeName { get; set; }
        public bool  IsDeleted { get; set; }
    }
}
