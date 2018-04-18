using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.CostCenters
{
    public class CreateCostCenterCommand
    {
        public CostCenter CostCenter { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimension");
            createElement.AppendNewElement("office").InnerText = CostCenter.Office;
            createElement.AppendNewElement("type").InnerText = "KPL";
            createElement.AppendNewElement("name").InnerText = CostCenter.Name;
            createElement.AppendNewElement("code").InnerText = CostCenter.Code;
//            createElement.AppendNewElement("inuse").InnerText = CostCenter.Inuse;
            createElement.AppendNewElement("shortname").InnerText = CostCenter.Shortname;
            createElement.AppendNewElement("behaviour").InnerText = CostCenter.Behaviour;
//            createElement.AppendNewElement("touched").InnerText = CostCenter.Touched;
            createElement.AppendNewElement("beginperiod").InnerText = CostCenter.Beginperiod;
            createElement.AppendNewElement("beginyear").InnerText = CostCenter.Beginyear;
            createElement.AppendNewElement("endperiod").InnerText = CostCenter.Endperiod;
            createElement.AppendNewElement("endyear").InnerText = CostCenter.Endyear;
            createElement.AppendNewElement("website").InnerText = CostCenter.Website;
            createElement.AppendNewElement("vatnumber").InnerText = CostCenter.Vatnumber;
            createElement.AppendNewElement("cocnumber").InnerText = CostCenter.Cocnumber;
            createElement.AppendNewElement("editdimensionname").InnerText = CostCenter.Editdimensionname;
//            var f1 = createElement.AppendNewElement("financials");
//            f1.AppendNewElement("level").InnerText = CostCenter.financials.Level;
//            f1.AppendNewElement("matchtype").InnerText = CostCenter.financials.Matchtype;
//            f1.AppendNewElement("accounttype").InnerText = CostCenter.financials.Accounttype;
//            f1.AppendNewElement("subanalyse").InnerText = CostCenter.financials.Subanalyse;
//            f1.AppendNewElement("payavailable").InnerText = CostCenter.financials.Payavailable;
//            f1.AppendNewElement("meansofpayment").InnerText = CostCenter.financials.Meansofpayment;
//            f1.AppendNewElement("paycode").InnerText = CostCenter.financials.Paycode;
//            f1.AppendNewElement("ebilling").InnerText = CostCenter.financials.Ebilling;
//            f1.AppendNewElement("duedays").InnerText = CostCenter.financials.Duedays;
//            f1.AppendNewElement("relationsreference").InnerText = CostCenter.financials.Relationsreference;
//            f1.AppendNewElement("substitutionlevel").InnerText = CostCenter.financials.Substitutionlevel;
//            f1.AppendNewElement("substitutewith").InnerText = CostCenter.financials.Substitutewith;
//            f1.AppendNewElement("vatobligatory").InnerText = CostCenter.financials.Vatobligatory;
//            f1.AppendNewElement("performancetype").InnerText = CostCenter.financials.Performancetype;
//            var c1 = f1.AppendNewElement("collectmandate");
//            c1.AppendNewElement("id").InnerText = CostCenter.financials.Collectmandate.Id;
//            c1.AppendNewElement("signaturedate").InnerText = CostCenter.financials.Collectmandate.Signaturedate;
//            c1.AppendNewElement("firstrundate").InnerText = CostCenter.financials.Collectmandate.Firstrundate;
//            f1.AppendNewElement("vatcode").InnerText = CostCenter.financials.Vatcode;
//            f1.AppendNewElement("vattype").InnerText = CostCenter.financials.Vattype;
            return command;
        }
    }
}
