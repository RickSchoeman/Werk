using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.DimensionGroups;

namespace DemoConnector.TwinfieldAPI.Handlers.DimensionGroups
{
    public class DeleteDimensionGroupCommand
    {
        public DimensionGroup DimensionGroup { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimensiongroup");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = DimensionGroup.Office;
            element.AppendNewElement("code").InnerText = DimensionGroup.Code;
            return command;
        }
    }
}
