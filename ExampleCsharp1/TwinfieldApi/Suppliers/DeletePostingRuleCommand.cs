using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Suppliers
{
    public class DeletePostingRuleCommand
    {
        public Supplier Supplier { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.AppendNewElement("office").InnerText = Supplier.Office;
            element.AppendNewElement("type").InnerText = Supplier.Type;
            element.AppendNewElement("code").InnerText = Supplier.Code;
            var p1 = element.AppendNewElement("postingrules");
            var p2 = p1.AppendNewElement("postingrule");
            p2.SetAttribute("status", "deleted");
            p2.SetAttribute("id", Supplier.postingrules.Postingrule[0].Id);
            return command;
        }
    }
}
