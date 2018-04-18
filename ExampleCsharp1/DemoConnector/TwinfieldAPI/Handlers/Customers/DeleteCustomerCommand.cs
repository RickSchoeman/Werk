using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Customers;

namespace DemoConnector.TwinfieldAPI.Handlers.Customers
{
    public class DeleteCustomerCommand
    {
        public Customer Customer { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("type").InnerText = Customer.Type;
            element.AppendNewElement("code").InnerText = Customer.Code;
            return command;
        }
    }
}
