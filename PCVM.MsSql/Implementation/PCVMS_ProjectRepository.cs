using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PCVMS.Model.Web;

namespace PCVM.MsSql.Implementation
{
    public class PCVMS_ProjectRepository : IPCVMS_Project
    {
        public PCVMS_ProjectRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }

        public async Task<PCVMS_Project> AddProject(PCVMS_Project PCVMS_Project)
        {
            var Project = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_Project>(PCVMS_Project);
            Project.StatusId = "1";
            SampleContext.PCVMS_Project.Add(Project);
            await SampleContext.SaveChangesAsync();
            PCVMS_Project.ID = Project.ID;
            return PCVMS_Project;
        }
        public async Task<bool> SubmitProject(Guid UserId, Guid ProfileId, string Comment)
        {

            Entities.PCVMS_ProfileStatusHistory objHistory = new Entities.PCVMS_ProfileStatusHistory();
            objHistory.StatusId = "2";
            objHistory.UserId = UserId;
            objHistory.UserComment = Comment;
            objHistory.ProfileId = ProfileId;
            SampleContext.PCVMS_ProfileStatusHistory.Add(objHistory);
            var Profile = SampleContext.PCVMS_Project.Where(w => w.ID == ProfileId).FirstOrDefault();
            Profile.StatusId = "2";
            await SampleContext.SaveChangesAsync();
            return true;


        }
        public async Task<bool> AcceptProject(Guid UserId, Guid ProfileId, string Comment)
        {

            Entities.PCVMS_ProfileStatusHistory objHistory = new Entities.PCVMS_ProfileStatusHistory();
            objHistory.StatusId = "3";
            objHistory.UserId = UserId;
            objHistory.UserComment = Comment;
            objHistory.ProfileId = ProfileId;
            SampleContext.PCVMS_ProfileStatusHistory.Add(objHistory);
            var PCVMS_Project = SampleContext.PCVMS_Project.Where(w => w.ID == ProfileId).FirstOrDefault();
            PCVMS_Project.StatusId = "3";

            
            await SampleContext.SaveChangesAsync();
            return true;


        }
        public async Task<bool> AddProjectLocation(PCVMS_ProjectLocation obj)
        {
            var Project = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_ProjectLocation>(obj);
            SampleContext.PCVMS_ProjectLocation.Add(Project);
            await SampleContext.SaveChangesAsync();
           
            return true;
        }
        public async Task<bool> AddProjectProfile(PCVMS_ProjectProfile obj)
        {

            var Project = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_ProjectProfile>(obj);
            SampleContext.PCVMS_ProjectProfile.Add(Project);
            await SampleContext.SaveChangesAsync();

            return true;
        }
        public async Task<dynamic> GetProjectProfile(Guid ProjectId)
        {


            var query = from pp in SampleContext.PCVMS_ProjectProfile
                        join p in SampleContext.PCVMS_Profile on pp.ProfileId equals p.ID
                       
                        where pp.ProjectId == ProjectId
                        select new { p.ID, p.CardId,p.Name, p.RegistrationHQ };

           return await query.ToListAsync<dynamic>();



        }
       
