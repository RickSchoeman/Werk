using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.SalesInvoice
{
    public class ReadSalesInvoiceCommand
    {
        public string Office { get; set; }
        public string SalesInvoiceType { get; set; }
        public string InvoiceNumber { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "salesinvoice";
            readElement.AppendNewElement("office").InnerText = Office;
            //hij haalt gegevens op die niet bestaan in de omgeving
            readElement.AppendNewElement("code").InnerText = SalesInvoiceType;
            readElement.AppendNewElement("invoicenumber").InnerText = InvoiceNumber;
            return command;
        }
    }
}
