using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCVM.MsSql.Entities
{
		
	public class LabSample
    {
        [Table("Import_Export_Local", Schema = "LabSample")]
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

        [Table("PortMaster", Schema = "LabSample")]
		public class PortMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}

		[Table("CountryMaster", Schema = "LabSample")]

		public class CountryMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}

		[Table("SampleMaster", Schema = "LabSample")]
		public class SampleMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}

		[Table("SampleSourceMaster", Schema = "LabSample")]
		public class SampleSourceMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}

		[Table("AnalysisMaster", Schema = "LabSample")]
		public class AnalysisMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}

		[Table("LabMaster", Schema = "LabSample")]
		public class LabMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }

		}

		[Table("Farm_Master", Schema = "LabSample")]
		public class FarmMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }
			public int OrderNo { get; set; }

		}


		[Table("CommodityName_Master", Schema = "LabSample")]
		public class CommodityNameMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }
			public int OrderNo { get; set; }

		}


		[Table("CommodityType_Master", Schema = "LabSample")]
		public class CommodityTypeMaster
		{
			public Guid ID { get; set; }
			public string NameEn { get; set; }
			public string NameAr { get; set; }
			public bool Deleted { get; set; }
			public int OrderNo { get; set; }

		}

		[Table("SampleDetails", Schema = "LabSample")]
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

		[Table("LabAnalysis", Schema = "LabSample")]
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

		[Table("LabResult", Schema = "LabSample")]
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

