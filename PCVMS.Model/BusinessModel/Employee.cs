using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCVMS.Model.BusinessModel;

namespace PCVMS.Model.BusinessModel
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid StructDivisionId { get; set; }
        public StructDivision StructDivision { get; set; }
        public bool IsHead { get; set; }

        public List<EmployeeRole> EmployeeRoles { get; set; }
    }
    public class EmployeeRole
    {
        public Guid EmployeeId { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
