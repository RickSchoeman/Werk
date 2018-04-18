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
            createElement.AppendNewElement("website").InnerText = GeneralLedger.Website;
            createElement.AppendNewElement("cocnumber").InnerText = GeneralLedger.Cocnumber;
            createElement.AppendNewElement("vatnumber").InnerText = GeneralLedger.Vatnumber;
            var f = createElement.AppendNewElement("financials");
            f.AppendNewElement("payavailable").InnerText = GeneralLedger.financials.Payavailable;
            f.AppendNewElement("meansofpayment").InnerText = GeneralLedger.financials.Meansofpayment;
            f.AppendNewElement("paycode").InnerText = GeneralLedger.financials.Paycode;
            f.AppendNewElement("ebilling").InnerText = GeneralLedger.financials.Ebilling;
            f.AppendNewElement("ebillmail").InnerText = GeneralLedger.financials.Ebillmail;
            f.AppendNewElement("substitutionlevel").InnerText = GeneralLedger.financials.Substitutionlevel;
            f.AppendNewElement("substitutewith").InnerText = GeneralLedger.financials.Substitutewith;
            f.AppendNewElement("relationsreference").InnerText = GeneralLedger.financials.Relationsreference;
            f.AppendNewElement("vattype").InnerText = GeneralLedger.financials.Vattype;
            f.AppendNewElement("vatcode").InnerText = GeneralLedger.financials.Vatcode;
            f.AppendNewElement("vatobligatory").InnerText = GeneralLedger.financials.Vatobligatory;
            f.AppendNewElement("performancetype").InnerText = GeneralLedger.financials.Performancetype;
            var c = f.AppendNewElement("collectmandate");
            c.AppendNewElement("id").InnerText = GeneralLedger.financials.Collectmandate.Id;
            c.AppendNewElement("signaturedate").InnerText = GeneralLedger.financials.Collectmandate.Signaturedate;
            c.AppendNewElement("firstrundate").InnerText = GeneralLedger.financials.Collectmandate.Firstrundate;
            f.AppendNewElement("collectionschema").InnerText = GeneralLedger.financials.Collectionschema;
            return command;
        }
    }
}