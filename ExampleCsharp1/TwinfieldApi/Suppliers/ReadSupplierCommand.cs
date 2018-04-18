using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Suppliers
{
    class ReadSupplierCommand
    {
        public string Office { get; set; }
        public string SupplierType { get; set; }
        public string SupplierCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "dimensions";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("dimtype").InnerText = SupplierType;
            readElement.AppendNewElement("code").InnerText = SupplierCode;
            return command;
        }
    }
}
