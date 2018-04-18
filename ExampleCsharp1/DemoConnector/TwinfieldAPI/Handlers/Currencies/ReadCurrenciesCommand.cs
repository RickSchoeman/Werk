using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.Currencies
{
    public class ReadCurrenciesCommand
    {
        public string Office { get; set; }
        public string CurrenciesType { get; set; }
        public string CurrenciesCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("currency");
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = CurrenciesCode;
            return command;
        }
    }
}
