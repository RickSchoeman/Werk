using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.FixedAssets
{
    public class DeleteFixedAssetCommand
    {
        public FixedAsset FixedAsset { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("type").InnerText = FixedAsset.Type;
            element.AppendNewElement("code").InnerText = FixedAsset.Code;
            return command;
        }
    }
}
