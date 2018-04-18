using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;

namespace DemoConnector.TwinfieldAPI.Handlers.GeneralLedgers
{
    public class DeleteGeneralLedgerCommand
    {
        public GeneralLedger GeneralLedger { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = GeneralLedger.Office;
            element.AppendNewElement("type").InnerText = GeneralLedger.Type;
            element.AppendNewElement("code").InnerText = GeneralLedger.Code;
            return command;
        }
    }
}
