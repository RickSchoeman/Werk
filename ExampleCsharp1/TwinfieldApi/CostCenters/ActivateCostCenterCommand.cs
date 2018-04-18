using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.CostCenters
{
    public class ActivateCostCenterCommand
    {
        public CostCenter CostCenter { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "active");
            element.AppendNewElement("office").InnerText = CostCenter.Office;
            element.AppendNewElement("type").InnerText = CostCenter.Type;
            element.AppendNewElement("code").InnerText = CostCenter.Code;
            return command;
        }
    }
}
