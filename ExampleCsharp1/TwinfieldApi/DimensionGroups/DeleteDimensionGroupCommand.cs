using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.DimensionGroups
{
    public class DeleteDimensionGroupCommand
    {
        public DimensionGroup DimensionGroup { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimensiongroup");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = DimensionGroup.Office;
            element.AppendNewElement("code").InnerText = DimensionGroup.Code;
            return command;
        }
    }
}
