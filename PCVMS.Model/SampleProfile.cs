using AutoMapper;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVMS.Model.Web
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<DocumentModel, Document>()
                .ForMember(d => d.Author, o => o.MapFrom(s => new Employee { Id = s.AuthorId, Name = s.AuthorName }))
                .ForMember(d => d.Manager, o => o.MapFrom(s => s.ManagerId.HasValue ? new Employee { Id = s.ManagerId.Value, Name = s.ManagerName } : null));
            CreateMap<PCVMS.Model.BusinessModel.PCVMS_Project, PCVMS_Project_Model>();
            CreateMap<PCVMS_Project_Model, PCVMS.Model.BusinessModel.PCVMS_Project>();

            CreateMap<PCVMS_Project_Model, PCVMS.Model.BusinessModel.PCVMS_Scheme>();

            CreateMap<PCVMS_Profile, PCVMS.Model.BusinessModel.PCVMS_Profile>();


        }
    }
}
