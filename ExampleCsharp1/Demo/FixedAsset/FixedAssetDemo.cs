using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.FixedAssets;

namespace Demo
{
    class FixedAssetDemo
    {
        const string FixedAssetType = "AST";
        private readonly FixedAssetService fixedAssetService;
        private readonly Session session;
        private FixedAssetSummary fixedAssetSummary;
        private FixedAsset fixedAsset;
        private IEnumerable<FixedAssetSummary> fixedAssets;

        public FixedAssetDemo(Session session)
        {
            this.session = session;
            fixedAssetService = new FixedAssetService(session);
        }

        public void Run()
        {
            var translines = new List<FixedAsset.Transline>();
            var transline = new FixedAsset.Transline
            {
                Code = "012",
                Number = "AST",
                Line = "1",
                Amount = "100",
                Period = "1",
                Dim1 = "",
                Dim2 = "",
                Dim3 = "",
                Dim4 = "",
                Dim5 = "",
                Dim6 = ""
            };
            translines.Add(transline);
            var fixedA = new FixedAsset
            {
                Office = session.Office,
                Type = "AST",
                Code = "60003",
                Name = "test",
                Shortname = "test",
                Inuse = "false",
                Behaviour = "normal",
                Beginperiod = "0",
                Beginyear = "0",
                Endperiod = "0",
                Endyear = "0",
                Website = "",
                Cocnumber = "",
                Vatnumber = "",
                Editdimensionname = "true",
                financials = new FixedAsset.Financials
                {
                    Matchtype = "notmatchable",
                    Accounttype = "inherit",
                    Subanalyse = "false",
                    Duedays = "30",
                    Level = "3",
                    Payavailable = "false",
                    Meansofpayment = "none",
                    Paycode = "",
                    Ebilling = "false",
                    Ebillmail = "",
                    Substitutionlevel = "2",
                    Substitutewith = "00000",
                    Relationsreference = "",
                    Vattype = "",
                    Vatcode = "",
                    Vatobligatory = "false",
                    Performancetype = "",
                    Collectmandate = new FixedAsset.Collectmandate
                    {
                        Id = "60003",
                        Signaturedate = "",
                        Firstrundate = ""
                    },
                    Collectionschema = "core"
                },
                fixedAssets = new FixedAsset.FixedAssets
                {
                    Residualvalue = "2500",
                    Stopvalue = "0",
                    Method = "",
                    Beginperiod = "2014/01",
                    Purchasedate = "20140101",
                    Selldate = "",
                    Freetext1 = "",
                    Freetext2 = "",
                    Freetext3 = "",
                    Freetext4 = "",
                    Freetext5 = "",
                    Nrofperiods = "",
                    Percentage = "",
                    Lastdepreciation = "",
                    Status = "tobeactivated",
                    Translines = new FixedAsset.Translines
                    {
                        Transline = translines
                    }
                },
                groups = new FixedAsset.Groups
                {
                    Group = ""
                }
            };
            fixedAssetService.CreateFixedAsset(fixedA);

            var delFix = new FixedAsset
            {
                Type = "AST",
                Code = "60003"
            };
            fixedAssetService.DeleteFixedAsset(delFix);

            if (!FindFixedAssets())
            {
                return;
            }

            if (!ReadFixedAssetsDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindFixedAssets()
        {
            Console.WriteLine("Searching for fixed assets");
            const int searchField = 2;
            var fixedAssets = fixedAssetService.FindFixedAssets("*", FixedAssetType, searchField);
            DisplayFixedAssetSummaries(fixedAssets);
            if (fixedAssets.Count < 1)
            {
                return false;
            }
            else
            {
                this.fixedAssets = fixedAssets;
                fixedAssetSummary = fixedAssets.First();
                return true;
            }
        }

        private bool ReadFixedAssetsDetails()
        {
            Console.WriteLine("Read fixed asset details");

            foreach (var f in fixedAssets)
            {
                fixedAsset = fixedAssetService.ReadFixedAsset(FixedAssetType, f.Code);
                if (fixedAssetSummary == null)
                {
                    Console.WriteLine("Fixed asset {0} not found.", fixedAsset.Code);
                    return false;
                }
                DisplayFixedAssetDetails(fixedAsset);
            }

            return true;
        }

        private static void DisplayFixedAssetSummaries(IEnumerable<FixedAssetSummary> fixedAssets)
        {
            foreach (var fixedAsset in fixedAssets)
            {
                Console.WriteLine("{0, -16} {1}", fixedAsset.Code, fixedAsset.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayFixedAssetDetails(FixedAsset fixedAsset)
        {
            Console.WriteLine("------");
            Console.WriteLine("Fixed asset details of {0}:", fixedAsset.Name);
            Console.WriteLine("office = {0}", fixedAsset.Office);
            Console.WriteLine("type = {0}", fixedAsset.Type);
            Console.WriteLine("code = {0}", fixedAsset.Code);
            Console.WriteLine("uid = {0}", fixedAsset.Uid);
            Console.WriteLine("name = {0}", fixedAsset.Name);
            Console.WriteLine("shortname = {0}", fixedAsset.Shortname);
            Console.WriteLine("inuse = {0}", fixedAsset.Inuse);
            Console.WriteLine("behaviour = {0}", fixedAsset.Behaviour);
            Console.WriteLine("touched = {0}", fixedAsset.Touched);
            Console.WriteLine("beginperiod = {0}", fixedAsset.Beginperiod);
            Console.WriteLine("beginyear = {0}", fixedAsset.Beginyear);
            Console.WriteLine("endperiod = {0}", fixedAsset.Endperiod);
            Console.WriteLine("endyear = {0}", fixedAsset.Endyear);
            Console.WriteLine("website = {0}", fixedAsset.Website);
            Console.WriteLine("cocnumber = {0}", fixedAsset.Cocnumber);
            Console.WriteLine("vatnumber = {0}", fixedAsset.Vatnumber);
            Console.WriteLine("editdimensionname = {0}", fixedAsset.Editdimensionname);
            Console.WriteLine("------");
            Console.WriteLine("Financials:");
            Console.WriteLine("matchtype = {0}", fixedAsset.financials.Matchtype);
            Console.WriteLine("accounttype = {0}", fixedAsset.financials.Accounttype);
            Console.WriteLine("subanalyse = {0}", fixedAsset.financials.Subanalyse);
            Console.WriteLine("duedays = {0}", fixedAsset.financials.Duedays);
            Console.WriteLine("level = {0}", fixedAsset.financials.Level);
            Console.WriteLine("payavailable = {0}", fixedAsset.financials.Payavailable);
            Console.WriteLine("meansofpayment = {0}", fixedAsset.financials.Meansofpayment);
            Console.WriteLine("paycode = {0}", fixedAsset.financials.Paycode);
            Console.WriteLine("ebilling = {0}", fixedAsset.financials.Ebilling);
            Console.WriteLine("ebillmail = {0}", fixedAsset.financials.Ebillmail);
            Console.WriteLine("substitutionlevel = {0}", fixedAsset.financials.Substitutionlevel);
            Console.WriteLine("substitutewith = {0}", fixedAsset.financials.Substitutewith);
            Console.WriteLine("relationreference = {0}", fixedAsset.financials.Relationsreference);
            Console.WriteLine("vattype = {0}", fixedAsset.financials.Vattype);
            Console.WriteLine("vatcode = {0}", fixedAsset.financials.Vatcode);
            Console.WriteLine("vatobligatory = {0}", fixedAsset.financials.Vatobligatory);
            Console.WriteLine("performancetype = {0}", fixedAsset.financials.Performancetype);
            Console.WriteLine("Collectmandate:");
            Console.WriteLine("id = {0}", fixedAsset.financials.Collectmandate.Id);
            Console.WriteLine("signaturedate = {0}", fixedAsset.financials.Collectmandate.Signaturedate);
            Console.WriteLine("firstrundate = {0}", fixedAsset.financials.Collectmandate);
            Console.WriteLine("collectionschema = {0}", fixedAsset.financials.Collectionschema);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Fixed assets:");
            Console.WriteLine("residualvalue = {0}", fixedAsset.fixedAssets.Residualvalue);
            Console.WriteLine("stopvalue = {0}", fixedAsset.fixedAssets.Stopvalue);
            Console.WriteLine("method = {0}", fixedAsset.fixedAssets.Method);
            Console.WriteLine("beginperiod = {0}", fixedAsset.fixedAssets.Beginperiod);
            Console.WriteLine("purchasedate = {0}", fixedAsset.fixedAssets.Purchasedate);
            Console.WriteLine("freetext1 = {0}", fixedAsset.fixedAssets.Freetext1);
            Console.WriteLine("nrofperiods = {0}", fixedAsset.fixedAssets.Nrofperiods);
            Console.WriteLine("percentage = {0}", fixedAsset.fixedAssets.Percentage);
            Console.WriteLine("status = {0}", fixedAsset.fixedAssets.Status);
            Console.WriteLine("lastdepreciation = {0}", fixedAsset.fixedAssets.Lastdepreciation);
            Console.WriteLine("selldate = {0}", fixedAsset.fixedAssets.Selldate);
            Console.WriteLine("freetext2 = {0}", fixedAsset.fixedAssets.Freetext2);
            Console.WriteLine("freetext3 = {0}", fixedAsset.fixedAssets.Freetext3);
            Console.WriteLine("freetext4 = {0}", fixedAsset.fixedAssets.Freetext4);
            Console.WriteLine("freetext5 = {0}", fixedAsset.fixedAssets.Freetext5);
            Console.WriteLine("------");
            Console.WriteLine("Translines:");
            for (int i = 0; i < fixedAsset.fixedAssets.Translines.Transline.Count; i++)
            {
                if (!fixedAsset.fixedAssets.Translines.Transline[i].Equals(null) || fixedAsset.fixedAssets.Translines.Transline[i] != null || !fixedAsset.fixedAssets.Translines.Transline[i].Code.Equals("") || fixedAsset.fixedAssets.Translines.Transline[i].Code != "")
                {
                    var transline = fixedAsset.fixedAssets.Translines.Transline[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Transline: " + (i + 1));
                    Console.WriteLine("code = {0}", transline.Code);
                    Console.WriteLine("number = {0}", transline.Number);
                    Console.WriteLine("line = {0}", transline.Line);
                    Console.WriteLine("amount = {0}", transline.Amount);
                    Console.WriteLine("period = {0}", transline.Period);
                    Console.WriteLine("dim1 = {0}", transline.Dim1);
                    Console.WriteLine("dim2 = {0}", transline.Dim2);
                    Console.WriteLine("dim3 = {0}", transline.Dim3);
                    Console.WriteLine("dim4 = {0}", transline.Dim4);
                    Console.WriteLine("dim5 = {0}", transline.Dim5);
                    Console.WriteLine("dim6 = {0}", transline.Dim6);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("Banks:");
            for (int i = 0; i < fixedAsset.banks.Bank.Count; i++)
            {
                if (!fixedAsset.banks.Bank[i].Equals(null) || fixedAsset.banks.Bank[i] != null || !fixedAsset.banks.Bank[i].Ascription.Equals("") || fixedAsset.banks.Bank[i].Ascription != "")
                {
                    var bank = fixedAsset.banks.Bank[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Bank: " + (i + 1));
                    Console.WriteLine("ascription = {0}", bank.Ascription);
                    Console.WriteLine("accountnumber = {0}", bank.Accountnumber);
                    Console.WriteLine("Address:");
                    Console.WriteLine("field2 = {0}", bank.Address.Field2);
                    Console.WriteLine("field3 = {0}", bank.Address.Field3);
                    Console.WriteLine("bankname = {0}", bank.Bankname);
                    Console.WriteLine("biccode = {0}", bank.Biccode);
                    Console.WriteLine("city = {0}", bank.City);
                    Console.WriteLine("country = {0}", bank.Country);
                    Console.WriteLine("iban = {0}", bank.Iban);
                    Console.WriteLine("natbiccode = {0}", bank.Natbiccode);
                    Console.WriteLine("postcode = {0}", bank.Postcode);
                    Console.WriteLine("state = {0}", bank.State);
                    Console.WriteLine("default = {0}", bank.Default);
                    Console.WriteLine("id = {0}", bank.Id);
                    Console.WriteLine("blocked = {0}", bank.Blocked);
                    Console.WriteLine("destination = {0}", bank.Destination);
                    Console.WriteLine("------");
                }
            }

            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Groups:");
            Console.WriteLine("group = {0}", fixedAsset.groups.Group);
            Console.WriteLine("------");
        }
    }
}
