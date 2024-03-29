﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.GeneralLedgers
{
    public class DeleteGeneralLedgerCommand
    {
        public GeneralLedger GeneralLedger { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var element = command.AppendNewElement("dimension");
            element.SetAttribute("status", "deleted");
            element.AppendNewElement("office").InnerText = GeneralLedger.Office;
            element.AppendNewElement("type").InnerText = GeneralLedger.Type;
            element.AppendNewElement("code").InnerText = GeneralLedger.Code;
            return command;
        }
    }
}
