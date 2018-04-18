using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Articles
{
    public class DeleteArticleCommand
    {
        public Article Article { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("article");
            var h = element.AppendNewElement("header");
            h.SetAttribute("status", "deleted");
            h.AppendNewElement("office").InnerText = Article.Header.Office;
            h.AppendNewElement("code").InnerText = Article.Header.Code;
            return command;
        }
    }
}
