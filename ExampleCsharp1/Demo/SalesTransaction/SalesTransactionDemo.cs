using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.SalesTransactions;

namespace Demo
{
    class SalesTransactionDemo
    {
        private const string SalesTransactionType = "IVT";
        private readonly SalesTransactionService salesTransactionService;
        private readonly Session session;
        private SalesTransactionSummary salesTransactionSummary;
        private SalesTransaction salesTransaction;
        private IEnumerable<SalesTransactionSummary> salesTransactions;

        public SalesTransactionDemo(Session session)
        {
            this.session = session;
            salesTransactionService = new SalesTransactionService(session);
        }

        public void Run()
        {
            var lines = new List<Line>();
            var line1 = new Line
            {
                Type = "total",
                Dim1 = "1300",
                Dim2 = "1000",
                Value = "121.00",
                Debitcredit = "debit",
                Description = ""
            };
            var line2 = new Line
            {
                Type = "detail",
                Dim1 = "8020",
                Value = "100",
                Debitcredit = "credit",
                Description = "Outfit",
                Vatcode = "VH",
                Destoffice = session.Office
            };
            lines.Add(line1);
            lines.Add(line2);
            var sale = new SalesTransaction
            {
                Header = new Header
                {
                    Code = "BNK",
                    Currency = "EUR",
                    Date = "20130502",
                    Period = "2013/05",
                    Invoicenumber = "20130-6000",
                    Paymentreference = "+++100/0160/01495+++",
                    Office = session.Office,
                    Duedate = "20130506",
                },
                Lines = new Lines
                {
                    Line = lines
                }
            };
            salesTransactionService.CreateSalesTransaction(sale);

            if (!FindSalesTransactions())
            {
                return;
            }

            if (!ReadSalesTransactionDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindSalesTransactions()
        {
            Console.WriteLine("Searching Sales Transactions");
            const int searchField = 0;
            var salesTransactions =
                salesTransactionService.FindSalesTransactions("*", SalesTransactionType, searchField);
            Console.WriteLine(salesTransactions.Count);
            DisplaySalesTransactionSummaries(salesTransactions);
            if (salesTransactions.Count < 1)
            {
                return false;
            }
            else
            {
                this.salesTransactions = salesTransactions;
                salesTransactionSummary = salesTransactions.First();
                return true;
            }
        }

        private bool ReadSalesTransactionDetails()
        {
            Console.WriteLine("Read Sales Transaction details");
            foreach (var s in salesTransactions)
            {
                salesTransaction = salesTransactionService.ReadSalesTransaction(SalesTransactionType, s.Code);
                if (salesTransactionSummary == null)
                {
                    Console.WriteLine("Sales transaction {0} not found.", s.Code);
                    return false;
                }
                DisplaySalesTransactionDetails(salesTransaction);
            }

            return true;
        }

        private static void DisplaySalesTransactionSummaries(IEnumerable<SalesTransactionSummary> salesTransactions)
        {
            foreach (var salesTransaction in salesTransactions)
            {
                Console.WriteLine("{0, -16} {1}", salesTransaction.Code, salesTransaction.Name);
            }
            Console.WriteLine();
        }

        private static void DisplaySalesTransactionDetails(SalesTransaction salesTransaction)
        {
            Console.WriteLine("------");
            Console.WriteLine("Sales transaction details of: {0}", salesTransaction.Header.Code);
            Console.WriteLine("------");
            Console.WriteLine("Header: ");
            Console.WriteLine("office = {0}", salesTransaction.Header.Office);
            Console.WriteLine("code = {0}", salesTransaction.Header.Code);
            //toevoegen
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
