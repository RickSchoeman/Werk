﻿using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Projects;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.Projects
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
