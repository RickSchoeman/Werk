using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Extras.InvoiceType;
using TwinfieldApi;
using TwinfieldApi.SalesInvoice;

namespace Demo
{
    class SalesInvoiceDemo
    {
        private const string SalesInvoiceType = "IVT";

        private readonly SalesInvoiceService salesInvoiceService;
        private readonly Session session;
        private SalesInvoiceSummary salesInvoiceSummary;
        private SalesInvoice salesInvoice;
        private IEnumerable<SalesInvoiceSummary> salesInvoices;

        public SalesInvoiceDemo(Session session)
        {
            this.session = session;
            salesInvoiceService = new SalesInvoiceService(session);
        }

        public void Run()
        {
            var lines = new List<Line>();
            var line = new Line
            {
                Article = "FRUIT",
                Subarticle = "BANAAN",
                Quantity = "3",
                Units = "1",
                Unitspriceexcl = "1"
            };
            lines.Add(line);
            var sales = new SalesInvoice
            {
                Header = new Header
                {
                    Office = session.Office,
                    Invoicetype = "FACTUUR",
                    Invoicedate = "20180412",
                    Duedate = "20181212",
                    Bank = "BNK",
                    Customer = "1002",
                    Period = "2018/4",
                    Currency = "EUR",
                    Status = "concept",
                    Paymentmethod = "cash"
                },
                Lines = new Lines
                {
                    Line = lines
                }
            };
//            salesInvoiceService.CreateSalesInvoice(sales);
//
//            if (!FindSalesInvoiceWithCustomerCode())
//            {
//                return;
//            }

            if (!ReadSalesInvoiceDetails())
            {
                return;
            }
            Console.WriteLine();
        }

//        private bool FindSalesInvoiceWithCustomerCode()
//        {
//            Console.WriteLine("Searching for sales invoices");
//
//            const int searchField = 0;
//            //hij haalt gegevens op die niet bestaan in de omgeving
//            var sInvoices = salesInvoiceService.FindSelesInvoices("*", SalesInvoiceType, searchField);
//            DisplaySalesInvoiceSummaries(sInvoices);
//
//            if (sInvoices.Count < 1)
//            {
//                return false;
//            }
//            else
//            {
//                this.salesInvoices = sInvoices;
//
//                salesInvoiceSummary = sInvoices.First();
//                return true;
//            }
//        }
        
        
        

