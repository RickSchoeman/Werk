using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.AssetMethods
{
    public class CreateAssetMethodCommand
    {
        public AssetMethod AssetMethod { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("assetmethod");
            createElement.AppendNewElement("office").InnerText = AssetMethod.Office;
            createElement.AppendNewElement("code").InnerText = AssetMethod.Code;
            createElement.AppendNewElement("name").InnerText = AssetMethod.Name;
            createElement.AppendNewElement("shortname").InnerText = AssetMethod.Shortname;
            createElement.AppendNewElement("depreciatereconciliation").InnerText = AssetMethod.Depreciaterconciliation;
            var f1 = createElement.AppendNewElement("freetexts");
            for (int i = 0; i < AssetMethod.Freetexts.Freetext.Count; i++)
            {
                if (!AssetMethod.Freetexts.Freetext[i].Equals(null) || AssetMethod.Freetexts.Freetext[i] != null || !AssetMethod.Freetexts.Freetext[i].Text.Equals("") || AssetMethod.Freetexts.Freetext[i].Text != "")
                {
                    var freetext = AssetMethod.Freetexts.Freetext[i];
                    var f2 = f1.AppendNewElement("freetext");
                    f2.SetAttribute("id", (i + 1).ToString());
                    f2.InnerText = freetext.Text;
                }
            }

            createElement.AppendNewElement("nrofperiods").InnerText = AssetMethod.Nrofperiods;
            createElement.AppendNewElement("calcmethod").InnerText = AssetMethod.Calcmethod;
            createElement.AppendNewElement("percentage").InnerText = AssetMethod.Percentage;
            var p1 = createElement.AppendNewElement("profitlossaccounts");
            p1.AppendNewElement("depreciation").InnerText = AssetMethod.Profitlossaccounts.Depreciation;
            p1.AppendNewElement("sales").InnerText = AssetMethod.Profitlossaccounts.Sales;
            p1.AppendNewElement("reconciliation").InnerText = AssetMethod.Profitlossaccounts.Reconciliation;
            var b1 = createElement.AppendNewElement("balanceaccounts");
            b1.AppendNewElement("purchasevaluegroup").InnerText = AssetMethod.Balanceaccounts.Purchasevaluegroup;
            b1.AppendNewElement("purchasevalue").InnerText = AssetMethod.Balanceaccounts.Purchasevalue;
            b1.AppendNewElement("depreciationgroup").InnerText = AssetMethod.Balanceaccounts.Depreciationgroup;
            b1.AppendNewElement("depreciation").InnerText = AssetMethod.Balanceaccounts.Depreciation;
            b1.AppendNewElement("assetstoactivate").InnerText = AssetMethod.Balanceaccounts.Assetstoactivate;
            b1.AppendNewElement("reconciliation").InnerText = AssetMethod.Balanceaccounts.Reconciliation;
            b1.AppendNewElement("tobeinvoiced").InnerText = AssetMethod.Balanceaccounts.Tobeinvoiced;
            return command;
        }
    }
}
