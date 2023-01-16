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
    public class FertilizerCertificateRepository : IFertilizerCertificate
    {
        // Initialization.  
        List<Lookup_Master> lstLookUpMaster = new List<Lookup_Master>();

        List<Common.CertificateAnalysis> lstCertificateAnalysis = new List<Common.CertificateAnalysis>();

        List<FertilizerCertificate> lstCertificateStatus = new List<FertilizerCertificate>();
        
        public FertilizerCertificateRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }



        #region SAVE UPDATE CANCEL METHOD

        public async Task<string> SaveCertificate(FertilizerCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.FertilizerCertificate>(objTransaction);
                var total = 1;
                if (Transaction.Application_Type.Equals("local"))
                    total = SampleContext.FertilizerCertificate.Where(w => w.Application_Type == "local").Count();
                else
                    total = SampleContext.FertilizerCertificate.Where(w => w.Application_Type == "imported").Count();

                var find = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.Local_Certificate_Registration_No = total + "-"+ Transaction.Local_Certificate_Registration_No;
                    find.StatusId = "Saved";
                    find.Deleted = false;

                    find.Fertilizer_Type = Transaction.Fertilizer_Type;
                    find.Fertilizer_Type_ID = Transaction.Fertilizer_Type_ID;

                    find.Fertilizer_Subcategory = Transaction.Fertilizer_Subcategory;
                    find.Fertilizer_Subcategory_ID = Transaction.Fertilizer_Subcategory_ID;

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

                    SampleContext.FertilizerCertificate.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;
                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.ID);

        }

        public async Task<List<FertilizerCertificate>> SubmitCertificate(FertilizerCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.FertilizerCertificate>(objTransaction);

                var find = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

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

        public async Task<string> SaveOrganicAnalysis(Organic_Analysis objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.Organic_Analysis>(objTransaction);

                var find = await SampleContext.OrganicAnalysis.Where(w => w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {

                }
                else
                {
                    SampleContext.OrganicAnalysis.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;
                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.ID);

        }     

        public async Task<string> SaveChemicalAnalysis(Chemical_Analysis objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.Chemical_Analysis>(objTransaction);

                var find = await SampleContext.ChemicalAnalysis.Where(w => w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {

                }
                else
                {
                    SampleContext.ChemicalAnalysis.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;
                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.ID);
        }

        public async Task<List<Review_History>> SaveRemark(Review_History objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.Review_History>(objTransaction);

                var find = await SampleContext.ReviewHistory.Where(w => w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find == null)
                {
                    SampleContext.ReviewHistory.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;
                }
            }
            catch (Exception ex)
            {

            }

            return await GetAllRemark(objTransaction.CertificateID, objTransaction.Remark_Type);
        }

        public async Task<List<FertilizerCertificate>> RequestCertificateCancel(FertilizerCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.FertilizerCertificate>(objTransaction);

                var find = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

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
        public async Task<List<FertilizerCertificate>> CancelCertificate(FertilizerCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.FertilizerCertificate>(objTransaction);

                var find = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

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


        #endregion

        #region Approval Method

        public async Task<List<FertilizerCertificate>> SectionHeadApproval(FertilizerCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.FertilizerCertificate>(objTransaction);

                var find = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

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

        public async Task<List<FertilizerCertificate>> DirectorApproval(FertilizerCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.FertilizerCertificate>(objTransaction);

                var find = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

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

        public async Task<List<FertilizerCertificate>> RegistrationFee(FertilizerCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.FertilizerCertificate>(objTransaction);

                var find = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

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

        public async Task<List<FertilizerCertificate>> CertificateFee(FertilizerCertificate objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.FertilizerCertificate>(objTransaction);

                var find = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

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

        public async Task<List<FertilizerCertificate>> GetAllCertificate()
        {
            var Result = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<FertilizerCertificate>>(Result);
            return buResult;

        }

       public async Task<List<FertilizerCertificate>> GetCertificateById(Guid id)
        {
            var Result = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.ID == id).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<FertilizerCertificate>>(Result);
            return buResult;
        }

        public async Task<List<FertilizerCertificate>> GetAllCertificate(string application_type)
        {
            var Result = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.Application_Type == application_type).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<FertilizerCertificate>>(Result);
            return buResult;

        }
        public async Task<List<FertilizerCertificate>> getAllSectionHeadCertificate()
        {
            var Result = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && (w.StatusId == "Review Application" || w.StatusId == "Director Review" || w.StatusId == "Approved" || w.StatusId == "Issued" || w.StatusId == "Director Review")).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<FertilizerCertificate>>(Result);
            return buResult;

        }

        public async Task<List<FertilizerCertificate>> getAllApprovedCertificate()
        {
            var Result = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && (w.StatusId == "Director Review")).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<FertilizerCertificate>>(Result);
            return buResult;

        }
        public async Task<List<FertilizerCertificate>> getAllPaymentCertificate()
        {
            var Result = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && (w.StatusId == "Approved")).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<FertilizerCertificate>>(Result);
            return buResult;

        }

        public async Task<List<FertilizerCertificate>> getAllIssuedCertificate()
        {
            var Result = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && (w.StatusId == "Issued")).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<FertilizerCertificate>>(Result);
            return buResult;

        }
        public async Task<List<FertilizerCertificate>> getAllCancelCertificate()
        {
            var Result = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && (w.StatusId == "Request Certificate Cancel" || w.StatusId == "Issued")).OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<FertilizerCertificate>>(Result);
            return buResult;

        }

        public async Task<List<FertilizerCertificate>> getAllCancelledCertificate()
        {
            var Result = await SampleContext.FertilizerCertificate.Where(w => w.Deleted == false && w.StatusId == "Cancelled").OrderByDescending(w => w.Requested_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<FertilizerCertificate>>(Result);
            return buResult;

        }


        public async Task<List<Organic_Analysis>> GetOrganicAnalysisByCertificateID(Guid ID)
        {
            var Result = await SampleContext.OrganicAnalysis.Where(w => w.CertificateID == ID).OrderByDescending(w => w.Updated_date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<Organic_Analysis>>(Result);
            return buResult;
        }

        public async Task<List<Review_History>> GetAllRemark(Guid CertificateID, String remark_type)
        {
            var Result = await SampleContext.ReviewHistory.Where(w => w.CertificateID == CertificateID && w.Remark_Type == remark_type).OrderByDescending(w => w.Created_date).ToListAsync();
            // removed the remark_type condition
            //var Result = await SampleContext.ReviewHistory.Where(w => w.CertificateID == CertificateID).OrderByDescending(w => w.Created_date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<Review_History>>(Result);

            return buResult;
        }


        public async Task<List<Chemical_Analysis>> GetChemicalAnalysisByCertificateID(Guid ID)
        {
            var Result = await SampleContext.ChemicalAnalysis.Where(w => w.CertificateID == ID).OrderByDescending(w => w.Updated_date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<Chemical_Analysis>>(Result);
            return buResult;
        }

        #endregion

        #region MASTER LIST

        public async Task<List<Lookup_Master>> GetMajorElementFormMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetMajorElementFormMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetMajorElementMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetMajorElementMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

       public async Task<List<Lookup_Master>> GetNatureMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetNatureMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetOrganicAnalysisMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetOrganicAnalysisMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetSecondaryElementMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetSecondaryElementMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetShapeMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetShapeMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetSubCategoryMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetSubCategoryMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetTraceElementFormMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetTraceElementFormMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetTraceElementMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetTraceElementMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetFertilizerTypeMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec fertilizer.GetTypeMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }


        #endregion MASTER LIST

        #region Analysis Dashboard

        public async Task<List<Common.CertificateAnalysis>> GetCertificateAnalysis(Guid userid)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserId", userid);
           
            var list = await SampleContext.CertificateAnalysis.FromSqlRaw("exec fertilizer.GetCertificateAnalysis @UserId", usernameParam).ToListAsync();
            lstCertificateAnalysis = Mappings.Mapper.Map<List<Common.CertificateAnalysis>>(list);
            
            return lstCertificateAnalysis;
        }            

        public async Task<List<FertilizerCertificate>> getReviewPendingCertificate(Guid userid)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserId", userid);

            var list = await SampleContext.FertilizerCertificate.FromSqlRaw("exec fertilizer.getReviewPendingCertificate @UserId", usernameParam).ToListAsync();
            lstCertificateStatus = Mappings.Mapper.Map<List<FertilizerCertificate>>(list);

            return lstCertificateStatus;

        }

        public async Task<List<FertilizerCertificate>> getApprovalPendingCertificate(Guid userid)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserId", userid);

            var list = await SampleContext.FertilizerCertificate.FromSqlRaw("exec fertilizer.getApprovalPendingCertificate @UserId", usernameParam).ToListAsync();
            lstCertificateStatus = Mappings.Mapper.Map<List<FertilizerCertificate>>(list);

            return lstCertificateStatus;

        }


        public async Task<List<Print>> GetCertificatePrint(Guid id)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@id", id);

            var list = await SampleContext.Print.FromSqlRaw("exec fertilizer.GetCertificatePrint @id", usernameParam).ToListAsync();
            List<Print> lstPrint = Mappings.Mapper.Map<List<Print>>(list);

            return lstPrint;

        }

        #endregion

    }
}
