using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.Rates
{
    public class ReadRateCommand
    {
        public string Office { get; set; }
        public string RateCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "projectrate";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = RateCode;
            return command;
        }
    }
}
