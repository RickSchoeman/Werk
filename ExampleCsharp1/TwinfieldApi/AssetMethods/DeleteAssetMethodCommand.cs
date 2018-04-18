using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.AssetMethods
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
