using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.Currencies
{
    public class Currency
    {
        internal static Currency FromXml(XmlElement element)
        {
            var rates = new List<Rate>();
            XmlNodeList elemListRates = element.GetElementsByTagName("rate");
            for (int i = 0; i < elemListRates.Count; i++)
            {
                if (!elemListRates[i].Equals(null) || elemListRates[i] != null ||
                    !elemListRates[i].SelectInnerText("startdate").Equals("") ||
                    elemListRates[i].SelectInnerText("startdate") != "")
                {
                    if (elemListRates[i].FirstChild.InnerText == elemListRates[i].SelectInnerText("startdate"))
                    {
                        var rate = new Rate
                        {
                            Startdate = elemListRates[i].SelectInnerText("startdate"),
                            rate = elemListRates[i].SelectInnerText("rate")
                        };
                        rates.Add(rate);
                    }
                }
            }

            return new Currency
            {
                Office = element.SelectInnerText("office"),
                Code = element.SelectInnerText("code"),
                Touched = element.SelectInnerText("touched"),
                Rates = new Rates
                {
                    Rate = rates
                },
                Uid = element.SelectInnerText("uid"),
                User = element.SelectInnerText("user"),
                Created = element.SelectInnerText("created"),
                Modified = element.SelectInnerText("modified"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),

            };
        }


        public string Office { get; set; }
        public string Code { get; set; }
        public string Touched { get; set; }
        public Rates Rates { get; set; }
        public string Uid { get; set; }
        public string User { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }


        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var currency = document.AppendNewElement("currency");
            return document;
        }
    }

    public class Rate
    {
        public string Startdate { get; set; }
        public string rate { get; set; }
    }

    public class Rates
    {
        public List<Rate> Rate { get; set; }
    }
}