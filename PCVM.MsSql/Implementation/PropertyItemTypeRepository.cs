using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCVM.MsSql.Implementation
{
    public class PropertyItemTypeRepository : IPropertyItemType
    {
        public PropertyItemTypeRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }

        public async Task<PropertyItemType> Add(PropertyItemType obj)
        {

            var objPro = Mappings.Mapper.Map<PCVM.MsSql.Entities.PropertyItemType>(obj);
            SampleContext.PropertyItemType.Add(objPro);
            var ObjProperty = await SampleContext.SaveChangesAsync();
            obj = Mappings.Mapper.Map<PropertyItemType>(ObjProperty);
            return obj;
        }
    }
}
