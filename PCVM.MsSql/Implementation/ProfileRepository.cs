using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PCVM.MsSql.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PCVM.MsSql.Implementation
{
    class ProfileRepository : IProfileRepository
    {
        private readonly SampleContext _sampleContext;

        public ProfileRepository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }
        public async Task<PCVMS.Model.BusinessModel.PCVMS_Profile> addProfile(PCVMS.Model.BusinessModel.PCVMS_Profile objProfile)
        {
            var Profile = Mappings.Mapper.Map<PCVM.MsSql.Entities.PCVMS_Profile>(objProfile);
            var find = await _sampleContext.PCVMS_Profile.Where(w => w.CardId == objProfile.CardId).FirstOrDefaultAsync();
            if(find!=null)
            {
                find.Name = Profile.Name;
                find.RegistrationDate = Profile.RegistrationDate;
                find.RegistrationHQ = Profile.RegistrationHQ;
                find.PoBox = Profile.PoBox;
                find.Email = Profile.Email;
                find.LandLine = Profile.LandLine;
                find.Mobile = Profile.Mobile;

                find.Fax = Profile.Fax;
                find.Remark = Profile.Remark;
                find.ProfileId = Profile.ProfileId;
                
                await _sampleContext.SaveChangesAsync();
                objProfile.ID = find.ID;
            }
            else

            {
                Profile.StatusId = "1";// draf status
                 _sampleContext.PCVMS_Profile.Add(Profile);
                await _sampleContext.SaveChangesAsync();
                objProfile.ID = Profile.ID;
            }


           
            return objProfile;
        }

        public async Task<List<PCVMS.Model.BusinessModel.PCVMS_Profile>> GetProfile(Guid ProfileId)
        {
            var DBresult= await _sampleContext.PCVMS_Profile.Where(w => w.ProfileId == ProfileId && w.StatusId=="3" && (w.Deleted == false || w.Deleted == null)).ToListAsync();

           var business= Mappings.Mapper.Map<List<PCVMS.Model.BusinessModel.PCVMS_Profile>>(DBresult);
            return business;

        }

        public async Task<bool> SubmitProfile(Guid UserId, Guid ProfileId, string Comment)
        {

            PCVMS_ProfileStatusHistory objHistory = new PCVMS_ProfileStatusHistory();
            objHistory.StatusId = "2";
            objHistory.UserId = UserId;
            objHistory.UserComment = Comment;
            objHistory.ProfileId = ProfileId;
            _sampleContext.PCVMS_ProfileStatusHistory.Add(objHistory);
            var Profile = _sampleContext.PCVMS_Profile.Where(w => w.ID == ProfileId).FirstOrDefault();
            Profile.StatusId = "2";
            await _sampleContext.SaveChangesAsync();
            return true;


        }
        public async Task<dynamic> GetProfileUser(Guid ProfileId)
        {


            var query = from pp in _sampleContext.PCVMS_ProjectProfile
                        join p in _sampleContext.PCVMS_Profile on pp.ProfileId equals p.ID
                        join u in _sampleContext.PCVMS_User on p.ID equals u.ProfileId
                        where pp.ProfileId == ProfileId
                        select new { u.UserId, u.CardID, u.NameEn, u.nameAr, pp.ProfileId };

            return await query.ToListAsync<dynamic>();



        }
        public async Task<bool> AcceptProfile(Guid UserId, Guid ProfileId, string Comment)
        {

            PCVMS_ProfileStatusHistory objHistory = new PCVMS_ProfileStatusHistory();
            objHistory.StatusId = "3";
            objHistory.UserId = UserId;
            objHistory.UserComment = Comment;
            objHistory.ProfileId = ProfileId;
            _sampleContext.PCVMS_ProfileStatusHistory.Add(objHistory);
            var Profile = _sampleContext.PCVMS_Profile.Where(w => w.ID == ProfileId).FirstOrDefault();
            Profile.StatusId = "3";

            var allUsers = _sampleContext.PCVMS_User.Where(w => w.ProfileId == ProfileId);
            foreach(var a in allUsers)
            {
                a.Active = true;

            }
            await _sampleContext.SaveChangesAsync();
            return true;


        }
    }
}
