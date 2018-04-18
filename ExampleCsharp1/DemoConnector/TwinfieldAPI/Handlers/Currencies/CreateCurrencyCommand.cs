using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Currencies;

namespace DemoConnector.TwinfieldAPI.Handlers.Currencies
{
    public class CreateCurrencyCommand
    {
        public Currency Currency { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var c1 = command.AppendNewElement("currency");
            c1.AppendNewElement("office").InnerText = Currency.Office;
            c1.AppendNewElement("code").InnerText = Currency.Code;
            c1.AppendNewElement("name").InnerText = Currency.Name;
            c1.AppendNewElement("shortname").InnerText = Currency.Shortname;
            var r1 = c1.AppendNewElement("rates");
            for (int i = 0; i < Currency.Rates.Rate.Count; i++)
            {
                if (!Currency.Rates.Rate[i].Equals(null) || Currency.Rates.Rate[i] != null || !Currency.Rates.Rate[i].Startdate.Equals("") || Currency.Rates.Rate[i].Startdate != "")
                {
                    var rate = Currency.Rates.Rate[i];
                    var r2 = r1.AppendNewElement("rate");
                    r2.SetAttribute("id", (i + 1).ToString());
                    r2.AppendNewElement("startdate").InnerText = rate.Startdate;
                    r2.AppendNewElement("rate").InnerText = rate.rate;
                }
            }

            return command;
        }
    }
}
