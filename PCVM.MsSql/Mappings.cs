using AutoMapper;
using PCVM.MsSql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVM.MsSql
{
    public  static class Mappings
    {
        public static IMapper Mapper { get { return _mapper.Value; } }

        private static Lazy<IMapper> _mapper = new Lazy<IMapper>(GetMapper);

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<StructDivision, PCVMS.Model.BusinessModel.StructDivision>();
                cfg.CreateMap<Employee, PCVMS.Model.BusinessModel.Employee>();
                cfg.CreateMap<PCVMS_Roles, PCVMS.Model.BusinessModel.PCVMS_Roles>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Roles, PCVMS_Roles>();
                cfg.CreateMap<PCVMS_Permission_Master, PCVMS.Model.BusinessModel.PCVMS_Permission_Master>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Permission_Master, PCVMS_Permission_Master>();
                
                cfg.CreateMap<EmployeeRole, PCVMS.Model.BusinessModel.EmployeeRole>();
                cfg.CreateMap<DocumentTransitionHistory, PCVMS.Model.BusinessModel.DocumentTransitionHistory>();

                cfg.CreateMap<Document, PCVMS.Model.BusinessModel.Document>();
                cfg.CreateMap<Property, PCVMS.Model.BusinessModel.Property>();
             
                cfg.CreateMap<PCVMS.Model.BusinessModel.Property,Property>();
                cfg.CreateMap<Propertydetails, PCVMS.Model.BusinessModel.Propertydetails>();
                cfg.CreateMap<PropertyItemType, PCVMS.Model.BusinessModel.PropertyItemType>();
                cfg.CreateMap<PCVMS_Permission, PCVMS.Model.BusinessModel.PCVMS_Permission>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Permission, PCVMS.Model.BusinessModel.PCVMS_Permission>();
                cfg.CreateMap<PCVMS_Scheme, PCVMS.Model.BusinessModel.PCVMS_Scheme>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Scheme, PCVMS_Scheme>();
                cfg.CreateMap<PCVMS_Roles, PCVMS.Model.BusinessModel.PCVMS_Roles>();
                cfg.CreateMap<PCVMS_Project, PCVMS.Model.BusinessModel.PCVMS_Project>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Project, PCVMS_Project>();
                cfg.CreateMap<PCVMS_Role_Permission, PCVMS.Model.BusinessModel.PCVMS_Role_Permission>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Role_Permission, PCVMS_Role_Permission>();
                cfg.CreateMap<PCVMS_Role_GroupName, PCVMS.Model.BusinessModel.PCVMS_Role_GroupName>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Role_GroupName, PCVMS_Role_GroupName>();
                cfg.CreateMap<PCVMS_User_Group_Name, PCVMS.Model.BusinessModel.PCVMS_User_Group_Name>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_User_Group_Name, PCVMS_User_Group_Name>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_User, PCVMS_User>();
                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Profile, PCVMS_Profile>();
                cfg.CreateMap<PCVMS_Profile, PCVMS.Model.BusinessModel.PCVMS_Profile>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LogEntry, LogEntry>();
                cfg.CreateMap<LogEntry, PCVMS.Model.BusinessModel.LogEntry>();


                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Documents, PCVMS_Documents>();
                cfg.CreateMap<PCVMS_Documents, PCVMS.Model.BusinessModel.PCVMS_Documents>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Governorates, PCVMS_Governorates>();
                cfg.CreateMap<PCVMS_Governorates, PCVMS.Model.BusinessModel.PCVMS_Governorates>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Wilayat, PCVMS_Wilayat>();
                cfg.CreateMap<PCVMS_Wilayat, PCVMS.Model.BusinessModel.PCVMS_Wilayat>();


                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Wilayat, PCVMS_Villages>();
                cfg.CreateMap<PCVMS_Villages, PCVMS.Model.BusinessModel.PCVMS_Villages>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_ProjectLocation, PCVMS_ProjectLocation>();
                cfg.CreateMap<PCVMS_ProjectLocation, PCVMS.Model.BusinessModel.PCVMS_ProjectLocation>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_GeometryDetails, PCVMS_GeometryDetails>();
                cfg.CreateMap<PCVMS_GeometryDetails, PCVMS.Model.BusinessModel.PCVMS_GeometryDetails>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_ProjectProfile, PCVMS_ProjectProfile>();
                cfg.CreateMap<PCVMS_ProjectProfile, PCVMS.Model.BusinessModel.PCVMS_ProjectProfile>();


                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Property, PCVMS_Property>();
                cfg.CreateMap<PCVMS_Property, PCVMS.Model.BusinessModel.PCVMS_Property>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_PropertyLandInfo, PCVMS_PropertyLandInfo>();
                cfg.CreateMap<PCVMS_PropertyLandInfo, PCVMS.Model.BusinessModel.PCVMS_PropertyLandInfo>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_PropertyMeterial, PCVMS_PropertyMeterial>();
                cfg.CreateMap<PCVMS_PropertyMeterial, PCVMS.Model.BusinessModel.PCVMS_PropertyMeterial>();


                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_PropertyWalls, PCVMS_PropertyWalls>();
                cfg.CreateMap<PCVMS_PropertyWalls, PCVMS.Model.BusinessModel.PCVMS_PropertyWalls>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_PropertyTree, PCVMS_PropertyTree>();
                cfg.CreateMap<PCVMS_PropertyTree, PCVMS.Model.BusinessModel.PCVMS_PropertyTree>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_PropertyCrop, PCVMS_PropertyCrop>();
                cfg.CreateMap<PCVMS_PropertyCrop, PCVMS.Model.BusinessModel.PCVMS_PropertyCrop>();


                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_PropertyStorage, PCVMS_PropertyStorage>();
                cfg.CreateMap<PCVMS_PropertyStorage, PCVMS.Model.BusinessModel.PCVMS_PropertyStorage>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_PropertyTank, PCVMS_PropertyTank>();
                cfg.CreateMap<PCVMS_PropertyTank, PCVMS.Model.BusinessModel.PCVMS_PropertyTank>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_PropertyChannle, PCVMS_PropertyChannle>();
                cfg.CreateMap<PCVMS_PropertyChannle, PCVMS.Model.BusinessModel.PCVMS_PropertyChannle>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_PropertyItem, PCVMS_PropertyItem>();
                cfg.CreateMap<PCVMS_PropertyItem, PCVMS.Model.BusinessModel.PCVMS_PropertyItem>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Excel, PCVMS_Excel>();
                cfg.CreateMap<PCVMS_Excel, PCVMS.Model.BusinessModel.PCVMS_Excel>();



                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Project_Scheme, PCVMS_Project_Scheme>();
                cfg.CreateMap<PCVMS_Project_Scheme, PCVMS.Model.BusinessModel.PCVMS_Project_Scheme>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Project_Role, PCVMS_Project_Role>();
                cfg.CreateMap<PCVMS_Project_Role, PCVMS.Model.BusinessModel.PCVMS_Project_Role>();


                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_User_Group, PCVMS_User_Group>();
                cfg.CreateMap<PCVMS_User_Group, PCVMS.Model.BusinessModel.PCVMS_User_Group>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_Resource, PCVMS_Resource>();
                cfg.CreateMap<PCVMS_Resource, PCVMS.Model.BusinessModel.PCVMS_Resource>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.FertilizerCertificate, FertilizerCertificate>();
                cfg.CreateMap<FertilizerCertificate, PCVMS.Model.BusinessModel.FertilizerCertificate>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Organic_Analysis, Organic_Analysis>();
                cfg.CreateMap<Organic_Analysis, PCVMS.Model.BusinessModel.Organic_Analysis>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Chemical_Analysis, Chemical_Analysis>();
                cfg.CreateMap<Chemical_Analysis, PCVMS.Model.BusinessModel.Chemical_Analysis>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Review_History, Review_History>();
                cfg.CreateMap<Review_History, PCVMS.Model.BusinessModel.Review_History>();          

                cfg.CreateMap<PCVMS.Model.BusinessModel.CAS_RN_Master, CAS_RN_Master>();
                cfg.CreateMap<CAS_RN_Master, PCVMS.Model.BusinessModel.CAS_RN_Master>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Certificate_Master, Certificate_Master>();
                cfg.CreateMap<Certificate_Master, PCVMS.Model.BusinessModel.Certificate_Master>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Common_Name_Master, Common_Name_Master>();
                cfg.CreateMap<Common_Name_Master, PCVMS.Model.BusinessModel.Common_Name_Master>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Pesticide_Use_Master, Pesticide_Use_Master>();
                cfg.CreateMap<Pesticide_Use_Master, PCVMS.Model.BusinessModel.Pesticide_Use_Master>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Target_Pest_Master, Target_Pest_Master>();
                cfg.CreateMap<Target_Pest_Master, PCVMS.Model.BusinessModel.Target_Pest_Master>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Chemical_Class_Master, Chemical_Class_Master>();
                cfg.CreateMap<Chemical_Class_Master, PCVMS.Model.BusinessModel.Chemical_Class_Master>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.PortMaster, LabSample.PortMaster>();
                cfg.CreateMap<LabSample.PortMaster, PCVMS.Model.BusinessModel.LabSample.PortMaster>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.CountryMaster, LabSample.CountryMaster>();
                cfg.CreateMap<LabSample.CountryMaster, PCVMS.Model.BusinessModel.LabSample.CountryMaster>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.AnalysisMaster, LabSample.AnalysisMaster>();
                cfg.CreateMap<LabSample.AnalysisMaster, PCVMS.Model.BusinessModel.LabSample.AnalysisMaster>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.LabMaster, LabSample.LabMaster>();
                cfg.CreateMap<LabSample.LabMaster, PCVMS.Model.BusinessModel.LabSample.LabMaster>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.SampleMaster, LabSample.SampleMaster>();
                cfg.CreateMap<LabSample.SampleMaster, PCVMS.Model.BusinessModel.LabSample.SampleMaster>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.SampleSourceMaster, LabSample.SampleSourceMaster>();
                cfg.CreateMap<LabSample.SampleSourceMaster, PCVMS.Model.BusinessModel.LabSample.SampleSourceMaster>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.ImportExport, LabSample.ImportExport>();
                cfg.CreateMap<LabSample.ImportExport, PCVMS.Model.BusinessModel.LabSample.ImportExport>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Lookup_Master, Lookup_Master>();
                cfg.CreateMap<Lookup_Master, PCVMS.Model.BusinessModel.Lookup_Master>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Type_Formulation_Master, Type_Formulation_Master>();
                cfg.CreateMap<Type_Formulation_Master, PCVMS.Model.BusinessModel.Type_Formulation_Master>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.WHO_Toxicity_Master, WHO_Toxicity_Master>();
                cfg.CreateMap<WHO_Toxicity_Master, PCVMS.Model.BusinessModel.WHO_Toxicity_Master>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Common_Name_Concentration, Common_Name_Concentration>();
                cfg.CreateMap<Common_Name_Concentration, PCVMS.Model.BusinessModel.Common_Name_Concentration>();

                cfg.CreateMap<PCVMS_User, PCVMS.Model.BusinessModel.PCVMS_User>().ForMember(p => p.PermissionList, act => act.Ignore());

                cfg.CreateMap<PCVMS.Model.BusinessModel.Common.CertificateAnalysis, Common.CertificateAnalysis>();
                cfg.CreateMap<Common.CertificateAnalysis, PCVMS.Model.BusinessModel.Common.CertificateAnalysis>();


                cfg.CreateMap<PCVMS.Model.BusinessModel.Payment, Payment>();
                cfg.CreateMap<Payment, PCVMS.Model.BusinessModel.Payment>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PaymentInvoice, PaymentInvoice>();
                cfg.CreateMap<PaymentInvoice, PCVMS.Model.BusinessModel.PaymentInvoice>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PCVMS_User_Role, PCVMS_User_Role>();
                cfg.CreateMap<PCVMS_User_Role, PCVMS.Model.BusinessModel.PCVMS_User_Role>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.Print, Print>();
                cfg.CreateMap<Print, PCVMS.Model.BusinessModel.Print>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PesticideCertificate, PesticideCertificate>();
                cfg.CreateMap<PesticideCertificate, PCVMS.Model.BusinessModel.PesticideCertificate>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.PaymentPesticide, PaymentPesticide>();
                cfg.CreateMap<PaymentPesticide, PCVMS.Model.BusinessModel.PaymentPesticide>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.FarmMaster, LabSample.FarmMaster>();
                cfg.CreateMap<LabSample.FarmMaster, PCVMS.Model.BusinessModel.LabSample.FarmMaster>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.CommodityTypeMaster, LabSample.CommodityTypeMaster>();
                cfg.CreateMap<LabSample.CommodityTypeMaster, PCVMS.Model.BusinessModel.LabSample.CommodityTypeMaster>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.CommodityNameMaster, LabSample.CommodityNameMaster>();
                cfg.CreateMap<LabSample.CommodityNameMaster, PCVMS.Model.BusinessModel.LabSample.CommodityNameMaster>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.SampleDetails, LabSample.SampleDetails>();
                cfg.CreateMap<LabSample.SampleDetails, PCVMS.Model.BusinessModel.LabSample.SampleDetails>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.LabAnalysis, LabSample.LabAnalysis>();
                cfg.CreateMap<LabSample.LabAnalysis, PCVMS.Model.BusinessModel.LabSample.LabAnalysis>();

                cfg.CreateMap<PCVMS.Model.BusinessModel.LabSample.LabResult, LabSample.LabResult>();
                cfg.CreateMap<LabSample.LabResult, PCVMS.Model.BusinessModel.LabSample.LabResult>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
