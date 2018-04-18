using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Currencies;

namespace DemoConnector.TwinfieldAPI.Handlers.Currencies
{
    public class DeleteCurrencyRateCommand
    {
        public Currency Currency { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("currency");
            element.AppendNewElement("office").InnerText = Currency.Office;
            element.AppendNewElement("code").InnerText = Currency.Code;
            var r1 = element.AppendNewElement("rates");
            var r2 = r1.AppendNewElement("rate");
            r2.SetAttribute("status", "deleted");
            r2.AppendNewElement("startdate").InnerText = Currency.Rates.Rate[0].Startdate;
            return command;
        }
    }
}
