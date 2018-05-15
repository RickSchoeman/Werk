using System.Collections.Generic;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data.Articles;

namespace DemoConnector.TwinfieldAPI.Converters
{
    public class ArticleConverter : IArticleConverter
    {
        public List<Product> ConvertArticle(Article article)
        {
            var list = new List<Product>();
            foreach (var l in article.Lines.Line)
            {
                var extrafields = new List<ExtensionData>();
                var freetext1 = new ExtensionData
                {
                    Name = "freetext1",
                    Value = new ExtensionValue
                    {
                        Value = l.Freetext1,
                        Type = ExtensionValueType.String
                    }
                };
                var freetext3 = new ExtensionData
                {
                    Name = "freetext3",
                    Value = new ExtensionValue
                    {
                        Value = l.Freetext3,
                        Type = ExtensionValueType.String
                    }
                };
                extrafields.Add(freetext1);
                extrafields.Add(freetext3);
                
                var subproduct = new Product
                {
                    Code = l.Subcode,
                    Description = l.Name,
                    SalesPrice = l.Unitspriceexcl,
                    ExtraFields = extrafields,
                    SupplierCode = l.Freetext2,
                    BestelEenheid = l.Units
                };
                list.Add(subproduct);
            }
            var product = new Product
            {
                Code = article.Header.Code,
                Description = article.Header.Name
            };
            list.Add(product);
            return list;
        }

        public Article ConvertProduct(Product product, string office, string vatCode)
        {
            var list = new List<Line>();

                var line = new Line
                {
                    Subcode = product.Code,
                    Name = product.Description,
                    Unitspriceexcl = product.SalesPrice,
                    Units = (int) product.BestelEenheid,
                    Freetext1 = product.ExtraFields[0].Value.Value,
                    Freetext2 = product.SupplierCode,
                    Freetext3 = product.ExtraFields[1].Value.Value
                };
            list.Add(line);

            return new Article
            {
                Header = new Header
                {
                    Office = office,
                    Code = product.Code,
                    Name = product.Description,
                    Shortname = product.Description,
                    Vatcode = vatCode,
                },
                Lines = new Lines
                {
                    Line = list
                }
            };
        }
    }
}
