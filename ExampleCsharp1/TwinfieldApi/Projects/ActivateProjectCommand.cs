using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Projects
{
    public class ActivateProjectCommand
    {
        public Project Project { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "active");
            element.AppendNewElement("office").InnerText = Project.Office;
            element.AppendNewElement("type").InnerText = Project.Type;
            element.AppendNewElement("code").InnerText = Project.Code;
            return command;
        }
    }
}
