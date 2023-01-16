using Microsoft.EntityFrameworkCore;
using PCVM.Business.DataAccess;
using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVM.MsSql.Implementation
{
    public class PesticideCertificateRepository : IPesticideCertificate
    {
        // Initialization.  
        List<Lookup_Master> lstLookUpMaster = new List<Lookup_Master>();

        List<Common.CertificateAnalysis> lstCertificateAnalysis = new List<Common.CertificateAnalysis>();

        List<PesticideCertificate> lstCertificateStatus = new List<PesticideCertificate>();

        public PesticideCertificateRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }

        #region SAVE UPDATE CANCEL METHOD
        public async Task<string> SaveCertificate(PesticideCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PesticideCertificate>(objTransaction);

                var total = 1;
                if (Transaction.Application_Type.Equals("local"))
                    total = SampleContext.FertilizerCertificate.Where(w => w.Application_Type == "local").Count();
                else
                    total = SampleContext.FertilizerCertificate.Where(w => w.Application_Type == "imported").Count();


                var find = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.Local_Registration_No = total + "-" + Transaction.Local_Registration_No;
                    find.StatusId = "Saved";
                    find.Deleted = false;
                    find.Certificate_Name = Transaction.Certificate_Name;
                    find.Certificate_Type_ID = Transaction.Certificate_Type_ID;
                    /*find.ID = Transaction.ID;
                    find.IndicatorID = Transaction.IndicatorID;
                    find.ProjectID = Transaction.ProjectID;
                    find.TargetID = Transaction.TargetID;
                    find.Weight = Transaction.Weight;
                      */
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }
                else
                {
                  
                    Transaction.StatusId = "Saved";
                    Transaction.Deleted = false;

                    SampleContext.PesticideCertificate.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;
                }

            }
            catch (Exception ex)
            {
                return Convert.ToString("failed"); 
            }

            return Convert.ToString(objTransaction.ID);

        }
        public async Task<List<PesticideCertificate>> SubmitCertificate(PesticideCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PesticideCertificate>(objTransaction);

                var find = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.ID = Transaction.ID;
                    find.StatusId = Transaction.StatusId;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }
            }
            catch (Exception ex)
            {

            }

            return await GetAllCertificate(objTransaction.Application_Type);
        }
        public async Task<string> SaveCommonName(Common_Name_Concentration objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.Common_Name_Concentration>(objTransaction);

                var find = await SampleContext.CommonNameConcentration.Where(w => w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {

                }
                else
                {

                    SampleContext.CommonNameConcentration.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;
                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.ID);

        }
        public async Task<List<PesticideCertificate>> RequestCertificateCancel(PesticideCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PesticideCertificate>(objTransaction);

                var find = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.ID = Transaction.ID;
                    find.StatusId = Transaction.StatusId;
                    find.CancelReason = Transaction.CancelReason;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }
            }
            catch (Exception ex)
            {

            }

            return await getAllCancelCertificate();
        }
        public async Task<List<PesticideCertificate>> CancelCertificate(PesticideCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PesticideCertificate>(objTransaction);

                var find = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.ID = Transaction.ID;
                    find.StatusId = Transaction.StatusId;
                    find.CancelReason = Transaction.CancelReason;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }
            }
            catch (Exception ex)
            {

            }

            return await getAllCancelCertificate();
        } 

        #endregion SAVE UPDATE CANCEL METHOD

        #region Approval Method
        public async Task<List<PesticideCertificate>> SectionHeadApproval(PesticideCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PesticideCertificate>(objTransaction);

                var find = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.ID = Transaction.ID;
                    find.StatusId = Transaction.StatusId;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }
            }
            catch (Exception ex)
            {

            }

            return await getAllSectionHeadCertificate();
        }
        public async Task<List<PesticideCertificate>> CommitteeApproval(PesticideCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PesticideCertificate>(objTransaction);

                var find = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.ID = Transaction.ID;
                    find.StatusId = Transaction.StatusId;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }
            }
            catch (Exception ex)
            {

            }

            return await getAllCommitteeCertificate();
        }

        public async Task<List<PesticideCertificate>> DirectorApproval(PesticideCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PesticideCertificate>(objTransaction);

                var find = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.ID = Transaction.ID;
                    find.StatusId = Transaction.StatusId;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }
            }
            catch (Exception ex)
            {

            }

            return await getAllApprovedCertificate();
        }

        #endregion


        #region PAYMENT METHOD
        public async Task<List<PesticideCertificate>> RegistrationFee(PesticideCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PesticideCertificate>(objTransaction);

                var find = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.ID = Transaction.ID;
                    find.RegistrationFee = Transaction.RegistrationFee;
                    find.StatusId = Transaction.StatusId;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }
            }
            catch (Exception ex)
            {

            }

            return await GetAllCertificate(objTransaction.Application_Type);
        }
        public async Task<List<PesticideCertificate>> CertificateFee(PesticideCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PesticideCertificate>(objTransaction);

                var find = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.ID = Transaction.ID;
                    find.StatusId = Transaction.StatusId;
                    find.CertificateFee = Transaction.CertificateFee;
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }
            }
            catch (Exception ex)
            {

            }

            return await getAllPaymentCertificate();
        }

        #endregion

        #region GET LIST

        public async Task<List<PesticideCertificate>> GetAllCertificate()
        {
            var Result = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<PesticideCertificate>>(Result);
            return buResult;

        }

        public async Task<List<PesticideCertificate>> GetAllCertificate(string application_type)
        {
            var Result = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.Application_Type == application_type).OrderByDescending(w=>w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<PesticideCertificate>>(Result);
            return buResult;

        }
        public async Task<List<PesticideCertificate>> getAllSectionHeadCertificate()
        {
            var Result = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && (w.StatusId == "Review Application" || w.StatusId == "Committee Review" || w.StatusId == "Director Review")).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<PesticideCertificate>>(Result);
            return buResult;

        }

        public async Task<List<PesticideCertificate>> getAllApprovedCertificate()
        {
            var Result = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.StatusId == "Director Review").OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<PesticideCertificate>>(Result);
            return buResult;

        }
        public async Task<List<PesticideCertificate>> getAllPaymentCertificate()
        {
            var Result = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.StatusId == "Approved").OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<PesticideCertificate>>(Result);
            return buResult;

        }

        public async Task<List<PesticideCertificate>> getAllIssuedCertificate()
        {
            var Result = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.StatusId == "Issued").OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<PesticideCertificate>>(Result);
            return buResult;

        }
        public async Task<List<PesticideCertificate>> getAllCancelCertificate()
        {
            var Result = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && (w.StatusId == "Request Certificate Cancel" || w.StatusId == "Issued")).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<PesticideCertificate>>(Result);
            return buResult;

        }

        #endregion

        #region ALL GET OPERATION
        public async Task<List<CAS_RN_Master>> getCASRNMasterList()
        {
           
                var query = await SampleContext.CASRNMasters.ToListAsync();
                var Result = Mappings.Mapper.Map<List<CAS_RN_Master>>(query);
                return Result;
           
        }
      
        public async Task<List<Chemical_Class_Master>> getChemicalClassMasterList()
        {
            var query = await SampleContext.Chemical_Class_Master.ToListAsync();
            var Result = Mappings.Mapper.Map<List<Chemical_Class_Master>>(query);
            return Result;
        }

        public async Task<List<Target_Pest_Master>> getTargetPestMasterList()
        {
            var query = await SampleContext.Target_Pest_Master.ToListAsync();
            var Result = Mappings.Mapper.Map<List<Target_Pest_Master>>(query);
            return Result;
        }

        public async Task<List<PesticideCertificate>> getAllCommitteeCertificate()
        {
            var Result = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && (w.StatusId == "Committee Review")).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<PesticideCertificate>>(Result);
            return buResult;
        }

        public async Task<List<Common_Name_Concentration>> getAllCommonName(Guid certificateID)
        {
            var Result = await SampleContext.CommonNameConcentration.Where(w => w.CertificateID == certificateID).OrderByDescending(w => w.Created_date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<Common_Name_Concentration>>(Result);
            return buResult;
        }

        #endregion ALL GET OPERATION

        #region MASTER LIST

        public async Task<List<Lookup_Master>> getCertificateMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec pesticide.getCertificateMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> getPesticideUseMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec pesticide.getPesticideUseMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> getTypeFormulationMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec pesticide.getTypeFormulationMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> getWHOToxicityMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec pesticide.getWHOToxicityMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> getCommonNameMaster()
        {

            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec pesticide.getCommonNameMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;

        }


        public async Task<List<Lookup_Master>> getServiceMaster()
        {

            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec pesticide.GetServiceMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;

        }

        #endregion

        #region Analysis Dashboard

        public async Task<List<Common.CertificateAnalysis>> GetCertificateAnalysis(Guid userid)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserId", userid);

            var list = await SampleContext.CertificateAnalysis.FromSqlRaw("exec pesticide.GetCertificateAnalysis @UserId", usernameParam).ToListAsync();
            lstCertificateAnalysis = Mappings.Mapper.Map<List<Common.CertificateAnalysis>>(list);

            return lstCertificateAnalysis;
        }

        public async Task<List<PesticideCertificate>> getReviewPendingCertificate(Guid userid)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserId", userid);

            var list = await SampleContext.PesticideCertificate.FromSqlRaw("exec pesticide.getReviewPendingCertificate @UserId", usernameParam).ToListAsync();
            lstCertificateStatus = Mappings.Mapper.Map<List<PesticideCertificate>>(list);

            return lstCertificateStatus;

        }

        public async Task<List<PesticideCertificate>> getApprovalPendingCertificate(Guid userid)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserId", userid);

            var list = await SampleContext.PesticideCertificate.FromSqlRaw("exec pesticide.getApprovalPendingCertificate @UserId", usernameParam).ToListAsync();
            lstCertificateStatus = Mappings.Mapper.Map<List<PesticideCertificate>>(list);

            return lstCertificateStatus;

        }

        #endregion

        public async Task<List<PesticideCertificate>> GetCertificateById(Guid id)
        {
            try
            {
                var Result = await SampleContext.PesticideCertificate.Where(w => w.Deleted == false && w.ID == id).OrderByDescending(w => w.Requested_Date).ToListAsync();

                var buResult = Mappings.Mapper.Map<List<PesticideCertificate>>(Result);
                return buResult;
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
