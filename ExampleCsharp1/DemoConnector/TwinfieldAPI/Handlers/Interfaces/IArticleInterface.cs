using System;
using System.Collections.Generic;
using DemoConnector.TwinfieldAPI.Data.Articles;
using DemoConnector.TwinfieldAPI.Data.Extras.SubArticles;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface IArticleInterface
    {
        List<Article> GetByName(string name);
        List<Article> GetAll();
        List<ArticleSummary> GetSummaries();
        Article Read(string code);
        string Create(Article article);
        string Delete(Article article);
        string Activate(Article article);
        string DeleteSubArticle(Article article);
        List<SubArticleSummary> GetSubArticlesByArticle(string article);
    }
}
