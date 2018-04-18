using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.Customers
{
    public class ReadCustomerCommandcs
    {
        public string Office { get; set; }
        public string CustomerType { get; set; }
        public string CustomerCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "dimensions";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("dimtype").InnerText = CustomerType;
            readElement.AppendNewElement("code").InnerText = CustomerCode;
            return command;
        }
    }
}
