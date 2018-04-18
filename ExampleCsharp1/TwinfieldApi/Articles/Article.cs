using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Articles
{
    public class Article
    {
        internal static Article FromXml(XmlElement element)
        {
            var list = new List<Line>();
            XmlNodeList elemList = element.GetElementsByTagName("line");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (elemList[i].SelectInnerText("name").Equals(null) ||
                    elemList[i].SelectInnerText("name") != null ||
                    elemList[i].SelectInnerText("name") != "" ||
                    elemList[i].SelectInnerText("name").Equals(""))
                {
                    var line = new Line
                    {
                        Unitspriceexcl = elemList[i].SelectInnerText("unitspriceexcl"),
                        Unitspriceinc = elemList[i].SelectInnerText("unitspriceincl"),
                        Units = elemList[i].SelectInnerText("units"),
                        Name = elemList[i].SelectInnerText("name"),
                        Shortname = elemList[i].SelectInnerText("shortname"),
                        Subcode = elemList[i].SelectInnerText("subcode"),
                        Freetext1 = elemList[i].SelectInnerText("freetext1"),
                        Freetext2 = elemList[i].SelectInnerText("freetext2"),
                        Freetext3 = elemList[i].SelectInnerText("freetext3"),
                        Freetext4 = elemList[i].SelectInnerText("freetext4"),
                        Freetext5 = elemList[i].SelectInnerText("freetext5"),
                        Freetext6 = elemList[i].SelectInnerText("freetext6"),
                    };
                    list.Add(line);
                }
            }

            return new Article
            {
                Header = new Header
                {
                    Office = element.SelectInnerText("header/office"),
                    Code = element.SelectInnerText("header/code"),
                    Type = element.SelectInnerText("header/type"),
                    Name = element.SelectInnerText("header/name"),
                    Shortname = element.SelectInnerText("header/shortname"),
                    Unitnamesingular = element.SelectInnerText("header/unitnamesingular"),
                    Unitnameplural = element.SelectInnerText("header/unitnameplural"),
                    Vatcode = element.SelectInnerText("header/vatcode"),
                    Allowchangevatcode = element.SelectInnerText("header/allowchangevatcode"),
                    Performancetype = element.SelectInnerText("header/performancetype"),
                    Allowchangeperformancetype = element.SelectInnerText("header/allowchangeperformancetype"),
                    Percentage = element.SelectInnerText("header/percentage"),
                    Allowdiscountorpremium = element.SelectInnerText("header/allowdiscountorpremium"),
                    Allowchangeunitsprice = element.SelectInnerText("header/allowchangeunitprice"),
                    Allowdecimalquantity = element.SelectInnerText("header/allowdecimalquantity")
                },
                Lines = new Lines
                {
                    Line = list
                }
            };
        }

        public Header Header { get; set; }
        public Lines Lines { get; set; }

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var article = document.AppendNewElement("article");
            article.AppendNewElement("header/office").InnerText = Header.Office;
            article.AppendNewElement("header/code").InnerText = Header.Code;
            article.AppendNewElement("header/type").InnerText = Header.Type;
            article.AppendNewElement("header/name").InnerText = Header.Name;
            article.AppendNewElement("header/shortname").InnerText = Header.Shortname;
            article.AppendNewElement("header/unitnamesingular").InnerText = Header.Unitnamesingular;
            article.AppendNewElement("header/unitnameplural").InnerText = Header.Unitnameplural;
            article.AppendNewElement("header/vatcode").InnerText = Header.Vatcode;
            article.AppendNewElement("header/allowchangevatcode").InnerText = Header.Allowchangevatcode;
            article.AppendNewElement("header/allowdiscounterpremium").InnerText = Header.Allowdiscountorpremium;
            article.AppendNewElement("header/allowchangeunitprice").InnerText = Header.Allowchangeunitsprice;
            article.AppendNewElement("header/allowdecimalquantity").InnerText = Header.Allowdecimalquantity;
            for (int i = 0; i < Lines.Line.Count; i++)
            {
                if (!Lines.Line[i].Equals(null) || Lines.Line[i] != null || Lines.Line[i].Name.Equals("") ||
                    Lines.Line[i].Name != "")
                {
                    var line = Lines.Line[i];
                    article.AppendNewElement("lines/line[@id='" + i + "']/unitspriceexcl").InnerText =
                        line.Unitspriceexcl;
                    article.AppendNewElement("lines/line[@id='" + i + "']/unitspriceincl").InnerText =
                        line.Unitspriceinc;
                    article.AppendNewElement("lines/line[@id='" + i + "']/units").InnerText = line.Units;
                    article.AppendNewElement("lines/line[@id='" + i + "']/name").InnerText = line.Name;
                    article.AppendNewElement("lines/line[@id='" + i + "']/shortname").InnerText = line.Shortname;
                    article.AppendNewElement("lines/line[@id='" + i + "']/subcode").InnerText = line.Subcode;
                    article.AppendNewElement("lines/line[@id='" + i + "']/freetext1").InnerText = line.Freetext1;
                    article.AppendNewElement("lines/line[@id='" + i + "']/freetext2").InnerText = line.Freetext2;
                    article.AppendNewElement("lines/line[@id='" + i + "']/freetext3").InnerText = line.Freetext3;
                    article.AppendNewElement("lines/line[@id='" + i + "']/freetext4").InnerText = line.Freetext4;
                    article.AppendNewElement("lines/line[@id='" + i + "']/freetext5").InnerText = line.Freetext5;
                    article.AppendNewElement("lines/line[@id='" + i + "']/freetext6").InnerText = line.Freetext6;
                }
            }

            return document;
        }
    }

    public class Header
    {
        public string Office { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Unitnamesingular { get; set; }
        public string Unitnameplural { get; set; }
        public string Vatcode { get; set; }
        public string Allowchangevatcode { get; set; }
        public string Performancetype { get; set; }
        public string Allowchangeperformancetype { get; set; }
        public string Percentage { get; set; }
        public string Allowdiscountorpremium { get; set; }
        public string Allowchangeunitsprice { get; set; }
        public string Allowdecimalquantity { get; set; }
    }

    public class Line
    {
        public string Id { get; set; }
        public string Unitspriceexcl { get; set; }
        public string Unitspriceinc { get; set; }
        public string Units { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Subcode { get; set; }
        public string Freetext1 { get; set; }
        public string Freetext2 { get; set; }
        public string Freetext3 { get; set; }
        public string Freetext4 { get; set; }
        public string Freetext5 { get; set; }
        public string Freetext6 { get; set; }
    }

    public class Lines
    {
        public List<Line> Line { get; set; }
    }
}