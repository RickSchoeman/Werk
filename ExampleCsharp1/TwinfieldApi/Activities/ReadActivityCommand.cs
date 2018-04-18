using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Activities
{
    public class ReadActivityCommand
    {
        public string Office { get; set; }
        public string ActivityType { get; set; }
        public string ActivityCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "dimensions";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("dimtype").InnerText = ActivityType;
            readElement.AppendNewElement("code").InnerText = ActivityCode;
            return command;
        }
    }
}
