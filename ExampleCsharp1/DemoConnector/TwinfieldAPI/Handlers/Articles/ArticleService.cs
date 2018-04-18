using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Articles;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Articles
{
    public class ArticleService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public ArticleService(Session session)
            : this(session, new ClientFactory())
        { }

        public ArticleService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<ArticleSummary> FindHeaders(string pattern, string headerType, int field)
        {
            var query = new FinderService.Query
            {
                Type = headerType,
                Pattern = pattern,
                Field = field,
                MaxRows = 10
            };
            var searchResult = finderService.Search(query);
            
            return SearchResultToHeaderSummaries(searchResult);
        }

        private static List<ArticleSummary> SearchResultToHeaderSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
                return new List<ArticleSummary>();

            return searchResult.Items.Select(item =>
                new ArticleSummary { Code = item[0], Name = item[1] }).ToList();
        }

        public Article ReadHeader(string headerCode)
        {
            var command = new ReadArticleCommand
            {
                Office = session.Office,
                HeaderCode = headerCode
            };
            var response = processXml.Process(command.ToXml());
            return Article.FromXml(response);
        }

        public void CreateArticle(Article article)
        {
            var command = new CreateArticleCommand
            {
                Article = article
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteArticle(Article article)
        {
            var command = new DeleteArticleCommand
            {
                Article = article
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateArticle(Article article)
        {
            var command = new ActivateArticleCommand
            {
                Article = article
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteSubArticle(Article article)
        {
            var command = new DeleteSubArticleCommand
            {
                Article = article
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteHeader(Article header)
        {
            var response = processXml.Process(header.ToXml());
            return response.IsSuccess();
        }
    }
}
