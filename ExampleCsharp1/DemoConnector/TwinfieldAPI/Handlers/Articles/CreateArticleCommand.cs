using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Articles;

namespace DemoConnector.TwinfieldAPI.Handlers.Articles
{
    public class CreateArticleCommand
    {
        public Article Article { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("article");
            var h = createElement.AppendNewElement("header");
            h.AppendNewElement("office").InnerText = Article.Header.Office;
            h.AppendNewElement("code").InnerText = Article.Header.Code;
            h.AppendNewElement("type").InnerText = Article.Header.Type.ToString().ToLower();
            h.AppendNewElement("name").InnerText = Article.Header.Name;
            h.AppendNewElement("shortname").InnerText = Article.Header.Shortname;
            h.AppendNewElement("unitnamesingular").InnerText = Article.Header.Unitnamesingular;
            h.AppendNewElement("unitnameplural").InnerText = Article.Header.Unitnameplural;
            h.AppendNewElement("vatcode").InnerText = Article.Header.Vatcode;
            h.AppendNewElement("allowchangevatcode").InnerText = Article.Header.Allowchangevatcode.ToString().ToLower();
            h.AppendNewElement("allowdiscountorpremium").InnerText = Article.Header.Allowdiscountorpremium.ToString().ToLower();
            h.AppendNewElement("allowdecimalquantity").InnerText = Article.Header.Allowdecimalquantity.ToString().ToLower();
            var l1 = createElement.AppendNewElement("lines");
            for (int i = 0; i < Article.Lines.Line.Count; i++)
            {
                if (Article.Lines.Line[i] != null)
                {
                    var line = Article.Lines.Line[i];
                    var l2 = l1.AppendNewElement("line");
                    l2.SetAttribute("id", i.ToString());
                    l2.AppendNewElement("unitspriceexcl").InnerText = line.Unitspriceexcl;
                    l2.AppendNewElement("unitspriceinc").InnerText = line.Unitspriceinc;
                    l2.AppendNewElement("units").InnerText = line.Units.ToString().ToLower();
                    l2.AppendNewElement("name").InnerText = line.Name;
                    l2.AppendNewElement("shortname").InnerText = line.Shortname;
                    l2.AppendNewElement("subcode").InnerText = line.Subcode;
                    l2.AppendNewElement("freetext1").InnerText = line.Freetext1;
                }
            }

            return command;
        }
    }
}
