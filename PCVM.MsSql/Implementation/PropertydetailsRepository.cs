
using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCVM.MsSql.Implementation
{
    public class PropertydetailsRepository : IPropertydetails
    {
        public PropertydetailsRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }

        public async Task<Propertydetails> Add(Propertydetails obj)
        {
            var objPro = Mappings.Mapper.Map<PCVM.MsSql.Entities.Propertydetails>(obj);
            SampleContext.Propertydetails.Add(objPro);
            var ObjProperty = await SampleContext.SaveChangesAsync();
            obj = Mappings.Mapper.Map<Propertydetails>(ObjProperty);
            return obj;
        }
    }
}
