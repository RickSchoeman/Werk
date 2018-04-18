using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.CostCenters;

namespace DemoConnector.TwinfieldAPI.Handlers.CostCenters
{
    public class DeleteCostCenterCommand
    {
        public CostCenter CostCenter { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("code").InnerText = CostCenter.Code;
            element.AppendNewElement("type").InnerText = CostCenter.Type;
            return command;
        }
    }
}
