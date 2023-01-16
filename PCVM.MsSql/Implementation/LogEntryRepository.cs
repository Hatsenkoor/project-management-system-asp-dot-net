using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCVM.MsSql.Implementation
{
    public class LogEntryRepository : ILogEntry
    {
        private readonly SampleContext _sampleContext;
        public LogEntryRepository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public  bool AddException(LogEntry obj)
        {
            var Log = Mappings.Mapper.Map<PCVM.MsSql.Entities.LogEntry>(obj);
            _sampleContext.LogEntry.Add(Log);
         var result=    _sampleContext.SaveChanges();
            return true;
        }
    }

}