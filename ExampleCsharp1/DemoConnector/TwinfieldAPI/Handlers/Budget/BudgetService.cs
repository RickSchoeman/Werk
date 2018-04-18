using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldBudgetService;

namespace DemoConnector.TwinfieldAPI.Handlers.Budget
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

        public DemoConnector.TwinfieldAPI.Data.Budget.Budget FindBudgetByProfitAndLoss(string code, int year)
        {
            var queryResult = QueryProfitLoss(new GetBudgetByProfitAndLoss {Code = code, Year = year});
            return DemoConnector.TwinfieldAPI.Data.Budget.Budget.FromQueryResult(queryResult);
        }

        public QueryResult QueryProfitLoss(GetBudgetByProfitAndLoss query)
        {
            var budgetClient = clientFactory.CreateBudgetServiceClient(session.ClusterUrl);
            return budgetClient.Query(session.SessionId, query);
        }

        public DemoConnector.TwinfieldAPI.Data.Budget.Budget FindBudgetByCostCenter(string code, int year, int periodFrom)
        {
            var queryResult = QueryCostCenter(new GetBudgetByCostCenter { Code = code, Year = year, PeriodFrom = periodFrom, PeriodTo = 12, IncludeFinal = true, IncludeProvisional = true});
            return DemoConnector.TwinfieldAPI.Data.Budget.Budget.FromQueryResult(queryResult);
        }

        public QueryResult QueryCostCenter(GetBudgetByCostCenter query)
        {
            var budgetClient = clientFactory.CreateBudgetServiceClient(session.ClusterUrl);
            return budgetClient.Query(session.SessionId, query);
        }

        public DemoConnector.TwinfieldAPI.Data.Budget.Budget FindBudgetByProject(string code, int year)
        {
            var queryResult = QueryProject(new GetBudgetByProject { Code = code , Year = year});
            return DemoConnector.TwinfieldAPI.Data.Budget.Budget.FromQueryResult(queryResult);
        }

        public QueryResult QueryProject(GetBudgetByProject query)
        {
            var budgetClient = clientFactory.CreateBudgetServiceClient(session.ClusterUrl);
            return budgetClient.Query(session.SessionId, query);
        }
    }

}
