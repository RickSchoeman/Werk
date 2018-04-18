using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Users
{
    public class DeleteUserCommand
    {
        public User User;

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("user");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("code").InnerText = User.Code;
            var dr1 = element.AppendNewElement("deletereason");
            dr1.AppendNewElement("code").InnerText = User.Deletereason.Code;
            dr1.AppendNewElement("comment").InnerText = User.Deletereason.Comment;
            return command;
        }
    }
}
