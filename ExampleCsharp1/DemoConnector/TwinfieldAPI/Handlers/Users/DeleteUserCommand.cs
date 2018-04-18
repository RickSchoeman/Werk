using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Users;

namespace DemoConnector.TwinfieldAPI.Handlers.Users
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
