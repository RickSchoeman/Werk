using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;

namespace TwinfieldApi.Extras.Countries
{
    public class CountryService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public CountryService(Session session) : this(session, new ClientFactory())
        {

        }

        public CountryService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<CountrySummary> FindCountries(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field,
                MaxRows = 500
            };
            var searchResult = finderService.Search(query);
            return SearchResultToCountrySummaries(searchResult);
        }

        private static List<CountrySummary> SearchResultToCountrySummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<CountrySummary>();
            }

            return searchResult.Items.Select(item => new CountrySummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
