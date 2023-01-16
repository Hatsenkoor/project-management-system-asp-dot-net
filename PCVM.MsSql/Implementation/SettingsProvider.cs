using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;


namespace PCVM.MsSql.Implementation
{
    public class SettingsProvider : ISettingsProvider
    {
        private readonly SampleContext _sampleContext;

        public SettingsProvider(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public Settings GetSettings()
        {
            var model = new Settings();

            var wfSheme = _sampleContext.WorkflowSchemes.FirstOrDefault(c => c.Code == model.SchemeName);
            if (wfSheme != null)
                model.WFSchema = wfSheme.Scheme;

            model.Employees = Mappings.Mapper.Map<IList<Employee>, List<PCVMS.Model.BusinessModel.Employee>>(
                _sampleContext.Employees.Include(x => x.StructDivision)
                                        .Include(x => x.EmployeeRoles)
                                        .ThenInclude(x => x.Role)
                                        .ToList()
            );

            model.Roles = Mappings.Mapper.Map<IList<Role>, List<PCVMS.Model.BusinessModel.Role>>(_sampleContext.Roles.ToList());

            model.StructDivision = Mappings.Mapper.Map<IList<StructDivision>, List<PCVMS.Model.BusinessModel.StructDivision>>(
                _sampleContext.StructDivisions.ToList()
            );

            return model;
            
        }
    }
}
