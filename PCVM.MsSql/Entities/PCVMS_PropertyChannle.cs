using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_PropertyChannle")]
  public  class PCVMS_PropertyChannle
    {
        public Guid ID { get; set; }
        public Guid PropertyId { get; set; }

        public Guid ChannelCode { get; set; }


        public Guid Type { get; set; }
        public Guid Description { get; set; }

        public Guid Cladding { get; set; }

        public Guid CreatedUserId { get; set; }

        public string Width { get; set; }
        public string Height { get; set; }
        public string Length { get; set; }
        public bool? Deleted { get; set; }
    }
}
