using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
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

    public class PesticideModel
    {
        public int CASRNID { get; set; }
        public List<SelectListItem> CASRNMaster { get; set; }
        public int ChemicalClassMasterID { get; set; }
        public List<SelectListItem> ChemicalClassMaster { get; set; }
        public int TargetPestMasterID { get; set; }
        public List<SelectListItem> TargetPestMaster { get; set; }

        #region MASTER LIST

        #region Certificate Master
        public int CertificateMasterID { get; set; }
        public List<SelectListItem> CertificateMaster { get; set; }

        #endregion

        #region Pesticide Use
        public int PesticideUseMasterID { get; set; }
        public List<SelectListItem> PesticideUseMaster { get; set; }
        #endregion

        #region Formulation Type
        public Guid TypeFormulationMasterID { get; set; }
        public List<SelectListItem> TypeFormulationMaster { get; set; }
        #endregion

        #region WHO Toxicity
        public Guid WHOToxicityMasterID { get; set; }
        public List<SelectListItem> WHOToxicityMaster { get; set; }
        #endregion

        #region Common Name
        public Guid CommonNameMasterID { get; set; }
        public List<SelectListItem> CommonNameMaster { get; set; }

        #endregion

        #region Service Master
        public Guid ServiceMasterID { get; set; }
        public List<SelectListItem> ServiceMaster { get; set; }

        #endregion Service Master

        #endregion
    }

    public class CAS_RN_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    }
   
    public class Chemical_Class_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    } 
  
    public class Target_Pest_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    }


    #region MASTER LIST
    public class Certificate_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }
    }
    public class Pesticide_Use_Master
    {
        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }
    }
    public class Type_Formulation_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class WHO_Toxicity_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class Common_Name_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }

    #endregion

}