        public async Task<bool> AddProjectGeometry(PCVMS_GeometryDetails obj)
        {

            var Project = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_GeometryDetails>(obj);
           
            if(Project.ID==new Guid("00000000-0000-0000-0000-000000000000"))
            {

                SampleContext.PCVMS_GeometryDetails.Add(Project);
            }
            else
            {
                var find = SampleContext.PCVMS_GeometryDetails.Where(w => w.ID == Project.ID).FirstOrDefault();
                find.Northing = obj.Northing;
                find.Easting = obj.Easting;
                find.GeometryId = obj.GeometryId;
            }
           
            await SampleContext.SaveChangesAsync();

            return true;
        }
        public async Task<List<PCVMS_ProjectLocation>> GetProjectLocation(Guid ProjectId)
        {
            var r = from l in SampleContext.PCVMS_ProjectLocation
                    join w in SampleContext.PCVMS_Wilayat on l.Wilayat equals w.ID
                    join v in SampleContext.PCVMS_Villages on l.Village equals v.ID
                    join g in SampleContext.PCVMS_Governorates on l.GovernorateID equals g.ID
                    where l.ProjectID== ProjectId
                    select new PCVMS_ProjectLocation() { GovernorateName=g.NameEn, WilayatName = w.NameEn, VillageName = v.NameEn };
            var Result = await r.ToListAsync();
            return Result;
        }
        public async Task<List<PCVMS_GeometryDetails>> GetProjectGeometry(Guid ProjectId)
        {
            var r = from gd in SampleContext.PCVMS_GeometryDetails
                    join g in SampleContext.PCVMS_Geometry on gd.GeometryId equals g.ID
                    where gd.ProjectId == ProjectId
                    select new PCVMS_GeometryDetails() { ID=gd.ID,GeometryId=gd.GeometryId, GeometryNameEn = g.NameEn,GeometryNameAr=g.NameAr, Northing = gd.Northing, Easting = gd.Easting };
            var Result = await r.ToListAsync();
            return Result;
        }
        public async Task<List<ProjectSchemeGrid>> GetProjectSchema(Guid ProjectId)
        {
            var r = from p in SampleContext.PCVMS_Project
                    join ps in SampleContext.PCVMS_Project_Scheme on p.ID equals ps.Project_ID
                    join s in SampleContext.PCVMS_Scheme on ps.Permission_Scheme_ID equals s.ID
                    join rs in SampleContext.PCVMS_Role_Scheme on s.ID equals rs.SchemeId
                    join ro in SampleContext.PCVMS_Roles on rs.RoleId equals ro.ID
                    
                    where p.ID == ProjectId
                    select new ProjectSchemeGrid { ID = p.ID, ProjectName = p.ProjectName,SchemeName=s.NameEn,RoleName=ro.NameEn  };
            var Result = await r.ToListAsync<ProjectSchemeGrid>();
            return Result;
        }

        public async Task<List<PCVMS_Project>> GetAllProject()
        {
            var query = await SampleContext.PCVMS_Project.ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Project>>(query);
            return Result;
        }
        
        public async Task<bool> AssignScheme(PCVMS_Project_Scheme PCVMS_Project_Scheme)
        {
            var Assign = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_Project_Scheme>(PCVMS_Project_Scheme);
            var exist = SampleContext.PCVMS_Project_Scheme.Where(w => w.Project_ID == PCVMS_Project_Scheme.Project_ID).FirstOrDefault();
            if (exist == null)
            {
                SampleContext.PCVMS_Project_Scheme.Add(Assign);
            }
            else

           {
                exist.Permission_Scheme_ID = PCVMS_Project_Scheme.Permission_Scheme_ID;
            }
            await SampleContext.SaveChangesAsync();
            return true;
        }

