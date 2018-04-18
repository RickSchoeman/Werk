using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Extras.TimeQuantities;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Extras.TimeQuantities
{
    public class TimeQuantityService
    {
        private readonly FinderService finderService;

        public TimeQuantityService(Session session) : this(session, new ClientFactory())
        {

        }

        public TimeQuantityService(Session session, IClientFactory clientFactory)
        {
            finderService = new FinderService(session);
        }

        public List<TimeQuantitySummary> FindTimeQuantities(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToTimeQuantitySummaries(searchResult);
        }

        private static List<TimeQuantitySummary> SearchResultToTimeQuantitySummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<TimeQuantitySummary>();
            }

            return searchResult.Items.Select(item => new TimeQuantitySummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
