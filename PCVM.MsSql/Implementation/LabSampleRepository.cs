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
    public class LabSampleRepository : ILabSample
    {
        List<Lookup_Master> lstLookUpMaster = new List<Lookup_Master>();

        public LabSampleRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }

        #region ALL SAVE UPDATE OPERATION
        public async Task<string> SaveImportExport(LabSample.ImportExport objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.LabSample.ImportExport>(objTransaction);

                var find = await SampleContext.ImportExport.Where(w => w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    /*find.ID = Transaction.ID;
                    find.IndicatorID = Transaction.IndicatorID;
                    find.ProjectID = Transaction.ProjectID;
                    find.TargetID = Transaction.TargetID;
                    find.Weight = Transaction.Weight;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                    */
                }
                else
                {
                    Transaction.StatusId = "Saved";
                    Transaction.Deleted = false;
                    
                    SampleContext.ImportExport.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;
                 
                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.ID);

        }

        public async Task<string> SaveSampleDetails(LabSample.SampleDetails objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.LabSample.SampleDetails>(objTransaction);

                var find = await SampleContext.SampleDetails.Where(w => w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    /*find.ID = Transaction.ID;
                    find.IndicatorID = Transaction.IndicatorID;
                    find.ProjectID = Transaction.ProjectID;
                    find.TargetID = Transaction.TargetID;
                    find.Weight = Transaction.Weight;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                    */
                }
                else
                {
                    Transaction.StatusId = "Saved";
                    Transaction.Deleted = false;

                    SampleContext.SampleDetails.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;

                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.ID);
        }
        public async Task<List<LabSample.SampleDetails>> GetSampleDetailsByID(Guid ID)
        {
            var Result = await SampleContext.SampleDetails.Where(w => w.Deleted == false && w.Sample_ID == ID).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<LabSample.SampleDetails>>(Result);
            return buResult;

        }
        public async Task<string> SaveLabAnalysis(LabSample.LabAnalysis objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.LabSample.LabAnalysis>(objTransaction);

                var find = await SampleContext.LabAnalysis.Where(w => w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    /*find.ID = Transaction.ID;
                    find.IndicatorID = Transaction.IndicatorID;
                    find.ProjectID = Transaction.ProjectID;
                    find.TargetID = Transaction.TargetID;
                    find.Weight = Transaction.Weight;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                    */
                }
                else
                {
                    Transaction.StatusId = "Saved";
                    Transaction.Deleted = false;

                    SampleContext.LabAnalysis.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;

                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.ID);
        }
        public async Task<LabSample.LabAnalysis> GetSampleAnalysisByID(Guid ID)
        {
            var Result = await SampleContext.LabAnalysis.Where(w => w.Deleted == false && w.Sample_ID == ID).FirstOrDefaultAsync();

            var buResult = Mappings.Mapper.Map<LabSample.LabAnalysis>(Result);
            return buResult;

        }
        public async Task<string> SaveLabResult(LabSample.LabResult objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.LabSample.LabResult>(objTransaction);

                var find = await SampleContext.LabResult.Where(w => w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    /*find.ID = Transaction.ID;
                    find.IndicatorID = Transaction.IndicatorID;
                    find.ProjectID = Transaction.ProjectID;
                    find.TargetID = Transaction.TargetID;
                    find.Weight = Transaction.Weight;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                    */
                }
                else
                {
                    Transaction.StatusId = "Saved";
                    Transaction.Deleted = false;

                    SampleContext.LabResult.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = Transaction.ID;

                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.ID);
        }
        public async Task<LabSample.LabResult> GetSampleResultByID(Guid ID)
        {
            var Result = await SampleContext.LabResult.Where(w => w.Deleted == false && w.Sample_ID == ID).FirstOrDefaultAsync();

            var buResult = Mappings.Mapper.Map<LabSample.LabResult>(Result);
            return buResult;

        }
        public async Task<List<LabSample.ImportExport>> SubmitSample(LabSample.ImportExport objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.LabSample.ImportExport>(objTransaction);

                var find = await SampleContext.ImportExport.Where(w => w.Deleted == false && w.ID == objTransaction.ID).FirstOrDefaultAsync();

                if (find != null)
                {
                    find.ID = Transaction.ID;
                    find.StatusId = Transaction.StatusId;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.ID = find.ID;
                }

                return await GetAllLabSample(find.App_Name);
            }
            catch (Exception ex)
            {
                return null;
            }

           
        }

        #endregion ALL SAVE UPDATE OPERATION


        public async Task<List<LabSample.PortMaster>> GetPortMaster()
        {
            var query = await SampleContext.PortMaster.ToListAsync();
            var Result = Mappings.Mapper.Map<List<LabSample.PortMaster>>(query);
            return Result;

        }

        public async Task<List<LabSample.CountryMaster>> GetCountryMaster()
        {
            var query = await SampleContext.CountryMaster.ToListAsync();
            var Result = Mappings.Mapper.Map<List<LabSample.CountryMaster>>(query);
            return Result;

        }

        public async Task<List<LabSample.AnalysisMaster>> GetAnalysisMaster()
        {
            var query = await SampleContext.AnalysisMaster.ToListAsync();
            var Result = Mappings.Mapper.Map<List<LabSample.AnalysisMaster>>(query);
            return Result;

        }

        public async Task<List<LabSample.LabMaster>> GetLabMaster()
        {
            var query = await SampleContext.LabMaster.ToListAsync();
            var Result = Mappings.Mapper.Map<List<LabSample.LabMaster>>(query);
            return Result;

        }

        public async Task<List<LabSample.SampleMaster>> GetSampleMaster()
        {

            var query = await SampleContext.SampleMaster.ToListAsync();
            var Result = Mappings.Mapper.Map<List<LabSample.SampleMaster>>(query);
            return Result;

        }

        public async Task<List<LabSample.SampleSourceMaster>> GetSampleSourceMaster()
        {
            var query = await SampleContext.SampleSourceMaster.ToListAsync();
            var Result = Mappings.Mapper.Map<List<LabSample.SampleSourceMaster>>(query);
            return Result;

        }

        public async Task<List<LabSample.FarmMaster>> GetFarmMaster()
        {
            var query = await SampleContext.FarmMasters.ToListAsync();
            var Result = Mappings.Mapper.Map<List<LabSample.FarmMaster>>(query);
            return Result;

        }

        public async Task<List<LabSample.ImportExport>> GetAllLabSample(string application_type)
        {
            var Result = await SampleContext.ImportExport.Where(w => w.Deleted == false && w.App_Name == application_type).OrderByDescending(w => w.Collection_Date).ToListAsync();

            var buResult = Mappings.Mapper.Map<List<LabSample.ImportExport>>(Result);
            return buResult;

        }

        public async Task<List<LabSample.CommodityTypeMaster>> GetCommodityTypeMaster()
        {
            var query = await SampleContext.CommodityTypeMaster.ToListAsync();
            var Result = Mappings.Mapper.Map<List<LabSample.CommodityTypeMaster>>(query);
            return Result;

        }

        public async Task<List<LabSample.CommodityNameMaster>> GetCommodityNameMaster()
        {
            var query = await SampleContext.CommodityNameMaster.ToListAsync();
            var Result = Mappings.Mapper.Map<List<LabSample.CommodityNameMaster>>(query);
            return Result;

        }

       

        #region MASTER LIST

        public async Task<List<Lookup_Master>> GetPaymentMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec dbo.GetPaymentMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetPackagingTypeMaster()
        {
            try
            {
                var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetPackagingTypeMaster").ToListAsync();
                lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
                return lstLookUpMaster;
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public async Task<List<Lookup_Master>> GetPackagingConditionMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetPackagingConditionMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetFindingMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetFindingMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetPesticideCommercialNameMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec Pesticide.GetCommonNameMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetPesticideUseMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec Pesticide.GetPesticideUseMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }
        public async Task<List<Lookup_Master>> GetFertilizerCommonNameMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec Fertilizer.GetCommonNameMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }
        public async Task<List<Lookup_Master>> GetFertilizerTypeMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec Fertilizer.GetFertilizerTypeMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetElementtobeAnalyzed()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec Fertilizer.GetElementtobeAnalyzed").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetPlantMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetPlantMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }
        public async Task<List<Lookup_Master>> GetInfectedPlantParts()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetInfectedPlantParts").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }
        public async Task<List<Lookup_Master>> GetCultivationTypeMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetCultivationTypeMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }
        public async Task<List<Lookup_Master>> GetIrrigationSystemMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetIrrigationSystemMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }
        public async Task<List<Lookup_Master>> GetInfectionSymptomsMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetInfectionSymptomsMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }
        public async Task<List<Lookup_Master>> GetInfectionInOnePlant()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetInfectionInOnePlant").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }
        public async Task<List<Lookup_Master>> GetInfectionInField()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetInfectionInField").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }

        public async Task<List<Lookup_Master>> GetPesticideTypeMaster()
        {
            var list = await SampleContext.Lookup_Master.FromSqlRaw("exec LabSample.GetPesticideTypeMaster").ToListAsync();
            lstLookUpMaster = Mappings.Mapper.Map<List<Lookup_Master>>(list);
            return lstLookUpMaster;
        }
        

        #endregion
    }
}
