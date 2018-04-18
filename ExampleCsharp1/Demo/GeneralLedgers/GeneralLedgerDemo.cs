using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.GeneralLedgers;

namespace Demo.GeneralLedgers
{
    public class GeneralLedgerDemo
    {
        private const string generalLedgerType = "DIM";
        private readonly GeneralLedgerService generalLedgerService;
        private readonly Session session;
        private GeneralLedgerSummary generalLedgerSummary;
        private GeneralLedger generalLedger;
        private IEnumerable<GeneralLedgerSummary> generalLedgers;

        public GeneralLedgerDemo(Session session)
        {
            this.session = session;
            generalLedgerService = new GeneralLedgerService(session);
        }

        public void Run()
        {
            var genBAS = new GeneralLedger
            {
                Office = session.Office,
                Type = "BAS",
                Code = "1090",
                Name = "test",
                Shortname = "test",
                financials = new Financials
                {
                    Matchtype = "notmatchable",
                    Accounttype = "balance",
                    Subanalyse = "true",
                    Payavailable = "false",
                    Ebilling = "false",
                    Substitutionlevel = "2",
                    Vatobligatory = "false",
                    Collectmandate = new Collectmandate(),
                    Collectionschema = "b2b"
                }
            };
            generalLedgerService.CreateGeneralLedger(genBAS);
            var delBAS = new GeneralLedger
            {
                Office = session.Office,
                Type = "BAS",
                Code = "1090"
            };
            generalLedgerService.DeleteGeneralLedger(delBAS);
            if (!FindGeneralLedgersBAS())
            {
                return;
            }

            if (!ReadGeneralLedgerDetailsBAS())
            {
                return;
            }
            Console.WriteLine();

            var genPNL = new GeneralLedger
            {
                Office = session.Office,
                Type = "PNL",
                Code = "4090",
                Name = "test",
                Shortname = "test",
                financials = new Financials
                {
                    Matchtype = "notmatchable",
                    Accounttype = "balance",
                    Subanalyse = "true",
                    Payavailable = "false",
                    Ebilling = "false",
                    Substitutionlevel = "2",
                    Vatobligatory = "false",
                    Collectmandate = new Collectmandate(),
                    Collectionschema = "b2b"
                }
            };
            generalLedgerService.CreateGeneralLedger(genPNL);
            var delPNL = new GeneralLedger
            {
                Office = session.Office,
                Type = "PNL",
                Code = "4090"
            };
            generalLedgerService.DeleteGeneralLedger(delPNL);
            if (!FindGeneralLedgersPNL())
            {
                return;
            }

            if (!ReadGeneralLedgerDetailsPNL())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindGeneralLedgersBAS()
        {
            Console.WriteLine("Searching for general ledgers BAS");
            const int searchField = 2;
            var generalLedgers = generalLedgerService.FindGeneralLedgers("*", "BAS", searchField);
            DisplayGeneralLedgerSummaries(generalLedgers);
            if (generalLedgers.Count < 1)
            {
                return false;
            }
            else
            {
                this.generalLedgers = generalLedgers;
                generalLedgerSummary = generalLedgers.First();
                return true;
            }
        }

        private bool ReadGeneralLedgerDetailsBAS()
        {
            Console.WriteLine("Read general ledger details BAS");
            foreach (var gl in generalLedgers)
            {
                
                    generalLedger = generalLedgerService.ReadGeneralLedger("BAS", gl.Code);
                
                if (generalLedgerSummary == null)
                {
                    Console.WriteLine("General ledger {0} not found", generalLedger.Code);
                    return false;
                }
                DisplayGeneralLedgerDetails(generalLedger);
            }

            return true;
        }

        private bool FindGeneralLedgersPNL()
        {
            Console.WriteLine("Searching for general ledgers PNL");
            const int searchField = 2;
            var generalLedgers = generalLedgerService.FindGeneralLedgers("*", "PNL", searchField);
            DisplayGeneralLedgerSummaries(generalLedgers);
            if (generalLedgers.Count < 1)
            {
                return false;
            }
            else
            {
                this.generalLedgers = generalLedgers;
                generalLedgerSummary = generalLedgers.First();
                return true;
            }
        }

        private bool ReadGeneralLedgerDetailsPNL()
        {
            Console.WriteLine("Read general ledger details PNL");
            foreach (var gl in generalLedgers)
            {

                generalLedger = generalLedgerService.ReadGeneralLedger("PNL", gl.Code);

                if (generalLedgerSummary == null)
                {
                    Console.WriteLine("General ledger {0} not found", generalLedger.Code);
                    return false;
                }
                DisplayGeneralLedgerDetails(generalLedger);
            }

            return true;
        }

        private static void DisplayGeneralLedgerSummaries(IEnumerable<GeneralLedgerSummary> generalLedgers)
        {
            foreach (var generalLedger in generalLedgers)
            {
                Console.WriteLine("{0,-16} {1}", generalLedger.Code, generalLedger.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayGeneralLedgerDetails(GeneralLedger generalLedger)
        {
            Console.WriteLine("------");
            Console.WriteLine("General ledger details of: {0}", generalLedger.Name);
            Console.WriteLine("office = {0}", generalLedger.Office);
            Console.WriteLine("type = {0}", generalLedger.Type);
            Console.WriteLine("code = {0}", generalLedger.Code);
            Console.WriteLine("uid = {0}", generalLedger.Uid);
            Console.WriteLine("name = {0}", generalLedger.Name);
            Console.WriteLine("shortname = {0}", generalLedger.Shortname);
            Console.WriteLine("inuse = {0}", generalLedger.Inuse);
            Console.WriteLine("behaviour = {0}", generalLedger.Behaviour);
            Console.WriteLine("touched = {0}", generalLedger.Touched);
            Console.WriteLine("beginperiod = {0}", generalLedger.Beginperiod);
            Console.WriteLine("beginyear = {0}", generalLedger.Beginyear);
            Console.WriteLine("endperiod = {0}", generalLedger.Endperiod);
            Console.WriteLine("endyear = {0}", generalLedger.Endyear);
            Console.WriteLine("website = {0}", generalLedger.Website);
            Console.WriteLine("cocnumber = {0}", generalLedger.Cocnumber);
            Console.WriteLine("vatnumber = {0}", generalLedger.Vatnumber);
            Console.WriteLine("editdimensionname = {0}", generalLedger.Editdimensionname);
            Console.WriteLine("------");
            Console.WriteLine("Financials:");
            Console.WriteLine("matchtype = {0}", generalLedger.financials.Matchtype);
            Console.WriteLine("accounttype = {0}", generalLedger.financials.Accounttype);
            Console.WriteLine("subanalyse = {0}", generalLedger.financials.Subanalyse);
            Console.WriteLine("duedays = {0}", generalLedger.financials.Duedays);
            Console.WriteLine("level = {0}", generalLedger.financials.Level);
            Console.WriteLine("payavailable = {0}", generalLedger.financials.Payavailable);
            Console.WriteLine("meansofpayment = {0}", generalLedger.financials.Meansofpayment);
            Console.WriteLine("paycode = {0}", generalLedger.financials.Paycode);
            Console.WriteLine("ebilling = {0}", generalLedger.financials.Ebilling);
            Console.WriteLine("ebillmail = {0}", generalLedger.financials.Ebillmail);
            Console.WriteLine("substitutionlevel = {0}", generalLedger.financials.Substitutionlevel);
            Console.WriteLine("substitutewith = {0}", generalLedger.financials.Substitutewith);
            Console.WriteLine("relationreference = {0}", generalLedger.financials.Relationsreference);
            Console.WriteLine("vattype = {0}", generalLedger.financials.Vattype);
            Console.WriteLine("vatcode = {0}", generalLedger.financials.Vatcode);
            Console.WriteLine("vatobligatory = {0}", generalLedger.financials.Vatobligatory);
            Console.WriteLine("performancetype = {0}", generalLedger.financials.Performancetype);
            Console.WriteLine("Collectmandate:");
            Console.WriteLine("id = {0}", generalLedger.financials.Collectmandate.Id);
            Console.WriteLine("signaturedate = {0}", generalLedger.financials.Collectmandate.Signaturedate);
            Console.WriteLine("firstrundate = {0}", generalLedger.financials.Collectmandate);
            Console.WriteLine("collectionschema = {0}", generalLedger.financials.Collectionschema);
            Console.WriteLine("Childvalidations:");
            Console.WriteLine("childvalidation = {0}", generalLedger.financials.Childvalidations.Childvalidation);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Groups:");
            Console.WriteLine("group = {0}", generalLedger.groups.Group);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
