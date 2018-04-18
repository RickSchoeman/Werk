using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.FixedAssets
{
    public class CreateFixedAssetCommand
    {
        public FixedAsset FixedAsset { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimension");
            createElement.AppendNewElement("office").InnerText = FixedAsset.Office;
            createElement.AppendNewElement("type").InnerText = "AST";
            createElement.AppendNewElement("code").InnerText = FixedAsset.Code;
            createElement.AppendNewElement("name").InnerText = FixedAsset.Name;
            createElement.AppendNewElement("shortname").InnerText = FixedAsset.Shortname;
            createElement.AppendNewElement("beginperiod").InnerText = FixedAsset.Beginperiod;
            createElement.AppendNewElement("beginyear").InnerText = FixedAsset.Beginyear;
            createElement.AppendNewElement("endperiod").InnerText = FixedAsset.Endperiod;
            createElement.AppendNewElement("endyear").InnerText = FixedAsset.Endyear;
            var f1 = createElement.AppendNewElement("financials");
            f1.AppendNewElement("matchtype").InnerText = FixedAsset.financials.Matchtype;
            f1.AppendNewElement("accounttype").InnerText = FixedAsset.financials.Accounttype;
            f1.AppendNewElement("subanalyse").InnerText = FixedAsset.financials.Subanalyse;
            f1.AppendNewElement("duedays").InnerText = FixedAsset.financials.Duedays;
            f1.AppendNewElement("level").InnerText = FixedAsset.financials.Level;
            f1.AppendNewElement("payavailable").InnerText = FixedAsset.financials.Payavailable;
            f1.AppendNewElement("meansofpayment").InnerText = FixedAsset.financials.Meansofpayment;
            f1.AppendNewElement("paycode").InnerText = FixedAsset.financials.Paycode;
            f1.AppendNewElement("ebilling").InnerText = FixedAsset.financials.Ebilling;
            f1.AppendNewElement("ebillmail").InnerText = FixedAsset.financials.Ebillmail;
            f1.AppendNewElement("substitutionlevel").InnerText = FixedAsset.financials.Substitutionlevel;
            f1.AppendNewElement("substitutewith").InnerText = FixedAsset.financials.Substitutewith;
            f1.AppendNewElement("relationsreference").InnerText = FixedAsset.financials.Relationsreference;
            f1.AppendNewElement("vattype").InnerText = FixedAsset.financials.Vattype;
            f1.AppendNewElement("vatcode").InnerText = FixedAsset.financials.Vatcode;
            f1.AppendNewElement("vatobligatory").InnerText = FixedAsset.financials.Vatobligatory;
            f1.AppendNewElement("performancetype").InnerText = FixedAsset.financials.Performancetype;
            var col = f1.AppendNewElement("collectmandate");
            col.AppendNewElement("id").InnerText = FixedAsset.financials.Collectmandate.Id;
            col.AppendNewElement("signaturedate").InnerText = FixedAsset.financials.Collectmandate.Signaturedate;
            col.AppendNewElement("firstrundate").InnerText = FixedAsset.financials.Collectmandate.Firstrundate;
            f1.AppendNewElement("collectionschema").InnerText = FixedAsset.financials.Collectionschema;
            var a1 = createElement.AppendNewElement("fixedassets");
            a1.AppendNewElement("residualvalue").InnerText = FixedAsset.fixedAssets.Residualvalue;
            a1.AppendNewElement("stopvalue").InnerText = FixedAsset.fixedAssets.Stopvalue;
            a1.AppendNewElement("method").InnerText = FixedAsset.fixedAssets.Method;
            a1.AppendNewElement("beginperiod").InnerText = FixedAsset.fixedAssets.Beginperiod;
            a1.AppendNewElement("purchasedate").InnerText = FixedAsset.fixedAssets.Purchasedate;
            a1.AppendNewElement("selldate").InnerText = FixedAsset.fixedAssets.Selldate;
            a1.AppendNewElement("freetext1").InnerText = FixedAsset.fixedAssets.Freetext1;
            a1.AppendNewElement("freetext2").InnerText = FixedAsset.fixedAssets.Freetext2;
            a1.AppendNewElement("freetext3").InnerText = FixedAsset.fixedAssets.Freetext3;
            a1.AppendNewElement("freetext4").InnerText = FixedAsset.fixedAssets.Freetext4;
            a1.AppendNewElement("freetext5").InnerText = FixedAsset.fixedAssets.Freetext5;
            a1.AppendNewElement("nrofperiods").InnerText = FixedAsset.fixedAssets.Nrofperiods;
            a1.AppendNewElement("percentage").InnerText = FixedAsset.fixedAssets.Percentage;
            a1.AppendNewElement("lastdepreciation").InnerText = FixedAsset.fixedAssets.Lastdepreciation;
            a1.AppendNewElement("status").InnerText = FixedAsset.fixedAssets.Status;
            var t1 = a1.AppendNewElement("translines");
            for (int i = 0; i < FixedAsset.fixedAssets.Translines.Transline.Count; i++)
            {
                if (!FixedAsset.fixedAssets.Translines.Transline[i].Equals(null) ||FixedAsset.fixedAssets.Translines.Transline[i] != null || !FixedAsset.fixedAssets.Translines.Transline[i].Code.Equals("") || FixedAsset.fixedAssets.Translines.Transline[i].Code != "")
                {
                    var transline = FixedAsset.fixedAssets.Translines.Transline[i];
                    var t2 = t1.AppendNewElement("transline");
                    t2.SetAttribute("id", (i + 1).ToString());
                    t2.AppendNewElement("code").InnerText = transline.Code;
                    t2.AppendNewElement("number").InnerText = transline.Number;
                    t2.AppendNewElement("line").InnerText = transline.Line;
                    t2.AppendNewElement("amount").InnerText = transline.Amount;
                    t2.AppendNewElement("period").InnerText = transline.Period;
                    t2.AppendNewElement("dim1").InnerText = transline.Dim1;
                    t2.AppendNewElement("dim2").InnerText = transline.Dim2;
                    t2.AppendNewElement("dim3").InnerText = transline.Dim3;
                    t2.AppendNewElement("dim4").InnerText = transline.Dim4;
                    t2.AppendNewElement("dim5").InnerText = transline.Dim5;
                    t2.AppendNewElement("dim6").InnerText = transline.Dim6;
                }
            }

//            var g1 = createElement.AppendNewElement("groups");
//            g1.AppendNewElement("group").InnerText = FixedAsset.groups.Group;

            return command;
        }
    }
}
