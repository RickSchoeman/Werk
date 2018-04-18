using System;
using TwinfieldApi.Articles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Articles;

namespace Demo
{
    class ArticleDemo
    {
        private const string ArticleHeaderType = "ART";

        private readonly ArticleService articleService;
        private readonly Session session;
        private ArticleSummary articleSummary;
        private Article article;
        private IEnumerable<ArticleSummary> articles;

        public ArticleDemo(Session session)
        {
            this.session = session;
            articleService = new ArticleService(session);
        }

        public void Run()
        {
            var lines = new List<Line>();
            var line1 = new Line
            {
                Unitspriceexcl = "420",
                Unitspriceinc = "",
                Units = "1",
                Name = "Rijpe mango",
                Shortname = "mango r",
                Subcode = "MANGO.R",
                Freetext1 = "8020"
            };
            lines.Add(line1);
            var line2 = new Line
            {
                Unitspriceexcl = "10",
                Unitspriceinc = "",
                Units = "1",
                Name = "Beschimmelde mango",
                Shortname = "Mango b",
                Subcode = "MANGO.B",
                Freetext1 = "8020"
            };
            lines.Add(line2);
            var art = new Article
            {
                Header = new Header
                {
                    Office = session.Office,
                    Code = "MANGO",
                    Type = "normal",
                    Name = "Mango", 
                    Shortname = "Mango",
                    Unitnamesingular = "Piece",
                    Unitnameplural = "Pieces",
                    Vatcode = "VH",
                    Allowchangevatcode = "false",
                    Allowdiscountorpremium = "true",
                    Allowchangeunitsprice = "false",
                    Allowdecimalquantity = "false"
                },
                Lines = new Lines
                {
                    Line = lines
                }
            };
            articleService.CreateArticle(art);

            var delArticle = new Article
            {
                Header = new Header
                {
                    Office = session.Office,
                    Code = "MANGO"
                }
            };
//            articleService.DeleteArticle(delArticle);

            var subs = new List<Line>();
            var sub = new Line
            {
                Subcode = "MANGO.B"
            };
            subs.Add(sub);
            var delSub = new Article
            {
                Header = new Header
                {
                    Office = session.Office,
                    Code = "MANGO"
                },
                Lines = new Lines
                {
                    Line = subs
                }
            };
            articleService.DeleteSubArticle(delSub);

            if (!FindArticlesWithNameThatStartsWithA())
            {
                return;
            }

            if (!ReadArticleDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private Boolean FindArticlesWithNameThatStartsWithA()
        {
            Console.WriteLine("Searching for articles");

            const int searchField = 0;
            var articles = articleService.FindHeaders("*", ArticleHeaderType, searchField);
            DisplayArticleSummaries(articles);

            if (articles.Count <1)
            {
                return false;
            }
            else
            {
                this.articles = articles;

                articleSummary = articles.First();
                return true;
            }

            
        }

        private Boolean ReadArticleDetails()
        {
            Console.WriteLine("Read article details");
            foreach (var a in this.articles)
            {
                article = articleService.ReadHeader(a.Code);

                if (articleSummary == null)
                {
                    Console.WriteLine("Article {0} not found.", article.Header.Code);
                    return false;
                }

                DisplayArticleDetails(article);
            }

            return true;

        }

        private static void DisplayArticleSummaries(IEnumerable<ArticleSummary> headers)
        {
            foreach (var header in headers)
            {
                Console.WriteLine("{0, -16} {1}", header.Code, header.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayArticleDetails(Article article)
        {
            Console.WriteLine("Article details of {0}:", article.Header.Name);
            Console.WriteLine("office = {0}", article.Header.Office);
            Console.WriteLine("code = {0}", article.Header.Code);
            Console.WriteLine("type = {0}", article.Header.Type);
            Console.WriteLine("name = {0}", article.Header.Name);
            Console.WriteLine("shortname = {0}", article.Header.Shortname);
            Console.WriteLine("unitnamesingular = {0}", article.Header.Unitnamesingular);
            Console.WriteLine("unitnameplural = {0}", article.Header.Unitnameplural);
            Console.WriteLine("vatcode = {0}", article.Header.Vatcode);
            Console.WriteLine("allowchangevatcode = {0}", article.Header.Allowchangevatcode);
            Console.WriteLine("allowdiscountorpremium = {0}", article.Header.Allowdiscountorpremium);
            Console.WriteLine("allowchangeunitprice = {0}", article.Header.Allowchangeunitsprice);
            Console.WriteLine("allowdecimalquantity = {0}", article.Header.Allowdecimalquantity);
            for (int i = 0; i < article.Lines.Line.Count; i++)
            {
                if (!article.Lines.Line[i].Equals(null) || article.Lines.Line[i] != null || !article.Lines.Line[i].Name.Equals("") || article.Lines.Line[i].Name != "")
                {
                    var line = article.Lines.Line[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Line: " + (i + 1));
                    Console.WriteLine("unitpriceexcl = {0}", line.Unitspriceexcl);
                    Console.WriteLine("unitpriceincl = {0}", line.Unitspriceinc);
                    Console.WriteLine("units = {0}", line.Units);
                    Console.WriteLine("name = {0}", line.Name);
                    Console.WriteLine("shortname = {0}", line.Shortname);
                    Console.WriteLine("subcode = {0}", line.Subcode);
                    Console.WriteLine("freetext1 = {0}", line.Freetext1);
                    Console.WriteLine("freetext2 = {0}", line.Freetext2);
                    Console.WriteLine("freetext3 = {0}", line.Freetext3);
                    Console.WriteLine("freetext4 = {0}", line.Freetext4);
                    Console.WriteLine("freetext5 = {0}", line.Freetext5);
                    Console.WriteLine("freetext6 = {0}", line.Freetext6);
                    Console.WriteLine("------");
                }
            }

            Console.WriteLine();
        }
    }
}
