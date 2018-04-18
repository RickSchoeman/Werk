using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.CostCenters
{
    public class ReadCostCenterCommand
    {
        public string Office { get; set; }
        public string CostCenterType { get; set; }
        public string CostCenterCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "dimensions";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("dimtype").InnerText = CostCenterType;
            readElement.AppendNewElement("code").InnerText = CostCenterCode;
            return command;
        }
    }
}
