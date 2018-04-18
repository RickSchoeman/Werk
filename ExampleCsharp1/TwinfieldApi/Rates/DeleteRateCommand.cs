using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Rates
{
    public class DeleteRateCommand
    {
        public Rate Rate { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("projectrate");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = Rate.Office;
            element.AppendNewElement("code").InnerText = Rate.Code;
            return command;
        }
    }
}
