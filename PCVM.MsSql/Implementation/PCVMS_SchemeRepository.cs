using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PCVM.MsSql.Implementation
{
    class PCVMS_SchemeRepository : IPCVMS_Scheme
    {
        public PCVMS_SchemeRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }

        public async Task<bool> AddProjectScheme(PCVMS_Scheme PCVMS_Scheme)
        {
            var Scheme = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_Scheme>(PCVMS_Scheme);
            SampleContext.PCVMS_Scheme.Add(Scheme);
            await SampleContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<PCVMS_Scheme>> GetAllSchemes()
        {
            var query = await SampleContext.PCVMS_Scheme.ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Scheme>>(query);
            return Result;
        }

        public async Task<List<PCVMS_Permission>> GetAllPermission()
        {
            var query = await SampleContext.PCVMS_Permission.ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Permission>>(query);
            return Result;
        }
        public async Task<bool> AddSchemePermission(Guid PermissionId,Guid SchemeId)
        {
            PCVM.MsSql.Entities.PCVMS_Permission_Scheme obj = new PCVM.MsSql.Entities.PCVMS_Permission_Scheme();
            obj.Permission_ID = PermissionId;
            obj.Permission_Scheme_ID = SchemeId;
            
            SampleContext.PCVMS_Permission_Scheme.Add(obj);
            await SampleContext.SaveChangesAsync();
            return true;
        }
    }
}
