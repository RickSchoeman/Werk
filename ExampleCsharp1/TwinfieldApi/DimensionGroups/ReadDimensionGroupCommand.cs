﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.DimensionGroups
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
