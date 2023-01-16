using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("PCVMS_Permission_Master")]
public  class PCVMS_Permission_Master
{
    public Guid ID { get; set; }
    public string NameEn { get; set; }
    public string NameAr { get; set; }
}

}
