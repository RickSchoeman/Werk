using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data.Articles;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Articles;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwinfieldTests
{
    [TestClass]
    public class ArticleOperationsTests
    {
        private IArticleInterface _articleInterface;

        [TestInitialize]
        public void Initialize()
        {
            var session = Utilities.CreateValidSession();
            _articleInterface = new ArticleOperations(session);
        }

        [TestMethod]
        public void Should_find_all_articles()
        {
            var articles = _articleInterface.GetAll();
            Assert.IsNotNull(articles);
        }

        [TestMethod]
        public void Should_find_all_article_summaries()
        {
            var article = _articleInterface.GetSummaries();
            Assert.IsNotNull(article);
        }

        [TestMethod]
        public void Should_read_given_article()
        {
            var a = _articleInterface.GetByName("KORTING");
            List<Article> articles = new List<Article>();
            foreach (var x in a)
            {
                var article = _articleInterface.Read(x.Header.Code);
                articles.Add(article);
            }
            Assert.IsNotNull(articles);
            Assert.AreEqual(articles[0].Header.Code, "KORTING");
        }

        [TestMethod]
        public void Should_find_subarticle_by_given_article()
        {
            var articles = _articleInterface.GetSubArticlesByArticle("KORTING");
            Assert.IsNotNull(articles);
        }

        [TestMethod]
        public void Should_fail_to_create_empty_article()
        {
            try
            {
                _articleInterface.Create(new Article());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_delete_with_empty_article()
        {
            try
            {
                _articleInterface.Delete(new Article());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_activate_with_empty_article()
        {
            try
            {
                _articleInterface.Activate(new Article());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_delete_subarticle_with_empty_article()
        {
            try
            {
                _articleInterface.DeleteSubArticle(new Article());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }
    }
}
