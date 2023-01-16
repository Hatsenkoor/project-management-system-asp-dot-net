using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCVMS.Model.BusinessModel
{
    public class LabSample
    {
		/*public class ImportExport
		{
			public Guid ID { get; set; }
			public string PC_Number { get; set; }

		}


        public class ImportExport
        {
            public Guid ID { get; set; }
            public string PC_Number { get; set; }

          
			public Guid Request_ID { get; set; }
			public Guid Payment_ID { get; set; }
			public DateTime? Collection_Date { get; set; }

			public Guid Port_ID { get; set; }
			public string Port_Name { get; set; }
			public string Custom_Document_Number { get; set; }
			public string Shipment_Document_Number { get; set; }
			public string Company_Name { get; set; }
			public Guid Country_Origin_ID { get; set; }
			public string Country_Origin_Name { get; set; }
			public Guid Country_Export_ID { get; set; }
			public string Country_Export_Name { get; set; }
			public Guid Sample_Type_ID { get; set; }
			public string Sample_Type_Name { get; set; }
			public Guid Sample_Source_ID { get; set; }
			public string Sample_Source_Name { get; set; }
			public Guid Analysis_Type_ID { get; set; }
			public string Analysis_Type_Name { get; set; }
			public string Importer_Name { get; set; }
			public string Importer_Contact_Detail { get; set; }
			public Guid Testing_Lab_ID { get; set; }
			public string Testing_Lab_Name { get; set; }
			public string Remark { get; set; }
			public string Created_by { get; set; }
			public DateTime? Created_date { get; set; }
			public string Updated_by { get; set; }
			public DateTime? Updated_date { get; set; }
			public bool Deleted { get; set; }
			public string StatusId { get; set; }

			

        }
		*/

		public class ImportExport
		{
			public Guid ID { get; set; }
			public Guid Request_ID { get; set; }
			public Guid Payment_ID { get; set; }
			public DateTime? Collection_Date { get; set; }
			public string PC_Number { get; set; }
			public string App_Name { get; set; }

			public Guid App_ID { get; set; }

			public Guid Port_ID { get; set; }
			public string Port_Name { get; set; }
			public string Custom_Document_Number { get; set; }
			public string Shipment_Document_Number { get; set; }
			public string Company_Name { get; set; }
			public Guid Country_Origin_ID { get; set; }
			public string Country_Origin_Name { get; set; }
			public Guid Country_Export_ID { get; set; }
			public string Country_Export_Name { get; set; }
			public Guid Sample_Type_ID { get; set; }
			public string Sample_Type_Name { get; set; }
			public Guid Sample_Source_ID { get; set; }
			public string Sample_Source_Name { get; set; }
			public Guid Analysis_Type_ID { get; set; }
			public string Analysis_Type_Name { get; set; }
			public string Importer_Name { get; set; }
			public string Importer_Contact_Detail { get; set; }
			public Guid Testing_Lab_ID { get; set; }
			public string Testing_Lab_Name { get; set; }
			public string Remark { get; set; }

			public string Governorate { get; set; }
			public Guid Governorate_ID { get; set; }

			public string Wilyat { get; set; }
			public Guid Wilyat_ID { get; set; }

			public string Village { get; set; }
			public string AgriculturalHoldingNumber { get; set; }

			public Decimal wgs84_latitude { get; set; }
			public Decimal wgs84_longitude { get; set; }

			public string Farm_Type { get; set; }
			public Guid Farm_Type_ID { get; set; }

			public string Farm_Owner_Name { get; set; }
			public string Created_by { get; set; }
			public DateTime? Created_date { get; set; }
			public string Updated_by { get; set; }
			public DateTime? Updated_date { get; set; }
			public bool Deleted { get; set; }
			public string StatusId { get; set; }


		}


		public class LabSample_Model
		{
			public Guid PortMasterID { get; set; }
			public List<SelectListItem> PortMaster { get; set; }

			public Guid CountryOriginMasterID { get; set; }
			public Guid CountryExportMasterID { get; set; }
			public List<SelectListItem> CountryMaster { get; set; }		

			public Guid SampleMasterID { get; set; }
			public List<SelectListItem> SampleMaster { get; set; }

			public Guid SampleSourceMasterID { get; set; }
			public List<SelectListItem> SampleSourceMaster { get; set; }

			public Guid AnalysisMasterID { get; set; }
			public List<SelectListItem> AnalysisMaster { get; set; }

			public Guid LabMasterID { get; set; }
			public List<SelectListItem> LabMaster { get; set; }

			public Guid GovernorateID { get; set; }
			public List<SelectListItem> GovernorateMaster { get; set; }

			public Guid FarmTypeID { get; set; }
			public List<SelectListItem> FarmMaster { get; set; }

			public Guid CommodityTypeID { get; set; }
			public List<SelectListItem> CommodityType { get; set; }

			public Guid CommodityNameID { get; set; }
			public List<SelectListItem> CommodityName { get; set; }

			public Guid PackagingTypeID { get; set; }
			public List<SelectListItem> PackagingType { get; set; }

			public Guid PackagingConditionID { get; set; }
			public List<SelectListItem> PackagingCondition { get; set; }

			public Guid PaymentTypeID { get; set; }
			public List<SelectListItem> PaymentType { get; set; }

			public Guid FindingTypeID { get; set; }
			public List<SelectListItem> FindingType { get; set; }

			public Guid PesticideCommercialNameID { get; set; }
			public List<SelectListItem> PesticideCommercialName { get; set; }

			public Guid PesticideUseID { get; set; }
			public List<SelectListItem> PesticideUseMaster { get; set; }

			public Guid FertilizerCommonNameMasterID { get; set; }
			public List<SelectListItem> FertilizerCommonNameMaster { get; set; }

			public Guid FertilizerTypeMasterID { get; set; }
			public List<SelectListItem> FertilizerTypeMaster { get; set; }

			public Guid ElementtobeAnalyzedID { get; set; }
			public List<SelectListItem> ElementtobeAnalyzed { get; set; }

			public Guid PlantMasterID { get; set; }
			public List<SelectListItem> PlantMaster { get; set; }
			public Guid InfectedPlantPartsID { get; set; }
			public List<SelectListItem> InfectedPlantParts { get; set; }
			public Guid CultivationTypeMasterID { get; set; }
			public List<SelectListItem> CultivationTypeMaster { get; set; }
			public Guid IrrigationSystemMasterID { get; set; }
			public List<SelectListItem> IrrigationSystemMaster { get; set; }
			public Guid InfectionSymptomsMasterID { get; set; }
			public List<SelectListItem> InfectionSymptomsMaster { get; set; }
			public Guid InfectionInOnePlantID { get; set; }
			public List<SelectListItem> InfectionInOnePlant { get; set; }
			public Guid InfectionInFieldID { get; set; }
			public List<SelectListItem> InfectionInField { get; set; }

			public Guid PesticideTypeMasterID { get; set; }
			public List<SelectListItem> PesticideTypeMaster { get; set; }


			

		}

		
		public class PortMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}
		public class CountryMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}
		public class SampleMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }		

		}
		public class SampleSourceMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}

		public class AnalysisMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}

		public class LabMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}

		public class FarmMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }
			public int OrderNo { get; set; }
		}

		public class SampleDetails
		{
			public Guid ID { get; set; }
			public Guid Sample_ID { get; set; }
			public Guid Commodity_Type_ID { get; set; }
			public string Commodity_Type_Name { get; set; }
			public Guid Commodity_Name_ID { get; set; }
			public string Commodity_Name { get; set; }
			public Decimal Weight_Units { get; set; }
			public string Batch_Number { get; set; }
			public Guid Pesticide_Commercial_Name_ID { get; set; }
			public string Pesticide_Commercial_Name { get; set; }
			public Decimal Percentage_Active_Ingredient { get; set; }
			public string Active_Ingredient { get; set; }
			public DateTime Production_Date { get; set; }
			public DateTime Expiry_Date { get; set; }

			public string Operation_Number { get; set; }

			public Guid Fertilizer_Commercial_Name_ID { get; set; }
			public string Fertilizer_Commercial_Name { get; set; }
			public Guid Fertilizer_Type_ID { get; set; }
			public string Fertilizer_Type { get; set; }
			public Guid Element_Analyzed_ID { get; set; }
			public string Element_Analyzed_Name { get; set; }

			public Guid Plant_Type_ID { get; set; }
			public string Plant_Type { get; set; }
			public string Plant_Name { get; set; }
			public int Area_Quantity_Estimated { get; set; }
			public Guid Infected_Part_Plant_ID { get; set; }
			public string Infected_Part_Plant_Name { get; set; }
			public Guid Cultivation_Type_ID { get; set; }
			public string Cultivation_Type_Name { get; set; }
			public Guid Irrigation_System_ID { get; set; }
			public string Irrigation_System_Name { get; set; }
			public Guid Infection_Symptoms_ID { get; set; }
			public string Infection_Symptoms_Name { get; set; }
			public Guid Percentage_Infection_One_Plant_ID { get; set; }
			public string Percentage_Infection_One_Plant_Name { get; set; }
			public Guid Percentage_Infection_In_Field_ID { get; set; }
			public string Percentage_Infection_In_Field_Name { get; set; }
			public DateTime Date_Symptoms_On_Set { get; set; }
			public string Age_Plant_Growth_Stage { get; set; }
			public string Symptoms_Description { get; set; }
			public DateTime Expected_Harvest_Date { get; set; }
			public string Created_by { get; set; }
			public DateTime Created_date { get; set; }
			public string Updated_by { get; set; }
			public DateTime Updated_date { get; set; }
			public bool Deleted { get; set; }
			public string StatusId { get; set; }

		}
				
		public class CommodityNameMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }
			public int OrderNo { get; set; }

		}
			
		public class CommodityTypeMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }
			public int OrderNo { get; set; }

		}

		public class LabAnalysis
		{
			public Guid ID { get; set; }
			public Guid Sample_ID { get; set; }			
			public DateTime? Receiving_Date { get; set; }
			public string Collected_From { get; set; }
			public string Delivered_By { get; set; }

			public Guid Packaging_Type_ID { get; set; }
			public string Packaging_Type_Name { get; set; }
			public Guid Packaging_Condition_ID { get; set; }
			public string Packaging_Condition_Name { get; set; }
			public decimal Sample_Quantity { get; set; }
			public decimal Sample_Temperature { get; set; }
			
			public Guid Sample_Type_ID { get; set; }
			public string Sample_Type_Name { get; set; }
			public Guid Sample_Product_ID { get; set; }
			public string Sample_Product_Name { get; set; }
			public Guid Payment_Type_ID { get; set; }
			public string Payment_Type_Name { get; set; }
			public Guid Formulation_Type_ID { get; set; }
			public string Formulation_Type_Name { get; set; }
			public string Commodity { get; set; }
			public string TestMethod { get; set; }
			public string InstrumentsForAnalysis { get; set; }
			public string Active_Ingredient_Concentration { get; set; }
			public Guid Pesticide_Type_ID { get; set; }
			public string Pesticide_Type_Name { get; set; }
			public string Trade_Name { get; set; }
			public string Remark { get; set; }
			public string Created_by { get; set; }
			public DateTime? Created_date { get; set; }
			public string Updated_by { get; set; }
			public DateTime? Updated_date { get; set; }
			public bool Deleted { get; set; }
			public string StatusId { get; set; }
		}

		public class LabResult
		{
			public Guid ID { get; set; }
			public Guid Sample_ID { get; set; }
			public string Report_ID { get; set; }
			public DateTime? Analysis_Date { get; set; }
			public string Analyzed_By { get; set; }
			public Guid Finding_ID { get; set; }
			public string Finding_Name { get; set; }
			public string Remark { get; set; }
			public string Created_by { get; set; }
			public DateTime? Created_date { get; set; }
			public string Updated_by { get; set; }
			public DateTime? Updated_date { get; set; }
			public bool Deleted { get; set; }
			public string StatusId { get; set; }
		}


		}
}

