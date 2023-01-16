using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("Certificate", Schema = "Fertilizer")]
    public  class FertilizerCertificate
    {
        public Guid ID { get; set; }
        public Guid Fertilizer_Type_ID { get; set; }
        public string Fertilizer_Type { get; set; }
        public Guid Fertilizer_Subcategory_ID { get; set; }
        public string Fertilizer_Subcategory { get; set; }
        public DateTime? Requested_Date { get; set; }
        public string Registration_Request_No { get; set; }
        public string Local_Certificate_Registration_No { get; set; }
        public string Scientific_Name { get; set; }
        public string Trade_Name { get; set; }
        public Guid Nature_ID { get; set; }
        public string Nature { get; set; }
        public Guid Shape_ID { get; set; }
        public string Shape { get; set; }
        public string Density_Concentration { get; set; }
        public string PH_Concentration { get; set; }
        public string Manufacturer { get; set; }
        public string Manufacturer_Address { get; set; }
        public string Manufacturing_Country { get; set; }
        public string Exporting_Company { get; set; }        
        public string Exporting_Company_Address { get; set; }
        public string CR_Number { get; set; }
        public string Registered_Commercial_Activities { get; set; }
        public string Company_Licensed_Import_Export_Trade { get; set; }
        public string Import_Export_License_Number { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string Created_by { get; set; }
        public DateTime? Created_date { get; set; }
        public string Updated_by { get; set; }
        public DateTime Updated_date { get; set; }       
        public bool Deleted { get; set; }
        public string StatusId { get; set; }
        public bool RegistrationFee { get; set; }
        public bool CertificateFee { get; set; }
        public string CancelReason { get; set; }
        public string Application_Type { get; set; }
        public DateTime expiry_date { get; set; }
    }

    [Table("Chemical_Analysis", Schema = "Fertilizer")]
    public class Chemical_Analysis
    {
        public Guid ID { get; set; }
        public Guid CertificateID { get; set; }

        public Guid ElementMasterID { get; set; }

        public string ElementMasterText { get; set; }

        public Guid FormMasterID { get; set; }

        public string FormMasterText { get; set; }

        public string Concentration { get; set; }

        public string Source { get; set; }

        public string Type { get; set; }

        public string Created_by { get; set; }

        public DateTime? Created_date { get; set; }
        public string Updated_by { get; set; }

        public DateTime? Updated_date { get; set; }

    }  

    [Table("Organic_Analysis", Schema = "Fertilizer")]
    public class Organic_Analysis
    {
        public Guid ID { get; set; }
        public Guid CertificateID { get; set; }
        public Guid AnalysisTypeMasterID { get; set; }
        public string AnalysisTypeMasterText { get; set; }
        public string description { get; set; }
        public string Concentration { get; set; }

        public string Source { get; set; }
        public string Created_by { get; set; }

        public DateTime? Created_date { get; set; }
        public string Updated_by { get; set; }

        public DateTime? Updated_date { get; set; }        

    }

    [Table("Review_History", Schema = "Fertilizer")]
    public class Review_History
    {
        public Guid ID { get; set; }
        public Guid CertificateID { get; set; }
        public string Remark { get; set; }
        public string Remark_Type { get; set; }
        public string Created_by_Name { get; set; }
        public string Created_by { get; set; }
        public DateTime? Created_date { get; set; }

    }
   
    public class Lookup_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }

    public class Common
    {
        public class CertificateAnalysis
        {
           [Key]
            public string status { get; set; }
            public int local { get; set; }
            public int imported { get; set; }
        }
    }

    public class Print
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }

    }
}

