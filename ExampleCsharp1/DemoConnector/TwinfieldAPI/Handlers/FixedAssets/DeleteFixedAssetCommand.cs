﻿using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.FixedAssets;

namespace DemoConnector.TwinfieldAPI.Handlers.FixedAssets
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
