using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.BankTransactions;

namespace Demo
{
    class BankTransactionDemo
    {
        private const string BankTransactionType = "BNK";
        private readonly BankTransactionService bankTransactionService;
        private readonly Session session;
        private BankTransactionSummary bankTransactionSummary;
        private BankTransaction bankTransaction;
        private IEnumerable<BankTransactionSummary> bankTransactions;

        public BankTransactionDemo(Session session)
        {
            this.session = session;
            bankTransactionService = new BankTransactionService(session);
        }

        public void Run()
        {
            var lines = new List<Line>();
            var line1 = new Line
            {
                Type = "total",
                Dim1 = "1010",
                Debitcredit = "debit",
                Value = "435.55",
            };
            var line2 = new Line
            {
                Type = "detail",
                Dim1 = "1300",
                Dim2 = "1000",
                Debitcredit = "credit",
                Value = "435.55",
                Description = "invoice paid"
            };
            lines.Add(line1);
            lines.Add(line2);
            var trans = new BankTransaction
            {
                Header = new Header
                {
                    Office = session.Office,
                    Code = "BNK",
                    Currency = "EUR",
                    Date = "20130101",
                    Statementnumber = "5",
                    Startvalue = "974.01",
                    Closevalue = "1409.56"
                },
                Lines = new Lines
                {
                    Line = lines
                }
            };
//            bankTransactionService.CreateBankTransaction(trans);

            if (!FindBankTransactions())
            {
                return;
            }

            if (!ReadBankTransactionDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindBankTransactions()
        {
            Console.WriteLine("Searching bank transactions");
            const int searchField = 2;
            var banktransactions = bankTransactionService.FindBankTransactions("*", BankTransactionType, searchField);
            DisplayBankTransactionSummaries(banktransactions);
            if (banktransactions.Count < 1)
            {
                return false;
            }
            else
            {
                this.bankTransactions = banktransactions;
                bankTransactionSummary = banktransactions.First();
                return true;
            }
        }

        private bool ReadBankTransactionDetails()
        {
            Console.WriteLine("Read bank transaction details");
            foreach (var b in bankTransactions)
            {
                
                bankTransaction = bankTransactionService.ReadBankTransaction(b.Name, b.Code);
                if (bankTransactionSummary == null || bankTransactionSummary.Equals(null))
                {
                    Console.WriteLine("Bank transaction {0} not found.", bankTransaction.Header.Code);
                    return false;
                }
                DisplayBankTransactionDetails(bankTransaction);
            }

            return true;
        }

        private static void DisplayBankTransactionSummaries(IEnumerable<BankTransactionSummary> bankTransactions)
        {
            foreach (var bankTransaction in bankTransactions)
            {
                Console.WriteLine("{0, -16} {1}", bankTransaction.Code, bankTransaction.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayBankTransactionDetails(BankTransaction bankTransaction)
        {
            Console.WriteLine("------");
            Console.WriteLine("Bank transaction details of: {0}", bankTransaction.Header.Code);
            Console.WriteLine("------");
            Console.WriteLine("Header: ");
            Console.WriteLine("office = {0}", bankTransaction.Header.Office);
            Console.WriteLine("code = {0}", bankTransaction.Header.Code);
            Console.WriteLine("number = {0}", bankTransaction.Header.Number);

            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
