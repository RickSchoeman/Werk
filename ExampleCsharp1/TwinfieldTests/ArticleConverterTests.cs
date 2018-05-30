using DemoConnector.TwinfieldAPI.Converters;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplicatie;
using TestApplicatie.Interfaces;

namespace TwinfieldTests
{
    [TestClass]
    public class ArticleConverterTests
    {
        private IArticleConverter _articleConverter;
        private IMiddlewareData _middlewareData;
        private IArticleInterface _articleInterface;
        private Session _session;

        [TestInitialize]
        public void Initialize()
        {
            _articleConverter = new ArticleConverter();
            _middlewareData = new MiddlewareData();
            _session = Utilities.CreateValidSession();
            _articleInterface = new ArticleOperations(_session);
        }

        [TestMethod]
        public void Should_convert_product_to_article()
        {
            var article = _articleConverter.ConvertProduct(_middlewareData.GetProductData(), _session.Office, "IN");
            Assert.IsNotNull(article);
        }

        [TestMethod]
        public void Should_convert_article_to_porduct()
        {
            var articles = _articleInterface.GetByName("KORTING");
            var product = _articleConverter.ConvertArticle(articles[0]);
            Assert.IsNotNull(product);
        }
    }
}
