using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Dimensions;
using TwinfieldApi.Suppliers;

namespace Demo
{
    class SupplierDemo
    {
        private const string SupplierType = "CRD";
        private readonly SupplierService supplierService;
        private readonly Session session;
        private SupplierSummary supplierSummary;
        private Supplier supplier;
        private IEnumerable<SupplierSummary> suppliers;

        public SupplierDemo(Session session)
        {
            this.session = session;
            supplierService = new SupplierService(session);
        }

        public void Run()
        {
            var adresses = new List<Supplier.Address>();
            var address = new Supplier.Address
            {
                Name = "test",
                Country = "NL",
                City = "plaats",
                Postcode = "9000AA",
                Telephone = "",
                Telefax = "",
                Email = "test@test.nl",
                Field1 = "",
                Field2 = "",
                Field3 = "",
                Field4 = "",
                Field5 = "",
                Field6 = ""
            };
            adresses.Add(address);
            var banks = new List<Supplier.Bank>();
            var bank = new Supplier.Bank
            {
                Ascription = "test",
                Accountnumber = "1234567",
                Address = new Supplier.Address
                {
                    Field2 = "",
                    Field3 = ""
                },
                Bankname = "testbank",
                Biccode = "",
                City = "plaats",
                Country = "NL",
                Iban = "NL20INGB0001234567",
                Natbiccode = "",
                Postcode = "",
                State = ""
            };
            banks.Add(bank);
            var lines = new List<Supplier.Line>();
            var line = new Supplier.Line
            {
                Office = session.Office,
                Dimension1 = "",
                Dimension2 = "",
                Dimension3 = "",
                Ratio = "",
                Vatcode = "",
                Description = "test"
            };
            lines.Add(line);
            var postingrules = new List<Supplier.Postingrule>();
            var postingrule = new Supplier.Postingrule
            {
                Id = "1",
                Currency = "EUR",
                Amount = "",
                Description = "test",
                lines = new Supplier.Lines
                {
                    Line = lines
                }
            };
            postingrules.Add(postingrule);
            var paymentconditions = new List<Supplier.Paymentcondition>();
            var paymentcondition = new Supplier.Paymentcondition
            {
                Discountdays = "5",
                Discountpercentage = "10"
            };
            paymentconditions.Add(paymentcondition);
            var supplier = new Supplier
            {
                Office = session.Office,
                Type = "CRD",
                Code = "2002",
                Name = "test",
                Shortname = "test",
                Beginperiod = "0",
                Beginyear = "0",
                Endperiod = "0",
                Endyear = "0",
                Website = "",
                financials = new Supplier.Financials
                {
                    Matchtype = "matchable",
                    Accounttype = "inherit",
                    Subanalyse = "false",
                    Duedays = "100",
                    Level = "2",
                    Payavailable = "false",
                    Meansofpayment = "",
                    Paycode = "SEPANLCT",
                    Substitutionlevel = "1",
                    Substitutewith = "1600",
                    Relationsreference = ""
                },
                addresses = new Supplier.Addresses
                {
                    Address = adresses
                },
                banks = new Supplier.Banks
                {
                    Bank = banks
                },
                groups = new Supplier.Groups
                {
                    Group = ""
                },
                postingrules = new Supplier.Postingrules
                {
                    Postingrule = postingrules
                },
                paymentconditions = new Supplier.Paymentconditions
                {
                    Paymentcondition = paymentconditions
                }
            };

            supplierService.CreateSupplier(supplier);

            var delSupplier = new Supplier
            {
                Office = session.Office,
                Code = "2002",
                Type = "CRD"
            };
//            supplierService.DeleteSupplier(delSupplier);

            var post = new List<Supplier.Postingrule>();
            post.Add(postingrule);
            var delpPost = new Supplier
            {
                Office = session.Office,
                Code = "2002",
                Type = "CRD",
                postingrules = new Supplier.Postingrules
                {
                    Postingrule = post
                }
            };
            supplierService.DeletePostingRule(delpPost);

            if (!FindSuppliers())
            {
                return;
            }

            if (!ReadSupplierDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindSuppliers()
        {
            Console.WriteLine("Searching for suppliers");

            const int searchField = 2;
            var suppliers = supplierService.FindSuppliers("*", SupplierType, searchField);

            DisplaySupplierSummaries(suppliers);

            if (suppliers.Count < 1)
            {
                return false;
            }
            else
            {
                this.suppliers = suppliers;
                supplierSummary = suppliers.First();
                return true;
            }
        }

        private bool ReadSupplierDetails()
        {
            Console.WriteLine("Read supplier details");

            foreach (var s in this.suppliers)
            {
                supplier = supplierService.ReadSupplier(SupplierType, s.Code);
                if (supplierSummary == null)
                {
                    Console.WriteLine("Supplier {0} ne found", supplier.Code);
                    return false;
                }
                DisplaySupplierDetails(supplier);
            }

            return true;
        }

        private static void DisplaySupplierSummaries(IEnumerable<SupplierSummary> suppliers)
        {
            foreach (var supplier in suppliers)
            {
                Console.WriteLine("{0, -16} {1}", supplier.Code, supplier.Name);
            }
            Console.WriteLine();
        }

        private static void DisplaySupplierDetails(Supplier supplier)
        {
            Console.WriteLine("------");
            Console.WriteLine("Supplier details of {0}:", supplier.Name);
            Console.WriteLine("Office = {0}", supplier.Office);
            Console.WriteLine("type = {0}", supplier.Type);
            Console.WriteLine("uid = {0}", supplier.Uid);
            Console.WriteLine("name = {0}", supplier.Name);
            Console.WriteLine("shortname = {0}", supplier.Shortname);
            Console.WriteLine("inuse = {0}", supplier.Inuse);
            Console.WriteLine("behaviour = {0}", supplier.Behaviour);
            Console.WriteLine("touched = {0}", supplier.Touched);
            Console.WriteLine("beginperiod = {0}", supplier.Beginperiod);
            Console.WriteLine("beginyear = {0}", supplier.Beginyear);
            Console.WriteLine("endperiod = {0}", supplier.Endperiod);
            Console.WriteLine("endyear = {0}", supplier.Endyear);
            Console.WriteLine("website = {0}", supplier.Website);
            Console.WriteLine("cocnumber = {0}", supplier.Cocnumber);
            Console.WriteLine("vatnumber = {0}", supplier.Vatnumber);
            Console.WriteLine("editdimensionname = {0}", supplier.Editdimensionname);
            Console.WriteLine("------");
            Console.WriteLine("Financials:");
            Console.WriteLine("matchtype = {0}", supplier.financials.Matchtype);
            Console.WriteLine("accounttype = {0}", supplier.financials.Accounttype);
            Console.WriteLine("subanalyse = {0}", supplier.financials.Subanalyse);
            Console.WriteLine("duedays = {0}", supplier.financials.Duedays);
            Console.WriteLine("level = {0}", supplier.financials.Level);
            Console.WriteLine("payavailable = {0}", supplier.financials.Payavailable);
            Console.WriteLine("meansofpayment = {0}", supplier.financials.Meansofpayment);
            Console.WriteLine("paycode = {0}", supplier.financials.Paycode);
            Console.WriteLine("ebilling = {0}", supplier.financials.Ebilling);
            Console.WriteLine("ebillmail = {0}", supplier.financials.Ebillmail);
            Console.WriteLine("substitutionlevel = {0}", supplier.financials.Substitutionlevel);
            Console.WriteLine("substitutewith = {0}", supplier.financials.Substitutewith);
            Console.WriteLine("relationreference = {0}", supplier.financials.Relationsreference);
            Console.WriteLine("vattype = {0}", supplier.financials.Vattype);
            Console.WriteLine("vatcode = {0}", supplier.financials.Vatcode);
            Console.WriteLine("vatobligatory = {0}", supplier.financials.Vatobligatory);
            Console.WriteLine("performancetype = {0}", supplier.financials.Performancetype);
            Console.WriteLine("collectmandate:");
            Console.WriteLine("id = {0}", supplier.financials.Collectmandate.Id);
            Console.WriteLine("signaturedate = {0}", supplier.financials.Collectmandate.Signaturedate);
            Console.WriteLine("firstrundate = {0}", supplier.financials.Collectmandate.Firstrundate);
            Console.WriteLine("collectionschema = {0}", supplier.financials.Collectionschema);
            Console.WriteLine("Childvalidations:");
            Console.WriteLine("chailvalidation = {0}", supplier.financials.Childvalidations.Childvalidation);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Addresses");
            for (int i = 0; i < supplier.addresses.Address.Count; i++)
            {
                if (!supplier.addresses.Address[i].Equals(null) || supplier.addresses.Address[i] != null ||!supplier.addresses.Address[i].Name.Equals("") || supplier.addresses.Address[i].Name != "")
                {
                    var address = supplier.addresses.Address[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Address: " + (i + 1));
                    Console.WriteLine("name = {0}", address.Name);
                    Console.WriteLine("country = {0}", address.Country);
                    Console.WriteLine("city = {0}", address.City);
                    Console.WriteLine("postcode = {0}", address.Postcode);
                    Console.WriteLine("telephone = {0}", address.Telephone);
                    Console.WriteLine("telefax = {0}", address.Telefax);
                    Console.WriteLine("email = {0}", address.Email);
                    Console.WriteLine("contact = {0}", address.Contact);
                    Console.WriteLine("field1 = {0}", address.Field1);
                    Console.WriteLine("field2 = {0}", address.Field2);
                    Console.WriteLine("field3 = {0}", address.Field3);
                    Console.WriteLine("field4 = {0}", address.Field4);
                    Console.WriteLine("field5 = {0}", address.Field5);
                    Console.WriteLine("field6 = {0}", address.Field6);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Banks:");
            for (int i = 0; i < supplier.banks.Bank.Count; i++)
            {
                if (!supplier.banks.Bank[i].Equals(null) || supplier.banks.Bank[i] != null || !supplier.banks.Bank[i].Ascription.Equals("") || supplier.banks.Bank[i].Ascription != "")
                {
                    var bank = supplier.banks.Bank[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Bank: "+ (i + 1));
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
            Console.WriteLine("group = {0}", supplier.groups.Group);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Postingrules:");
            for (int i = 0; i < supplier.postingrules.Postingrule.Count; i++)
            {
                if (!supplier.postingrules.Postingrule[i].Equals(null) || supplier.postingrules.Postingrule[i] != null || !supplier.postingrules.Postingrule[i].Currency.Equals("") || supplier.postingrules.Postingrule[i].Currency != "")
                {
                    var pr = supplier.postingrules.Postingrule[i];
                    Console.WriteLine("------");
                    Console.WriteLine("postingrule: " + (i + 1));
                    Console.WriteLine("currency = {0}", pr.Currency);
                    Console.WriteLine("amount = {0}", pr.Amount);
                    Console.WriteLine("description = {0}", pr.Description);
                    Console.WriteLine("------");
                    Console.WriteLine("Lines:");
                    for (int j = 0; j < pr.lines.Line.Count; j++)
                    {
                        if (!pr.lines.Line[i].Equals(null) || pr.lines.Line[i] != null || !pr.lines.Line[i].Office.Equals("") || pr.lines.Line[i].Office != "")
                        {
                            var line = pr.lines.Line[i];
                            Console.WriteLine("------");
                            Console.WriteLine("Line: " + (j + 1));
                            Console.WriteLine("office = {0}", line.Office);
                            Console.WriteLine("dimension1 = {0}", line.Dimension1);
                            Console.WriteLine("dimension2 = {0}", line.Dimension2);
                            Console.WriteLine("dimension3 = {0}", line.Dimension3);
                            Console.WriteLine("ratio = {0}", line.Ratio);
                            Console.WriteLine("vatcode = {0}", line.Vatcode);
                            Console.WriteLine("description = {0}", line.Description);
                            Console.WriteLine("------");
                        }
                    }
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Paymentconditions:");
            for (int i = 0; i < supplier.paymentconditions.Paymentcondition.Count; i++)
            {
                if (!supplier.paymentconditions.Paymentcondition[i].Equals(null) || supplier.paymentconditions.Paymentcondition[i] != null || !supplier.paymentconditions.Paymentcondition[i].Discountdays.Equals("") || supplier.paymentconditions.Paymentcondition[i].Discountdays != "")
                {
                    var paymentcondition = supplier.paymentconditions.Paymentcondition[i];
                    Console.WriteLine("------");
                    Console.WriteLine("discountdays = {0}", paymentcondition.Discountdays);
                    Console.WriteLine("discountpercentage = {0}", paymentcondition.Discountpercentage);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
