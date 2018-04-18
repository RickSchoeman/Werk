using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.CostCenters;

namespace DemoConnector.TwinfieldAPI.Handlers.CostCenters
{
    public class ActivateCostCenterCommand
    {
        public CostCenter CostCenter { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "active");
            element.AppendNewElement("office").InnerText = CostCenter.Office;
            element.AppendNewElement("type").InnerText = CostCenter.Type;
            element.AppendNewElement("code").InnerText = CostCenter.Code;
            return command;
        }
    }
}
