using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Currencies;

namespace DemoConnector.TwinfieldAPI.Handlers.Currencies
{
    public class DeleteCurrencyCommand
    {
        public Currency Currency { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("currency");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = Currency.Office;
            element.AppendNewElement("code").InnerText = Currency.Code;
            return command;
        }
    }
}
