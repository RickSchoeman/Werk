using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Articles
{
    public class DeleteSubArticleCommand
    {
        public Article Article { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("article");
            var h = element.AppendNewElement("header");
            h.AppendNewElement("office").InnerText = Article.Header.Office;
            h.AppendNewElement("code").InnerText = Article.Header.Code;
            var l1 = element.AppendNewElement("lines");
            var l2 = l1.AppendNewElement("line");
            l2.SetAttribute("status", "deleted");
            l2.AppendNewElement("subcode").InnerText = Article.Lines.Line[0].Subcode;
            return command;
        }
    }
}
