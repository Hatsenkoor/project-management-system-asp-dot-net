using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
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

    public class Fertilizer_Model
    {
        
        #region Detail Screen
        public Guid NatureMasterID { get; set; }
        public List<SelectListItem> NatureMaster { get; set; }
        public Guid ShapeMasterID { get; set; }
        public List<SelectListItem> ShapeMaster { get; set; }
        public Guid FertilizerTypeMasterID { get; set; }
        public List<SelectListItem> FertilizerTypeMaster { get; set; }
        public Guid SubCategoryMasterID { get; set; }
        public List<SelectListItem> SubCategoryMaster { get; set; }
        #endregion

        #region Analysis Type
        public Guid OrganicAnalysisMasterID { get; set; }
        public List<SelectListItem> OrganicAnalysisMaster { get; set; }

        #endregion

        #region Major Element

        //public Guid ChemicalDensityMasterID { get; set; }
        //public List<SelectListItem> ChemicalDensityMaster { get; set; }

        //public Guid ChemicalDensityFormMasterID { get; set; }
        //public List<SelectListItem> ChemicalDensityFormMaster { get; set; }


        public Guid MajorElementMasterID { get; set; }
        public List<SelectListItem> MajorElementMaster { get; set; }

        public Guid MajorElementFormMasterID { get; set; }
        public List<SelectListItem> MajorElementFormMaster { get; set; }

        

        #endregion

        #region Secondary Element
        //public Guid SecondaryElementMasterID { get; set; }
        //public List<SelectListItem> Secondary_Master { get; set; }
        public Guid SecondaryElementMasterID { get; set; }
        public List<SelectListItem> SecondaryElementMaster { get; set; }

        #endregion

        #region Trace Element
        //public Guid TraceElementMasterID { get; set; }
        //public List<SelectListItem> Trace_Master { get; set; }
        //public Guid FormElementMasterID { get; set; }
        //public List<SelectListItem> Element_Form_Master { get; set; }

        public Guid TraceElementMasterID { get; set; }
        public List<SelectListItem> TraceElementMaster { get; set; }
        public Guid TraceElementFormMasterID { get; set; }
        public List<SelectListItem> TraceElementFormMaster { get; set; }

        #endregion

        //public Guid ChemicalConcentrationMasterID { get; set; }
        //public List<SelectListItem> ChemicalConcentrationMaster { get; set; }

        //public Guid ChemicalPercentageMasterID { get; set; }
        //public List<SelectListItem> ChemicalPercentageMaster { get; set; }

        public MOCICompany.Root MOCICompanyRoot { get; set; }

    }
    public class Organic_Analysis_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class Major_Element_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    }
    public class Major_Element_Form_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int Order { get; set; }

    }
    public class Chemical_Concentration_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    }
    public class Chemical_Percentage_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }

    }
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

    public class Receipt
    {
        ///ID
        private int id;
        public int ID { [DebuggerStepThrough]get { return id; } [DebuggerStepThrough]set { id = value; } }

        ///ID
        private int location_ID;
        public int Location_ID { [DebuggerStepThrough]get { return location_ID; } [DebuggerStepThrough]set { location_ID = value; } }

        ///ID
        private int customer_ID;
        public int Customer_ID { [DebuggerStepThrough]get { return customer_ID; } [DebuggerStepThrough]set { customer_ID = value; } }

        /// <summary>
        /// Customer_Name
        /// </summary>
        private string customer_Name;
        public string Customer_Name { [DebuggerStepThrough]get { return customer_Name; } [DebuggerStepThrough]set { customer_Name = value; } }

        ///ID
        private int bank_ID;
        public int Bank_ID { [DebuggerStepThrough]get { return bank_ID; } [DebuggerStepThrough]set { bank_ID = value; } }

        ///Bank_Name
        private string bank_Name;
        public string Bank_Name { [DebuggerStepThrough]get { return bank_Name; } [DebuggerStepThrough]set { bank_Name = value; } }



        /// <summary>
        /// Receipt_Date
        /// </summary>
        private string receipt_Date;
        public string Receipt_Date { [DebuggerStepThrough]get { return receipt_Date; } [DebuggerStepThrough]set { receipt_Date = value; } }

        /// <summary>
        /// Distibutor_No
        /// </summary>
        private string distibutor_No;
        public string Distibutor_No { [DebuggerStepThrough]get { return distibutor_No; } [DebuggerStepThrough]set { distibutor_No = value; } }


        /// <summary>
        /// Total_Amount_Number
        /// </summary>
        private decimal total_Amount_Number;
        public decimal Total_Amount_Number { [DebuggerStepThrough]get { return total_Amount_Number; } [DebuggerStepThrough]set { total_Amount_Number = value; } }

        /// <summary>
        /// Key
        /// </summary>
        private string total_Amount_Words;
        public string Total_Amount_Words { [DebuggerStepThrough]get { return total_Amount_Words; } [DebuggerStepThrough]set { total_Amount_Words = value; } }

        /// <summary>
        /// Cheque_Number
        /// </summary>
        private string cheque_Number;
        public string Cheque_Number { [DebuggerStepThrough]get { return cheque_Number; } [DebuggerStepThrough]set { cheque_Number = value; } }

        /// <summary>
        /// Cheque_Date
        /// </summary>
        private string cheque_Date;
        public string Cheque_Date { [DebuggerStepThrough]get { return cheque_Date; } [DebuggerStepThrough]set { cheque_Date = value; } }


        /// <summary>
        /// user_Name
        /// </summary>
        private string user_Name;
        public string User_Name { [DebuggerStepThrough]get { return user_Name; } [DebuggerStepThrough]set { user_Name = value; } }


    }

    public class Receipt_Invoice
    {
        ///ID
        private int id;
        public int ID { [DebuggerStepThrough]get { return id; } [DebuggerStepThrough]set { id = value; } }

        ///ID
        private int receipt_ID;
        public int Receipt_ID { [DebuggerStepThrough]get { return receipt_ID; } [DebuggerStepThrough]set { receipt_ID = value; } }


        ///ID
        private int invoice_ID;
        public int Invoice_ID { [DebuggerStepThrough]get { return invoice_ID; } [DebuggerStepThrough]set { invoice_ID = value; } }


        /// <summary>
        /// Receipt_Date
        /// </summary>
        private string invoice_Date;
        public string Invoice_Date { [DebuggerStepThrough]get { return invoice_Date; } [DebuggerStepThrough]set { invoice_Date = value; } }

        /// <summary>
        /// user_Name
        /// </summary>
        private decimal amount;
        public decimal Amount { [DebuggerStepThrough]get { return amount; } [DebuggerStepThrough]set { amount = value; } }
    }


    public class Secondary_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class Trace_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class Element_Form_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class Lookup_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class Nature_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class Shape_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class Type_Master
    {
        public Guid ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool Deleted { get; set; }
        public int OrderNo { get; set; }

    }
    public class SubCategory_Master
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
