using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVMS.Model.BusinessModel
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Comment { get; set; }
        public Guid AuthorId { get; set; }
        public Guid? ManagerId { get; set; }
        public decimal Sum { get; set; }
        public string State { get; set; }
        public string StateName { get; set; }
        public Employee Author { get; set;}
        public Employee Manager { get; set; }
    }
    public class DocumentTransitionHistory
    {
        public Guid Id { get; set; }
        public Guid ProcessId { get; set; }
        public Guid? IdentityId { get; set; }
        public Employee Employee { get; set; }
        public string AllowedToEmployeeNames { get; set; }
        public DateTime? TransitionTime { get; set; }
        public long Order { get; set; }
        public string InitialState { get; set; }
        public string DestinationState { get; set; }
        public string Command { get; set; }

    }
}
