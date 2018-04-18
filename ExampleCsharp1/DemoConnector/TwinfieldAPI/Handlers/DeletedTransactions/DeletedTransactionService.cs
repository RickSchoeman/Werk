using System;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldDeletedTransactionService;

namespace DemoConnector.TwinfieldAPI.Handlers.DeletedTransactions
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

        public DemoConnector.TwinfieldAPI.Data.DeletedTransactions.DeletedTransactions FindDeletedTransactions(string companyCode, string dayBook, DateTime dateFrom,
            DateTime dateTo)
        {
            var queryResult = Query(new GetDeletedTransactions
            {
                CompanyCode = companyCode,
                Daybook = dayBook,
                DateFrom = dateFrom,
                DateTo = dateTo
            });
            return DemoConnector.TwinfieldAPI.Data.DeletedTransactions.DeletedTransactions.FromQueryResult(queryResult);
        }

        public QueryResult Query(GetDeletedTransactions query)
        {
            var deletedTransactionsClient = clientFactory.CreateDeletedTransactionsClient(session.ClusterUrl);
            return deletedTransactionsClient.Query(session.SessionId, query);
        }
    }
}
