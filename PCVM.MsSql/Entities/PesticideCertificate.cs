using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
    [Table("Certificate", Schema = "Pesticide")]
    public class PesticideCertificate
    {
        public Guid ID { get; set; }
        public Guid Certificate_Type_ID { get; set; }
        public string Certificate_Name { get; set; }
        public DateTime? Requested_Date { get; set; }
        public string Certificate_Request_No { get; set; }
        public string Local_Registration_No { get; set; }
        public string Trade_Name { get; set; }
        public string Chemical_Class { get; set; }
        public Guid Pesticide_Use_ID { get; set; }
        public string Pesticide_Use { get; set; }

        public Guid Type_Formulation_ID { get; set; }
        public string Type_Formulation { get; set; }
        public string Target_Pest { get; set; }
        public Guid WHO_Toxicity_Classification_ID { get; set; }
        public string WHO_Toxicity_Classification { get; set; }     
       
        public string Target_Crops { get; set; }       
        
        public string CR_Number { get; set; }
        public string Registered_Commercial_Activities { get; set; }
        public string Manufacturer_Company { get; set; }
        public string Local_Company { get; set; }
        public string License_Number { get; set; }
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

    }

    [Table("Common_Name_Concentration", Schema = "Pesticide")]
    public class Common_Name_Concentration
    {
        public Guid ID { get; set; }
        public Guid CertificateID { get; set; }
        public Guid Common_Name_ID { get; set; }
        public string Common_Name { get; set; }
        public string Active_Ingredient { get; set; }

        public string Created_by_Name { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_date { get; set; }

    }

   
    [Table("CAS_RN_Master", Schema = "Pesticide")]
    public class CAS_RN_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    }
    [Table("Certificate_Master", Schema = "Pesticide")]
    public class Certificate_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    }
    [Table("Chemical_Class_Master", Schema = "Pesticide")]
    public class Chemical_Class_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    }
    [Table("Common_Name_Master", Schema = "Pesticide")]
    public class Common_Name_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    [Table("Pesticide_Use_Master", Schema = "Pesticide")]
    public class Pesticide_Use_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }

    [Table("Target_Pest_Master", Schema = "Pesticide")]
    public class Target_Pest_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    }

    [Table("Type_Formulation_Master", Schema = "Pesticide")]
    public class Type_Formulation_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }

    [Table("WHO_Toxicity_Master", Schema = "Pesticide")]
    public class WHO_Toxicity_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }

}








