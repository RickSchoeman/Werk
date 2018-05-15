using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.FixedAssets;

namespace DemoConnector.TwinfieldAPI.Handlers.FixedAssets
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
            createElement.AppendNewElement("beginperiod").InnerText = FixedAsset.Beginperiod.ToString();
            createElement.AppendNewElement("beginyear").InnerText = FixedAsset.Beginyear.ToString();
            createElement.AppendNewElement("endperiod").InnerText = FixedAsset.Endperiod.ToString();
            createElement.AppendNewElement("endyear").InnerText = FixedAsset.Endyear.ToString();
            var f1 = createElement.AppendNewElement("financials");
            f1.AppendNewElement("matchtype").InnerText = FixedAsset.Financials.Matchtype.ToString();
            f1.AppendNewElement("accounttype").InnerText = FixedAsset.Financials.Accounttype;
            f1.AppendNewElement("subanalyse").InnerText = FixedAsset.Financials.Subanalyse.ToString();
            f1.AppendNewElement("duedays").InnerText = FixedAsset.Financials.Duedays.ToString();
            f1.AppendNewElement("level").InnerText = FixedAsset.Financials.Level.ToString();
            f1.AppendNewElement("payavailable").InnerText = FixedAsset.Financials.Payavailable.ToString();
            f1.AppendNewElement("meansofpayment").InnerText = FixedAsset.Financials.Meansofpayment.ToString();
            f1.AppendNewElement("paycode").InnerText = FixedAsset.Financials.Paycode;
            f1.AppendNewElement("ebilling").InnerText = FixedAsset.Financials.Ebilling.ToString();
            f1.AppendNewElement("ebillmail").InnerText = FixedAsset.Financials.Ebillmail;
            f1.AppendNewElement("substitutionlevel").InnerText = FixedAsset.Financials.Substitutionlevel.ToString();
            f1.AppendNewElement("substitutewith").InnerText = FixedAsset.Financials.Substitutewith;
            f1.AppendNewElement("relationsreference").InnerText = FixedAsset.Financials.Relationsreference;
            f1.AppendNewElement("vattype").InnerText = FixedAsset.Financials.Vattype;
            var v = f1.AppendNewElement("vatcode");
            v.SetAttribute("name", FixedAsset.Financials.Vatcode.Name);
            v.SetAttribute("shortname", FixedAsset.Financials.Vatcode.Shortname);
            v.SetAttribute("type", FixedAsset.Financials.Vatcode.Type.ToString());
            v.SetAttribute("fixed", FixedAsset.Financials.Vatcode.Fixed.ToString());
            f1.AppendNewElement("vatobligatory").InnerText = FixedAsset.Financials.Vatobligatory.ToString();
            f1.AppendNewElement("performancetype").InnerText = FixedAsset.Financials.Performancetype;
            var col = f1.AppendNewElement("collectmandate");
            col.AppendNewElement("id").InnerText = FixedAsset.Financials.Collectmandate.Id;
            col.AppendNewElement("signaturedate").InnerText = FixedAsset.Financials.Collectmandate.Signaturedate;
            col.AppendNewElement("firstrundate").InnerText = FixedAsset.Financials.Collectmandate.Firstrundate;
            f1.AppendNewElement("collectionschema").InnerText = FixedAsset.Financials.Collectionschema.ToString();
            var a1 = createElement.AppendNewElement("fixedassets");
            a1.AppendNewElement("residualvalue").InnerText = FixedAsset.FixedAssets.Residualvalue;
            a1.AppendNewElement("stopvalue").InnerText = FixedAsset.FixedAssets.Stopvalue;
            a1.AppendNewElement("method").InnerText = FixedAsset.FixedAssets.Method;
            a1.AppendNewElement("beginperiod").InnerText = FixedAsset.FixedAssets.Beginperiod;
            a1.AppendNewElement("purchasedate").InnerText = FixedAsset.FixedAssets.Purchasedate;
            a1.AppendNewElement("selldate").InnerText = FixedAsset.FixedAssets.Selldate;
            a1.AppendNewElement("freetext1").InnerText = FixedAsset.FixedAssets.Freetext1;
            a1.AppendNewElement("freetext2").InnerText = FixedAsset.FixedAssets.Freetext2;
            a1.AppendNewElement("freetext3").InnerText = FixedAsset.FixedAssets.Freetext3;
            a1.AppendNewElement("freetext4").InnerText = FixedAsset.FixedAssets.Freetext4;
            a1.AppendNewElement("freetext5").InnerText = FixedAsset.FixedAssets.Freetext5;
            a1.AppendNewElement("nrofperiods").InnerText = FixedAsset.FixedAssets.Nrofperiods.ToString();
            a1.AppendNewElement("percentage").InnerText = FixedAsset.FixedAssets.Percentage.ToString();
            a1.AppendNewElement("lastdepreciation").InnerText = FixedAsset.FixedAssets.Lastdepreciation;
            a1.AppendNewElement("status").InnerText = FixedAsset.FixedAssets.Status.ToString();
            var t1 = a1.AppendNewElement("translines");
            for (int i = 0; i < FixedAsset.FixedAssets.Translines.Transline.Count; i++)
            {
                if (FixedAsset.FixedAssets.Translines.Transline[i] != null)
                {
                    var transline = FixedAsset.FixedAssets.Translines.Transline[i];
                    var t2 = t1.AppendNewElement("transline");
                    t2.SetAttribute("id", (i + 1).ToString());
                    t2.AppendNewElement("code").InnerText = transline.Code;
                    t2.AppendNewElement("number").InnerText = transline.Number.ToString();
                    t2.AppendNewElement("line").InnerText = transline.Line.ToString();
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
            return command;
        }
    }
}
