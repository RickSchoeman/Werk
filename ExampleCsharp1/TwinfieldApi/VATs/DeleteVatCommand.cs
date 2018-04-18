using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.VATs
{
    public class DeleteVatCommand
    {
        public Vat Vat { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("vat");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = Vat.Office;
            element.AppendNewElement("code").InnerText = Vat.Code;
            return command;
        }
    }
}
