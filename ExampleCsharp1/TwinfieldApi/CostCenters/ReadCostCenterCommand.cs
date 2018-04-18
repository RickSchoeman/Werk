using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.CostCenters
{
    public class ReadCostCenterCommand
    {
        public string Office { get; set; }
        public string CostCenterType { get; set; }
        public string CostCenterCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "dimensions";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("dimtype").InnerText = CostCenterType;
            readElement.AppendNewElement("code").InnerText = CostCenterCode;
            return command;
        }
    }
}
