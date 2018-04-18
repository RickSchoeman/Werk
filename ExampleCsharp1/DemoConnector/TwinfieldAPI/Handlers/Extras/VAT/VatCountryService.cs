using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Extras.VAT;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Extras.VAT
{
    public class VatCountryService
    {
        private readonly FinderService finderService;

        public VatCountryService(Session session) : this(session, new ClientFactory())
        {

        }

        public VatCountryService(Session session, IClientFactory clientFactory)
        {
            finderService = new FinderService(session, clientFactory);
        }

        public List<VatCountrySummary> FindVatCountries(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToVatCountrySummaries(searchResult);
        }

        private static List<VatCountrySummary> SearchResultToVatCountrySummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<VatCountrySummary>();
            }

            return searchResult.Items.Select(item => new VatCountrySummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
