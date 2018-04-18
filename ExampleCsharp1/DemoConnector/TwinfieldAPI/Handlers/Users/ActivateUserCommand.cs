using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Users;

namespace DemoConnector.TwinfieldAPI.Handlers.Users
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
