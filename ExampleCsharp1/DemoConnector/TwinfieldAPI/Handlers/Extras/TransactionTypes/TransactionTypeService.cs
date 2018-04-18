using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Extras.TransactionTypes;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Extras.TransactionTypes
{
    public class TransactionTypeService
    {
        private readonly FinderService finderService;

        public TransactionTypeService(Session session) : this(session, new ClientFactory())
        {

        }

        public TransactionTypeService(Session session, IClientFactory clientFactory)
        {
            finderService = new FinderService(session);
        }

        public List<TransactionTypeSummary> FindTransactionTypes(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToTransactionTypeSummaries(searchResult);
        }

        private static List<TransactionTypeSummary> SearchResultToTransactionTypeSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<TransactionTypeSummary>();
            }

            return searchResult.Items.Select(item => new TransactionTypeSummary {Code = item[0], Name = item[1]})
                .ToList();
        }
    }
}
