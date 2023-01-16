using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PCVM.Business.DataAccess;
using System.Linq;

using PCVMS.Model.BusinessModel;

namespace PCVM.MsSql.Implementation
{
    public class SchemeMappingRepository : IFormSchemeMappingProvider
    {
        private readonly SampleContext _sampleContext;
        public SchemeMappingRepository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }
        public async  Task<FormSchemeMapping> Update(FormSchemeMapping obj)

        {
            var objNew= this.Find(obj.FormName);
            if (objNew != null)
            {
                
                objNew.FormName = obj.FormName;
                objNew.IsDeleted = false;
               
                objNew.SchemeName = obj.SchemeName;
               
                await _sampleContext.SaveChangesAsync();
              
            }
            return obj;
        }
        private PCVM.MsSql.Entities.FormSchemeMapping Find(string FormName)
        {

            var obj = _sampleContext.FormSchemeMapping.Where(w => w.FormName == FormName).FirstOrDefault();
         
            return obj;
        }
        public async Task<string> GetFromNameById(int nId)
        {
            var obj = await _sampleContext.FormSchemeMapping.FindAsync(nId);

            return obj.SchemeName;
        }
    }
}
