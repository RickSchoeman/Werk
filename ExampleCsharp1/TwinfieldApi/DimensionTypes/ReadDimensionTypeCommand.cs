using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.DimensionTypes
{
    public class ReadDimensionTypeCommand
    {
        public string Office { get; set; }
        public string DimensionTypeCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("dimensiontype");
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = DimensionTypeCode;
            return command;
        }
    }
}
