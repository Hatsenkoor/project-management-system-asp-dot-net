using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PCVM.MsSql.Entities;
using PCVM.Business.DataAccess;

namespace PCVM.MsSql.Implementation
{
  public  class PropertyRepository : IProperty
    {
        public PropertyRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
           
        }

        public SampleContext SampleContext { get; }
        public SecondContext secondContext { get; }


        public async Task<dynamic> GetPropertyByNumber(string PropertyNumber)
        {


            var result = from f in SampleContext.PCVMS_Property
                         join t in SampleContext.PCVMS_PropertyType on f.OwnerType equals t.ID
                         where f.PropertyNumber == PropertyNumber && (f.Deleted==null  || f.Deleted==false)
                         select new
                         {
                             Id = f.ID,
                             PropertyName=f.Name,
                             PropertyOwnerTypeEn = t.NameEn,
                             PropertyOwnerTypeAr = t.NameAr,
                             PropertyCardId = f.CardId,
                             PropertyNumber = f.PropertyNumber,
                             PropertyEmail = f.Email,
                             PropertyLandline = f.LandLine,
                             PropertyMobile = f.Mobile,
                             PropertyFax = f.Fax,
                             PropertyRemark = f.Remark

                         };
          return await  result.FirstOrDefaultAsync<dynamic>();
           

        }
       
        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyLandInfo> AddUpdateProjectInfo(PCVMS.Model.BusinessModel.PCVMS_PropertyLandInfo obj)
        {
            var Property = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_PropertyLandInfo>(obj);
            if (Property.ID == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                SampleContext.PCVMS_PropertyLandInfo.Add(Property);
            
            }
            else
            {
                var existing =await SampleContext.PCVMS_PropertyLandInfo.FindAsync(Property.ID);
                existing.ActualLandUse = Property.ActualLandUse;
                existing.AffectedBuildArea = Property.AffectedBuildArea;
                existing.AffectedLandArea = Property.AffectedLandArea;
                existing.LandUse = Property.LandUse;

                existing.RemainingBuildArea= Property.RemainingBuildArea;

                existing.RemainingLandArea = Property.RemainingLandArea;
                existing.Remark = Property.Remark;
                existing.SubLandUse = Property.SubLandUse;
                existing.TotalArea= Property.TotalArea;
                existing.TotalBuildAre = Property.TotalBuildAre;
                existing.PropertyId = Property.PropertyId;
             
            }
           
            await SampleContext.SaveChangesAsync();
            return  Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyLandInfo>(Property); ;

        }
       
