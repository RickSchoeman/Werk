using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;

namespace TwinfieldApi.Extras.DistByPeriods
{
    public class DistByPeriodService
    {
        private readonly FinderService finderService;

        public DistByPeriodService(Session session) : this(session, new ClientFactory())
        {

        }

        public DistByPeriodService(Session session, IClientFactory clientFactory)
        {
            finderService = new FinderService(session, clientFactory);
        }

        public List<DistByPeriodSummary> FindDistByPeriods(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToDistByPeriodSummaries(searchResult);
        }

        private static List<DistByPeriodSummary> SearchResultToDistByPeriodSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<DistByPeriodSummary>();
            }

            return searchResult.Items.Select(item => new DistByPeriodSummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
