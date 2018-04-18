using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;

namespace TwinfieldApi.Extras.Translations
{
    public class TranslationService
    {
        private readonly FinderService finderService;

        public TranslationService(Session session) : this(session, new ClientFactory())
        {

        }

        public TranslationService(Session session, IClientFactory clientFactory)
        {
            finderService = new FinderService(session, clientFactory);
        }

        public List<TranslationSummary> FindTranslations(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchresult = finderService.Search(query);
            return SearchResultToTranslationSummaries(searchresult);
        }

        private static List<TranslationSummary> SearchResultToTranslationSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<TranslationSummary>();
            }

            return searchResult.Items.Select(item => new TranslationSummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
