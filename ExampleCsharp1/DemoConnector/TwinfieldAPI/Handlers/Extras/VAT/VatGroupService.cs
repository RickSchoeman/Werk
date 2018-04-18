using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Extras.VAT;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Extras.VAT
{
    public class VatGroupService
    {
        private readonly FinderService finderService;

        public VatGroupService(Session session) : this(session, new ClientFactory())
        {

        }

        public VatGroupService(Session session, IClientFactory clientFactory)
        {
            finderService = new FinderService(session, clientFactory);
        }

        public List<VatGroupSummary> FindVatGroups(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToVatGroupSummaries(searchResult);
        }

        private static List<VatGroupSummary> SearchResultToVatGroupSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<VatGroupSummary>();
            }

            return searchResult.Items.Select(item => new VatGroupSummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
