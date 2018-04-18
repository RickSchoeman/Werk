using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.PurchaseTransactions;

namespace Demo
{
    class PurchaseTransactionDemo
    {
        private const string PurchaseTransactionType = "IVT";
        private readonly PurchaseTransactionService purchaseTransactionService;
        private readonly Session session;
        private PurchaseTransactionSummary purchaseTransactionSummary;
        private PurchaseTransaction purchaseTransaction;
        private IEnumerable<PurchaseTransactionSummary> purchaseTransactions;

        public PurchaseTransactionDemo(Session session)
        {
            this.session = session;
            purchaseTransactionService = new PurchaseTransactionService(session);
        }

        public void Run()
        {
            var lines = new List<Line>();
            var line1 = new Line
            {
                Type = "total",
                Dim1 = "1600",
                Dim2 = "2000",
                Value = "121.00",
                Debitcredit = "credit",
                Description = ""
            };
            var line2 = new Line
            {
                Type = "detail",
                Dim1 = "8020",
                Value = "100",
                Debitcredit = "debit",
                Description = "Outfit",
                Vatcode = "IH",
                Destoffice = session.Office
            };
            lines.Add(line1);
            lines.Add(line2);
            var purchase = new PurchaseTransaction
            {
                Header = new Header
                {
                    Code = "INK",
                    Currency = "EUR",
                    Date = "",
                    Period = "",
                    Invoicenumber = "",
                    Paymentreference = "",
                    Office = session.Office,
                    Duedate = ""
                },
                Line = lines
            };
            purchaseTransactionService.CreatePurchaseTransaction(purchase);

            if (!FindPurchaseTransactions())
            {
                return;
            }

            if (!ReadPurchaseTransactionDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindPurchaseTransactions()
        {
            Console.WriteLine("Searching purchase transactions");
            const int searchField = 0;
            var purchaseTransactions =
                purchaseTransactionService.FindPurchaseTransactions("*", PurchaseTransactionType, searchField);

            DisplayPurchaseTransactionSummaries(purchaseTransactions);
            if (purchaseTransactions.Count <1)
            {
                return false;
            }
            else
            {
                this.purchaseTransactions = purchaseTransactions;
                purchaseTransactionSummary = purchaseTransactions.First();
                return true;
            }
        }

        private bool ReadPurchaseTransactionDetails()
        {
            Console.WriteLine("Read purchase transaction details");
            foreach (var p in purchaseTransactions)
            {
                purchaseTransaction =
                    purchaseTransactionService.ReadPurchaseTransaction(p.Code);
                if (purchaseTransactionSummary == null)
                {
                    Console.WriteLine("Purchase transaction {0} not found.", p.Code);
                    return false;
                }

                DisplayPurchaseTransactionDetails(purchaseTransaction);
            }

            return true;
        }

        private static void DisplayPurchaseTransactionSummaries(
            IEnumerable<PurchaseTransactionSummary> purchaseTransactions)
        {

            foreach (var purchaseTransaction in purchaseTransactions)
            {
                Console.WriteLine("{0, -16} {1}", purchaseTransaction.Code, purchaseTransaction.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayPurchaseTransactionDetails(PurchaseTransaction purchaseTransaction)
        {
            Console.WriteLine("------");
            Console.WriteLine("Purchase transaction details of: {0}", purchaseTransaction.Header.Code);
            Console.WriteLine("------");
            Console.WriteLine("Header:");
            Console.WriteLine("office = {0}", purchaseTransaction.Header.Office);
            Console.WriteLine("code = {0}", purchaseTransaction.Header.Code);
            //toevoegen
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
