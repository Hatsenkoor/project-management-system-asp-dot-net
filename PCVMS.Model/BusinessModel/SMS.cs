using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class SMS
    {
        public string UserID { get; set; }

        public string Password { get; set; }

        public string Message { get; set; }

        public string Language { get; set; }

        public string ScheddateTime { get; set; }

        public string MobileNo { get; set; }

        public string RecipientType { get; set; }
    }
}
