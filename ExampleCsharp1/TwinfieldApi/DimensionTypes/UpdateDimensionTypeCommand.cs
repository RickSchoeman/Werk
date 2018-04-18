using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.DimensionTypes
{
    public class UpdateDimensionTypeCommand
    {
        public DimensionType DimensionType { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimensiontype");
            createElement.AppendNewElement("office").InnerText = DimensionType.Office;
            createElement.AppendNewElement("code").InnerText = DimensionType.Code;
            createElement.AppendNewElement("name").InnerText = DimensionType.Name;
            createElement.AppendNewElement("mask").InnerText = DimensionType.Mask;
            createElement.AppendNewElement("shortname").InnerText = DimensionType.Shortname;
            var a1 = createElement.AppendNewElement("address");
            a1.AppendNewElement("label1").InnerText = DimensionType.address.Label1;
            a1.AppendNewElement("label2").InnerText = DimensionType.address.Label2;
            a1.AppendNewElement("label3").InnerText = DimensionType.address.Label3;
            a1.AppendNewElement("label4").InnerText = DimensionType.address.Label4;
            a1.AppendNewElement("label5").InnerText = DimensionType.address.Label5;
            a1.AppendNewElement("label6").InnerText = DimensionType.address.Label6;
            return command;
        }
    }
}
