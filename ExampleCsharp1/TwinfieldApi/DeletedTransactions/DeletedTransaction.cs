using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.TwinfieldDeletedTransactionService;

namespace TwinfieldApi.DeletedTransactions
{
    public class DeletedTransactions
    {
        public List<DeletedTransaction> deletedTransactions { get; set; }

        public static DeletedTransactions FromQueryResult(QueryResult queryResult)
        {
            var result = queryResult as GetDeletedTransactionsResult;
            if (result == null)
            {
                return null;
            }

            var deletedTransactions = new List<DeletedTransaction>();
            foreach (var r in result.DeletedTransactions)
            {
                var deletedTransaction = new DeletedTransaction
                {
                    Daybook = r.Daybook,
                    TransactionNumber = r.TransactionNumber,
                    TransactionDate = r.TransactionDate,
                    DeletionDate = r.DeletionDate,
                    User = r.User,
                    ReasonForDeletion = r.ReasonForDeletion
                };
                deletedTransactions.Add(deletedTransaction);
            }
            return new DeletedTransactions
            {
                deletedTransactions = deletedTransactions
            };
        }
    }
}
