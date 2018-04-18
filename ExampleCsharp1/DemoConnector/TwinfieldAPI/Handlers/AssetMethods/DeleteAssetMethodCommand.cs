using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.AssetMethods;

namespace DemoConnector.TwinfieldAPI.Handlers.AssetMethods
{
    public class DeleteAssetMethodCommand
    {
        public AssetMethod AssetMethod { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("assetmethod");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = AssetMethod.Office;
            element.AppendNewElement("code").InnerText = AssetMethod.Code;
            return command;
        }
    }
}
