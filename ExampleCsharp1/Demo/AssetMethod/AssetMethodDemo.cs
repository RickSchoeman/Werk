using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi;
using TwinfieldApi.AssetMethods;

namespace Demo
{
    class AssetMethodDemo
    {
        private const string AssetMethodType = "ASM";
        private readonly AssetMethodService assetMethodService;
        private readonly Session session;
        private AssetMethodSummary assetMethodSummary;
        private AssetMethod assetMethod;
        private IEnumerable<AssetMethodSummary> assetMethods;

        public AssetMethodDemo(Session session)
        {
            this.session = session;
            assetMethodService = new AssetMethodService(session);
        }

        public void Run()
        {
            var freetexts = new List<Freetext>();
            var freetext = new Freetext
            {
                Text = "test2 text"
            };
            freetexts.Add(freetext);
            var aMethod = new AssetMethod
            {
                Office = session.Office,
                Code = "TEST2",
                Name = "test",
                Shortname = "test",
                Depreciaterconciliation = "",
                Freetexts = new Freetexts
                {
                    Freetext = freetexts
                },
                Nrofperiods = "12",
                Calcmethod = "linear",
                Percentage = "0",
                Profitlossaccounts = new Profitlossaccounts
                {
                    Depreciation = "4100",
                    Sales = "",
                    Reconciliation = ""
                },
                Balanceaccounts = new Balanceaccounts
                {
                    Purchasevaluegroup = "",
                    Purchasevalue = "1000",
                    Depreciationgroup = "",
                    Depreciation = "0150",
                    Assetstoactivate = "",
                    Reconciliation = "",
                    Tobeinvoiced = ""
                }
            };
            assetMethodService.CreateAssetMethod(aMethod);

            var delAs = new AssetMethod
            {
                Office = session.Office,
                Code = "TEST2"
            };
            assetMethodService.DeleteAssetMethod(delAs);
//            assetMethodService.ActivateAssetMethod(delAs);

            if (!FindAssetMethods())
            {
                return;
            }

            if (!ReadAssetMethodDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindAssetMethods()
        {
            Console.WriteLine("Searching asset methods");
            const int searchField = 2;
            var assetMethods = assetMethodService.FindAssetMethods("*", AssetMethodType, searchField);
            DisplayAssetMethodSummaries(assetMethods);
            if (assetMethods.Count < 1)
            {
                return false;
            }
            else
            {
                this.assetMethods = assetMethods;
                assetMethodSummary = assetMethods.First();
                return true;
            }
        }

        private bool ReadAssetMethodDetails()
        {
            Console.WriteLine("Read asset method details");
            foreach (var a in assetMethods)
            {
                assetMethod = assetMethodService.ReadAssetMethod(AssetMethodType, a.Code);

                if (assetMethodSummary == null)
                {
                    Console.WriteLine("Asset method {0} not found.", assetMethod.Code);
                    return false;
                }
                DisplayAssetMethodDetails(assetMethod);
            }

            return true;
        }

        private static void DisplayAssetMethodSummaries(IEnumerable<AssetMethodSummary> assetMethods)
        {
            foreach (var assetMethod in assetMethods)
            {
                Console.WriteLine("{0, -16} {1}", assetMethod.Code, assetMethod.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayAssetMethodDetails(AssetMethod assetMethod)
        {
            Console.WriteLine("------");
            Console.WriteLine("Asset method details of: {0}", assetMethod.Name);
            Console.WriteLine("office = {0}", assetMethod.Office);
            Console.WriteLine("code = {0}", assetMethod.Code);
            Console.WriteLine("name = {0}", assetMethod.Name);
            Console.WriteLine("shortname = {0}", assetMethod.Shortname);
            Console.WriteLine("depreciaterconciliation = {0}", assetMethod.Depreciaterconciliation);
            Console.WriteLine("------");
            Console.WriteLine("Freetexts:");
            for (int i = 0; i < assetMethod.Freetexts.Freetext.Count; i++)
            {
                if (!assetMethod.Freetexts.Freetext[i].Equals(null) || assetMethod.Freetexts.Freetext[i] != null || !assetMethod.Freetexts.Freetext[i].Text.Equals("") || assetMethod.Freetexts.Freetext[i].Text != "")
                {
                    var freetext = assetMethod.Freetexts.Freetext[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Freetext: " + (i + 1));
                    Console.WriteLine("freetext = {0}", freetext.Text);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("nrofperiods = {0}", assetMethod.Nrofperiods);
            Console.WriteLine("calcmethod = {0}", assetMethod.Calcmethod);
            Console.WriteLine("perentage = {0}", assetMethod.Percentage);
            Console.WriteLine("------");
            Console.WriteLine("Profitlossaccounts:");
            Console.WriteLine("depreciation = {0}", assetMethod.Profitlossaccounts.Depreciation);
            Console.WriteLine("sales = {0}", assetMethod.Profitlossaccounts.Sales);
            Console.WriteLine("reconciliation = {0}", assetMethod.Profitlossaccounts.Reconciliation);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Balanceaccounts:");
            Console.WriteLine("purchasevaluegroup = {0}", assetMethod.Balanceaccounts.Purchasevaluegroup);
            Console.WriteLine("purchasevalue = {0}", assetMethod.Balanceaccounts.Purchasevalue);
            Console.WriteLine("depreciationgroup = {0}", assetMethod.Balanceaccounts.Depreciationgroup);
            Console.WriteLine("depreciation = {0}", assetMethod.Balanceaccounts.Depreciation);
            Console.WriteLine("assetstoactivate = {0}", assetMethod.Balanceaccounts.Assetstoactivate);
            Console.WriteLine("reconciliation = {0}", assetMethod.Balanceaccounts.Reconciliation);
            Console.WriteLine("tobeinvoiced = {0}", assetMethod.Balanceaccounts.Tobeinvoiced);
            Console.WriteLine("------");
            Console.WriteLine("touched = {0}", assetMethod.Touched);
            Console.WriteLine("user = {0}", assetMethod.User);
            Console.WriteLine("modified = {0}", assetMethod.Modified);
            Console.WriteLine("created = {0}", assetMethod.Created);
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
