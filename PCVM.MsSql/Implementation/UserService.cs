using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Configuration;
using PCVMS.Model.Web;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PCVM.MsSql.Implementation
{
    public class UserRepository : IUserService
    {
        private readonly SampleContext _sampleContext;

        public UserRepository()
        {

        }
        public UserRepository(IOptions<AppSettings> appSettings, SampleContext sampleContext)
        {
            _appSettings = appSettings.Value;
            _sampleContext = sampleContext;

        }
        private readonly AppSettings _appSettings;
        public async Task<PCVMS.Model.BusinessModel.PCVMS_User> IsValidUser(string userName, string password)
        {

            var query = _sampleContext.PCVMS_User.Where(s => s.Email == userName && s.Password == password);
            var result = // query.Include(x => x.UserRoles)


                       query.AsQueryable()
                        .Select(d => Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_User>(d)).FirstOrDefault();

            if (result != null)
            {

                var UserPermission = await _sampleContext.spGetUserPermission(result.UserId);
                result.PermissionList = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Permission>>(UserPermission);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<PCVMS.Model.BusinessModel.PCVMS_Permission>> GetUserPermission(Guid UserId)
        {
            try
            {
                var UserPermission = await _sampleContext.spGetUserPermission(UserId);
                return Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Permission>>(UserPermission);
            } catch (Exception ex)
            {

            }

            return null;
        }
        public async Task<List<UserRole>> GetUserRole(Guid UserId)
        {

            var query = from u in _sampleContext.PCVMS_User
                        join ur in _sampleContext.PCVMS_User_Role on u.UserId equals ur.UserId
                        join r in _sampleContext.PCVMS_Roles on ur.RoleId equals r.ID
                        where u.UserId == UserId
                        select new UserRole
                        {
                            UserId = u.UserId,
                            NameEn = r.NameEn




                        };
            var userRole = await query.ToListAsync<UserRole>();
            var query1 = from u in _sampleContext.PCVMS_User
                         join ug in _sampleContext.PCVMS_User_Group on u.UserId equals ug.UserId
                         join gr in _sampleContext.PCVMS_UserGroup_Role on ug.GroupId equals gr.UserGroupID
                         join r in _sampleContext.PCVMS_Roles on gr.RoleId equals r.ID
                         where u.UserId == UserId
                         select new UserRole
                         {
                             UserId = u.UserId,
                             NameEn = r.NameEn




                         };
            userRole.AddRange(await query1.ToListAsync<UserRole>());
            return userRole;
        }
        public async Task<List<UserRole>> GetUserRoleGroup(Guid UserId)
        {

            var query = from u in _sampleContext.PCVMS_User
                        join ur in _sampleContext.PCVMS_User_RoleGroups on u.UserId equals ur.UserId

                        join rg in _sampleContext.PCVMS_Role_GroupName on ur.RoleGroupId equals rg.ID

                        where u.UserId == UserId
                        select new UserRole
                        {
                            UserId = u.UserId,
                            NameEn = rg.RoleGroupNameEn


                        };
            return await query.ToListAsync<UserRole>();
        }
        public User Authenticate(string username, string password)
        {
            var user = new User();// _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            user.Username = username;
            user.Password = password;
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            //  var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Username.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public async Task<PCVMS_User> AddUser(PCVMS_User PCVMS_User)
        {
            var User = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_User>(PCVMS_User);
            var existing = _sampleContext.PCVMS_User.Where(w => w.UserId == PCVMS_User.UserId).FirstOrDefault();
            if (existing == null)
            {

                _sampleContext.PCVMS_User.Add(User);
            }
            else
            {

                existing.NameEn = PCVMS_User.NameEn;


                existing.Email = PCVMS_User.Email;
                existing.Mobile = PCVMS_User.Mobile;

                existing.CardID = PCVMS_User.CardID;
                existing.JobTitle = PCVMS_User.JobTitle;


                existing.Department = PCVMS_User.Department;
                existing.LandLine = PCVMS_User.LandLine;

                existing.Fax = PCVMS_User.Fax;
                existing.Remark = PCVMS_User.Remark;
                existing.ProfileId = PCVMS_User.ProfileId;
            }
            try
            {

                await _sampleContext.SaveChangesAsync();
            } catch (Exception ex)
            {

            }
            PCVMS_User.UserId = User.UserId;
            return PCVMS_User;
        }
        public async Task<bool> AddUserGrupName(string Name)
        {
            PCVM.MsSql.Entities.PCVMS_User_Group_Name obj = new PCVM.MsSql.Entities.PCVMS_User_Group_Name();
            obj.NameEn = Name;
            _sampleContext.PCVMS_User_Group_Name.Add(obj);
            await _sampleContext.SaveChangesAsync();
            return true;

        }
        public async Task<PCVMS_User> GetuserById(Guid UserId)
        {
            var query = await _sampleContext.PCVMS_User.Where(w => w.UserId == UserId).FirstAsync();
            var Result = Mappings.Mapper.Map<PCVMS.Model.BusinessModel.PCVMS_User>(query);
            return Result;
        }
        public async Task<List<PCVMS_User>> GetAllUsersByProfile(Guid ProfleId)
        {
            var query = await _sampleContext.PCVMS_User.Where(w => w.ProfileId == ProfleId).ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_User>>(query);
            return Result;
        }
        public async Task<List<PCVMS_User>> GetAllUsers()
        {
            var query = await _sampleContext.PCVMS_User.Where(w => w.Active == true).ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_User>>(query);
            return Result;
        }
        public async Task<dynamic> GetAllUsersForGrid()
        {
            var query = from u in _sampleContext.PCVMS_User
                        select new
                        {

                            UserId = u.UserId,
                            NameEn = u.NameEn,
                            Email = u.Email
                        };

            var Result = await query.ToListAsync<dynamic>();
            return Result;
        }
        public async Task<bool> AssignRole(Guid UserId, Guid RoleId, DateTime StartDate, DateTime EndDate)
        {
            PCVM.MsSql.Entities.PCVMS_User_Role obj = new PCVM.MsSql.Entities.PCVMS_User_Role();
            obj.UserId = UserId;
            obj.RoleId = RoleId;
            _sampleContext.PCVMS_User_Role.Add(obj);
            await _sampleContext.SaveChangesAsync();
            return true;


        }
        public async Task<List<PCVMS_User_Group_Name>> GetAllUserGroupName()
        {

            var query = await _sampleContext.PCVMS_User_Group_Name.Where(w => w.Deleted == false).ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_User_Group_Name>>(query);
            return Result;
        }
        public async Task<List<PCVMS_User_Group_Name>> GetUserGroupName(Guid UserId)
        {

            var query = from ug in _sampleContext.PCVMS_User_Group
                        join ugn in _sampleContext.PCVMS_User_Group_Name on ug.GroupId equals ugn.ID
                        where ug.UserId == UserId && ug.Deleted == false
                        select ugn;

            var data = await query.ToListAsync();
            var Result = Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_User_Group_Name>>(data);
            return Result;
        }
        public async Task<bool> AssignUserGroup(Guid GrupId, Guid UserId)
        {
            PCVM.MsSql.Entities.PCVMS_User_Group obj = new PCVM.MsSql.Entities.PCVMS_User_Group();
            obj.UserId = UserId;
            obj.GroupId = GrupId;
            _sampleContext.PCVMS_User_Group.Add(obj);
            await _sampleContext.SaveChangesAsync();
            return true;


        }

        public async Task<bool> AssignRoleGruop(Guid UserId, Guid RoleGroupId)
        {
            PCVM.MsSql.Entities.PCVMS_User_RoleGroups obj = new PCVM.MsSql.Entities.PCVMS_User_RoleGroups();
            obj.UserId = UserId;
            obj.RoleGroupId = RoleGroupId;
            _sampleContext.PCVMS_User_RoleGroups.Add(obj);
            await _sampleContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> AssignRoleToUserGruop(Guid RoleId, Guid GroupId)
        {
            PCVM.MsSql.Entities.PCVMS_UserGroup_Role obj = new PCVM.MsSql.Entities.PCVMS_UserGroup_Role();
            obj.RoleId = RoleId;
            obj.UserGroupID = GroupId;
            _sampleContext.PCVMS_UserGroup_Role.Add(obj);
            await _sampleContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<PCVMS_Project>> GetUserProject(Guid UserId)
        {
            // Initialization.  
            List<PCVMS_Project> lst = new List<PCVMS_Project>();

            try
            {
                // Settings.  
                Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserId", UserId);



                var list = await _sampleContext.PCVMS_Project.FromSqlRaw("exec spGetUserProject @UserId", usernameParam).ToListAsync();
                lst = Mappings.Mapper.Map<List<PCVMS_Project>>(list);
            }
            catch (Exception ex)
            {
                // throw ex;
            }

            // Info.  
            return lst;
        }

        public async Task<Fertilizer_Model> GetMociCompany(string crNo)
        {
           
            Fertilizer_Model MociRoot = new Fertilizer_Model();

            try
            {
                Uri uri = new Uri("https://10.26.1.19/moci/oss3ws/companyregistry/crinfo/v2.1");

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);

                string file = "integration.meca.gov.om.p12"; //ConfigurationManager.AppSettings["ITACertificateFile"].ToString();
                string FilePath = @"C:\Pesticide Design\PCVM.MsSql\keys\"; // ConfigurationManager.AppSettings["ITAClientCertificate"].ToString();

                //X509Certificate2 X509cert = new X509Certificate2((string)AppDomain.CurrentDomain.GetData(FilePath) + file, ConfigurationManager.AppSettings["ITAClientCertificatePwd"].ToString());

                X509Certificate2 X509cert = new X509Certificate2(FilePath + file, "passw0rd");
                //X509Certificate2 X509cert = new X509Certificate2(FilePath + file, ConfigurationManager.AppSettings["ITAClientCertificatePwd"].ToString());
                webRequest.ClientCertificates.Add(X509cert);

                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                string fileTemplatePath = @"C:\Pesticide Design\PCVM.MsSql\XmlSoapTemplates\GetCompanyData.xml";

                StreamReader sr = new StreamReader(fileTemplatePath);
                string postData = sr.ReadToEnd();
                sr.Close();
                postData = postData.Replace("#InRequestId#", DateTime.Now.ToString("ddMMyyHHmmss"));
                postData = postData.Replace("#InRequestDateTime#", DateTimeOffset.UtcNow.ToString("o"));
                postData = postData.Replace("#InServiceRequester#", "MECA_WSCR");
                postData = postData.Replace("#InPassword#", "M3CA_WSC8");
                postData = postData.Replace("#CrNumber#", crNo);

                string sRequiredDocumentTemplate = string.Empty;
                StringBuilder sbRequiredDocumentPostData = new StringBuilder();
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = postBytes.Length;
                webRequest.ContentType = "text/xml";
                webRequest.Method = "POST";
                Stream postStream = webRequest.GetRequestStream();
                postStream.Write(postBytes, 0, postBytes.Length);

                using (WebResponse response = webRequest.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        int startIndex = soapResult.IndexOf("<companyOverview>");
                        int endIndex = soapResult.IndexOf("</companyOverview>") + 18 - startIndex;
                        soapResult = soapResult.Substring(startIndex, endIndex);
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(soapResult);

                        //To remove the Activities node from XML

                        XmlNode root = doc.DocumentElement;

                        XmlNodeList nodes = doc.SelectNodes("//placesOfActivities");
                       
                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }

                        nodes = doc.SelectNodes("//investors");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }

                        nodes = doc.SelectNodes("//placesOfActivities");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }


                        nodes = doc.SelectNodes("//mortgages");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }

                        nodes = doc.SelectNodes("//auditors");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }

                        nodes = doc.SelectNodes("//signatories");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }

                        nodes = doc.SelectNodes("//legalStatus");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }

                        nodes = doc.SelectNodes("//address");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }

                        nodes = doc.SelectNodes("//contact");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }

                        nodes = doc.SelectNodes("//capital");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }

                        nodes = doc.SelectNodes("//fiscal");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }                       

                       

                        nodes = doc.SelectNodes("//registrationStatus");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }
                        
                        

                        nodes = doc.SelectNodes("//country");

                        for (int i = nodes.Count - 1; i >= 0; i--)
                        {
                            root.RemoveChild(nodes[i]);
                        }


                        string json = JsonConvert.SerializeXmlNode(doc);
                        MociRoot.MOCICompanyRoot = JsonConvert.DeserializeObject<MOCICompany.Root>(json.Replace("@", ""));

                        //PCVMS_User objPCVMS_User = new PCVMS_User();

                        //objPCVMS_User.NameEn = "Customer";
                        //objPCVMS_User.nameAr = "Customer";
                        //objPCVMS_User.Password = "1234";
                        //objPCVMS_User.Email = crNo;
                        //objPCVMS_User.Active = true;
                        //objPCVMS_User.Mobile = "93894475";
                        //var result = await SaveCustomer(objPCVMS_User);

                        return MociRoot;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetMociMobile(string crNo, string OTP)
        {
            try
            {
                // Uri uri = new Uri(ConfigurationManager.AppSettings["MociCRSrv2"].ToString());

                Uri uri = new Uri("https://10.26.1.19/moci/oss3ws/companyregistry/crinfo/v2.1");

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);

                string file = "integration.meca.gov.om.p12"; //ConfigurationManager.AppSettings["ITACertificateFile"].ToString();
                string FilePath = @"C:\Pesticide Design\PCVM.MsSql\keys\"; // ConfigurationManager.AppSettings["ITAClientCertificate"].ToString();

                //X509Certificate2 X509cert = new X509Certificate2((string)AppDomain.CurrentDomain.GetData(FilePath) + file, ConfigurationManager.AppSettings["ITAClientCertificatePwd"].ToString());

                X509Certificate2 X509cert = new X509Certificate2(FilePath + file, "passw0rd");
                //X509Certificate2 X509cert = new X509Certificate2(FilePath + file, ConfigurationManager.AppSettings["ITAClientCertificatePwd"].ToString());
                webRequest.ClientCertificates.Add(X509cert);

                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                string fileTemplatePath = @"C:\Pesticide Design\PCVM.MsSql\XmlSoapTemplates\GetCompanyData.xml";
                StreamReader sr = new StreamReader(fileTemplatePath);
                string postData = sr.ReadToEnd();
                sr.Close();
                postData = postData.Replace("#InRequestId#", DateTime.Now.ToString("ddMMyyHHmmss"));
                postData = postData.Replace("#InRequestDateTime#", DateTimeOffset.UtcNow.ToString("o"));
                postData = postData.Replace("#InServiceRequester#", "MECA_WSCR");
                postData = postData.Replace("#InPassword#", "M3CA_WSC8");
                // postData = postData.Replace("#InServiceRequester#", ConfigurationManager.AppSettings["MOCIWSUserName"].ToString());
                // postData = postData.Replace("#InPassword#", ConfigurationManager.AppSettings["MOCIWSPwd"].ToString());
                postData = postData.Replace("#CrNumber#", crNo);

                string sRequiredDocumentTemplate = string.Empty;
                StringBuilder sbRequiredDocumentPostData = new StringBuilder();
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = postBytes.Length;
                webRequest.ContentType = "text/xml";
                webRequest.Method = "POST";
                Stream postStream = webRequest.GetRequestStream();
                postStream.Write(postBytes, 0, postBytes.Length);

                using (WebResponse response = webRequest.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(soapResult);


                        postStream.Flush();
                        postStream.Close();

                        XmlNode mobile = doc.SelectSingleNode("//companyOverview/contact/mobile");

                        PCVMS_User objPCVMS_User = new PCVMS_User();

                        objPCVMS_User.NameEn = "Customer";
                        objPCVMS_User.nameAr = "Customer";
                        objPCVMS_User.Password = OTP;
                        objPCVMS_User.Email = crNo;
                        objPCVMS_User.Active = true;
                        objPCVMS_User.Mobile = mobile.InnerText;

                         var result = await SaveCustomer(objPCVMS_User);


                        return (mobile != null) ? mobile.InnerText : string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void SendSMS(string myData)
        //{
        //    myData = @"{'UserID': 'pf-project','Password': 'T@ssal74','Message' :'I am testing SMS Integration regards @@HARMAN','Language': '64','ScheddateTime': '01/22/2017 00:00:00','MobileNo' : ['96893894475'],'RecipientType': '1'}";
        //    string smsAPI = "https://ismartsms.net/RestApi/api/SMS/PostSMS";
        //    // build the request based on the supplied settings
        //    var request = WebRequest.Create(smsAPI);

        //    // supply the credentials
        //    request.Credentials = new NetworkCredential("pf-project", "T@ssal74");
        //    request.PreAuthenticate = true;
        //    // we want to use HTTP POST
        //    request.Method = "POST";
        //    // for this API, the type must always be JSON
        //    request.ContentType = "application/json";

        //    // Here we use Unicode encoding, but ASCIIEncoding would also work
        //    var encoding = new UnicodeEncoding();
        //    var encodedData = encoding.GetBytes(myData);

        //    // Write the data to the request stream
        //    var stream = request.GetRequestStream();
        //    stream.Write(encodedData, 0, encodedData.Length);
        //    stream.Close();

        //    // try ... catch to handle errors nicely
        //    try
        //    {
        //        // make the call to the API
        //        var response = request.GetResponse();

        //        // read the response and print it to the console
        //        var reader = new StreamReader(response.GetResponseStream());
        //        // Console.WriteLine(reader.ReadToEnd());


        //    }
        //    catch (WebException ex)
        //    {
        //        // show the general message
        //        Console.WriteLine("An error occurred:" + ex.Message);

        //        // print the detail that comes with the error
        //        var reader = new StreamReader(ex.Response.GetResponseStream());
        //        // Console.WriteLine("Error details:" + reader.ReadToEnd());
        //    }

        //}


        public Task<bool> SendSMS(SMS objSMS)
        {

            string myData = @"{'UserID': '"+objSMS.UserID +"','Password': '"+ objSMS.Password +"','Message' : '" +objSMS.Message + "','Language': '"+ objSMS.Language +"','ScheddateTime': '" + objSMS.ScheddateTime + "','MobileNo' : [" + objSMS.MobileNo +"],'RecipientType': '" + objSMS.RecipientType +"'}";

           
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ismartsms.net/RestApi/api/SMS/PostSMS");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(myData);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse =  (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            return Task.FromResult(true);
        }

        public async Task<bool> SaveCustomer(PCVMS_User  objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PCVMS_User>(objTransaction);

                var find = await _sampleContext.PCVMS_User.Where(w => w.Email == objTransaction.Email).FirstOrDefaultAsync();

                if (find != null)
                {

                    find.Password = objTransaction.Password;

                    await _sampleContext.SaveChangesAsync();
                    objTransaction.UserId = find.UserId;
                }
                else
                {
                    _sampleContext.PCVMS_User.Add(Transaction);
                    await  _sampleContext.SaveChangesAsync();
                    objTransaction.UserId = Transaction.UserId;
                }

                //Save Customer Role if not exist
                #region TO ADD Role for Customer

                PCVMS_User_Role objCustomer = new PCVMS_User_Role();
                objCustomer.RoleId = new Guid("1BFA98FB-A9AC-4A8E-A85B-6A9B1242B365");
                objCustomer.UserId = objTransaction.UserId;

                var RoleTransaction = Mappings.Mapper.Map<Entities.PCVMS_User_Role>(objCustomer);

                var Rolefind = await _sampleContext.PCVMS_User_Role.Where(w => w.UserId == objCustomer.UserId).FirstOrDefaultAsync();

                if (Rolefind == null)
                {
                    _sampleContext.PCVMS_User_Role.Add(RoleTransaction);
                    await _sampleContext.SaveChangesAsync();
                    objTransaction.UserId = Transaction.UserId;
                }

                #endregion



            }
            catch (Exception ex)
            {

            }

            return true;

        }

    }
}
