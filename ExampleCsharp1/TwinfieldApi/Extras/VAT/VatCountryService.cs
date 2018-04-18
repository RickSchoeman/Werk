using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;

namespace TwinfieldApi.Extras.VAT
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
