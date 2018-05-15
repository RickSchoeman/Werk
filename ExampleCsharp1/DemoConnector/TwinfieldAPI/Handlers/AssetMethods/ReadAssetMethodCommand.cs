using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.AssetMethods
{
    public class ReadAssetMethodCommand 
    {
        public string Office { get; set; }
        public string AssetMethodType { get; set; }
        public string AssetMethodCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("assetmethod");
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = AssetMethodCode;
            return command;
        }
    }
}
