using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVMS.Model.BusinessModel
{
    public class Payment
    {
        public long Id { get; set; }
        public Guid AppID { get; set; }
        public string PaymentType { get; set; }
        public string tracking_id { get; set; }
        public string bank_ref_no { get; set; }
       
        public string order_status { get; set; }
        public string failure_message { get; set; }
        public string payment_mode { get; set; }
        public string card_name { get; set; }
        public string card_no { get; set; }
        public string status_code { get; set;}
        public string status_message { get; set; }
        public string currency { get; set; }
        public decimal amount { get; set; }
        public DateTime? trans_date { get; set; }
    }

    public class PaymentInvoice
    {
        public long Id { get; set; }
        public Guid AppID { get; set; }
        public string PaymentType { get; set; }
        public string Payment_mode { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Trans_date { get; set; }
        public string RegistrationNo { get; set; }
    }

    public class PaymentPesticide
    {
        public long Id { get; set; }
        public Guid AppID { get; set; }
        public string ServiceType { get; set; }
        public Guid Service_ID { get; set; }
        public string ServiceDescription { get; set; }
        public decimal amount { get; set; }
        public DateTime? trans_date { get; set; }
    }
}

