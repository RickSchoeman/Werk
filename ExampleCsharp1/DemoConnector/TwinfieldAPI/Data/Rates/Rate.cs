using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.Rates
{
    public class Rate
    {
        internal static Rate FromXml(XmlElement element)
        {
            var ratechanges = new List<Ratechange>();
            XmlNodeList elemList = element.GetElementsByTagName("ratechange");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (!elemList[i].Equals(null) || elemList[i] != null || !elemList[i].SelectInnerText("begindate").Equals("") || elemList[i].SelectInnerText("begindate") != "")
                {
                    var ratechange = new Ratechange
                    {
                        Begindate = elemList[i].SelectInnerText("begindate"),
                        Enddate = elemList[i].SelectInnerText("enddate"),
                        Internalrate = elemList[i].SelectInnerText("internalrate"),
                        Externalrate = elemList[i].SelectInnerText("externalrate")
                    };
                    ratechanges.Add(ratechange);
                }
            }

            return new Rate
            {
                Office = element.SelectInnerText("office"),
                Code = element.SelectInnerText("code"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Type = element.SelectInnerText("type"),
                Unit = element.SelectInnerText("unit"),
                Currency = element.SelectInnerText("currency"),
                Ratechanges = new Ratechanges
                {
                    Ratechange = ratechanges
                },
                User = element.SelectInnerText("user"),
                Touched = element.SelectInnerText("touched"),
                Created = element.SelectInnerText("created"),
                Modified = element.SelectInnerText("modified")
            };
        }
        public string Office { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string Currency { get; set; }
        public Ratechanges Ratechanges { get; set; }
        public string User { get; set; }
        public string Touched { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var rate = document.AppendNewElement("projectrate");
            rate.AppendNewElement("office").InnerText = Office;
            rate.AppendNewElement("code").InnerText = Code;
            rate.AppendNewElement("name").InnerText = Name;
            rate.AppendNewElement("shortname").InnerText = Shortname;
            rate.AppendNewElement("type").InnerText = Type;
            rate.AppendNewElement("unit").InnerText = Unit;
            rate.AppendNewElement("currency").InnerText = Currency;
            for (int i = 0; i < Ratechanges.Ratechange.Count; i++)
            {
                if (!Ratechanges.Ratechange[i].Equals(null) || Ratechanges.Ratechange[i] != null || !Ratechanges.Ratechange[i].Begindate.Equals("") || Ratechanges.Ratechange[i].Begindate != "")
                {
                    var ratechange = Ratechanges.Ratechange[i];
                    rate.AppendNewElement("ratechanges/ratechange[@id='" + i + "']/begindate").InnerText =
                        ratechange.Begindate;
                    rate.AppendNewElement("ratechanges/ratechange[@id='" + i + "']/enddate").InnerText =
                        ratechange.Enddate;
                    rate.AppendNewElement("ratechanges/ratechange[@id='" + i + "']/internalrate").InnerText =
                        ratechange.Internalrate;
                    rate.AppendNewElement("ratechanges/ratechange[@id='" + i + "']/externalrate").InnerText =
                        ratechange.Externalrate;
                }
            }

            rate.AppendNewElement("user").InnerText = User;
            rate.AppendNewElement("touched").InnerText = Touched;
            rate.AppendNewElement("created").InnerText = Created;
            rate.AppendNewElement("modified").InnerText = Modified;
            return document;
        }
    }

    public class Ratechanges
    {
        public List<Ratechange> Ratechange { get; set; }
    }

    public class Ratechange
    {
        public string Id { get; set; }
        public string Begindate { get; set; }
        public string Enddate { get; set; }
        public string Internalrate { get; set; }
        public string Externalrate { get; set; }
    }
}
