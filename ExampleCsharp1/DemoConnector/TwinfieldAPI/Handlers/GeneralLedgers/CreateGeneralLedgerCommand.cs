using System;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;

namespace DemoConnector.TwinfieldAPI.Handlers.GeneralLedgers
{
    public class CreateGeneralLedgerCommand
    {
        public GeneralLedger GeneralLedger { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimension");
            createElement.AppendNewElement("office").InnerText = GeneralLedger.Office;
            createElement.AppendNewElement("type").InnerText = GeneralLedger.Type;
            createElement.AppendNewElement("code").InnerText = GeneralLedger.Code;
            createElement.AppendNewElement("name").InnerText = GeneralLedger.Name;
            var f = createElement.AppendNewElement("financials");
            Console.WriteLine(GeneralLedger.Financials.Matchtype + "test");
            f.AppendNewElement("matchtype").InnerText = GeneralLedger.Financials.Matchtype.ToString();
            f.AppendNewElement("accounttype").InnerText = GeneralLedger.Financials.Accounttype;
            f.AppendNewElement("subanalyse").InnerText = GeneralLedger.Financials.Subanalyse.ToString();
            f.AppendNewElement("level").InnerText = GeneralLedger.Financials.Level.ToString();
            var v = f.AppendNewElement("vatcode");
            v.InnerText = GeneralLedger.Financials.Vatcode.Name;
            v.SetAttribute("name", GeneralLedger.Financials.Vatcode.Name);
            v.SetAttribute("shortname", GeneralLedger.Financials.Vatcode.Shortname);
            v.SetAttribute("type", GeneralLedger.Financials.Vatcode.Type.ToString());
            v.SetAttribute("fixed", GeneralLedger.Financials.Vatcode.Fixed.ToString());
            return command;
        }
    }
}