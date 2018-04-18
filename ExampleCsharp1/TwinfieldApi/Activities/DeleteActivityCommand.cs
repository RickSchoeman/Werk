using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Activities
{
    public class DeleteActivityCommand
    {
        public Activity Activity { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("type").InnerText = Activity.Type;
            element.AppendNewElement("code").InnerText = Activity.Code;
            return command;
        }
    }
}
