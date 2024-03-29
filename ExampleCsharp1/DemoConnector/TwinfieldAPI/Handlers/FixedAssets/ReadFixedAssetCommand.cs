﻿using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.FixedAssets
{
    class ReadFixedAssetCommand
    {
        public string Office { get; set; }
        public string FixedAssetType { get; set; }
        public string FixedAssetCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "dimensions";
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("dimtype").InnerText = FixedAssetType;
            readElement.AppendNewElement("code").InnerText = FixedAssetCode;
            return command;
        }
    }
}
