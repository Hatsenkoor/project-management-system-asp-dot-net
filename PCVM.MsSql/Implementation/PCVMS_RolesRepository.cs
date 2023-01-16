using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PCVM.MsSql.Implementation
{
    public class PCVMS_RolesRepository : IPCVMS_Roles
    {

        public PCVMS_RolesRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }

        public async Task<bool> AddRoles(PCVMS_Roles objectRoles)
        {
            var Role = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_Roles>(objectRoles);
            SampleContext.PCVMS_Roles.Add(Role);
            await SampleContext.SaveChangesAsync();
            return true;
        }
        
        public async Task<List<PCVMS.Model.BusinessModel.PCVMS_Roles>> GetAllRoles(Guid? Level = null)
        {
            if (Level.HasValue)
            {
                var query = await SampleContext.PCVMS_Roles.Where(w => w.Permission_Master_ID == Level).ToListAsync();
                var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Roles>>(query);
                
                return Result;
            }
            else
            {

                var query = await SampleContext.PCVMS_Roles.ToListAsync();
                var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Roles>>(query);
                return Result;
            }
        }
        public async Task<List<PCVMS_Permission_Master>> GetPermissionMaster()
        {
            var query =await SampleContext.PCVMS_Permission_Master.ToListAsync();
    var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Permission_Master>>(query);
            return Result;

           
        }
        public async Task<List<PCVMS_Permission>> GetPermission()
        {
            var query = await SampleContext.PCVMS_Permission.ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Permission>>(query);
            return Result;
        }
        public async Task<bool> AddRolePermission(PCVMS_Role_Permission PCVMS_Permission)
        {

            var Role = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_Role_Permission>(PCVMS_Permission);
            SampleContext.PCVMS_Role_Permission.Add(Role);
            await SampleContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<PCVMS_Role_GroupName>> GetAllRoleGroups()
        {
            var query = await SampleContext.PCVMS_Role_GroupName.Where(w => w.Deleted == false).ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Role_GroupName>>(query);
            return Result;
        }
        public async Task<List<PCVMS_Permission>> GetRolePermission(Guid RoleId)
        {
            var query = from rp in SampleContext.PCVMS_Role_Permission
                        join p in SampleContext.PCVMS_Permission on rp.PermissionId equals p.ID
                        where rp.RoleId == RoleId
                        select p;
           var result=  await query.ToListAsync();

          return  Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Permission>>(query);

        }
    }
}
