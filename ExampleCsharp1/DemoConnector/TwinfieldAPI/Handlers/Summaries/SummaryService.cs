using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Summaries;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Summaries
{
    public class SummaryService
    {
        private readonly FinderService _finderService;

        public SummaryService(Session session) : this(session, new ClientFactory())
        {

        }

        public SummaryService(Session session, IClientFactory clientFactory)
        {
            _finderService = new FinderService(session, clientFactory);
        }

        public List<Summary> FindSummaries(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field,
                MaxRows = 500
            };
            var searchResult = _finderService.Search(query);
            return SearchResultToSummaries(searchResult);
        }

        public List<Summary> SearchResultToSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<Summary>();
            }

            return searchResult.Items.Select(item => new Summary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
