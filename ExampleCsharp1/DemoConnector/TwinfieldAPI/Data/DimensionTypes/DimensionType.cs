using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.DimensionTypes
{
    public class DimensionType
    {
        internal static DimensionType FromXml(XmlElement element)
        {
            return new DimensionType
            {
                Office = element.SelectInnerText("office"),
                Code = element.SelectInnerText("code"),
                Mask = element.SelectInnerText("mask"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Address = new Address
                {
                    Label1 = element.SelectInnerText("address/label1"),
                    Label2 = element.SelectInnerText("address/label2"),
                    Label3 = element.SelectInnerText("address/label3"),
                    Label4 = element.SelectInnerText("address/label4"),
                    Label5 = element.SelectInnerText("address/label5"),
                    Label6 = element.SelectInnerText("address/label6")
                },
                Levels = new Levels
                {
                    Financials = element.SelectInnerText("levels/financials"),
                    Time = element.SelectInnerText("levels/time")
                }
                
            };
        }

        public string Office { get; set; }
        public string Code { get; set; }
        public string Mask { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public Address Address { get; set; }
        public Levels Levels { get; set; }
        
        

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var dimensionType = document.AppendNewElement("dimeniontype");
            
            return document;
        }
    }

    public class Address
    {
        public string Label1 { get; set; }
        public string Label2 { get; set; }
        public string Label3 { get; set; }
        public string Label4 { get; set; }
        public string Label5 { get; set; }
        public string Label6 { get; set; }
    }

    public class Levels
    {
        public string Financials { get; set; }
        public string Time { get; set; }
    }
}
