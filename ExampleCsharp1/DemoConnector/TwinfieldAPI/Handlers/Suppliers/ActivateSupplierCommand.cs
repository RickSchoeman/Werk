using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Suppliers;

namespace DemoConnector.TwinfieldAPI.Handlers.Suppliers
{
    public class ActivateSupplierCommand
    {
        public Supplier Supplier { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "active");
            element.AppendNewElement("office").InnerText = Supplier.Office;
            element.AppendNewElement("type").InnerText = Supplier.Type;
            element.AppendNewElement("code").InnerText = Supplier.Code;
            return command;
        }
    }
}
