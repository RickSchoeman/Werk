using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.GeneralLedgers
{
    public class ReadGeneralLedgerCommand
    {
        public string Office { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "dimensions";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("dimtype").InnerText = Type;
            readElement.AppendNewElement("code").InnerText = Code;
            return command;
        }
    }
}
