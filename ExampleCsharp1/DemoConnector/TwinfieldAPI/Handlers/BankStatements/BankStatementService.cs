using System;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldBankStatementService;

namespace DemoConnector.TwinfieldAPI.Handlers.BankStatements
{
    public class BankStatementService
    {
        private readonly Session session;
        private readonly IClientFactory clientFactory;

        public BankStatementService(Session session) : this(session, new ClientFactory())
        {

        }

        public BankStatementService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            this.clientFactory = clientFactory;
        }

        public DemoConnector.TwinfieldAPI.Data.BankStatements.BankStatements FindBankBook(DateTime statementdateFrom, DateTime statementDateTo, Boolean includePostedStatements)
        {
            var queryyResult = Query(new GetBankStatements
            {
                StatementDateFrom = statementdateFrom,
                StatementDateTo = statementDateTo,
                IncludePostedStatements = includePostedStatements
            });
            return DemoConnector.TwinfieldAPI.Data.BankStatements.BankStatements.FromQueryResult(queryyResult);
        }

        private QueryResult Query(GetBankStatements query)
        {
            var bankStatementClient = clientFactory.CreateBankStatementClient(session.ClusterUrl);
            return bankStatementClient.Query(session.SessionId, query);
        }
    }
}
