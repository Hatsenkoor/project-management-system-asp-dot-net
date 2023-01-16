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
    public class PaymentRepository : IPayment
    {

        List<PaymentInvoice> lstPaymentInvoice = new List<PaymentInvoice>();

        List<PaymentPesticide> lstPaymentPesticide = new List<PaymentPesticide>();

        public PaymentRepository(SampleContext sampleContext)
        {
            SampleContext = sampleContext;
        }

        public SampleContext SampleContext { get; }



        #region SAVE UPDATE CANCEL METHOD

        public async Task<string> SavePayment(Payment objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.Payment>(objTransaction);
               
                var find = await SampleContext.Payment.Where(w => w.Id == objTransaction.Id).FirstOrDefaultAsync();

                if (find != null)
                {
                  
                    find.PaymentType =objTransaction.PaymentType;
                   
                    find.tracking_id = objTransaction.tracking_id;

                    find.bank_ref_no = objTransaction.bank_ref_no;


                    find.order_status = objTransaction.order_status;


                    find.failure_message = objTransaction.failure_message;


                    find.payment_mode = objTransaction.payment_mode;


                    find.card_name = objTransaction.card_name;


                    find.status_code = objTransaction.status_code;


                    find.status_message = objTransaction.status_message;


                    find.currency = objTransaction.currency;


                    find.amount = objTransaction.amount;


                    find.trans_date = objTransaction.trans_date;


                    find.card_no = objTransaction.card_no;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.Id = find.Id;

                }
                else
                {                   
                    SampleContext.Payment.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.Id = Transaction.Id;
                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.Id);

        }

        public async Task<string> SavePaymentPesticide(PaymentPesticide objTransaction)
        {
            try
            {
                var Transaction = Mappings.Mapper.Map<Entities.PaymentPesticide>(objTransaction);

                var find = await SampleContext.PaymentPesticide.Where(w => w.Id == objTransaction.Id).FirstOrDefaultAsync();

                if (find != null)
                {

                    find.ServiceDescription = objTransaction.ServiceDescription;

                    find.ServiceType = objTransaction.ServiceType;

                    find.Service_ID = objTransaction.Service_ID;

                    find.amount = objTransaction.amount;

                    find.trans_date = objTransaction.trans_date;

                    await SampleContext.SaveChangesAsync();
                    objTransaction.Id = find.Id;

                }
                else
                {
                    SampleContext.PaymentPesticide.Add(Transaction);
                    await SampleContext.SaveChangesAsync();
                    objTransaction.Id = Transaction.Id;
                }

            }
            catch (Exception ex)
            {

            }

            return Convert.ToString(objTransaction.Id);
        }



        #endregion

        public async Task<List<PaymentInvoice>> GetPaymentInvoice(Guid userid)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserId", userid);

            var list = await SampleContext.PaymentInvoice.FromSqlRaw("exec dbo.getPaymentInvoice @UserId", usernameParam).ToListAsync();
            lstPaymentInvoice = Mappings.Mapper.Map<List<PaymentInvoice>>(list);

            return lstPaymentInvoice;
        }

        public async Task<List<PaymentInvoice>> GetPaymentInvoiceById(int Id)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@Id", Id);

            var list = await SampleContext.PaymentInvoice.FromSqlRaw("exec dbo.getPaymentInvoiceByID @Id", usernameParam).ToListAsync();
            lstPaymentInvoice = Mappings.Mapper.Map<List<PaymentInvoice>>(list);

            return lstPaymentInvoice;
        }

        public async Task<List<PaymentPesticide>> GetPaymentPesticideByCertificateID(Guid id)
        {
            // Settings.  
            Microsoft.Data.SqlClient.SqlParameter usernameParam = new Microsoft.Data.SqlClient.SqlParameter("@id", id);

            var list = await SampleContext.PaymentPesticide.FromSqlRaw("exec Pesticide.getPaymentByCertificateByID @id", usernameParam).ToListAsync();
            lstPaymentPesticide = Mappings.Mapper.Map<List<PaymentPesticide>>(list);

            return lstPaymentPesticide;
        }

    }
}
