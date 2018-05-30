using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.DimensionTypes;

namespace DemoConnector.TwinfieldAPI.Handlers.DimensionTypes
{
    public class UpdateDimensionTypeCommand
    {
        public DimensionType DimensionType { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimensiontype");
            createElement.AppendNewElement("office").InnerText = DimensionType.Office;
            createElement.AppendNewElement("code").InnerText = DimensionType.Code;
            createElement.AppendNewElement("name").InnerText = DimensionType.Name;
            createElement.AppendNewElement("mask").InnerText = DimensionType.Mask;
            createElement.AppendNewElement("shortname").InnerText = DimensionType.Shortname;
            var a1 = createElement.AppendNewElement("address");
            a1.AppendNewElement("label1").InnerText = DimensionType.Address.Label1;
            a1.AppendNewElement("label2").InnerText = DimensionType.Address.Label2;
            a1.AppendNewElement("label3").InnerText = DimensionType.Address.Label3;
            a1.AppendNewElement("label4").InnerText = DimensionType.Address.Label4;
            a1.AppendNewElement("label5").InnerText = DimensionType.Address.Label5;
            a1.AppendNewElement("label6").InnerText = DimensionType.Address.Label6;
            return command;
        }
    }
}
