using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Rates
{
    public class ActivateRateCommand
    {
        public Rate Rate { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("projectrate");
            element.SetAttribute("status", "active");
            element.AppendNewElement("office").InnerText = Rate.Office;
            element.AppendNewElement("code").InnerText = Rate.Code;
            return command;
        }
    }
}
