namespace PCVM.MsSql
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using PCVM.MsSql.Entities;

    public partial class SampleContext : DbContext
    {
        private readonly IConfiguration _config;

        public SampleContext(IConfiguration config)
        {
            _config = config;
        }

        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentTransitionHistory> DocumentTransitionHistories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StructDivision> StructDivisions { get; set; }
        public virtual DbSet<Head> VHeads { get; set; }
        public virtual DbSet<WorkflowInbox> WorkflowInboxes { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<WorkflowScheme> WorkflowSchemes { get; set; }
        public virtual DbSet<FormSchemeMapping> FormSchemeMapping { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Propertydetails> Propertydetails { get; set; }
        public virtual DbSet<PropertyItemType> PropertyItemType { get; set; }


        public virtual DbSet<PCVMS_Permission> PCVMS_Permission { get; set; }
        public virtual DbSet<PCVMS_Permission_Category> PCVMS_Permission_Category { get; set; }
        public virtual DbSet<PCVMS_Permission_Master> PCVMS_Permission_Master { get; set; }
        public virtual DbSet<PCVMS_Permission_Scheme> PCVMS_Permission_Scheme { get; set; }
        public virtual DbSet<PCVMS_Project> PCVMS_Project { get; set; }
        public virtual DbSet<PCVMS_Project_Scheme> PCVMS_Project_Scheme { get; set; }
        public virtual DbSet<PCVMS_Role_GroupName> PCVMS_Role_GroupName { get; set; }
        public virtual DbSet<PCVMS_Role_Permission> PCVMS_Role_Permission { get; set; }
        public virtual DbSet<PCVMS_Roles> PCVMS_Roles { get; set; }
        public virtual DbSet<PCVMS_Roles_Group> PCVMS_Roles_Group { get; set; }
        public virtual DbSet<PCVMS_Scheme> PCVMS_Scheme { get; set; }
        public virtual DbSet<PCVMS_User> PCVMS_User { get; set; }
        public virtual DbSet<PCVMS_User_Group> PCVMS_User_Group { get; set; }
        public virtual DbSet<PCVMS_User_Group_Name> PCVMS_User_Group_Name { get; set; }
        public virtual DbSet<PCVMS_User_Role> PCVMS_User_Role { get; set; }
        public virtual DbSet<PCVMS_User_RoleGroups> PCVMS_User_RoleGroups { get; set; }

        public virtual DbSet<PCVMS_Project_Role> PCVMS_Project_Role { get; set; }

        public virtual DbSet<PCVMS_Role_Scheme> PCVMS_Role_Scheme { get; set; }
        public virtual DbSet<PCVMS_UserGroup_Role> PCVMS_UserGroup_Role { get; set; }

        public virtual DbSet<PCVMS_Profile> PCVMS_Profile { get; set; }

        public virtual DbSet<LogEntry> LogEntry { get; set; }

        public virtual DbSet<PCVMS_ProfileStatusHistory> PCVMS_ProfileStatusHistory { get; set; }
        public virtual DbSet<PCVMS_Documents> PCVMS_Documents { get; set; }


        public virtual DbSet<PCVMS_Governorates> PCVMS_Governorates { get; set; }

        public virtual DbSet<PCVMS_Wilayat> PCVMS_Wilayat { get; set; }
        public virtual DbSet<PCVMS_Villages> PCVMS_Villages { get; set; }
        public virtual DbSet<PCVMS_ProjectLocation> PCVMS_ProjectLocation { get; set; }

        public virtual DbSet<PCVMS_Geometry> PCVMS_Geometry { get; set; }

        public virtual DbSet <PCVMS_GeometryDetails> PCVMS_GeometryDetails { get; set; }

        public virtual DbSet<PCVMS_ProjectProfile> PCVMS_ProjectProfile { get; set; }
        public virtual DbSet<PCVMS_PropertyType> PCVMS_PropertyType { get; set; }

        public virtual DbSet<PCVMS_Property> PCVMS_Property { get; set; }

        public virtual DbSet<PCVMS_ProjectType> PCVMS_ProjectType { get; set; }

        public virtual DbSet<PCVMS_ActualLandUse> PCVMS_ActualLandUse { get; set; }
        public virtual DbSet<PCVMS_SubLandUse> PCVMS_SubLandUse { get; set; }
        public virtual DbSet<PCVMS_LandUser> PCVMS_LandUser { get; set; }
        public virtual DbSet<PCVMS_PropertyLandInfo> PCVMS_PropertyLandInfo { get; set; }
        public virtual DbSet<PCVMS_BuildingMeterialType> PCVMS_BuildingMeterialType { get; set; }
        public virtual DbSet<PCVMS_BuildingMeterial> PCVMS_BuildingMeterial { get; set; }

        public virtual DbSet<PCVMS_PropertyMeterial> PCVMS_PropertyMeterial { get; set; }

        public virtual DbSet<PCVMS_PropertyWalls> PCVMS_PropertyWalls { get; set; }
        public virtual DbSet<PCVMS_PropertyTree> PCVMS_PropertyTree { get; set; }
        public virtual DbSet<PCVMS_PropertyCrop> PCVMS_PropertyCrop { get; set; }
        
        public virtual DbSet<PCVMS_PropertyStorage> PCVMS_PropertyStorage { get; set; }

        public virtual DbSet<PCVMS_PropertyTank> PCVMS_PropertyTank { get; set; }

        public virtual DbSet<PCVMS_PropertyChannle> PCVMS_PropertyChannle { get; set; }

        public virtual DbSet<PCVMS_PropertyItem> PCVMS_PropertyItem { get; set; }
        public virtual DbSet<PCVMS_Excel> PCVMS_Excel { get; set; }
        public virtual DbSet<PCVMS_Resource> PCVMS_Resource { get; set; }
        public virtual DbSet<PCVMS_PropertyDraft> PCVMS_PropertyDraft { get; set; }
        public virtual DbSet<PCVMS_ValuetionDraft> PCVMS_ValuetionDraft { get; set; }

        public virtual DbSet<PCVMS_PropertyItemPrice> PCVMS_PropertyItemPrice { get; set; }

        public virtual DbSet<FertilizerCertificate> FertilizerCertificate { get; set; }
         

        public virtual DbSet<Review_History> ReviewHistory { get; set; }

        public virtual DbSet<PesticideCertificate> PesticideCertificate { get; set; }

        public virtual DbSet<CAS_RN_Master> CASRNMasters { get; set; }
        public virtual DbSet<Certificate_Master> CertificateMaster { get; set; }
        public virtual DbSet<Chemical_Class_Master> Chemical_Class_Master { get; set; }
        public virtual DbSet<Common_Name_Master> Common_Name_Master { get; set; }     

        public virtual DbSet<Target_Pest_Master> Target_Pest_Master { get; set; }
        public virtual DbSet<LabSample.SampleDetails> SampleDetails { get; set; }

        public virtual DbSet<LabSample.ImportExport> ImportExport { get; set; }

        public virtual DbSet<LabSample.PortMaster> PortMaster { get; set; }
        public virtual DbSet<LabSample.CountryMaster> CountryMaster { get; set; }
        public virtual DbSet<LabSample.AnalysisMaster> AnalysisMaster { get; set; }
        public virtual DbSet<LabSample.LabMaster> LabMaster { get; set; }
        public virtual DbSet<LabSample.SampleMaster> SampleMaster { get; set; }
        public virtual DbSet<LabSample.SampleSourceMaster> SampleSourceMaster { get; set; }

        public virtual DbSet<Type_Formulation_Master> TypeFormulationMaster { get; set; }
        public virtual DbSet<WHO_Toxicity_Master> WHOToxicityMaster { get; set; }

        public virtual DbSet<Common_Name_Concentration> CommonNameConcentration { get; set; }
        

        public virtual DbSet<Lookup_Master> Lookup_Master { get; set; }

        public virtual DbSet<Chemical_Analysis> ChemicalAnalysis { get; set; }
        public virtual DbSet<Organic_Analysis> OrganicAnalysis { get; set; }

        public virtual DbSet<Pesticide_Use_Master> PesticideUseMaster { get; set; }

        public virtual DbSet<Common.CertificateAnalysis> CertificateAnalysis { get; set; }

        public virtual DbSet<Payment> Payment { get; set; }

        public virtual DbSet<PaymentInvoice> PaymentInvoice { get; set; }

        public virtual DbSet<PaymentPesticide> PaymentPesticide { get; set; }

        public virtual DbSet<LabSample.FarmMaster> FarmMasters { get; set; }

        public virtual DbSet<LabSample.CommodityTypeMaster> CommodityTypeMaster { get; set; }

        public virtual DbSet<LabSample.CommodityNameMaster> CommodityNameMaster { get; set; }

        public virtual DbSet<LabSample.LabAnalysis> LabAnalysis { get; set; }

        public virtual DbSet<LabSample.LabResult> LabResult { get; set; }

        public virtual DbSet<Print> Print { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PCVMS_Property>()
     .HasKey(e => e.ID);

            modelBuilder.Entity<PCVMS_ProjectProfile>()
       .HasKey(e => e.ID);

            modelBuilder.Entity<PCVMS_GeometryDetails>()
       .HasKey(e => e.ID);

            modelBuilder.Entity<PCVMS_Geometry>()
       .HasKey(e => e.ID);
            modelBuilder.Entity<PCVMS_ProjectLocation>()
        .HasKey(e => e.ID);
            modelBuilder.Entity<PCVMS_Governorates>()
         .HasKey(e => e.ID);
            modelBuilder.Entity<PCVMS_Wilayat>()
        .HasKey(e => e.ID);

            modelBuilder.Entity<PCVMS_Villages>()
     .HasKey(e => e.ID);

            modelBuilder.Entity<PCVMS_ProfileStatusHistory>()
         .HasKey(e => e.ID);

            modelBuilder.Entity<PCVMS_Documents>()
          .HasKey(e => e.ID);

            modelBuilder.Entity<LogEntry>()
           .HasKey(e => e.Id);
            modelBuilder.Entity<PCVMS_Permission>()
            .HasKey(e => e.ID);

            modelBuilder.Entity<PCVMS_Profile>()
          .HasKey(e => e.ID);


            modelBuilder.Entity<PCVMS_UserGroup_Role>()
           .HasKey(e => e.ID);

            modelBuilder.Entity<PCVMS_Permission_Category>()
                .HasKey(e => e.ID);

                modelBuilder.Entity<PCVMS_Permission_Master>()
                .HasKey(e => e.ID);
                modelBuilder.Entity<PCVMS_Permission_Scheme>()
                .HasKey(e => e.ID);
                modelBuilder.Entity<PCVMS_Project>()
                .HasKey(e => e.ID);
            modelBuilder.Entity<PCVMS_Project_Role>()
               .HasKey(e => e.ID);
            
                modelBuilder.Entity<PCVMS_Project_Scheme>()
                .HasKey(e => e.ID);
                modelBuilder.Entity<PCVMS_Role_GroupName>()
                .HasKey(e => e.ID);
            modelBuilder.Entity<PCVMS_Role_Permission>()
            .HasKey(e => e.ID);
                
                modelBuilder.Entity<PCVMS_Roles>()
                .HasKey(e => e.ID);
                modelBuilder.Entity<PCVMS_Roles_Group>()
                .HasKey(e => e.ID);
                modelBuilder.Entity<PCVMS_Scheme>()
                .HasKey(e => e.ID);
            //modelBuilder.Entity<PCVMS_User>()
            //.HasMany(e => e.UserRoles)
            //.WithOne(e => e.PCVMS_User)
            //.HasForeignKey(e => e.UserId);



           

            //modelBuilder.Entity<PCVMS_User>()
            //.HasMany(e => e.PCVMS_User_RoleGroups)
            //.WithOne(e => e.PCVMS_User)
            //.HasForeignKey(e => e.UserId);

           // modelBuilder.Entity<PCVMS_User_RoleGroups>()
           //.HasMany(e => e.PCVMS_Roles)
           //.WithOne(e => e.PCVMS_User_RoleGroups)
           //.HasForeignKey(e => e.ID);







            modelBuilder.Entity<PCVMS_User>()
                .HasKey(e => e.UserId);



                modelBuilder.Entity<PCVMS_User_Group>()
                .HasKey(e => e.ID);
                modelBuilder.Entity<PCVMS_User_Group_Name>()
                .HasKey(e => e.ID);
            modelBuilder.Entity<PCVMS_User_Role>()
            .HasKey(e => e.ID);





            modelBuilder.Entity<PCVMS_User_RoleGroups>()
                .HasKey(e => e.ID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Documents)
                .WithOne(e => e.Author)
                .HasForeignKey(e => e.AuthorId);

            modelBuilder.Entity<FormSchemeMapping>()
              .HasKey(e => e.nId);
            modelBuilder.Entity<Property>()
            .HasKey(e => e.nPropertyId);
            modelBuilder.Entity<PropertyItemType>()
           .HasKey(e => e.nItemId);
            modelBuilder.Entity<Propertydetails>()
          .HasKey(e => e.nPropertyDetails);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Documents1)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeRoles)
                .WithOne(r => r.Employee)
                .HasForeignKey(r => r.EmployeeId);

            modelBuilder.Entity<Role>()
                        .HasMany(e => e.EmployeeRoles)
                        .WithOne(r => r.Role)
                        .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<StructDivision>()
                .HasMany(e => e.StructDivision1)
                .WithOne(e => e.StructDivision2)
                .HasForeignKey(e => e.ParentId)
            ;

            modelBuilder.Entity<EmployeeRole>()
                .HasKey(x => new { x.RoleId, x.EmployeeId })
            ;

            modelBuilder.Entity<EmployeeRole>()
             .HasOne(x => x.Role).WithMany(x => x.EmployeeRoles)
         ;
           

        }

        public async Task<List<PCVMS_Permission>> spGetUserPermission(Guid UserId)
        {
            // Initialization.  
            List<PCVMS_Permission> lst = new List<PCVMS_Permission>();

            try
            {
                // Settings.  
                Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserId", UserId);



                 lst = await PCVMS_Permission.FromSqlRaw("exec spGetUserPermission @UserId", usernameParam).ToListAsync();

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Info.  
           
        }       
    }
}



