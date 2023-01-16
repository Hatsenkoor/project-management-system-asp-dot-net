using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PCVMS.Model.Web
{
    public class DocumentModel
    {
        public Guid Id { get; set; }
        public int? Number { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        
        public Guid AuthorId { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Manager")]
        public Guid? ManagerId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Manager")]
        public string ManagerName { get; set; }

        [Display(Name = "Sum")]
        public decimal Sum { get; set; }

        [Display(Name = "State")]
        public string StateName { get; set; }

        public DocumentCommandModel[] Commands { get; set; }

        public Dictionary<string, string> AvailiableStates { get; set; }

        public DocumentModel ()
        {
            Commands = new DocumentCommandModel[0];
            AvailiableStates = new Dictionary<string, string>{};
            HistoryModel = new DocumentHistoryModel();
        }

        public string StateNameToSet { get; set; }

        public DocumentHistoryModel HistoryModel { get; set; }
    }

    public class DocumentCommandModel
    {
        public string key { get; set; }
        public string value { get; set; }
       // public OptimaJet.Workflow.Core.Model.TransitionClassifier Classifier { get; set; }
    }
    public class DocumentHistoryModel
    {
        public List<DocumentTransitionHistory> Items { get; set; }
    }
    public class DocumentListModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<DocumentModel> Docs { get; set; }
    }
}