using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.AssetMethods
{
    public class AssetMethod
    {
        internal static AssetMethod FromXml(XmlElement element)
        {
            var freetexts = new List<Freetext>();
            XmlNodeList elemListFreetexts = element.GetElementsByTagName("freetext");
            for (int i = 0; i < elemListFreetexts.Count; i++)
            {
                if (!elemListFreetexts[i].Equals(null) || elemListFreetexts[i] != null)
                {
                    var freetext = new Freetext
                    {
                        Text = elemListFreetexts[i].InnerText
                    };
                    freetexts.Add(freetext);
                }
            }

            return new AssetMethod
            {
                Office = element.SelectInnerText("office"),
                Code = element.SelectInnerText("code"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Depreciaterconciliation = element.SelectInnerText("depreciatorconciliation"),
                Freetexts = new Freetexts
                {
                    Freetext = freetexts
                },
                Nrofperiods = element.SelectInnerText("nrofperiods"),
                Calcmethod = element.SelectInnerText("calcmethod"),
                Percentage = element.SelectInnerText("percentage"),
                Profitlossaccounts = new Profitlossaccounts
                {
                    Depreciation = element.SelectInnerText("profitlossaccounts/depreciation"),
                    Sales = element.SelectInnerText("profitlossaccounts/sales"),
                    Reconciliation = element.SelectInnerText("profitlossaccounts/reconciliation")
                },
                Balanceaccounts = new Balanceaccounts
                {
                    Purchasevaluegroup = element.SelectInnerText("balanceaccounts/purchasevaluegroup"),
                    Purchasevalue = element.SelectInnerText("balanceaccounts/purchasevalue"),
                    Depreciationgroup = element.SelectInnerText("balanceaccounts/depreciationgroup"),
                    Depreciation = element.SelectInnerText("balanceaccounts/depreciation"),
                    Assetstoactivate = element.SelectInnerText("balanceaccounts/assetstoactivate"),
                    Reconciliation = element.SelectInnerText("balanceaccounts/reconciliation"),
                    Tobeinvoiced = element.SelectInnerText("balanceaccounts/tobeinvoiced")
                },
                Touched = element.SelectInnerText("touched"),
                User = element.SelectInnerText("user"),
                Modified = element.SelectInnerText("modified"),
                Created = element.SelectInnerText("created")
            };
        }
        public string Office { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Depreciaterconciliation { get; set; }
        public Freetexts Freetexts { get; set; }
        public string Nrofperiods { get; set; }
        public string Calcmethod { get; set; }
        public string Percentage { get; set; }
        public Profitlossaccounts Profitlossaccounts { get; set; }
        public Balanceaccounts Balanceaccounts { get; set; }
        public string Touched { get; set; }
        public string User { get; set; }
        public string Modified { get; set; }
        public string Created { get; set; }

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var assetMethod = document.AppendNewElement("assetmethod");
            assetMethod.AppendNewElement("office").InnerText = Office;
            assetMethod.AppendNewElement("code").InnerText = Code;
            assetMethod.AppendNewElement("name").InnerText = Name;
            assetMethod.AppendNewElement("shortname").InnerText = Shortname;
            assetMethod.AppendNewElement("depreciaterconciliation").InnerText = Depreciaterconciliation;
            for (int i = 0; i < Freetexts.Freetext.Count; i++)
            {
                if (!Freetexts.Freetext[i].Equals(null) || Freetexts.Freetext[i] != null || !Freetexts.Freetext[i].Text.Equals("") || Freetexts.Freetext[i].Text != "")
                {
                    var freetext = Freetexts.Freetext[i];
                    assetMethod.AppendNewElement("freetexts/freetext[@id='" + i + "']").InnerText = freetext.Text;
                }
            }
            assetMethod.AppendNewElement("nrofperiods").InnerText = Nrofperiods;
            assetMethod.AppendNewElement("calcmethod").InnerText = Calcmethod;
            assetMethod.AppendNewElement("percentage").InnerText = Percentage;
            assetMethod.AppendNewElement("profitlossaccount/depreciation").InnerText = Profitlossaccounts.Depreciation;
            assetMethod.AppendNewElement("profitlossaccounts/sales").InnerText = Profitlossaccounts.Sales;
            assetMethod.AppendNewElement("profitlossaccounts/reconciliation").InnerText =
                Profitlossaccounts.Reconciliation;
            assetMethod.AppendNewElement("balanceaccounts/purchasevaluegroup").InnerText =
                Balanceaccounts.Purchasevaluegroup;
            assetMethod.AppendNewElement("balanceaccounts/purchasevalue").InnerText = Balanceaccounts.Purchasevalue;
            assetMethod.AppendNewElement("balanceaccounts/depreciationgroup").InnerText =
                Balanceaccounts.Depreciationgroup;
            assetMethod.AppendNewElement("balanceaccounts/depreciation").InnerText = Balanceaccounts.Depreciation;
            assetMethod.AppendNewElement("balanceaccounts/assetstoactivate").InnerText =
                Balanceaccounts.Assetstoactivate;
            assetMethod.AppendNewElement("balanceaccounts/reconciliation").InnerText = Balanceaccounts.Reconciliation;
            assetMethod.AppendNewElement("balanceaccounts/tobeinvoiced").InnerText = Balanceaccounts.Tobeinvoiced;
            assetMethod.AppendNewElement("touched").InnerText = Touched;
            assetMethod.AppendNewElement("user").InnerText = User;
            assetMethod.AppendNewElement("modified").InnerText = Modified;
            assetMethod.AppendNewElement("created").InnerText = Created;
            return document;
        }
    }

    public class Freetexts
    {
        public List<Freetext> Freetext { get; set; }
    }

    public class Freetext
    {
        public string Text { get; set; }
    }

    public class Profitlossaccounts
    {
        public string Depreciation { get; set; }
        public string Sales { get; set; }
        public string Reconciliation { get; set; }
    }

    public class Balanceaccounts
    {
        public string Purchasevaluegroup { get; set; }
        public string Purchasevalue { get; set; }
        public string Depreciationgroup { get; set; }
        public string Depreciation { get; set; }
        public string Assetstoactivate { get; set; }
        public string Reconciliation { get; set; }
        public string Tobeinvoiced { get; set; }
    }
}
