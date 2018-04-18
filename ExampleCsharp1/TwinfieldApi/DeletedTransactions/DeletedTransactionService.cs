using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldDeletedTransactionService;

namespace TwinfieldApi.DeletedTransactions
{
    public class DeletedTransactionService
    {
        private readonly Session session;
        private readonly IClientFactory clientFactory;

        public DeletedTransactionService(Session session) : this(session, new ClientFactory())
        {

        }

        public DeletedTransactionService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            this.clientFactory = clientFactory;
        }

        public DeletedTransactions FindDeletedTransactions(string companyCode, string dayBook, DateTime dateFrom,
            DateTime dateTo)
        {
            var queryResult = Query(new GetDeletedTransactions
            {
                CompanyCode = companyCode,
                Daybook = dayBook,
                DateFrom = dateFrom,
                DateTo = dateTo
            });
            return DeletedTransactions.FromQueryResult(queryResult);
        }

        public QueryResult Query(GetDeletedTransactions query)
        {
            var deletedTransactionsClient = clientFactory.CreateDeletedTransactionsClient(session.ClusterUrl);
            return deletedTransactionsClient.Query(session.SessionId, query);
        }
    }
}
