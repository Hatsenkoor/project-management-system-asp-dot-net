using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PCVM.MsSql.Implementation
{
    public class PCVMS_DocumentsRepository : IPCVMS_Documents
    {
        private readonly SampleContext _sampleContext;

        public PCVMS_DocumentsRepository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public async Task<bool> addDocument(List<PCVMS_Documents> obj)
        {
            var Document = Mappings.Mapper.Map<List<PCVM.MsSql.Entities.PCVMS_Documents>>(obj);

            foreach(var d in obj)
            {
                var  exists = await _sampleContext.PCVMS_Documents.Where(w => w.ID == d.ID || (w.DocumentType == d.DocumentType && w.ParentId == d.ParentId && w.GroupID == d.GroupID)).FirstOrDefaultAsync();
           
                if (exists!=null)
                {
                    exists.DocumentPath = d.DocumentPath;                  
                    exists.DocumentName = d.DocumentName;
                }
                else
                {
                 var Notexist=   Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_Documents>(d);
                    _sampleContext.PCVMS_Documents.Add(Notexist);
                }
            }
            try
            {
                await _sampleContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
           
         
            return true;
        }
       public async Task<List<PCVMS_Documents>> GetDocumentByGroupId(Guid GroupId)
        {

            var DocumentList = await _sampleContext.PCVMS_Documents.Where(w => w.GroupID == GroupId && (w.Deleted == null || w.Deleted == false)).ToListAsync();
            var DocumentBusiness = Mappings.Mapper.Map<List<PCVMS_Documents>>(DocumentList);
            return DocumentBusiness;


        }
        public async Task<bool> SaveExcelRecords(List<PCVMS_Excel> list)
        {
            var dblist= Mappings.Mapper.Map<List<PCVM.MsSql.Entities.PCVMS_Excel>>(list);
            _sampleContext.PCVMS_Excel.AddRange(dblist);
            await _sampleContext.SaveChangesAsync();
            return true;

        }
        public async Task<PCVMS_Documents> GetDocumentById(Guid Id)
        {
            var query =await _sampleContext.PCVMS_Documents.Where(d =>d.ID== Id && (d.Deleted == null || d.Deleted == false)).FirstOrDefaultAsync();

            var DocumentBusiness = Mappings.Mapper.Map<PCVMS_Documents>(query);
            
            return DocumentBusiness;
        }

        public async Task<bool> AddParentToDocument(Guid GroupId,Guid ParentId)
        {
            var document =await _sampleContext.PCVMS_Documents.Where(w => w.GroupID == GroupId).ToListAsync();
            foreach(var d in document)
            {
                d.ParentId = ParentId;
            }

            await _sampleContext.SaveChangesAsync();
            return true;
        }
        public async Task<dynamic> DeleteDocument(Guid Id)
        

            {
                var query = await _sampleContext.PCVMS_Documents.FindAsync(Id);
                if (query != null)
                {
                    query.Deleted = true;
                    await _sampleContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }


            }
        
    }
}
