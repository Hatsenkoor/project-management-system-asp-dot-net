using Microsoft.EntityFrameworkCore;
using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVM.MsSql.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SampleContext _sampleContext;

        public EmployeeRepository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public bool CheckRole(Guid employeeId, string roleName)
        {
            return _sampleContext.EmployeeRoles.Any(r => r.EmployeeId == employeeId && r.Role.Name == roleName);
        }

        public List<PCVMS.Model.BusinessModel.Employee> GetAll()
        {
      
            return _sampleContext.Employees
                                 .Include(x => x.StructDivision)
                                 .Include(x => x.EmployeeRoles)
                                 .ThenInclude(x => x.Role)
                                 .ToList().Select(e => Mappings.Mapper.Map<PCVMS.Model.BusinessModel.Employee>(e))
                                 .OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<string> GetInRole(string roleName)
        {
            return
                  _sampleContext.EmployeeRoles.Where(r => r.Role.Name == roleName).ToList()
                      .Select(r => r.EmployeeId.ToString()).ToList();
        }

        public string GetNameById(Guid id)
        {
            string res = "Unknown";
            
            var item = _sampleContext.Employees.Find(id);
            if (item != null)
                res = item.Name;
            
            return res;
        }
       
        public async Task<bool> AssignRole(Guid Empid,Guid RoleId,DateTime FromDate,DateTime EndDate)
        {
            var  ObjEmpRole = _sampleContext.EmployeeRoles.Where(e => e.EmployeeId == Empid && e.RoleId == RoleId ).FirstOrDefault();
            if(ObjEmpRole==null)
            {
                ObjEmpRole = new EmployeeRole();
                ObjEmpRole.EmployeeId = Empid;
                ObjEmpRole.RoleId = RoleId;
                ObjEmpRole.FromDate = FromDate;
                ObjEmpRole.EndDate = EndDate;
                _sampleContext.EmployeeRoles.Add(ObjEmpRole);
                await _sampleContext.SaveChangesAsync();
            }
            return true;
            
        }
    }
}
