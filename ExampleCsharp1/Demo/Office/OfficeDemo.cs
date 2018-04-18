using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Offices;
using TwinfieldApi.TwinfieldBudgetService;

namespace Demo
{
    public class OfficeDemo
    {
        private const string OfficeType = "OFF";
        private readonly OfficeService officeService;
        private readonly Session session;
        private OfficeSummary officeSummary;
        private Office office;
        private IEnumerable<OfficeSummary> offices;

        public OfficeDemo(Session session)
        {
            this.session = session;
            officeService = new OfficeService(session);
        }

        public void Run()
        {
            if (!FindOffices())
            {
                return;
            }

            if (!ReadOfficeDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindOffices()
        {
            Console.WriteLine("Searching offices");
            const int searchField = 2;
            var offices = officeService.FindOffices("*", OfficeType, searchField);
            DisplayOfficeSummaries(offices);
            if (offices.Count < 1)
            {
                return false;
            }
            else
            {
                this.offices = offices;
                officeSummary = offices.First();
                return true;
            }
        }

        private bool ReadOfficeDetails()
        {
            Console.WriteLine("Read office details");
            foreach (var o in offices)
            {
                office = officeService.ReadOffice(o.Code);
                if (officeSummary == null)
                {
                    Console.WriteLine("Office {0} not found", o.Code);
                    return false;
                }
                DisplayOfficeDetails(office);
            }
            return true;
        }

        private static void DisplayOfficeSummaries(IEnumerable<OfficeSummary> offices)
        {
            foreach (var office in offices)
            {
                Console.WriteLine("{0,-16} {1}", office.Code, office.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayOfficeDetails(Office office)
        {
            Console.WriteLine("------");
            Console.WriteLine("Office details of: {0}", office.Name);
            Console.WriteLine("code = {0}", office.Code);
            Console.WriteLine("created = {0}", office.Created);
            Console.WriteLine("modified = {0}", office.Modified);
            Console.WriteLine("name = {0}", office.Name);
            Console.WriteLine("shortname = {0}", office.Shortname);
            Console.WriteLine("touched = {0}", office.Touched);
            Console.WriteLine("user = {0}", office.User);
            Console.WriteLine("------");
            Console.WriteLine("General:");
            var general = office.General;
            Console.WriteLine("basecurrency = {0}", general.Basecurrency);
            Console.WriteLine("reportingcurrency = {0}", general.Reportingcurrency);
            Console.WriteLine("type = {0}", general.Type);
            Console.WriteLine("demo = {0}", general.Demo);
            Console.WriteLine("vatnumber = {0}", general.Vatnumber);
            Console.WriteLine("cocnumber = {0}", general.Cocnumber);
            Console.WriteLine("currentyear = {0}", general.Currentyear);
            Console.WriteLine("currentperiod = {0}", general.Currentperiod);
            Console.WriteLine("numberofperiods = {0}", general.Numberofperiods);
            Console.WriteLine("lastclosedyear = {0}", general.Lastclosedyear);
            Console.WriteLine("creditoridentifier = {0}", general.Creditoridentifier);
            Console.WriteLine("defaultbank = {0}", general.Defaultbank);
            Console.WriteLine("defaultmatching = {0}", general.Defaultmatching);
            Console.WriteLine("region = {0}", general.Region);
            Console.WriteLine("hierarchy = {0}", general.Hierarchy);
            Console.WriteLine("template = {0}", general.Template);
            Console.WriteLine("templateoffice = {0}", general.Templateoffice);
            Console.WriteLine("editdimensionname = {0}", general.Editdimensionname);
            Console.WriteLine("allowmultiplecontrolaccounts = {0}", general.Allowmultiplecontrolaccounts);
            Console.WriteLine("paymentdiscount = {0}", general.Paymentdiscount);
            Console.WriteLine("scheme = {0}", general.Scheme);
            Console.WriteLine("allowicmt940 = {0}", general.Allowicmt940);
            Console.WriteLine("lockwordinv = {0}", general.Lockwordinv);
            Console.WriteLine("todolist = {0}", general.Todolist);
            Console.WriteLine("sicmajorgroup = {0}", general.Sicmajorgroup);
            Console.WriteLine("------");
            Console.WriteLine("Address:");
            Console.WriteLine("field1 = {0}", general.Address.Field1);
            Console.WriteLine("field2 = {0}", general.Address.Field2);
            Console.WriteLine("field3 = {0}", general.Address.Field3);
            Console.WriteLine("field4 = {0}", general.Address.Field4);
            Console.WriteLine("field5 = {0}", general.Address.Field5);
            Console.WriteLine("field6 = {0}", general.Address.Field6);
            Console.WriteLine("city = {0}", general.Address.City);
            Console.WriteLine("country = {0}", general.Address.Country);
            Console.WriteLine("postcode = {0}", general.Address.Postcode);
            Console.WriteLine("telephone = {0}", general.Address.Telephone);
            Console.WriteLine("fax = {0}", general.Address.Fax);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Systemdimensions:");
            var sysdim = office.Systemdimensions;
            Console.WriteLine("accountsreceivable = {0}", sysdim.Accountsreceivable);
            Console.WriteLine("accountspayable = {0}", sysdim.Accountspayable);
            Console.WriteLine("openingbalance = {0}", sysdim.Openingbalance);
            Console.WriteLine("suspenceaccount = {0}", sysdim.Suspenceaccount);
            Console.WriteLine("workingprogress = {0}", sysdim.Workingprogress);
            Console.WriteLine("profitriseprojects = {0}", sysdim.Profitriseprojects);
            Console.WriteLine("turnover = {0}", sysdim.Turnover);
            Console.WriteLine("------");
            Console.WriteLine("Exchangedifference:");
            Console.WriteLine("debit = {0}", sysdim.Exchangedifference.Debit);
            Console.WriteLine("credit = {0}", sysdim.Exchangedifference.Credit);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Paymentdifference:");
            Console.WriteLine("debit = {0}", sysdim.Paymentdifference.Debit);
            Console.WriteLine("credit = {0}", sysdim.Paymentdifference.Credit);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Discount:");
            Console.WriteLine("debit = {0}", sysdim.Discount.Debit);
            Console.WriteLine("credit = {0}", sysdim.Discount.Credit);
            Console.WriteLine("------");
            Console.WriteLine("teqcostcenter = {0}", sysdim.Teqcostcenter);
            Console.WriteLine("astcostcenter = {0}", sysdim.Astcostcenter);
            Console.WriteLine("closepnl = {0}", sysdim.Closepnl);
            Console.WriteLine("forbalynd = {0}", sysdim.Forbalynd);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Systemdimensiontypes:");
            var typesysdim = office.Systemdimensiontype;
            Console.WriteLine("accountsreceivable = {0}", typesysdim.Accountsreceivable);
            Console.WriteLine("accountspayable = {0}", typesysdim.Accountspayable);
            Console.WriteLine("balance = {0}", typesysdim.Balance);
            Console.WriteLine("profitandloss = {0}", typesysdim.Profitandloss);
            Console.WriteLine("fixedassets = {0}", typesysdim.Fixedassets);
            Console.WriteLine("projects = {0}", typesysdim.Projects);
            Console.WriteLine("costcenters = {0}", typesysdim.Costcenters);
            Console.WriteLine("activities = {0}", typesysdim.Activities);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Creditmanagement:");
            var cred = office.Creditmanagement;
            Console.WriteLine("daysafterduedate = {0}", cred.Daysafterduedate);
            Console.WriteLine("daysafterduedatevalue = {0}", cred.Daysafterduedatevalue);
            Console.WriteLine("daysafterpartpayment = {0}", cred.Daysafterpartpayment);
            Console.WriteLine("invoicebrowse = {0}", cred.Invoicebrowse);
            Console.WriteLine("invoiceexplodebrowse = {0}", cred.Invoiceexplodebrowse);
            Console.WriteLine("------");
            Console.WriteLine("Prompts:");
            for (int i = 0; i < cred.Prompts.Count; i++)
            {
                if (!cred.Prompts[i].Equals(null) || cred.Prompts[i] != null || !cred.Prompts[i].Prompt.Equals("") || cred.Prompts[i].Prompt != "")
                {
                    var prompt = cred.Prompts[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Prompt: " + (i + 1));
                    Console.WriteLine("prompt = {0}", prompt.Prompt);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Sort:");
            for (int i = 0; i < cred.Sort.Count; i++)
            {
                if (!cred.Sort[i].Equals(null) || cred.Sort[i] != null || !cred.Sort[i].Field.Equals("") || cred.Sort[i].Field != "")
                {
                    var sort = cred.Sort[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Field: " + (i + 1));
                    Console.WriteLine("field = {0}", sort.Field);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("vatmanagement:");
            var vat = office.Vatmanagement;
            Console.WriteLine("------");
            Console.WriteLine("Txp:");
            Console.WriteLine("cpid = {0}", vat.Txp.Cpid);
            Console.WriteLine("cpname = {0}", vat.Txp.Cpname);
            Console.WriteLine("cptel = {0}", vat.Txp.Cptel);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Int:");
            Console.WriteLine("cpid = {0}", vat.Int.Cpid);
            Console.WriteLine("cpname = {0}", vat.Int.Cpname);
            Console.WriteLine("cptel = {0}", vat.Int.Cptel);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Seb:");
            Console.WriteLine("cpid = {0}", vat.Seb.Cpid);
            Console.WriteLine("cpname = {0}", vat.Seb.Cpname);
            Console.WriteLine("cptel = {0}", vat.Seb.Cptel);
            Console.WriteLine("------");
            Console.WriteLine("taxgroup = {0}", vat.Taxgroup);
            Console.WriteLine("decltimeframe = {0}", vat.Decltimeframe);
            Console.WriteLine("startingquarter = {0}", vat.Startingquarter);
            Console.WriteLine("icptimeframe = {0}", vat.Icptimeframe);
            Console.WriteLine("mayestimate = {0}", vat.Mayestimate);
            Console.WriteLine("includepurchaseorsalesprovisionaltransactions = {0}", vat.Includepurchaseorsalesprovisionaltransactions);
            Console.WriteLine("includecashorbankprovisionaltransactions = {0}", vat.Includecashorbankprovisionaltransactions);
            Console.WriteLine("includejournalprovisionaltransactions = {0}", vat.Includejournalprovisionaltransactions);
            Console.WriteLine("defwgytype = {0}", vat.Defgwytype);
            Console.WriteLine("defwgycode = {0}", vat.Defgwycode);
            Console.WriteLine("accountingscheme = {0}", vat.Accountingscheme);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Fixedassets:");
            var fix = office.Fixedassets;
            Console.WriteLine("transaction = {0}", fix.Transaction);
            Console.WriteLine("browsepurchase = {0}", fix.Browsepurchase);
            Console.WriteLine("browsedepreciate = {0}", fix.Browsedepreciate);
            Console.WriteLine("browsereconcile = {0}", fix.Browsereconcile);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Intercompany:");
            var inter = office.Intercompany;
            Console.WriteLine("outs = {0}", inter.Outs);
            Console.WriteLine("ins = {0}", inter.Ins);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Regional:");
            var reg = office.Regional;
            Console.WriteLine("dateformat = {0}", reg.Dateformat);
            Console.WriteLine("thousandsep = {0}", reg.Thousandsep);
            Console.WriteLine("decimalsep = {0}", reg.Decimalsep);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
