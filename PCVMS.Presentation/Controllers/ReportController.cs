using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCVMS.Model.BusinessModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using PCVM.Web.Helpers;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;
using static iTextSharp.text.Font;
using System.Drawing;
using System.Text.RegularExpressions;

namespace PCVM.Web.Controllers
{
    public class ReportController : Controller
    {

        public List<PaymentInvoice> lstPaymentInvoice = new List<PaymentInvoice>();

        IConfiguration configuration;
        string url;

        public IWebHostEnvironment Env { get; }
        public IOptions<Helpers.AppSettings> AppSettings { get; }

        public ReportController(IConfiguration configuration, IOptions<Helpers.AppSettings> appSettings, IWebHostEnvironment web)
        {
            AppSettings = appSettings;
            Env = web;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            this.configuration = configuration;
            url = this.configuration.GetSection("AppSettings:ApiUrl.Finance").Value;
        }

        public IActionResult Fertilizer()
        {
            return View();
        }
        public IActionResult Pesticide()
        {
            return View();
        }
        public IActionResult LabSample()
        {
            return View();
        }
        public IActionResult Invoice()
        {
            return View();
        }
        public IActionResult Miscellaneous()
        {
            return View();
        }

        public async Task<List<PaymentInvoice>> getAllInoice()
        {
            var UserId = CurrentUserSettings.GetCurrentUser(HttpContext);

            using (var objectClient = new ApiClient(AppSettings))
            {
                var result = await objectClient.Get<List<PaymentInvoice>>("API/FertilizerCertificate/GetPaymentInvoice/?userid=" + UserId, "");
                return result;
            }
        }

