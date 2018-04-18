using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.VATs
{
    public class ReadVatCommand
    {
        public string Office { get; set; }
        public string VatCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "vat";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = VatCode;
            return command;
        }
    }
}
