using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Data.Articles;

namespace DemoConnector.TwinfieldAPI.Converters.Interfaces
{
    public interface IArticleConverter
    {
        List<Product> ConvertArticle(Article article);
        Article ConvertProduct(Product product, string office, string vatCode);
    }
}
