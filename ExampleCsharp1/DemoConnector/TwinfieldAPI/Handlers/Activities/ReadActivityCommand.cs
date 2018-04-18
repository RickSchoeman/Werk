using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.Activities
{
    public class ReadActivityCommand
    {
        public string Office { get; set; }
        public string ActivityType { get; set; }
        public string ActivityCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "dimensions";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("dimtype").InnerText = ActivityType;
            readElement.AppendNewElement("code").InnerText = ActivityCode;
            return command;
        }
    }
}
