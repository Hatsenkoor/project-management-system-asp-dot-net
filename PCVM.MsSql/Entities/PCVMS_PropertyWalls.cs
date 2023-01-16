using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyWalls")]
  public  class PCVMS_PropertyWalls
    {
        public Guid ID { get; set; }
        public Guid Type { get; set; }

        public Guid PropertyId { get; set; }
        public string Height { get; set; }

        public string Thickness { get; set; }
        public string Length { get; set; }
        public string Line { get; set; }
        public bool? Deleted { get; set; }


    }
}
