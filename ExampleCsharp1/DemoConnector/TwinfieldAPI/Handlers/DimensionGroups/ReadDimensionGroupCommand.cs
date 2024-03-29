﻿using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.DimensionGroups
{
    public class ReadDimensionGroupCommand
    {
        public string Office { get; set; }
        public string DimensionGroupCode { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("dimensiongroup");
            readElement.AppendNewElement("office").InnerText = Office;
            readElement.AppendNewElement("code").InnerText = DimensionGroupCode;
            return command;
        }
    }
}
