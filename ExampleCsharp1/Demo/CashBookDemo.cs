using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.TwinfieldCashBookService;
using CashBookService = TwinfieldApi.CashBooks.CashBookService;

namespace Demo
{
    class CashBookDemo
    {
        private readonly CashBookService cashBookService;

        public CashBookDemo(Session session)
        {
            cashBookService = new CashBookService(session);
        }

        public void Run()
        {
            cashBookService.CreateCashBook("CASHBOOK", "test", "1000");
            cashBookService.ChangeCashBookName("CASHBOOK", "hoi");
            cashBookService.ChangeCashBookShortName("CASHBOOK", "hai");
            cashBookService.ChangeCashBookGeneralLedgerAccount("CASHBOOK", "1010");
            Console.WriteLine("Read cash book");
            var cashBook = cashBookService.FindCashBook("CASHBOOK");
            if (cashBook == null)
            {
                Console.WriteLine("Cash book not found");
            }
            else
            {
                Console.WriteLine("Cash book found");
                Console.WriteLine("\tname = {0}", cashBook.Name);
                Console.WriteLine("\tshortname = {0}", cashBook.ShortName);
                Console.WriteLine("\tgeneral ledger account = {0}", cashBook.GeneralLedgerAccount);
            }
            Console.WriteLine();
        }
    }
}
