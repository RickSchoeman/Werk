using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.Projects
{
    class ReadProjectCommand
    {
        public string Office { get; set; }
        public string Dimtype { get; set; }
        public string ProjectCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "dimensions";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("dimtype").InnerText = Dimtype;
            readElement.AppendNewElement("code").InnerText = ProjectCode;
            return command;
        }
    }
}
