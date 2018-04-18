using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.CostCenters
{
    public class DeleteCostCenterCommand
    {
        public CostCenter CostCenter { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("code").InnerText = CostCenter.Code;
            element.AppendNewElement("type").InnerText = CostCenter.Type;
            return command;
        }
    }
}
