using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Suppliers
{
    public class DeleteSupplierCommand
    {
        public Supplier Supplier { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("code").InnerText = Supplier.Code;
            element.AppendNewElement("type").InnerText = Supplier.Type;
            return command;
        }
    }
}
