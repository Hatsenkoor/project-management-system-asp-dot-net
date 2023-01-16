using Microsoft.EntityFrameworkCore;
using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVM.MsSql.Implementation
{
    public class ResourceRepository : IResource
    {
        public ResourceRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }

        public async Task<List<PCVMS_Resource>> GetAllResource()
        {
            try
            {
                var Result = await SampleContext.PCVMS_Resource.Where(w => w.Deleted == false).OrderBy(w => w.Name).ToListAsync();

                var buResult = Mappings.Mapper.Map<List<PCVMS_Resource>>(Result);
                return buResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> UpdateResource(PCVMS_Resource objTransaction)
        {
            var Transaction = Mappings.Mapper.Map<Entities.PCVMS_Resource>(objTransaction);

            Entities.PCVMS_Resource existName = null;
            var existKey = await SampleContext.PCVMS_Resource.Where(w => w.Deleted == false && w.Key == objTransaction.Key).FirstOrDefaultAsync();
            if (existKey == null)
             existName = await SampleContext.PCVMS_Resource.Where(w => w.Deleted == false && w.Key == objTransaction.Name).FirstOrDefaultAsync();



            if (existKey == null && existName == null)
            {

                PCVM.MsSql.Entities.PCVMS_Resource obj = new PCVM.MsSql.Entities.PCVMS_Resource();

                obj.Name = Transaction.Name;
                obj.Value = Transaction.Value;
                obj.Deleted = false;
                obj.Key = objTransaction.Name;
                SampleContext.PCVMS_Resource.Add(obj);
            }
            else

            {
                if (existKey != null)
                {
                    existKey.Value = Transaction.Value;
                    existKey.Name = Transaction.Name;
                }
                else if (existName != null)
                {
                    existName.Value = Transaction.Value;
                    existName.Name = Transaction.Name;
                }
            }
            await SampleContext.SaveChangesAsync();

            return objTransaction.ID.ToString();

        }
    }
}
