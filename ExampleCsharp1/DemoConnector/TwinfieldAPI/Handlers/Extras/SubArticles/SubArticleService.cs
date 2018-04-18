using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Extras.SubArticles;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Extras.SubArticles
{
    public class SubArticleService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public SubArticleService(Session session) : this(session, new ClientFactory())
        {

        }

        public SubArticleService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<SubArticleSummary> FindSubArticles(string pattern, string article, int field)
        {
            var query = new FinderService.Query
            {
                Type = "SAR",
                Pattern = pattern,
                Field = field,
                Options = new []{new []{"article", article}}
            };
            var searchResult = finderService.Search(query);
            return SearchResultToSubArticleSummaries(searchResult);
        }

        public static List<SubArticleSummary> SearchResultToSubArticleSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<SubArticleSummary>();
            }

            return searchResult.Items.Select(item => new SubArticleSummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
