using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Customers;

namespace DemoConnector.TwinfieldAPI.Handlers.Customers
{
    public class DeletePostingRuleCommand
    {
        public Customer Customer { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.AppendNewElement("office").InnerText = Customer.Office;
            element.AppendNewElement("type").InnerText = Customer.Type;
            element.AppendNewElement("code").InnerText = Customer.Code;
            var p1 = element.AppendNewElement("postingrules");
            var p2 = p1.AppendNewElement("postingrule");
            p2.SetAttribute("status", "deleted");
            p2.SetAttribute("id", Customer.Postingrules.Postingrule[0].Id);
            return command;
        }
    }
}
