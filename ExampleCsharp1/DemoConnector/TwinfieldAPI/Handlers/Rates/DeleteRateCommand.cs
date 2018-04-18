using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Rates;

namespace DemoConnector.TwinfieldAPI.Handlers.Rates
{
    public class DeleteRateCommand
    {
        public Rate Rate { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("projectrate");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = Rate.Office;
            element.AppendNewElement("code").InnerText = Rate.Code;
            return command;
        }
    }
}