        public async Task<bool> SaveTable<T>(T obj)
        {
            try { 
            SampleContext.Add(obj);
            var result = await SampleContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {

                SampleContext.Attach(obj);
                var result = await SampleContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyLandInfo> GetPropertyLandInfo(Guid PropertyId)
        {
          var result=  await SampleContext.PCVMS_PropertyLandInfo.Where(w => w.PropertyId == PropertyId && (w.Deleted == null || w.Deleted == false)).FirstOrDefaultAsync();
            return Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyLandInfo>(result); 
        }
        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyMeterial> AddUpdatePropertyMaterial(PCVMS.Model.BusinessModel.PCVMS_PropertyMeterial obj)
        {
            var Property = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_PropertyMeterial>(obj);
            if (Property.ID == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                SampleContext.PCVMS_PropertyMeterial.Add(Property);
            }
            else
            {
                var existing = await SampleContext.PCVMS_PropertyMeterial.FindAsync(Property.ID);
                existing.Type = Property.Type;
                
                existing.TotalArea = Property.TotalArea;
                existing.Note = Property.Note;


                Property = existing;
            }
            await SampleContext.SaveChangesAsync();
            return Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyMeterial>(Property); ;

        }

        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyWalls> AddPropertyWalls(PCVMS.Model.BusinessModel.PCVMS_PropertyWalls obj)
        {
            var Property = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_PropertyWalls>(obj);
            
                SampleContext.PCVMS_PropertyWalls.Add(Property);
          
            await SampleContext.SaveChangesAsync();
              return Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyWalls>(Property); ; ;

        }

        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyTree> AddPropertTree(PCVMS.Model.BusinessModel.PCVMS_PropertyTree obj)
        {
            var Property = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_PropertyTree>(obj);

            SampleContext.PCVMS_PropertyTree.Add(Property);

            await SampleContext.SaveChangesAsync();
            return Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyTree>(Property); ; ;

        }
        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyCrop> AddPropertCrop(PCVMS.Model.BusinessModel.PCVMS_PropertyCrop obj)
        {
            var Property = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_PropertyCrop>(obj);

            SampleContext.PCVMS_PropertyCrop.Add(Property);

            await SampleContext.SaveChangesAsync();
            return Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyCrop>(Property); ; ;

        }
        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyStorage> AddPropertStorage(PCVMS.Model.BusinessModel.PCVMS_PropertyStorage obj)
        {
            var Property = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_PropertyStorage>(obj);

            SampleContext.PCVMS_PropertyStorage.Add(Property);

            await SampleContext.SaveChangesAsync();
            return Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyStorage>(Property); ; ;

        }
        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyTank> AddPropertTank(PCVMS.Model.BusinessModel.PCVMS_PropertyTank obj)
        {
            var Property = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_PropertyTank>(obj);

            SampleContext.PCVMS_PropertyTank.Add(Property);

            await SampleContext.SaveChangesAsync();
            return Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyTank>(Property); ; ;

        }


        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyChannle> AddPropertChannel(PCVMS.Model.BusinessModel.PCVMS_PropertyChannle obj)
        {
            var Property = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_PropertyChannle>(obj);

            SampleContext.PCVMS_PropertyChannle.Add(Property);

            await SampleContext.SaveChangesAsync();
            return Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyChannle>(Property); ; ;

        }
        public async Task<PCVMS.Model.BusinessModel.PCVMS_PropertyItem> AddPropertItem(PCVMS.Model.BusinessModel.PCVMS_PropertyItem obj)
        {
            var Property = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_PropertyItem>(obj);

            SampleContext.PCVMS_PropertyItem.Add(Property);

            await SampleContext.SaveChangesAsync();
            return Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_PropertyItem>(Property); ; ;

        }

        public async Task<bool> SubmitProperty(Guid PropertyId)
        {

            var exist = await SampleContext.PCVMS_PropertyDraft.Where(w => w.PropertyId == PropertyId).FirstOrDefaultAsync();
                if(exist!=null)
            {
                return false;
            }
            var PropertyValueation = new PCVMS_PropertyDraft();
            PropertyValueation.PropertyId = PropertyId;
            PropertyValueation.CreatedDate = System.DateTime.Now;
            PropertyValueation.Active = true;
            var currenttime = System.DateTime.Now;
            var result = from f in SampleContext.PCVMS_ValuetionDraft
                         where f.Active == true && f.StartDate <= currenttime && f.EndDate >= currenttime
                         select new { f.ID };

            var Draft = await result.FirstOrDefaultAsync();
            PropertyValueation.DraftId = Draft.ID;
        
            SampleContext.PCVMS_PropertyDraft.Add(PropertyValueation);

           await SampleContext.SaveChangesAsync();
            return true;
        }
        public async Task<dynamic> GetPropertyMeterial(Guid PropertyId)
        {
            var query = from p in SampleContext.PCVMS_PropertyMeterial
                        join b in SampleContext.PCVMS_BuildingMeterial on p.Type equals b.ID
                        where p.PropertyId == PropertyId && (p.Deleted == null || p.Deleted == false)
                        select new
                        {
                            ID=p.ID,
                            NameEn = b.NameEn,
                            NameAr = b.NameAr,
                            TotalArea = p.TotalArea,
                            Note = p.Note


                        };

            return  await query.ToListAsync<dynamic>();

        }
        public async Task<dynamic> DeletePropertyMeterial(Guid Id)
        {
            var query = await SampleContext.PCVMS_PropertyMeterial.FindAsync(Id);
            if(query!=null)
            {
                query.Deleted = true;
             await   SampleContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
                     

        }
        public async Task<dynamic> GetPropertyTreeList(Guid PropertyId)
        {
            var query = from p in SampleContext.PCVMS_PropertyTree
                        join b in SampleContext.PCVMS_BuildingMeterial on p.TreeCode equals b.ID
                        join c in SampleContext.PCVMS_BuildingMeterial on p.TreeCategory equals c.ID
                        join d in SampleContext.PCVMS_BuildingMeterial on p.TreeType equals d.ID
                        join e in SampleContext.PCVMS_BuildingMeterial on p.TreeSize equals e.ID
                        where p.PropertyId == PropertyId && (p.Deleted == null || p.Deleted == false)
                        select new
                        {
                            ID = p.ID,
                            TreeCodeNameEn=b.NameEn,
                            TreeCodeNameAr = b.NameAr,
                            CategoryNameEn= c.NameEn,
                            CategoryNameAr = c.NameAr,
                            TypeNameEn = d.NameEn,
                            TypeNameAr = d.NameAr,
                            SizeNameEn = e.NameEn,
                            SizeNameAr = e.NameAr,
                            Number=p.Number

                        };

            return await query.ToListAsync<dynamic>();

        }
        public async Task<dynamic> DeletePropertyTree(Guid Id)
        {
            var query = await SampleContext.PCVMS_PropertyTree.FindAsync(Id);
            if (query != null)
            {
                query.Deleted = true;
                await SampleContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }


        }
        public async Task<dynamic> GetPropertyCropList(Guid PropertyId)
        {
            var query = from p in SampleContext.PCVMS_PropertyCrop
                        join b in SampleContext.PCVMS_BuildingMeterial on p.CropCode equals b.ID
                        join c in SampleContext.PCVMS_BuildingMeterial on p.CropType equals c.ID
                        join d in SampleContext.PCVMS_BuildingMeterial on p.CropName equals d.ID
                       
                        where p.PropertyId == PropertyId && (p.Deleted == null || p.Deleted == false)
                        select new
                        {
                            ID = p.ID,
                            CodeNameEn=b.NameEn,
                            CodeNameAr = b.NameAr,
                            TypeNameEn=c.NameEn,
                            TypeNameAr = c.NameAr,
                            CropNameEn=d.NameEn,
                            CropNameAr=d.NameAr,
                            Area=p.TotalArea,
                            Production=p.TotalProduction

                        };

            return await query.ToListAsync<dynamic>();

        }
        public async Task<dynamic> DeletePropertyCrop(Guid Id)
        {
            var query = await SampleContext.PCVMS_PropertyCrop.FindAsync(Id);
            if (query != null)
            {
                query.Deleted = true;
                await SampleContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }


        }
        public async Task<dynamic> GetPropertyWalls(Guid PropertyId)
        {
            var query = from p in SampleContext.PCVMS_PropertyWalls
                        join b in SampleContext.PCVMS_BuildingMeterial on p.Type equals b.ID
                        where p.PropertyId == PropertyId && (p.Deleted == null || p.Deleted == false)
                        select new
                        {
                            ID = p.ID,
                            NameEn = b.NameEn,
                            NameAr = b.NameAr,
                            Height = p.Height,
                            Thickness = p.Thickness,
                            Length = p.Length,
                            Line = p.Line


                        };

            return await query.ToListAsync<dynamic>();

        }
        public async Task<dynamic> DeletePropertyWalls(Guid Id)
        {
            var query = await SampleContext.PCVMS_PropertyWalls.FindAsync(Id);
            if (query != null)
            {
                query.Deleted = true;
                await SampleContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }


        }
        public async Task<dynamic> GetPropertyWells(Guid PropertyId)
        {
            var query = from p in SampleContext.PCVMS_PropertyStorage
                        join b in SampleContext.PCVMS_BuildingMeterial on p.WellsCode equals b.ID
                        join c in SampleContext.PCVMS_BuildingMeterial on p.Type equals c.ID
                        join d in SampleContext.PCVMS_BuildingMeterial on p.Description equals d.ID
                        join e in SampleContext.PCVMS_BuildingMeterial on p.Size equals e.ID
                        join f in SampleContext.PCVMS_BuildingMeterial on p.SoilType equals f.ID
                        join g in SampleContext.PCVMS_BuildingMeterial on p.Status equals g.ID
                        join h in SampleContext.PCVMS_BuildingMeterial on p.Cladding equals h.ID
                        join i in SampleContext.PCVMS_BuildingMeterial on p.CladSize equals i.ID
                        where p.PropertyId == PropertyId && (p.deleted == null || p.deleted == false)
                        select new
                        {
                            ID = p.ID,
                            WellCodeNameEn=b.NameEn,
                            WellCodeNameAr=b.NameAr,
                            TypeNameEn=c.NameEn,
                            TypeNameAr=c.NameAr,
                            DescriptionEn=d.NameEn,
                            DescriptionAr = d.NameAr,
                            SizeEn=e.NameEn,
                            SizeAr=e.NameAr,
                            SoilNameEn=f.NameEn,
                             SoilNameAr = f.NameAr,
                             StatusEn=g.NameEn,
                             StatusAr=g.NameAr,
                             CladdingNameEn=h.NameEn,
                            CladdingNameAr = h.NameAr,
                            CladSizeEn=i.NameEn,
                            CladSizeAr=i.NameAr
                        };

            return await query.ToListAsync<dynamic>();

        }


        public async Task<dynamic> DeletePropertyWells(Guid Id)
        {
            var query = await SampleContext.PCVMS_PropertyStorage.FindAsync(Id);
            if (query != null)
            {
                query.deleted = true;
                await SampleContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }


        }
        public async Task<dynamic> GetPropertyTank(Guid PropertyId)
        {
            var query = from p in SampleContext.PCVMS_PropertyTank
                        join b in SampleContext.PCVMS_BuildingMeterial on p.TankCode equals b.ID
                        join c in SampleContext.PCVMS_BuildingMeterial on p.TankType equals c.ID
                        join d in SampleContext.PCVMS_BuildingMeterial on p.TankDescription equals d.ID
                        join e in SampleContext.PCVMS_BuildingMeterial on p.Size equals e.ID
                        join f in SampleContext.PCVMS_BuildingMeterial on p.SoilType equals f.ID
                       // join g in SampleContext.PCVMS_BuildingMeterial on p.Status equals g.ID
                        join h in SampleContext.PCVMS_BuildingMeterial on p.Cladding equals h.ID
                        join i in SampleContext.PCVMS_BuildingMeterial on p.CladSize equals i.ID
                        where p.PropertyId == PropertyId && (p.Deleted == null || p.Deleted == false)
                        select new
                        {
                            ID = p.ID,
                            CodeNameEn = b.NameEn,
                            CodeNameAr = b.NameAr,
                            TypeNameEn = c.NameEn,
                            TypeNameAr = c.NameAr,
                            DescriptionEn = d.NameEn,
                            DescriptionAr = d.NameAr,
                            SizeEn = e.NameEn,
                            SizeAr = e.NameAr,
                            SoilNameEn = f.NameEn,
                            SoilNameAr = f.NameAr,
                           // StatusEn = g.NameEn,
                            //StatusAr = g.NameAr,
                            CladdingNameEn = h.NameEn,
                            CladdingNameAr = h.NameAr,
                            CladSizeEn = i.NameEn,
                            CladSizeAr = i.NameAr
                        };

            return await query.ToListAsync<dynamic>();
        }


        public async Task<dynamic> DeletePropertyTank(Guid Id)
        {
            var query = await SampleContext.PCVMS_PropertyTank.FindAsync(Id);
            if (query != null)
            {
                query.Deleted = true;
                await SampleContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }


        }


        public async Task<dynamic> GetPropertyChannel(Guid PropertyId)
        {
            var query = from p in SampleContext.PCVMS_PropertyChannle
                        join b in SampleContext.PCVMS_BuildingMeterial on p.ChannelCode equals b.ID
                        join c in SampleContext.PCVMS_BuildingMeterial on p.Type equals c.ID
                        join d in SampleContext.PCVMS_BuildingMeterial on p.Description equals d.ID
                        join e in SampleContext.PCVMS_BuildingMeterial on p.Cladding equals e.ID
                        
                        where p.PropertyId == PropertyId && (p.Deleted == null || p.Deleted == false)
                        select new
                        {
                            ID = p.ID,
                            CodeNameEn = b.NameEn,
                            CodeNameAr = b.NameAr,
                            TypeNameEn = c.NameEn,
                            TypeNameAr = c.NameAr,
                            DescriptionEn = d.NameEn,
                            DescriptionAr = d.NameAr,
                            CladdingNameEn = e.NameEn,
                            CladdingNameAr = e.NameAr,
                           Width=p.Width,
                           Height=p.Height,
                           Length=p.Length
                        };

            return await query.ToListAsync<dynamic>();
        }

        public async Task<dynamic> GetPropertyItemPrice(Guid PropertyId)
        {
            var query = from p in SampleContext.PCVMS_PropertyItemPrice
                        join pro in SampleContext.PCVMS_Property on p.ProjectId equals pro.ID
                        join m in SampleContext.PCVMS_BuildingMeterial on p.ItemId equals m.ID
                        where pro.ID == PropertyId
                        select new
                        {
                            PropertyName = pro.Name ,
                            ItemName=m.NameEn  ,
                            TotalPrice=p.TotalPrice


                        };
            return await query.ToListAsync<dynamic>();
        }

        public async Task<dynamic> DeletePropertyChannel(Guid Id)
        {
            var query = await SampleContext.PCVMS_PropertyChannle.FindAsync(Id);
            if (query != null)
            {
                query.Deleted = true;
                await SampleContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }


        }
        public async Task<dynamic> GetPropertyItem(Guid PropertyId)
        {
            var query = from p in SampleContext.PCVMS_PropertyItem
                        join b in SampleContext.PCVMS_BuildingMeterial on p.ItemCode equals b.ID
                        join c in SampleContext.PCVMS_BuildingMeterial on p.ItemType equals c.ID
                        join d in SampleContext.PCVMS_BuildingMeterial on p.ItemDescription equals d.ID
                        join e in SampleContext.PCVMS_BuildingMeterial on p.ItemCondition equals e.ID

                        where p.PropertyId == PropertyId && (p.Deleted == null || p.Deleted == false)
                        select new
                        {
                            ID = p.ID,
                            CodeNameEn = b.NameEn,
                            CodeNameAr = b.NameAr,
                            TypeNameEn = c.NameEn,
                            TypeNameAr = c.NameAr,
                            DescriptionEn = d.NameEn,
                            DescriptionAr = d.NameAr,
                            Number=p.ItemNumber,
                            ConditionEn = e.NameEn,
                            ConditionAr= e.NameAr
                        };

            return await query.ToListAsync<dynamic>();
        }
        public async Task<dynamic> DeletePropertyItem(Guid Id)
        {
            var query = await SampleContext.PCVMS_PropertyItem.FindAsync(Id);
            if (query != null)
            {
                query.Deleted = true;
                await SampleContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
