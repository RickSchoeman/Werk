using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.TransactionTypes;

namespace Demo.Extras.TransactionType
{
    class TransactionTypeDemo
    {
        private const string TransactionTypeType = "TRS";
        private readonly TransactionTypeService transactionTypeService;

        public TransactionTypeDemo(Session session)
        {
            transactionTypeService = new TransactionTypeService(session);
        }

        public void Run()
        {
            if (!FindTransactionTypes())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindTransactionTypes()
        {
            Console.WriteLine("Searching transaction types");
            const int searchField = 0;
            var transactionTypes = transactionTypeService.FindTransactionTypes("*", TransactionTypeType, searchField);
            DisplayTransactionTypeSummaries(transactionTypes);
            if (transactionTypes.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayTransactionTypeSummaries(IEnumerable<TransactionTypeSummary> transactionTypes)
        {
            foreach (var t in transactionTypes)
            {
                Console.WriteLine("{0,-16} {1}", t.Code, t.Name);
            }
            Console.WriteLine();
        }
    }
}
