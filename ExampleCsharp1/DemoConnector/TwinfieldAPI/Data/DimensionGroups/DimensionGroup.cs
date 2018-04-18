using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.DimensionGroups
{
    public class DimensionGroup
    {
        internal static DimensionGroup FromXml(XmlElement element)
        {
            var dimensions = new List<Dimension>();
            XmlNodeList elemList = element.GetElementsByTagName("dimension");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (!elemList[i].Equals(null) || elemList[i] != null || !elemList[i].SelectInnerText("type").Equals("") || elemList[i].SelectInnerText("type") != "")
                {
                    var dimension = new Dimension
                    {
                        Type = elemList[i].SelectInnerText("type"),
                        Code = elemList[i].SelectInnerText("code")
                    };
                    dimensions.Add(dimension);
                }
            }

            return new DimensionGroup
            {
                Office = element.SelectInnerText("office"),
                Code = element.SelectInnerText("code"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Dimensions = new Dimensions
                {
                    Dimension = dimensions
                }
            };
        }

        public string Office { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public Dimensions Dimensions { get; set; }

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var dimensionGroup = document.AppendNewElement("dimensiongroup");
            dimensionGroup.AppendNewElement("office").InnerText = Office;
            dimensionGroup.AppendNewElement("code").InnerText = Code;
            dimensionGroup.AppendNewElement("name").InnerText = Name;
            dimensionGroup.AppendNewElement("shortname").InnerText = Shortname;
            for (int i = 0; i < Dimensions.Dimension.Count; i++)
            {
                if (!Dimensions.Dimension[i].Equals(null) || Dimensions.Dimension[i] != null || !Dimensions.Dimension[i].Type.Equals("") || Dimensions.Dimension[i].Type != "")
                {
                    var dimension = Dimensions.Dimension[i];
                    dimensionGroup.AppendNewElement("dimensions/dimension[@id='" + i + "']/type").InnerText =
                        dimension.Type;
                    dimensionGroup.AppendNewElement("dimensions/dimension[@id='" + i + "']/code").InnerText =
                        dimension.Code;
                }
            }

            return document;
        }
    }

    public class Dimension
    {
        public string Type { get; set; }
        public string Code { get; set; }
    }
    
    public class Dimensions
    {
        public List<Dimension> Dimension { get; set; }
    }
    
}
