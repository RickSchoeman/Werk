using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.SubArticles;

namespace Demo.Extras.Articles
{
    public class SubArticleDemo
    {
        private const string SubArticleType = "SAR";
        private readonly SubArticleService subArticleService;
        private readonly Session session;
        private SubArticleSummary subArticleSummary;
        private IEnumerable<SubArticleSummary> subArticles;

        public SubArticleDemo(Session session)
        {
            this.session = session;
            subArticleService = new SubArticleService(session);
        }

        public void Run()
        {
            if (!FindSubArticlesFromArticle("FRUIT"))
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindSubArticlesFromArticle(string article)
        {
            Console.WriteLine("Searching sub articles");
            const int searchField = 0;
            var subArticles = subArticleService.FindSubArticles("*", article, searchField);
            DislaySubArticleSummaries(subArticles);
            if (subArticles.Count < 1)
            {
                return false;
            }
            else
            {
                this.subArticles = subArticles;
                subArticleSummary = subArticles.First();
                return true;
            }
        }

        private static void DislaySubArticleSummaries(IEnumerable<SubArticleSummary> subArticles)
        {
            foreach (var subArticle in subArticles)
            {
                Console.WriteLine("{0,-16} {1}", subArticle.Code, subArticle.Name);
            }
            Console.WriteLine();
        }

    }
}
