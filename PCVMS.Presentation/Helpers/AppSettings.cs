using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVM.Web.Helpers
{
    public class AppSettings
    {
        private string uri;
        private string _Secret;
        public string Secret { get
            {
                return "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
            }

            set
            {
                _Secret = value;
            }
            }
        public string ApiUrl { get; set; }
       
       
    }
}
