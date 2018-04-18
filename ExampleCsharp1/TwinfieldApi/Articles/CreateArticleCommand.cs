using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Articles
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
            h.AppendNewElement("type").InnerText = Article.Header.Type;
            h.AppendNewElement("name").InnerText = Article.Header.Name;
            h.AppendNewElement("shortname").InnerText = Article.Header.Shortname;
            h.AppendNewElement("unitnamesingular").InnerText = Article.Header.Unitnamesingular;
            h.AppendNewElement("unitnameplural").InnerText = Article.Header.Unitnameplural;
            h.AppendNewElement("vatcode").InnerText = Article.Header.Vatcode;
            h.AppendNewElement("allowchangevatcode").InnerText = Article.Header.Allowchangevatcode;
//            h.AppendNewElement("performancetype").InnerText = Article.Header.Performancetype;
//            h.AppendNewElement("allowchangeperformancetype").InnerText =
//                Article.Header.Allowchangeperformancetype;
//            h.AppendNewElement("percentage").InnerText = Article.Header.Percentage;
            h.AppendNewElement("allowdiscountorpremium").InnerText = Article.Header.Allowdiscountorpremium;
//            h.AppendNewElement("allowchangeunitprice").InnerText = Article.Header.Allowchangeunitsprice;
            h.AppendNewElement("allowdecimalquantity").InnerText = Article.Header.Allowdecimalquantity;
            var l1 = createElement.AppendNewElement("lines");
            for (int i = 0; i < Article.Lines.Line.Count; i++)
            {
                if (!Article.Lines.Line[i].Equals(null) || Article.Lines.Line[i] != null || !Article.Lines.Line[i].Name.Equals("") || Article.Lines.Line[i].Name != "")
                {
                    var line = Article.Lines.Line[i];
                    var l2 = l1.AppendNewElement("line");
                    l2.SetAttribute("id", i.ToString());
                    l2.AppendNewElement("unitspriceexcl").InnerText = line.Unitspriceexcl;
                    l2.AppendNewElement("unitspriceinc").InnerText = line.Unitspriceinc;
                    l2.AppendNewElement("units").InnerText = line.Units;
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
