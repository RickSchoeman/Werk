using System;
using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.Articles
{
    public class Article
    {
        internal static Article FromXml(XmlElement element)
        {
            var list = new List<Line>();
            XmlNodeList elemList = element.GetElementsByTagName("line");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (elemList[i].SelectInnerText("name") != null)
                {
                    var line = new Line
                    {
                        Unitspriceexcl = elemList[i].SelectInnerText("unitspriceexcl"),
                        Unitspriceinc = elemList[i].SelectInnerText("unitspriceincl"),
                        Units = int.Parse(elemList[i].SelectInnerText("units")),
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

            var type = Type.Normal;
            bool allowChangeVatCode = false;
            bool allowChangePerformanceType = false;
            bool allowDiscountorPremium = false;
            bool allowChangeUnitsPrice = false;
            bool allowDecimalQuantity = false;

            if (element.SelectInnerText("header/allowchangevatcode") == "true")
            {
                allowChangeVatCode = true;
            }

            if (element.SelectInnerText("header/allowchangeperformancetype") == "true")
            {
                allowChangePerformanceType = true;
            }

            if (element.SelectInnerText("header/allowdiscountorpremium") == "true")
            {
                allowDiscountorPremium = true;
            }

            if (element.SelectInnerText("header/allowchangeunitprice") == "true")
            {
                allowChangeUnitsPrice = true;
            }

            if (element.SelectInnerText("header/allowdecimalquantity") == "true")
            {
                allowDecimalQuantity = true;
            }
            if (element.SelectInnerText("header/type") == Type.Discount.ToString())
            {
                type = Type.Discount;
            }

            if (element.SelectInnerText("header/type") == Type.Premium.ToString())
            {
                type = Type.Premium;
            }
            return new Article
            {
                Header = new Header
                {
                    Office = element.SelectInnerText("header/office"),
                    Code = element.SelectInnerText("header/code"),
                    Type = type,
                    Name = element.SelectInnerText("header/name"),
                    Shortname = element.SelectInnerText("header/shortname"),
                    Unitnamesingular = element.SelectInnerText("header/unitnamesingular"),
                    Unitnameplural = element.SelectInnerText("header/unitnameplural"),
                    Vatcode = element.SelectInnerText("header/vatcode"),
                    Allowchangevatcode = allowChangeVatCode,
                    Performancetype = element.SelectInnerText("header/performancetype"),
                    Allowchangeperformancetype = allowChangePerformanceType,
                    Allowdiscountorpremium = allowDiscountorPremium,
                    Allowchangeunitsprice = allowChangeUnitsPrice,
                    Allowdecimalquantity = allowDecimalQuantity
                },
                Lines = new Lines
                {
                    Line = list
                }
            };
        }

        public Article()
        {
            Header = new Header
            {
                Type = Type.Normal,
                Allowdiscountorpremium = false,
                Allowchangevatcode = false,
                Allowdecimalquantity = false,
                Allowchangeunitsprice = false,
                Allowchangeperformancetype = false,
                Vatcode = "IN"
            };
        }

        public Header Header { get; set; }
        public Lines Lines { get; set; }
    }

    public class Header
    {
        public string Office { get; set; }
        public string Code { get; set; }
        public Type Type { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Unitnamesingular { get; set; }
        public string Unitnameplural { get; set; }
        public string Vatcode { get; set; }
        public bool Allowchangevatcode { get; set; }
        public string Performancetype { get; set; }
        public bool Allowchangeperformancetype { get; set; }

        public bool Percentage => Type != Type.Normal;

        public bool Allowdiscountorpremium { get; set; }
        public bool Allowchangeunitsprice { get; set; }
        public bool Allowdecimalquantity { get; set; }
    }

    public enum Type
    {
        Normal,
        Discount,
        Premium
    }

    public class Line
    {
        public int Id { get; set; }
        public string Unitspriceexcl { get; set; }
        public string Unitspriceinc { get; set; }
        public int Units { get; set; }
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