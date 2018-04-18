using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.CostCenters;

namespace Demo
{
    class CostCenterDemo
    {
        private const string CostCenterType = "KPL";
        private readonly Session session;
        private readonly CostCenterService costCenterService;
        private CostCenterSummary costCenterSummary;
        private CostCenter costCenter;
        private IEnumerable<CostCenterSummary> costCenters;

        public CostCenterDemo(Session session)
        {
            this.session = session;
            costCenterService = new CostCenterService(session);
        }

        public void Run()
        {
            var costCenter = new CostCenter
            {
                Office = session.Office,
                Type = "KPL",
                Name = "test",
                Code = "01234",
                Inuse = "",
                Shortname = "test",
                Behaviour = "normal",
                Touched = "",
                Beginperiod = "0",
                Beginyear = "0",
                Endperiod = "0",
                Endyear = "0",
                Website = "",
                Vatnumber = "",
                Cocnumber = "",
                Editdimensionname = "",
                financials = new CostCenter.Financials
                {
                    Level = "",
                    Matchtype = "notmatchable",
                    Accounttype = "inherit",
                    Subanalyse = "maybe",
                    Payavailable = "false",
                    Meansofpayment = "none",
                    Paycode = "",
                    Ebilling = "false",
                    Duedays = "100",
                    Relationsreference = "",
                    Substitutionlevel = "0",
                    Substitutewith = "",
                    Vatobligatory = "false",
                    Performancetype = "",
                    Collectmandate = new CostCenter.Collectmandate
                    {
                        Id = "00007",
                        Signaturedate = "",
                        Firstrundate = ""
                    },
                    Vatcode = "",
                    Vattype = "" 
                }
            };
            costCenterService.CreateCostCenter(costCenter);
            var delCostCenter = new CostCenter
            {
                Code = "01234",
                Type = "KPL"
            };
            costCenterService.DeleteCostCenter(delCostCenter);

            if (!FindCostCenters())
            {
                return;
            }

            if (!ReadCostCenterDetails())
            {
                return;
            }

            Console.WriteLine();
        }

        private bool FindCostCenters()
        {
            Console.WriteLine("Searching for cost centers");
            const int searchfield = 2;
            var costCenters = costCenterService.FindCostCenters("*", CostCenterType, searchfield);
            DisplayCostCenterSummaries(costCenters);
            if (costCenters.Count < 1)
            {
                return false;
            }
            else
            {
                this.costCenters = costCenters;
                costCenterSummary = costCenters.First();
                return true;
            }
        }

        private bool ReadCostCenterDetails()
        {
            Console.WriteLine("Read cost center details");
            foreach (var c in costCenters)
            {
                costCenter = costCenterService.ReadCostCenter(CostCenterType, c.Code);

                if (costCenter == null)
                {
                    Console.WriteLine("Cost center {0} not found.", costCenter.Code);
                    return false;
                }

                DisplayCostCenterDetails(costCenter);
            }

            return true;
        }

        private static void DisplayCostCenterSummaries(IEnumerable<CostCenterSummary> costCenters)
        {
            foreach (var costCenter in costCenters)
            {
                Console.WriteLine("{0, -16} {1}", costCenter.Code, costCenter.Name);
            }

            Console.WriteLine();
        }

        private static void DisplayCostCenterDetails(CostCenter costCenter)
        {
            Console.WriteLine("------");
            Console.WriteLine("Cost center details of {0}:", costCenter.Name);
            Console.WriteLine("office = {0}", costCenter.Office);
            Console.WriteLine("type = {0}", costCenter.Type);
            Console.WriteLine("code = {0}", costCenter.Code);
            Console.WriteLine("uid = {0}", costCenter.Uid);
            Console.WriteLine("name = {0}", costCenter.Name);
            Console.WriteLine("shortname = {0}", costCenter.Shortname);
            Console.WriteLine("inuse = {0}", costCenter.Inuse);
            Console.WriteLine("behaviour = {0}", costCenter.Behaviour);
            Console.WriteLine("touched = {0}", costCenter.Touched);
            Console.WriteLine("beginperiod = {0}", costCenter.Beginperiod);
            Console.WriteLine("beginyear = {0}", costCenter.Beginyear);
            Console.WriteLine("endperiod = {0}", costCenter.Endperiod);
            Console.WriteLine("endyear = {0}", costCenter.Endyear);
            Console.WriteLine("website = {0}", costCenter.Website);
            Console.WriteLine("cocnumber = {0}", costCenter.Cocnumber);
            Console.WriteLine("vatnumber = {0}", costCenter.Vatnumber);
            Console.WriteLine("editdimensionname = {0}", costCenter.Editdimensionname);
            Console.WriteLine("------");
            Console.WriteLine("Financials:");
            Console.WriteLine("matchtype = {0}", costCenter.financials.Matchtype);
            Console.WriteLine("accounttype = {0}", costCenter.financials.Accounttype);
            Console.WriteLine("subanalyse = {0}", costCenter.financials.Subanalyse);
            Console.WriteLine("duedays = {0}", costCenter.financials.Duedays);
            Console.WriteLine("level = {0}", costCenter.financials.Level);
            Console.WriteLine("payavailable = {0}", costCenter.financials.Payavailable);
            Console.WriteLine("meansofpayment = {0}", costCenter.financials.Meansofpayment);
            Console.WriteLine("paycode = {0}", costCenter.financials.Paycode);
            Console.WriteLine("ebilling = {0}", costCenter.financials.Ebilling);
            Console.WriteLine("ebillmail = {0}", costCenter.financials.Ebillmail);
            Console.WriteLine("substitutionlevel = {0}", costCenter.financials.Substitutionlevel);
            Console.WriteLine("substitutewith = {0}", costCenter.financials.Substitutewith);
            Console.WriteLine("relationreference = {0}", costCenter.financials.Relationsreference);
            Console.WriteLine("vattype = {0}", costCenter.financials.Vattype);
            Console.WriteLine("vatcode = {0}", costCenter.financials.Vatcode);
            Console.WriteLine("vatobligatory = {0}", costCenter.financials.Vatobligatory);
            Console.WriteLine("performancetype = {0}", costCenter.financials.Performancetype);
            Console.WriteLine("Collectmandate:");
            Console.WriteLine("id = {0}", costCenter.financials.Collectmandate.Id);
            Console.WriteLine("signaturedate = {0}", costCenter.financials.Collectmandate.Signaturedate);
            Console.WriteLine("firstrundate = {0}", costCenter.financials.Collectmandate.Firstrundate);
            Console.WriteLine("collectionschema = {0}", costCenter.financials.Collectionschema);
            Console.WriteLine("Childvalidations:");
            Console.WriteLine("childvalidation = {0}", costCenter.financials.Childvalidations.Childvalidation);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Banks:");
            for (int i = 0; i < costCenter.banks.Bank.Count; i++)
            {
                if(!costCenter.banks.Bank[i].Equals(null) || costCenter.banks.Bank[i] != null ||
                    !costCenter.banks.Bank[i].Ascription.Equals("") || costCenter.banks.Bank[i].Ascription != "")
                {
                    var bank = costCenter.banks.Bank[i];
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
            Console.WriteLine();
        }
    }
}