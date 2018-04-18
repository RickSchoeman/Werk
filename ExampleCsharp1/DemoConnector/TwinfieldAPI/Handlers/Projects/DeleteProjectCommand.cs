using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Projects;

namespace DemoConnector.TwinfieldAPI.Handlers.Projects
{
    public class DeleteProjectCommand
    {
        public Project Project { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = Project.Office;
            element.AppendNewElement("type").InnerText = Project.Type;
            element.AppendNewElement("code").InnerText = Project.Code;
            return command;
        }
    }
}
