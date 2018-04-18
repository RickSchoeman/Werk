using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Activities;

namespace DemoConnector.TwinfieldAPI.Handlers.Activities
{
    public class ActivateActivityCommand
    {
        public Activity Activity { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "active");
            element.AppendNewElement("office").InnerText = Activity.Office;
            element.AppendNewElement("type").InnerText = Activity.Type;
            element.AppendNewElement("code").InnerText = Activity.Code;
            return command;
        }
    }
}
