using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;

namespace TwinfieldApi.Extras.TaxGroups
{
    public class TaxGroupService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public TaxGroupService(Session session) : this(session, new ClientFactory())
        {

        }

        public TaxGroupService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<TaxGroupSummary> FindTaxGroups(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = "TXG",
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToTaxGroupSummaries(searchResult);
        }

        private static List<TaxGroupSummary> SearchResultToTaxGroupSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<TaxGroupSummary>();
            }

            return searchResult.Items.Select(item => new TaxGroupSummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
