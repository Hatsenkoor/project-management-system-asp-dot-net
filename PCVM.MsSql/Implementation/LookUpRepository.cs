using PCVM.Business.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PCVMS.Model.BusinessModel;

namespace PCVM.MsSql.Implementation
{
    public class LookUpRepository : ILookUp
    {
        private readonly SampleContext _sampleContext;

        public LookUpRepository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }
        public async Task<List<PCVMS_CommonLookUp>> GetBuilindMaterialList(string Screen)
        {


            var result = from b in _sampleContext.PCVMS_BuildingMeterial
                         join t in _sampleContext.PCVMS_BuildingMeterialType on b.Type equals t.ID
                         where (b.Deleted == null || b.Deleted == false)
                         && (t.Deleted == null || t.Deleted == false)
                         && t.Screen==Screen
                         select new PCVMS_CommonLookUp
                         {
                             ID = b.ID,
                             TypeName = t.NameEn,
                             NameEn = b.NameEn,
                             NameAr = b.NameAr

                         };
            return await result.ToListAsync();


        }
        public async Task<List<PCVMS_CommonLookUp>> GetLookUpList(Guid Item)
        {


            var result = from b in _sampleContext.PCVMS_BuildingMeterial
                        
                         where (b.Deleted == null || b.Deleted == false)
                        
                         && b.Type == Item
                         select new PCVMS_CommonLookUp
                         {
                             ID = b.ID,
                             
                             NameEn = b.NameEn,
                             NameAr = b.NameAr

                         };
            return await result.ToListAsync();


        }
        public async Task<List<PCVMS_Governorates>> GetAllGovernorates()
        {
          var resutl=await  _sampleContext.PCVMS_Governorates.Where(w =>  w.Deleted==false || w.Deleted==null).ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Governorates>>(resutl);
            return Result;
        }
        public async Task<List<PCVMS_CommonLookUp>> GetAllProjectType()
        {
            var resutl = from p in _sampleContext.PCVMS_ProjectType
                         where p.Delated == false || p.Delated == null
                         select new PCVMS_CommonLookUp() { ID = p.ID, NameEn = p.NameEn, NameAr = p.NameAr };
            return await resutl.ToListAsync();
        }
        public async Task<List<PCVMS_Wilayat>> GetAllWilayat(Guid GovenorateID)
        {
            var resutl = await _sampleContext.PCVMS_Wilayat.Where(w => (w.Deleted != true || w.Deleted==null) && w.GovernorateID== GovenorateID).ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Wilayat>>(resutl);
            return Result;
        }
        public async Task<List<PCVMS_CommonLookUp>> GetLandUse()
        {
            var resutl = from g in _sampleContext.PCVMS_LandUser
                         where g.Deleted == false || g.Deleted == null
                         select new PCVMS_CommonLookUp() { ID = g.ID, NameEn = g.NameEn, NameAr = g.NameAr };
            return await resutl.ToListAsync();
        }
        public async Task<List<PCVMS_CommonLookUp>> GetSubLandUse(Guid LandUse)
        {
            var resutl = from g in _sampleContext.PCVMS_SubLandUse
                         where (g.Deleted == false || g.Deleted == null ) && g.LandUserId== LandUse
                         select new PCVMS_CommonLookUp() { ID = g.ID, NameEn = g.NameEn, NameAr = g.NameAr };
            return await resutl.ToListAsync();
        }
        public async Task<List<PCVMS_CommonLookUp>> GetActualLandUse(Guid SubLandUse)
        {
            var resutl = from g in _sampleContext.PCVMS_ActualLandUse
                         where (g.Deleted == false || g.Deleted == null) && g.SubLandUseId == SubLandUse
                         select new PCVMS_CommonLookUp() { ID = g.ID, NameEn = g.NameEn, NameAr = g.NameAr };
            return await resutl.ToListAsync();
        }
        public async Task<List<PCVMS_Villages>> GetAllVillage(Guid WilayatID)
        {
            var resutl = await _sampleContext.PCVMS_Villages.Where(w => (w.Deleted != true || w.Deleted == true) && w.WilayatID == WilayatID).ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Villages>>(resutl);
            return Result;
        }
        public async Task<List<PCVMS_CommonLookUp>> GetAllGeometry()
        {
            var resutl = from g in _sampleContext.PCVMS_Geometry
                         where g.Deleted == false || g.Deleted == null
                         select new PCVMS_CommonLookUp() { ID = g.ID, NameEn = g.NameEn, NameAr = g.NameAr };
           return await resutl.ToListAsync();

        }
        public async Task<List<PCVMS_CommonLookUp>> GetPropertyType()
        {
            var resutl = from g in _sampleContext.PCVMS_PropertyType
                         where g.Deleted == false || g.Deleted == null
                         select new PCVMS_CommonLookUp() { ID = g.ID, NameEn = g.NameEn, NameAr = g.NameAr };
            return await resutl.ToListAsync();

        }

        
    }
}
