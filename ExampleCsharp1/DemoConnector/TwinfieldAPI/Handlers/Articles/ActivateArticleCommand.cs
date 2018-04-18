using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Articles;

namespace DemoConnector.TwinfieldAPI.Handlers.Articles
{
    public class ActivateArticleCommand
    {
        public Article Article { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("article");
            var h = element.AppendNewElement("header");
            h.SetAttribute("status", "active");
            h.AppendNewElement("office").InnerText = Article.Header.Office;
            h.AppendNewElement("code").InnerText = Article.Header.Code;
            return command;
        }
    }
}
