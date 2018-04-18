using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldBudgetService;

namespace TwinfieldApi.Budget
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

        public Budget FindBudgetByProfitAndLoss(string code, int year)
        {
            var queryResult = QueryProfitLoss(new GetBudgetByProfitAndLoss {Code = code, Year = year});
            return Budget.FromQueryResult(queryResult);
        }

        public QueryResult QueryProfitLoss(GetBudgetByProfitAndLoss query)
        {
            var budgetClient = clientFactory.CreateBudgetServiceClient(session.ClusterUrl);
            return budgetClient.Query(session.SessionId, query);
        }

        public Budget FindBudgetByCostCenter(string code, int year, int periodFrom)
        {
            var queryResult = QueryCostCenter(new GetBudgetByCostCenter { Code = code, Year = year, PeriodFrom = periodFrom, PeriodTo = 12, IncludeFinal = true, IncludeProvisional = true});
            return Budget.FromQueryResult(queryResult);
        }

        public QueryResult QueryCostCenter(GetBudgetByCostCenter query)
        {
            var budgetClient = clientFactory.CreateBudgetServiceClient(session.ClusterUrl);
            return budgetClient.Query(session.SessionId, query);
        }

        public Budget FindBudgetByProject(string code, int year)
        {
            var queryResult = QueryProject(new GetBudgetByProject { Code = code , Year = year});
            return Budget.FromQueryResult(queryResult);
        }

        public QueryResult QueryProject(GetBudgetByProject query)
        {
            var budgetClient = clientFactory.CreateBudgetServiceClient(session.ClusterUrl);
            return budgetClient.Query(session.SessionId, query);
        }
    }

}
