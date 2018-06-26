using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldBudgetService;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.Budget
{
    public class BudgetService
    {
        private readonly Session session;
        private readonly IClientFactory clientFactory;

        public BudgetService(Session session) : this(session, new ClientFactory())
        {

        }

        public BudgetService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            this.clientFactory = clientFactory;
        }

        public Data.NotImplemented.Budget.Budget FindBudgetByProfitAndLoss(string code, int year)
        {
            var queryResult = QueryProfitLoss(new GetBudgetByProfitAndLoss {Code = code, Year = year});
            return Data.NotImplemented.Budget.Budget.FromQueryResult(queryResult);
        }

        public QueryResult QueryProfitLoss(GetBudgetByProfitAndLoss query)
        {
            var budgetClient = clientFactory.CreateBudgetServiceClient(session.ClusterUrl);
            return budgetClient.Query(session.SessionId, query);
        }

        public Data.NotImplemented.Budget.Budget FindBudgetByCostCenter(string code, int year, int periodFrom)
        {
            var queryResult = QueryCostCenter(new GetBudgetByCostCenter { Code = code, Year = year, PeriodFrom = periodFrom, PeriodTo = 12, IncludeFinal = true, IncludeProvisional = true});
            return Data.NotImplemented.Budget.Budget.FromQueryResult(queryResult);
        }

        public QueryResult QueryCostCenter(GetBudgetByCostCenter query)
        {
            var budgetClient = clientFactory.CreateBudgetServiceClient(session.ClusterUrl);
            return budgetClient.Query(session.SessionId, query);
        }

        public Data.NotImplemented.Budget.Budget FindBudgetByProject(string code, int year)
        {
            var queryResult = QueryProject(new GetBudgetByProject { Code = code , Year = year});
            return Data.NotImplemented.Budget.Budget.FromQueryResult(queryResult);
        }

        public QueryResult QueryProject(GetBudgetByProject query)
        {
            var budgetClient = clientFactory.CreateBudgetServiceClient(session.ClusterUrl);
            return budgetClient.Query(session.SessionId, query);
        }
    }

}
