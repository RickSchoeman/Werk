using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.SalesTransactions
{
    public class ReadSalesTransactionCommand
    {
        public string Office { get; set; }
        public string SalesTransactionCode { get; set; }
        public string SalesTransactionNumber { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "transaction";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = SalesTransactionCode;
            readElement.AppendNewElement("number").InnerText = SalesTransactionNumber;
            return command;
        }
    }
}
