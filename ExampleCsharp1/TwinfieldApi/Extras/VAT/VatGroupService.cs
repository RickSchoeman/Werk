using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;

namespace TwinfieldApi.Extras.VAT
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
