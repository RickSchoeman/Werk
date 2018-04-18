using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldBankStatementService;

namespace TwinfieldApi.BankStatements
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

        public BankStatements FindBankBook(DateTime statementdateFrom, DateTime statementDateTo, Boolean includePostedStatements)
        {
            var queryyResult = Query(new GetBankStatements
            {
                StatementDateFrom = statementdateFrom,
                StatementDateTo = statementDateTo,
                IncludePostedStatements = includePostedStatements
            });
            return BankStatements.FromQueryResult(queryyResult);
        }

        private QueryResult Query(GetBankStatements query)
        {
            var bankStatementClient = clientFactory.CreateBankStatementClient(session.ClusterUrl);
            return bankStatementClient.Query(session.SessionId, query);
        }
    }
}