       public async Task<bool> AddProjectProperty(PCVMS_Property Obj)
        {
            var dbProperty= Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_Property>(Obj);
            if(Obj.ID== new Guid("00000000-0000-0000-0000-000000000000"))
            {
                SampleContext.PCVMS_Property.Add(dbProperty);
            }
            else
             {
                var Exist =await SampleContext.PCVMS_Property.FindAsync(Obj.ID);
                if(Exist!=null)
                {
                    Exist.CardId = dbProperty.CardId;
                    Exist.Email = dbProperty.Email;
                    Exist.Fax = dbProperty.Fax;
                    Exist.LandLine = dbProperty.LandLine;
                    Exist.Mobile = dbProperty.Mobile;
                    Exist.Name = dbProperty.Name;
                    Exist.OwnerType = dbProperty.OwnerType;
                    Exist.PropertyNumber = dbProperty.PropertyNumber;
                    Exist.Remark = dbProperty.Remark;
                    
                }

            }
            await SampleContext.SaveChangesAsync();
            return true;

        }
        public async Task<dynamic> GetProjectProperty(Guid ProjectId)
        {
            var result = from p in SampleContext.PCVMS_Property
                         join pt in SampleContext.PCVMS_PropertyType on p.OwnerType equals pt.ID
                         where p.ProjectId== ProjectId
                         select new { ID=p.ID ,NameEn=pt.NameEn, NameAr= pt.NameAr,
                             Name=p.Name,
                             CardId=p.CardId,
                             PropertyNumber=p.PropertyNumber,
                             Email = p.Email,
                             Landline = p.LandLine,
                             Mobile= p.Mobile,
                             Fax = p.Fax,
                             Remark=p.Remark,
                             PropertyId=p.OwnerType
                         };

            return await result.ToListAsync<dynamic>();
        }
        public async Task<bool> AssignRole(PCVMS_Project_Role PCVMS_Project_Role)
        {
            var Assign = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_Project_Role>(PCVMS_Project_Role);
            SampleContext.PCVMS_Project_Role.Add(Assign);
            //relating role to scheme
            var roleschem = SampleContext.PCVMS_Role_Scheme.Where(w => w.RoleId == PCVMS_Project_Role.RoleId && w.SchemeId == PCVMS_Project_Role.SchemeId).FirstOrDefault();

            if (roleschem == null)
            {
                PCVM.MsSql.Entities.PCVMS_Role_Scheme objRolescheme = new PCVM.MsSql.Entities.PCVMS_Role_Scheme();
                objRolescheme.RoleId = PCVMS_Project_Role.RoleId;
                objRolescheme.SchemeId = PCVMS_Project_Role.SchemeId;
                objRolescheme.Deleted = false;
                SampleContext.PCVMS_Role_Scheme.Add(objRolescheme);
            }
            await SampleContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<PCVMS_Roles>> GetProjectRole(Guid ProjectId)
        {
            // Initialization.  
            List<PCVMS_Roles> lst = new List<PCVMS_Roles>();

            try
            {
                // Settings.  
                Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@ProjectId", ProjectId);


                
                var list = await SampleContext.PCVMS_Roles.FromSqlRaw("exec spGetProjectRole @ProjectId", usernameParam).ToListAsync();
                 lst = Mappings.Mapper.Map<List<PCVMS_Roles>>(list);
            }
            catch (Exception ex)
            {
                // throw ex;
            }

            // Info.  
            return lst;
        }
        public async Task<List<PCVMS_Roles>> GetProjectUserRole(Guid ProjectId, Guid UserId)
        {
            // Initialization.  
            List<PCVMS_Roles> lst = new List<PCVMS_Roles>();

            try
            {
                // Settings.  
                Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@ProjectId", ProjectId);
                Microsoft.Data.SqlClient.SqlParameter usernameParam1 = new Microsoft.Data.SqlClient.SqlParameter("@UserId", UserId);



                var list = await SampleContext.PCVMS_Roles.FromSqlRaw("exec spGetProjectRole @ProjectId,@UserId", usernameParam, usernameParam1).ToListAsync();
                lst = Mappings.Mapper.Map<List<PCVMS_Roles>>(list);
            }
            catch (Exception ex)
            {
                // throw ex;
            }

            // Info.  
            return lst;
        }
        public async Task<List<PCVMS_Permission>> GetSchemaPermission(Guid SchemaId)
        {
            var query = from f in SampleContext.PCVMS_Permission_Scheme
                        join p in SampleContext.PCVMS_Permission on f.Permission_ID equals p.ID
                        where f.Permission_Scheme_ID == SchemaId
                        select p;

          var result= await query.ToListAsync();
          return   Mappings.Mapper.Map<List<PCVMS_Permission>>(result);
           
        }
        
    }
}
