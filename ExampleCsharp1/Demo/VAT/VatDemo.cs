using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.VATs;

namespace Demo
{
    class VatDemo
    {
        private const string VatType = "VAT";
        private readonly VatService vatService;
        private readonly Session session;
        private VatSummary vatSummary;
        private Vat vat;
        private IEnumerable<VatSummary> vats;

        public VatDemo(Session session)
        {
            this.session = session;
            vatService = new VatService(session);
        }

        public void Run()
        {
            var accounts = new List<Account>();
            var account = new Account
            {
                Dim1 = "1530",
                Groupcountry = "NL",
                Group = "NL1A",
                Percentage = "100",
                Linetype = "vat"
            };
            accounts.Add(account);
            var percentages = new List<Percentage>();
            var percentage = new Percentage
            {
                Date = "20180101",
                percentage = "15",
                Name = "BTW 15%",
                Shortname = "TE 15%",
                Accounts = new Accounts
                {
                    Account = accounts
                }
            };
            percentages.Add(percentage);
            var v = new Vat
            {
                Office = session.Office,
                Code = "TE",
                Name = "BTW 15%",
                Shortname = "TE 15%",
                Type = "sales",
                Percentages = new Percentages
                {
                    Percentage = percentages
                }
            };
            vatService.CreateVat(v);

            var delVat = new Vat
            {
                Office = session.Office,
                Code = "TE"
            };
            vatService.DeleteVat(delVat);

            if (!FindVats())
            {
                return;
            }

            if (!ReadVatDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindVats()
        {
            Console.WriteLine("Searching VATs");
            const int seachField = 2;
            var vats = vatService.FindVats("*", VatType, seachField);
            DisplayVatSummaries(vats);
            if (vats.Count < 1)
            {
                return false;
            }
            else
            {
                this.vats = vats;
                vatSummary = vats.First();
                return true;
            }
        }

        private bool ReadVatDetails()
        {
            Console.WriteLine("Read vat details");
            foreach (var v in vats)
            {
                vat = vatService.ReadVat(v.Code);
                if (vatSummary == null)
                {
                    Console.WriteLine("Vat {0} not found.", vat.Code);
                    return false;
                }
                DisplayVatDetails(vat);
            }

            return true;
        }

        private static void DisplayVatSummaries(IEnumerable<VatSummary> vats)
        {
            foreach (var vat in vats)
            {
                Console.WriteLine("{0, -16} {1}", vat.Code, vat.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayVatDetails(Vat vat)
        {
            Console.WriteLine("------");
            Console.WriteLine("Vat details of: {0}", vat.Name);
            Console.WriteLine("office = {0}", vat.Office);
            Console.WriteLine("code = {0}", vat.Code);
            Console.WriteLine("name = {0}", vat.Name);
            Console.WriteLine("shortname = {0}", vat.Shortname);
            Console.WriteLine("type = {0}", vat.Type);
            Console.WriteLine("------");
            Console.WriteLine("Percentages: ");
            for (int i = 0; i < vat.Percentages.Percentage.Count; i++)
            {
                if (!vat.Percentages.Percentage[i].Equals(null) || vat.Percentages.Percentage[i] != null || !vat.Percentages.Percentage[i].Name.Equals("") || vat.Percentages.Percentage[i].Name != "")
                {
                    var percentage = vat.Percentages.Percentage[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Percentage: " + (i + 1));
                    Console.WriteLine("date = {0}", percentage.Date);
                    Console.WriteLine("percentage = {0}", percentage.percentage);
                    Console.WriteLine("name = {0}", percentage.Name);
                    Console.WriteLine("shortname = {0}", percentage.Shortname);
                    Console.WriteLine("------");
                    Console.WriteLine("Accounts: ");
                    var ac = new List<Account>();
                    var x = Math.Floor((double) (percentage.Accounts.Account.Count / vat.Percentages.Percentage.Count));
                    x = x * (vat.Percentages.Percentage.Count - 1);
                    for (int j = 0; j < x; j++)
                    {
                        ac.Add(percentage.Accounts.Account[j]);
                    }
                    for (int j = 0; j < ac.Count; j++)
                    {
                        if (!ac[j].Equals(null) || ac[j] != null || !ac[j].Dim1.Equals("") || ac[j].Dim1 != "")
                        {
                            var account = ac[j];
                            Console.WriteLine("------");
                            Console.WriteLine("Account: " + (j + 1));
                            Console.WriteLine("dim1 = {0}", account.Dim1);
                            Console.WriteLine("groupcountry = {0}", account.Percentage);
                            Console.WriteLine("group = {0}", account.Group);
                            Console.WriteLine("percentage = {0}", account.Percentage);
                            Console.WriteLine("linetype = {0}", account.Linetype);
                            Console.WriteLine("------");
                        }
                    }
                    Console.WriteLine("------");
                    Console.WriteLine("user = {0}", percentage.User);
                    Console.WriteLine("------");
                }
                
            }
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
