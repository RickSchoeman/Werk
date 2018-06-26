using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Rates;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.Rates
{
    public class DeleteRateChangeCommand
    {
        public Rate Rate { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("projectrate");
            element.AppendNewElement("office").InnerText = Rate.Office;
            element.AppendNewElement("code").InnerText = Rate.Code;
            var r1 = element.AppendNewElement("ratechanges");
            var r2 = r1.AppendNewElement("ratechange");
            r2.SetAttribute("status", "deleted");
            r2.SetAttribute("id", Rate.Ratechanges.Ratechange[0].Id);
            return command;
        }
    }
}