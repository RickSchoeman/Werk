using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Users
{
    public class ActivateUserCommand
    {
        public User User { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("user");
            element.SetAttribute("status", "active");
            element.AppendNewElement("code").InnerText = User.Code;
            return command;
        }
    }
}
