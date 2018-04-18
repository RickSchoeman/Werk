using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Customers
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
