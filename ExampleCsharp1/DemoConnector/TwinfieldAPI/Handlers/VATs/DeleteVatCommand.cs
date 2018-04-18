using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.VATs;

namespace DemoConnector.TwinfieldAPI.Handlers.VATs
{
    public class DeleteVatCommand
    {
        public Vat Vat { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("vat");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = Vat.Office;
            element.AppendNewElement("code").InnerText = Vat.Code;
            return command;
        }
    }
}
