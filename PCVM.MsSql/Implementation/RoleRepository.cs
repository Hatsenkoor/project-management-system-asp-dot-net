using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using Microsoft.EntityFrameworkCore;
namespace PCVM.MsSql.Implementation
{
    public class RoleRepository : IRoles
    {
        public RoleRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }

        public async  Task<bool> addRole(string RoleName)
        {
            Role ObjRole = new Role();
            ObjRole.Name = RoleName;
            ObjRole.Id = System.Guid.NewGuid();
            SampleContext.Roles.Add(ObjRole);
           await SampleContext.SaveChangesAsync();
            return true;
        }

        public   List<PCVMS.Model.BusinessModel.Role> GetAllRoles(Guid? EmployeeId=null)
        {
            if (EmployeeId == null)
            {
                var query = SampleContext.Roles.OrderBy(c => c.Name);

                return query.ToList()
                            .Select(d => Mappings.Mapper.Map<PCVMS.Model.BusinessModel.Role>(d)).ToList();
            }
            else
            {
                var role = SampleContext.Roles;
                var emprore = SampleContext.EmployeeRoles;
                var query = (from r in role
                             join emp in emprore on r.Id equals emp.RoleId
                             where emp.EmployeeId.Equals(EmployeeId)
                             select r);
                return query.ToList()
                            .Select(d => Mappings.Mapper.Map<PCVMS.Model.BusinessModel.Role>(d)).ToList();
            }
        }

        public async Task<PCVMS.Model.BusinessModel.Role> GetRole(Guid Id)
        {
            var Roles = await SampleContext.Roles.FindAsync(Id);
            var BusinessRole = Mappings.Mapper.Map<PCVMS.Model.BusinessModel.Role>(Roles);
            return BusinessRole;
        }

        //public async Task<dynamic> GetRolePermission()
        //{
        //    var Roles = from r in SampleContext.PCVMS_Roles
        //                join rp in SampleContext.PCVMS_Role_Permission on r.ID equals rp.RoleId
        //                join p in SampleContext.PCVMS_Permission on rp.PermissionId equals p.ID
            
        //    return BusinessRole;
        //}


    }
}
