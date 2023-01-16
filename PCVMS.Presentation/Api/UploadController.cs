using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PCVM.Web.Helpers;
using PCVMS.Model.Web;
using PCVMS.Model.BusinessModel;

namespace PCVM.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        public IOptions<Helpers.AppSettings> AppSettings { get; }

        public UploadController(IOptions<PCVM.Web.Helpers.AppSettings> appSettings)
        {

            AppSettings = appSettings;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<List<PCVMS_Documents>> Upload(string Group)
        {
            Guid GroupId;
            if (Group != null)
            {
                GroupId = new Guid(Group.ToString());
            }
            else
            {
                GroupId = System.Guid.NewGuid();
            }
           
            var file = Request.Form.Files[0];
            List<Documents_Model> objModel = new List<Documents_Model>();
            Documents_Model NewObj;
            List<PCVMS_Documents> objDocumentList;
            foreach (var f in Request.Form.Files)
            {
                NewObj = new Documents_Model();
                NewObj.GroupID = GroupId;
                using (var memoryStream = new MemoryStream())
                {
                    await f.CopyToAsync(memoryStream);

                    NewObj.file = memoryStream.ToArray();
                    NewObj.DocumentName = f.Name;
                    

                }    

                    objModel.Add(NewObj);
            }


            var values = Newtonsoft.Json.JsonConvert.SerializeObject(objModel);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                 objDocumentList = await objectClient.Post<List<PCVMS_Documents>>("API/Upload/Upload", stringContent, "");
            }

            return objDocumentList;
        }



        [HttpPost]
        [Route("UploadProfileLogo")]
        public async Task<List<PCVMS_Documents>> UploadProfileLogo(string Group,string Id,string ProjectId, string DocumentType)
        {
            //if user not selected any record to attach document.
            if (ProjectId == null)
                return null;

            Guid GroupId;
            Guid ParentId;
            if (Group != null)
            {
                ParentId = System.Guid.NewGuid();
                GroupId = new Guid(Group.ToString());
            }
            else if(ProjectId!=null)
            {
                GroupId = new Guid(ProjectId.ToString());
                ParentId = new Guid(ProjectId.ToString());
            }
            else 
            {
                ParentId = System.Guid.NewGuid();
                GroupId = System.Guid.NewGuid();
            }

            var file = Request.Form.Files[0];
            List<Documents_Model> objModel = new List<Documents_Model>();
            Documents_Model NewObj;
            List<PCVMS_Documents> objDocumentList;
            foreach (var f in Request.Form.Files)
            {
                NewObj = new Documents_Model();
                NewObj.GroupID = GroupId;
                NewObj.ParentId = ParentId;
                NewObj.DocumentType = DocumentType;

                using (var memoryStream = new MemoryStream())
                {
                    await f.CopyToAsync(memoryStream);

                    NewObj.file = memoryStream.ToArray();
                    NewObj.DocumentName = f.Name;
                    if (!string.IsNullOrEmpty(Id))
                    {
                        NewObj.ID = new Guid(Id);
                    }

                }

                objModel.Add(NewObj);
            }


            var values = Newtonsoft.Json.JsonConvert.SerializeObject(objModel);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                objDocumentList = await objectClient.Post<List<PCVMS_Documents>>("API/Upload/Upload", stringContent, "");
            }

            return objDocumentList;
        }

        [HttpPost]
        [Route("UploadExecl")]
        public async Task<List<PCVMS_Documents>> UploadExecl(string ParentId,string Id)
        {

            Guid GroupId;
            Guid _ParentId;
            if (ParentId == "" || ParentId==null)
            {
                GroupId = System.Guid.NewGuid();
                _ParentId = GroupId;
            }
            else
            {
                GroupId = new Guid(ParentId.ToString());
                _ParentId = new Guid(ParentId.ToString());
            }
          

            var file = Request.Form.Files[0];
            List<Documents_Model> objModel = new List<Documents_Model>();
            Documents_Model NewObj;
            List<PCVMS_Documents> objDocumentList;
            foreach (var f in Request.Form.Files)
            {
                NewObj = new Documents_Model();
                NewObj.GroupID = GroupId;
                NewObj.ParentId = _ParentId;
                using (var memoryStream = new MemoryStream())
                {
                    await f.CopyToAsync(memoryStream);

                    NewObj.file = memoryStream.ToArray();
                    NewObj.DocumentName = f.Name;
                    if (!string.IsNullOrEmpty(Id))
                    {
                        NewObj.ID = new Guid(Id);
                    }

                }

                objModel.Add(NewObj);
            }


            var values = Newtonsoft.Json.JsonConvert.SerializeObject(objModel);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                objDocumentList = await objectClient.Post<List<PCVMS_Documents>>("API/Upload/UploadExcel", stringContent, "");
            }

            return objDocumentList;
        }


        [HttpPost]
        [Route("UploadPropertyDocument")]
        public async Task<List<PCVMS_Documents>> UploadPropertyDocument(string PropertyId,string Description)
        {

            Guid GroupId;
            Guid ParentId;
            
                GroupId = new Guid(PropertyId.ToString());
                ParentId = new Guid(PropertyId.ToString());
            

            var file = Request.Form.Files[0];
            List<Documents_Model> objModel = new List<Documents_Model>();
            Documents_Model NewObj;
            List<PCVMS_Documents> objDocumentList;
            foreach (var f in Request.Form.Files)
            {
                NewObj = new Documents_Model();
                NewObj.GroupID = GroupId;
                NewObj.ParentId = ParentId;
                using (var memoryStream = new MemoryStream())
                {
                    await f.CopyToAsync(memoryStream);

                    NewObj.file = memoryStream.ToArray();
                    NewObj.DocumentName = f.Name;
                    NewObj.Description = Description;


                    NewObj.ID = System.Guid.NewGuid();
                    

                }

                objModel.Add(NewObj);
            }


            var values = Newtonsoft.Json.JsonConvert.SerializeObject(objModel);
            var stringContent = new StringContent(values.ToString());
            using (var objectClient = new ApiClient(AppSettings))
            {
                stringContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                objDocumentList = await objectClient.Post<List<PCVMS_Documents>>("API/Upload/Upload", stringContent, "");
            }

            return objDocumentList;
        }
        [HttpGet]
        [Route("GetDocumentByParent")]
        public async Task<List<PCVMS_Documents>> GetDocumentByParent(Guid id)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var DocumentList = await objectClient.Get<List<PCVMS_Documents>>("API/Upload/GetDocumentByParent?id=" + id, "");
               
                return DocumentList;
            }

        }
        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> Download(string DocumentId, string Name)
        {
            using (var objectClient = new ApiClient(AppSettings))
            {
                var filearry= await objectClient.Get<byte[]>("API/Upload/Download?DocumentId="+ DocumentId, "");
                var contentType = "APPLICATION/octet-stream";
                
                switch (Name.Substring(Name.IndexOf(".")))
                {
                    case ".jpg":
                        // Statements executed if expression(or variable) = value1
                        contentType = "APPLICATION/jpg";
                        break;
                    case ".JPG":
                        // Statements executed if expression(or variable) = value1
                        contentType = "APPLICATION/jpg";
                        break;
                    case "pdf":
                        // Statements executed if expression(or variable) = value1
                        contentType = "APPLICATION/pdf";
                        break;
                     default:
                        // Statements executed if no case matches
                        break;
                }

                return File(filearry, contentType,Name);
            }
        }
        [HttpDelete]
        [Route("DeleteDocument")]
        public async Task<bool> DeleteDocument(Guid Id)
        {
            var id = "?Id=" + Id;

            using (var objectClient = new ApiClient(AppSettings))
            {

                var result = await objectClient.Delete<bool>("API/Upload/DeleteDocument", id);
                return true;
            }
        }
    }
}