        private bool ReadSalesInvoiceDetails()
        {
            Console.WriteLine("Read Sales Invoice details");
            var invoiceTypeDemo = new InvoiceTypeDemo(session);
            var invoiceTypes = invoiceTypeDemo.GetInvoiceTypeSummaries();
            for (int i = 0; i < invoiceTypes.Count; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    try
                    {
                        salesInvoice = salesInvoiceService.ReadSalesInvoice((j + 1).ToString(), invoiceTypes[i].Code);
                        DisplaySalesInvoiceDetails(salesInvoice);
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
            }
            return true;
        }

//        private static void DisplaySalesInvoiceSummaries(IEnumerable<SalesInvoiceSummary> salesInvoices)
//        {
//            foreach (var salesInvoice in salesInvoices)
//            {
//                Console.WriteLine("{0,-16} {1}", salesInvoice.Invoicenumber, salesInvoice.Name);
//            }
//            Console.WriteLine();
//        }

        private static void DisplaySalesInvoiceDetails(SalesInvoice salesInvoice)
        {
            Console.WriteLine("------");
            Console.WriteLine("Sales Invoice deatils of {0}:", salesInvoice.Header.Customer);
            Console.WriteLine("office = {0}", salesInvoice.Header.Office);
            Console.WriteLine("invoicetype = {0}", salesInvoice.Header.Invoicetype);
            Console.WriteLine("invoicedate = {0}", salesInvoice.Header.Invoicedate);
            Console.WriteLine("duedate = {0}", salesInvoice.Header.Duedate);
            Console.WriteLine("bank = {0}", salesInvoice.Header.Bank);
            Console.WriteLine("customer = {0}", salesInvoice.Header.Customer);
            Console.WriteLine("period = {0}", salesInvoice.Header.Period);
            Console.WriteLine("currency = {0}", salesInvoice.Header.Currency);
            Console.WriteLine("status = {0}", salesInvoice.Header.Status);
            Console.WriteLine("paymentmethod = {0}", salesInvoice.Header.Paymentmethod);
            Console.WriteLine("invoiceaddressnumber = {0}", salesInvoice.Header.Invoiceaddressnumber);
            Console.WriteLine("deliveraddressnumber = {0}", salesInvoice.Header.Deliveraddressnumber);
            Console.WriteLine("headertext = {0}", salesInvoice.Header.Headertext);
            Console.WriteLine("footertext = {0}", salesInvoice.Header.Footertext);
            Console.WriteLine("invoicenumber = {0}", salesInvoice.Header.Invoicenumber);
            Console.WriteLine("------");
            Console.WriteLine("Lines:");
            for (int i = 0; i < salesInvoice.Lines.Line.Count; i++)
            {
                if (!salesInvoice.Lines.Line[i].Equals(null) || salesInvoice.Lines.Line[i] != null || !salesInvoice.Lines.Line[i].Article.Equals("") || salesInvoice.Lines.Line[i].Article != "")
                {
                    var line = salesInvoice.Lines.Line[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Line: " + (i + 1));
                    Console.WriteLine("article = {0}", line.Article);
                    Console.WriteLine("subarticle = {0}", line.Subarticle);
                    Console.WriteLine("quantity = {0}", line.Quantity);
                    Console.WriteLine("units = {0}", line.Units);
                    Console.WriteLine("unitspricexcl = {0}", line.Unitspriceexcl);
                    Console.WriteLine("vatcode = {0}", line.Vatcode);
                    Console.WriteLine("allowdiscountorpremium = {0}", line.Allowdiscountorpremium);
                    Console.WriteLine("description = {0}", line.Description);
                    Console.WriteLine("performancedate = {0}", line.Performancedate);
                    Console.WriteLine("performancetype = {0}", line.Performancetype);
                    Console.WriteLine("freetext1 = {0}", line.Freetext1);
                    Console.WriteLine("freetext2 = {0}", line.Freetext2);
                    Console.WriteLine("freetext3 = {0}", line.Freetext3);
                    Console.WriteLine("dim1 = {0}", line.Dim1);
                    Console.WriteLine("vlaueexcl = {0}", line.Valueexcl);
                    Console.WriteLine("vatvalue = {0}", line.Vatvalue);
                    Console.WriteLine("valueinc = {0}", line.Valueinc);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("valueexcl = {0}", salesInvoice.Totals.Valueexcl);
            Console.WriteLine("valueincl = {0}", salesInvoice.Totals.Valueinc);
            Console.WriteLine("------");
            Console.WriteLine("VatLines:");
            for (int i = 0; i < salesInvoice.Vatlines.Vatline.Count; i++)
            {
                if (!salesInvoice.Vatlines.Vatline[i].Equals(null) || salesInvoice.Vatlines.Vatline[i] != null || !salesInvoice.Vatlines.Vatline[i].Vatcode.Equals("") || salesInvoice.Vatlines.Vatline[i].Vatcode != "")
                {
                    var vatLine = salesInvoice.Vatlines.Vatline[i];
                    Console.WriteLine("------");
                    Console.WriteLine("VatLine: " + (i + 1));
                    Console.WriteLine("vatcode = {0}", vatLine.Vatcode);
                    Console.WriteLine("vatvalue = {0}", vatLine.Vatvalue);
                    Console.WriteLine("performancetype = {0}", vatLine.Performancetype);
                    Console.WriteLine("performancedate = {0}", vatLine.Performancedate);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("code = {0}", salesInvoice.Financials.Code);
            Console.WriteLine("number = {0}", salesInvoice.Financials.Number);
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
