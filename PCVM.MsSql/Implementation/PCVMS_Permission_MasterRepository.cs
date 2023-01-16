using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCVM.MsSql.Implementation
{
    public class PCVMS_Permission_MasterRepository : IPCVMS_Permission_Master
    {
        private readonly SampleContext _sampleContext;
        public PCVMS_Permission_MasterRepository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }
        public List<PCVMS_Permission_Master> GetPermission()
        {
            var query = _sampleContext.PCVMS_Permission_Master;
          
           
            return query.ToList()
                        .Select(d => Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_Permission_Master>(d)).ToList();
        }
    }
}
