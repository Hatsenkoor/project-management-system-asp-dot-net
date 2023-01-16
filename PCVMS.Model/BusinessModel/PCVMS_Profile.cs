using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class PCVMS_Profile
    {
        public string _CardId;
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string CardId
        {
            get { return _CardId; }
            set
            {
                try
                {
                    _CardId = value;
                }
                catch (Exception ex)
                {

                }
            }
        }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationHQ { get; set; }
        public string PoBox { get; set; }

        public string PostalCode { get; set; }

        public string Email { get; set; }

        public string LandLine { get; set; }

        public string Mobile { get; set; }
        public string Fax { get; set; }

        public string Remark { get; set; }

        public Guid ProfileId { get; set; }

        public bool Deleted { get; set; }
        public string StatusId { get; set; }
        public Guid CreatedUserid { get; set; }
    }
    public class PCVMS_ProfileType
    {
        public Guid ID { get; set; }
        public string ProfileNameEn { get; set; }
        public string ProfileNameAr { get; set; }
        public bool? Deleted { get; set; }
    }
}
