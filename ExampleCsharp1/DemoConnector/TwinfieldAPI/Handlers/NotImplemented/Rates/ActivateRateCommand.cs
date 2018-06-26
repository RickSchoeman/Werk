using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Rates;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.Rates
{
    public class ActivateRateCommand
    {
        public Rate Rate { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("projectrate");
            element.SetAttribute("status", "active");
            element.AppendNewElement("office").InnerText = Rate.Office;
            element.AppendNewElement("code").InnerText = Rate.Code;
            return command;
        }
    }
}
