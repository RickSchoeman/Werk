using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.DeletedTransactions;

namespace Demo
{
    class DeletedTransactionDemo
    {
        private readonly DeletedTransactionService deletedTransactionService;

        public DeletedTransactionDemo(Session session)
        {
            deletedTransactionService = new DeletedTransactionService(session);
        }

        public void Run()
        {
            var list = new List<string>();
            list.Add("BEGINBALANS");
            list.Add("BNK");
            list.Add("CASHBOOK");
            list.Add("INK");
            list.Add("KAS");
            list.Add("MEMO");
            list.Add("RC");
            list.Add("SALARIS");
            list.Add("TEST");
            list.Add("VJP");
            list.Add("VJP2");
            list.Add("VRK");
            Console.WriteLine("Read deleted transactions");
            foreach (var l in list)
            {
                var deletedTransactions = deletedTransactionService.FindDeletedTransactions("NLA000218", l,
                new DateTime(1995, 01, 01), new DateTime(2019, 12, 12));
            if (deletedTransactions == null || deletedTransactions.deletedTransactions.Count < 1)
            {
                Console.WriteLine("No deleted transactions found");
            }
            else
            {
                Console.WriteLine("Deleted transactions found");
                foreach (var dt in deletedTransactions.deletedTransactions)
                {
                    Console.WriteLine("Deleted transaction:");
                    Console.WriteLine("Transaction type: {0}", dt.Daybook);
                    Console.WriteLine("Transaction number: {0}", dt.TransactionNumber);
                    Console.WriteLine("Transaction date: {0}", dt.TransactionDate);
                    Console.WriteLine("Deletion date: {0}", dt.DeletionDate);
                    Console.WriteLine("Reason for deletion: {0}", dt.DeletionDate);
                    Console.WriteLine("User: {0}", dt.User);
                }
            }
            }
            
        }
    }
}
