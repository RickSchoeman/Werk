using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Customers
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
