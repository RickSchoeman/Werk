using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.DimensionTypes
{
    public class ReadDimensionTypeCommand
    {
        public string Office { get; set; }
        public string DimensionTypeCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("dimensiontype");
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = DimensionTypeCode;
            return command;
        }
    }
}