        public async Task<ActionResult> InvoiceDesign(int Id)
        {
            #region GENERAL

            string webRootPath = Env.WebRootPath;
            string rootPath = "";
            rootPath = Path.Combine(webRootPath, "font\\");

            BaseFont harman = BaseFont.CreateFont(rootPath + "Arial_Italic.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Create a font from the base font 
            iTextSharp.text.Font f_harman = new iTextSharp.text.Font(harman, 12);
            iTextSharp.text.Font f_harman_i = new iTextSharp.text.Font(harman, 12, iTextSharp.text.Font.ITALIC);

            ///////////////////////////////////
            BaseFont bfArialUniCode = BaseFont.CreateFont(rootPath + "Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Create a font from the base font 
            iTextSharp.text.Font font = new iTextSharp.text.Font(bfArialUniCode, 12);
            iTextSharp.text.Font fontB = new iTextSharp.text.Font(bfArialUniCode, 12, BOLD);
            iTextSharp.text.Font fonti = new iTextSharp.text.Font(bfArialUniCode, 12, iTextSharp.text.Font.ITALIC);


            var doc = new iTextSharp.text.Document(PageSize.A4);

            string directoryName = DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss");

            string path = Path.Combine(webRootPath, "pdf\\") + directoryName + "_Invoice.pdf";

            if (System.IO.File.Exists(path + ".pdf"))
            {
                System.IO.File.Copy(path + ".pdf", path + "_temp.pdf", true);
                System.IO.File.Delete(path + ".pdf");
            }

            //path = path + ".pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();


            PdfContentByte cb = writer.DirectContent;

            double docWidth = doc.PageSize.Width;
            double docHeight = doc.PageSize.Height;

            double rateX = 680.0 / docWidth;
            double rateY = 960.0 / docHeight;

            int center = Convert.ToInt32(docWidth / 2);

            //Add the cell to the table 
            int cellHeight = 25;
            int headerHeight = 30;


            //Create a regex expression to detect hebrew or arabic code points 
            const string regex_match_arabic_hebrew = @"[\u0600-\u06FF,\u0590-\u05FF]+";

            #endregion GENERAL

            #region Invoice Details

            try
            {

                using (var objectClient = new ApiClient(AppSettings))
                {

                    lstPaymentInvoice = await objectClient.Get<List<PaymentInvoice>>("API/FertilizerCertificate/GetPaymentInvoiceById?Id=" + Id, "");

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            #endregion Invoice details           

            #region BORDERS

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue start

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(5 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(955 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(675 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(5 / rateY));
            cb.SetLineWidth(1);
            cb.SetColorStroke(new BaseColor(Color.Blue));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue end


            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary green start

            // LEFT SIDE VERTICAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(17 / rateX), (float)(943 / rateY));

            //TOP HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(943 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            // RIGHT SIDE VERTICAL LINE
            cb.MoveTo((float)(663 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            //BOTTOM HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(17 / rateY));

            cb.SetLineWidth(3);
            // cb.SetColorStroke(new BaseColor(174, 47, 45));
            cb.SetColorStroke(new BaseColor(Color.ForestGreen));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary gray end
            ///


            #endregion BORDERS          

            #region Center TOP LOGO

            //////////////////////////////////////////////////////////////////////  png mark center logo

            String imageURL = Path.Combine(webRootPath, "images\\") + "logo_white.png";

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            jpg.ScaleToFit(100f, 100f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            jpg.SetAbsolutePosition((float)(docWidth - jpg.ScaledWidth) / 2, (float)(943 / rateY) - 100);

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(jpg);

            #endregion CENTER TOP LOGO

            #region LEFT SIDE HEADER
            ///////////////////////////////////////////////////////   header Text

            String header_text = "Sultanate of Oman";

            cb.SetColorFill(new BaseColor(0, 255, 0));
            PdfPTable tablehr1 = new PdfPTable(1);
            tablehr1.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr1.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr1.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 14;
            font.SetColor(0, 0, 0);
            PdfPCell texthr1 = new PdfPCell(new Phrase(header_text, font));
            texthr1.FixedHeight = (float)(60 / rateY);
            texthr1.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            texthr1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr1.PaddingTop = 0;
            texthr1.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr1.SetLeading((float)1.5, (float)1.3);
            texthr1.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr1.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr1.NoWrap = false;

            //Add the cell to the table 
            tablehr1.AddCell(texthr1);

            //Add the table to the document 
            PdfContentByte pcbhr1 = writer.DirectContent;
            tablehr1.TotalWidth = (float)(docWidth / rateX);
            tablehr1.WriteSelectedRows(0, -1, (float)(36 / rateX), (float)(950 / rateY), pcbhr1); // changed from 255 t 263 by harmanjeet on 7/4/2019
                                                                                                  ///////////////////////////////////////////////////////////


            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehr2 = new PdfPTable(1);
            tablehr2.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr2.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 10;
            font.SetColor(0, 0, 0);
            PdfPCell texthr2 = new PdfPCell(new Phrase("Ministry of Agriculture \n Fisheries Wealth & Water Resources", font));
            texthr2.FixedHeight = (float)(60 / rateY);
            texthr2.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            texthr2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr2.PaddingTop = 0;
            texthr2.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr2.SetLeading((float)1.5, (float)1.3);
            texthr2.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr2.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr2.NoWrap = false;

            //Add the cell to the table 
            tablehr2.AddCell(texthr2);

            //Add the table to the document 
            PdfContentByte pcbhr2 = writer.DirectContent;
            tablehr2.TotalWidth = (float)(docWidth / rateX);
            tablehr2.WriteSelectedRows(0, -1, (float)(36 / rateX), (float)(910 / rateY), pcbhr2); // changed from 255 t 263 by harmanjeet on 7/4/2019
                                                                                                  ///////////////////////////////////////////////////////////
            ///


            String header3_text = "Directorate General for Agriculture Development";

            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehr3 = new PdfPTable(1);
            tablehr3.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr3.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 10;
            font.SetColor(0, 0, 0);
            PdfPCell texthr3 = new PdfPCell(new Phrase(header3_text, font));
            texthr3.FixedHeight = (float)(60 / rateY);
            texthr3.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            texthr3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr3.PaddingTop = 0;
            texthr3.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr3.SetLeading((float)1.5, (float)1.3);
            texthr3.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr3.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr3.NoWrap = false;

            //Add the cell to the table 
            tablehr3.AddCell(texthr3);
            //Add the table to the document 
            PdfContentByte pcbhr3 = writer.DirectContent;
            tablehr3.TotalWidth = (float)(docWidth / rateX);
            tablehr3.WriteSelectedRows(0, -1, (float)(36 / rateX), (float)(875 / rateY), pcbhr3); // changed from 255 t 263 by harmanjeet on 7/4/2019

            /////////////////////////////////////////////////////////////////////////////////// Header End

            #endregion LEFT SIDE HEADER

            #region RIGHT SIDE HEADER
            ///////////////////////////////////////////////////////   header Text

            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehtop = new PdfPTable(1);
            tablehtop.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehtop.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehtop.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 14;  // changed font to italic font fonti by harmanjeet 0n 7/4/2019
            font.SetColor(0, 0, 0);
            PdfPCell texttop = new PdfPCell(new Phrase("سلطنة عمان", font));
            texttop.FixedHeight = (float)(60 / rateY);
            texttop.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            texttop.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texttop.PaddingTop = 0;
            texttop.PaddingRight = 0;
            texttop.BorderColor = new BaseColor(174, 47, 45);
            texttop.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texttop.NoWrap = false;

            //Add the cell to the table 
            tablehtop.AddCell(texttop);

            //Add the table to the document 
            PdfContentByte pcbhtop = writer.DirectContent;
            tablehtop.TotalWidth = (float)(docWidth);
            tablehtop.WriteSelectedRows(0, -1, (float)((-36) / rateX), (float)(950 / rateY), pcbhtop);

            cb.SetColorFill(new BaseColor(0, 0, 0));
            PdfPTable tablehr2r = new PdfPTable(1);
            tablehr2r.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr2r.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr2r.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 12;
            font.SetColor(0, 0, 0);
            PdfPCell texthr2r = new PdfPCell(new Phrase("وزارة الثروة الزراعية \n والسمكية وموارد المياه", font));
            texthr2r.FixedHeight = (float)(60 / rateY);
            texthr2r.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            texthr2r.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr2r.PaddingTop = 0;
            texthr2r.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr2r.SetLeading((float)1.5, (float)1.3);
            texthr2r.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr2r.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr2r.NoWrap = false;

            //Add the cell to the table 
            tablehr2r.AddCell(texthr2r);

            //Add the table to the document 
            PdfContentByte pcbhr2r = writer.DirectContent;
            tablehr2r.TotalWidth = (float)(docWidth);
            tablehr2r.WriteSelectedRows(0, -1, (float)((-36) / rateX), (float)(910 / rateY), pcbhr2r); // changed from 255 t 263 by harmanjeet on 7/4/2019
                                                                                                       ///////////////////////////////////////////////////////////
            ///


            String header3r_text = "المديرية العامة للأمن الغذائي";


            PdfPTable tablehr3r = new PdfPTable(1);
            tablehr3r.DefaultCell.FixedHeight = (float)(60f / rateY);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tablehr3r.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 

            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tablehr3r.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //Create a cell and add text to it 
            font.Size = 12;
            font.SetColor(0, 0, 0);
            PdfPCell texthr3r = new PdfPCell(new Phrase(header3r_text, font));
            texthr3r.FixedHeight = (float)(60 / rateY);
            texthr3r.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            texthr3r.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            texthr3r.PaddingTop = 0;
            texthr3r.PaddingRight = 0; // changed 10 to 0 by harmanjeet on april 7, 2019
            texthr3r.SetLeading((float)1.5, (float)1.3);
            texthr3r.BorderColor = new BaseColor(174, 47, 45); // added by harmanjeet on april 7, 2019
            texthr3r.BorderWidth = 0;
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            texthr3r.NoWrap = false;

            //Add the cell to the table 
            tablehr3r.AddCell(texthr3r);

            //Add the table to the document 
            PdfContentByte pcbhr3r = writer.DirectContent;
            tablehr3r.TotalWidth = (float)(docWidth);
            tablehr3r.WriteSelectedRows(0, -1, (float)(-36 / rateX), (float)(875 / rateY), pcbhr3r); // changed from 255 t 263 by harmanjeet on 7/4/2019

            /////////////////////////////////////////////////////////////////////////////////// Header End

            #endregion RIGHT SIDE HEADER

            #region Center TOP TITLE

            //////////////////////////////////////////////////////////////////////  png mark center logo

            String imageURLTitle = Path.Combine(webRootPath, "images\\") + "invoice.png";

            iTextSharp.text.Image imageTitle = iTextSharp.text.Image.GetInstance(imageURLTitle);
            imageTitle.ScaleToFit(300f, 50f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            imageTitle.SetAbsolutePosition((float)(docWidth - imageTitle.ScaledWidth) / 2, (float)(943 / rateY) - 150);

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageTitle);

            #endregion CENTER TOP TITLE          

            #region DISTIBUTOR SECTION

            PdfPTable table_distibutor = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_distibutor.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_distibutor.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            //string receipt_Date = "       التاريخ" + receiptObj.Receipt_Date + "       Date";
            //string distibutor_NO = "       الرقم" + receiptObj.Distibutor_No + "       Number";

            //Added by Harmanjeet on sept 12, 2022


            fontB.Size = 12;
            fontB.SetColor(0, 0, 255);

            font.Size = 10;
            font.SetColor(0, 0, 0);

            string dateInvoice = Convert.ToDateTime(lstPaymentInvoice[0].Trans_date).ToShortDateString();

            Font regular = new Font(FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.DARK_GRAY);
            Font bold = new Font(FontFamily.HELVETICA, 10, Font.BOLD);
            Phrase p = new Phrase("DATE: ", bold);
            p.Add(new Chunk(dateInvoice, regular));
            // PdfPCell cell = new PdfPCell(p);

            string Invoice_No = "الرقم: Number: " + lstPaymentInvoice[0].RegistrationNo;

            PdfPCell receipt_Date_Cell = new PdfPCell(p);
            receipt_Date_Cell.FixedHeight = (float)(cellHeight / rateY);
            receipt_Date_Cell.NoWrap = false;
            receipt_Date_Cell.PaddingTop = 0;
            receipt_Date_Cell.BorderColor = new BaseColor(174, 47, 45);
            receipt_Date_Cell.BorderWidth = 0;
            receipt_Date_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            receipt_Date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            receipt_Date_Cell.Colspan = 1;


            PdfPCell distibutor_NO_Cell = new PdfPCell(new Phrase(Invoice_No, font));
            distibutor_NO_Cell.FixedHeight = (float)(cellHeight / rateY);
            distibutor_NO_Cell.NoWrap = false;
            distibutor_NO_Cell.PaddingTop = 0;
            distibutor_NO_Cell.BorderColor = new BaseColor(0, 0, 0);
            distibutor_NO_Cell.BorderWidth = 0;
            distibutor_NO_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            distibutor_NO_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            distibutor_NO_Cell.Colspan = 1;

            table_distibutor.AddCell(distibutor_NO_Cell);
            table_distibutor.AddCell(receipt_Date_Cell);


            //Add the table to the document 
            PdfContentByte pcb_distibutor = writer.DirectContent;
            table_distibutor.TotalWidth = (float)(630 / rateX);
            table_distibutor.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(750 / rateY), pcb_distibutor);


            #endregion DISTIBUTOR SECTION


            #region BORDERS

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue start

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(5 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(955 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(675 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(955 / rateY));

            cb.MoveTo((float)(5 / rateX), (float)(5 / rateY));
            cb.LineTo((float)(675 / rateX), (float)(5 / rateY));
            cb.SetLineWidth(1);
            cb.SetColorStroke(new BaseColor(Color.Blue));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary blue end


            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary gray start

            // LEFT SIDE VERTICAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(17 / rateX), (float)(943 / rateY));

            //TOP HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(943 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            // RIGHT SIDE VERTICAL LINE
            cb.MoveTo((float)(663 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(943 / rateY));

            //BOTTOM HORIZONTAL LINE
            cb.MoveTo((float)(17 / rateX), (float)(17 / rateY));
            cb.LineTo((float)(663 / rateX), (float)(17 / rateY));

            cb.SetLineWidth(3);
            // cb.SetColorStroke(new BaseColor(174, 47, 45));
            cb.SetColorStroke(new BaseColor(Color.ForestGreen));
            cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  outer boundary gray end
            ///


            #endregion BORDERS

            #region ITEMS TABLE

            // PdfPTable table8 = new PdfPTable(4);
            PdfPTable tbl_Items = new PdfPTable(3);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            tbl_Items.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                tbl_Items.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            
            iTextSharp.text.Font headerFont;

            headerFont = new iTextSharp.text.Font(bfArialUniCode, 8);

            iTextSharp.text.Font cellFont;
            cellFont = new iTextSharp.text.Font(bfArialUniCode, 7);



            string Value = "Amount in OMR";
            string Element_Description = "Payment Details";
            string RegistrationNo = "Registration Number";


            PdfPCell Element_Description_Cell = new PdfPCell(new Phrase(Element_Description, headerFont));
            Element_Description_Cell.FixedHeight = (float)(headerHeight / rateY);
            Element_Description_Cell.NoWrap = false;
            Element_Description_Cell.PaddingTop = 0;
            Element_Description_Cell.BorderColor = new BaseColor(0, 0, 0);
            Element_Description_Cell.BorderWidth = 1;
            Element_Description_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            Element_Description_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell Value_Cell = new PdfPCell(new Phrase(Value, headerFont));
            Value_Cell.FixedHeight = (float)(headerHeight / rateY);
            Value_Cell.NoWrap = false;
            Value_Cell.PaddingTop = 0;
            Value_Cell.BorderColor = new BaseColor(0, 0, 0);
            Value_Cell.BorderWidth = 1;
            Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell RegistrationNo_Cell = new PdfPCell(new Phrase(RegistrationNo, headerFont));
            RegistrationNo_Cell.FixedHeight = (float)(headerHeight / rateY);
            RegistrationNo_Cell.NoWrap = false;
            RegistrationNo_Cell.PaddingTop = 0;
            RegistrationNo_Cell.BorderColor = new BaseColor(0, 0, 0);
            RegistrationNo_Cell.BorderWidth = 1;
            RegistrationNo_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
            RegistrationNo_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;


            tbl_Items.AddCell(Element_Description_Cell);
            tbl_Items.AddCell(Value_Cell);
            tbl_Items.AddCell(RegistrationNo_Cell);

            for (int i = 0; i < lstPaymentInvoice.Count; i++)
            {

                Value = Convert.ToString(lstPaymentInvoice[i].Amount);
                Element_Description = Convert.ToString(lstPaymentInvoice[i].PaymentType);
                RegistrationNo = Convert.ToString(lstPaymentInvoice[i].RegistrationNo);

                Value_Cell = new PdfPCell(new Phrase(Value, cellFont));
                Value_Cell.FixedHeight = (float)(cellHeight / rateY);
                Value_Cell.NoWrap = false;
                Value_Cell.Padding = 0;
                Value_Cell.BorderColor = new BaseColor(0, 0, 0);
                Value_Cell.BorderWidth = 1;
                Value_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                Value_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                Element_Description_Cell = new PdfPCell(new Phrase(Element_Description, cellFont));
                Element_Description_Cell.FixedHeight = (float)(cellHeight / rateY);
                Element_Description_Cell.NoWrap = false;
                Element_Description_Cell.Padding = 0;
                Element_Description_Cell.BorderColor = new BaseColor(0, 0, 0);
                Element_Description_Cell.BorderWidth = 1;
                Element_Description_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                Element_Description_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;


                RegistrationNo_Cell = new PdfPCell(new Phrase(RegistrationNo, cellFont));
                RegistrationNo_Cell.FixedHeight = (float)(cellHeight / rateY);
                RegistrationNo_Cell.NoWrap = false;
                RegistrationNo_Cell.Padding = 0;
                RegistrationNo_Cell.BorderColor = new BaseColor(0, 0, 0);
                RegistrationNo_Cell.BorderWidth = 1;
                RegistrationNo_Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                RegistrationNo_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                tbl_Items.AddCell(Value_Cell);
                tbl_Items.AddCell(Element_Description_Cell);
                tbl_Items.AddCell(RegistrationNo_Cell);


            }

            //Add the table to the document 
            PdfContentByte pcb8 = writer.DirectContent;
            tbl_Items.TotalWidth = (float)(docWidth - 50);

            tbl_Items.WriteSelectedRows(0, -1, (float)(30 / rateX), (float)(360 + cellHeight * lstPaymentInvoice.Count / rateY), pcb8);

            ////////////////////////////////////////////////////////////////////////////////////////////
            #endregion ITEMS TABLE

            #region Middle Line Divider
            /*
            String imageURL1 = Server.MapPath(".") + "/images/save.png";

            iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(imageURL1);
            jpg1.ScaleToFit(30f, 260f);

            jpg1.Alignment = Element.ALIGN_CENTER;

            jpg1.SetAbsolutePosition((float)(283.0), (float)350.0);
            doc.Add(jpg1);
            */
            ///////////////////////////////////   center logo end
            ///
            #endregion MIddle Line Divider

            #region UNDERLINE


            /////////////////////////////////////////////////////////////////////////////////////////////////////  note underline start

            // Underline for BackSit and Note fields

            // cb.MoveTo((float)((center - 16) / rateX), (float)(820 / rateY));
            //  cb.LineTo((float)((center + 100) / rateX), (float)(820 / rateY));
            /*
            cb.MoveTo((float)(580 / rateX), (float)(522 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(522 / rateY));

            cb.MoveTo((float)(600 / rateX), (float)(476 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(476 / rateY));

            cb.MoveTo((float)(360 / rateX), (float)(445 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(445 / rateY));

            cb.MoveTo((float)(360 / rateX), (float)(420 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(420 / rateY));

            cb.MoveTo((float)(360 / rateX), (float)(400 / rateY));
            cb.LineTo((float)(650 / rateX), (float)(400 / rateY));
            */


            // cb.SetLineWidth(1);
            // cb.SetColorStroke(new BaseColor(255, 0, 0));
            //cb.SetLineDash(0f, 0f);
            // cb.Stroke();

            /////////////////////////////////////////////////////////////////////////////////////////////////////  note underline end
            ///
            #endregion UNDERLINE           

            #region SIGNATURE SECTION             

            PdfPTable table_signature_row_2 = new PdfPTable(2);
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table_signature_row_2.DefaultCell.NoWrap = false;

            //Create a regex expression to detect hebrew or arabic code points 
            if (Regex.IsMatch("م الموافق", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
            {
                table_signature_row_2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            }

            string signature_Date = "  التاريخ" + DateTime.Now.ToShortDateString() + "    Date";
            string signature_receiver = "توقيع المستلم.................Receiver's Signature";

            font.Size = 10;
            font.SetColor(0, 0, 0);

            PdfPCell signature_date_Cell = new PdfPCell(new Phrase(signature_Date, font));
            signature_date_Cell.FixedHeight = (float)(cellHeight / rateY);
            signature_date_Cell.NoWrap = false;
            signature_date_Cell.PaddingTop = 0;
            signature_date_Cell.BorderColor = new BaseColor(174, 47, 45);
            signature_date_Cell.BorderWidth = 0;
            signature_date_Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            signature_date_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            signature_date_Cell.Colspan = 1;


            PdfPCell signature_receiver_Cell = new PdfPCell(new Phrase(signature_receiver, font));
            signature_receiver_Cell.FixedHeight = (float)(cellHeight / rateY);
            signature_receiver_Cell.NoWrap = false;
            signature_receiver_Cell.PaddingTop = 0;
            signature_receiver_Cell.BorderColor = new BaseColor(0, 0, 0);
            signature_receiver_Cell.BorderWidth = 0;
            signature_receiver_Cell.HorizontalAlignment = Element.ALIGN_LEFT;
            signature_receiver_Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            signature_receiver_Cell.Colspan = 1;

            table_signature_row_2.AddCell(signature_receiver_Cell);
            table_signature_row_2.AddCell(signature_date_Cell);

            //Add the table to the document 
            PdfContentByte pcb_signature_row2 = writer.DirectContent;
            table_signature_row_2.TotalWidth = (float)(630 / rateX);
            table_signature_row_2.WriteSelectedRows(0, -1, (float)(25 / rateX), (float)(280 / rateY), pcb_signature_row2);

            #endregion SIGNATURE SECTION

            #region Center TOP TITLE

            //////////////////////////////////////////////////////////////////////  png mark center logo

            String imageURLSignature = Path.Combine(webRootPath, "images\\") + "signature.jpg";
            //String imageURLSignature = Path.Combine(webRootPath, "images\\") + "fertilizer_certificate.png";
            iTextSharp.text.Image imageSignature = iTextSharp.text.Image.GetInstance(imageURLSignature);
            imageSignature.ScaleToFit(120f, 90f);
            // jpg.SetAbsolutePosition(doc.PageSize.Width - 36f - 310f, doc.PageSize.Height - 36f - 72f);
            imageSignature.SetAbsolutePosition((float)(docWidth - imageSignature.ScaledWidth) / 2, (float)(100 / rateY));

            //jpg.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageSignature);

            #endregion CENTER TOP TITLE     


            doc.Close();

            string urlPdf = "/pdf/" + directoryName + "_Invoice.pdf";
            return Json(new { url = urlPdf });

        }
    }
}
