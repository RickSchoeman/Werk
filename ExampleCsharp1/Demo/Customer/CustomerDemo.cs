using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Customers;

namespace Demo.Customer
{
    public class CustomerDemo
    {
        private const string CustomerType = "DEB";
        private readonly CustomerService customerService;
        private readonly Session session;
        private CustomerSummary customerSummary;
        private TwinfieldApi.Customers.Customer customer;
        private IEnumerable<CustomerSummary> customers;

        public CustomerDemo(Session session)
        {
            this.session = session;
            customerService = new CustomerService(session);
        }

        public void Run()
        {
            var banks = new List<Bank>();
            var bank = new Bank
            {
                Bankname = "ing",
                Ascription = "test",
                Accountnumber = "",
                Iban = "NL20INGB0001234567",
                Biccode = "INGBNL2A",
                Natbiccode = "",
                Country = "NL",
                Address = new Address()
            };
            banks.Add(bank);
            var addresses = new List<Address>();
            var address = new Address
            {
                Name = "testlocatie",
                Country = "NL",
                City = "testplaats"
            };
            addresses.Add(address);
            var line = new Line
            {
                Office = session.Office
            };
            var postingrules = new List<Postingrule>();
            var postingrule = new Postingrule
            {
                Currency = "EUR",
                Amount = "3",
                Description = "test",
                Lines = new Lines
                {
                    Line = line
                }
            };
            postingrules.Add(postingrule);
            var cust = new TwinfieldApi.Customers.Customer
            {
                Office = session.Office,
                Type = "DEB",
                Name = "test2",
                Code = "1011",
                Addresses = new Addresses
                {
                    Address = addresses
                },
                Banks = new Banks
                {
                    Bank = banks
                },
                Creditmanagement = new Creditmanagement
                {
                    Basecreditlimit = "500",
                    Sendreminder = "false",
                    Blocked = "false"
                },
                Financials = new Financials
                {
                    Collectmandate = new Collectmandate
                    {
                        Id = "1090"
                    },
                    Duedays = "30",
                    Payavailable = "false",
                    Meansofpayment = "none",
                    Ebilling = "false",
                    Substitutionlevel = "1",
                    Vatobligatory = "false",
                    Collectionschema = "b2b"
                },
                Paymentconditions = new Paymentconditions
                {
                    Paymentcondition = new Paymentcondition
                    {
                        Discountdays = "30",
                        Discountpercentage = "20"
                    }
                },
                Groups = new Groups
                {
                    Group = ""
                },
                Postingrules = new Postingrules
                {
                    Postingrule = postingrules
                }
            };
            customerService.CreateCustomer(cust);
            var delCust = new TwinfieldApi.Customers.Customer
            {
                Type = "DEB",
                Code = "1010"
            };
//            customerService.DeleteCustomer(delCust);
            var post = new List<Postingrule>();
            var p = new Postingrule
            {
                Id = "1"
            };
            post.Add(p);
            var delPost = new TwinfieldApi.Customers.Customer
            {
                Office = session.Office,
                Type = "DEB",
                Code = "1011",
                Postingrules = new Postingrules
                {
                    Postingrule = post
                }
            };
            customerService.DeletePostingRule(delPost);

            if (!FindCustomers())
            {
                return;
            }

            if (!ReadCustomerDeatils())
            {
                return;
            }
            Console.WriteLine();
        }

        public bool FindCustomers()
        {
            Console.WriteLine("Searching for customers");
            const int searchField = 2;
            var customers = customerService.FindCustomers("*", CustomerType, searchField);
            DisplayCustomerSummaries(customers);
            if (customers.Count < 1)
            {
                return false;
            }
            else
            {
                this.customers = customers;
                customerSummary = customers.First();
                return true;
            }
        }

        public bool ReadCustomerDeatils()
        {
            Console.WriteLine("Read customer details");
            foreach (var c in customers)
            {
                customer = customerService.ReadCustomer(CustomerType, c.Code);
                if (customerSummary == null)
                {
                    Console.WriteLine("Customer {0} not found", customer.Code);
                    return false;
                }
                DisplayCustomerDetails(customer);
            }

            return true;
        }

        private static void DisplayCustomerSummaries(IEnumerable<CustomerSummary> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("{0,-16} {1}", customer.Code, customer.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayCustomerDetails(TwinfieldApi.Customers.Customer customer)
        {
            Console.WriteLine("------");
            Console.WriteLine("Customer details of: {0}", customer.Name);
            Console.WriteLine("office = {0}", customer.Office);
            Console.WriteLine("type = {0}", customer.Type);
            Console.WriteLine("code = {0}", customer.Code);
            Console.WriteLine("uid = {0}", customer.Uid);
            Console.WriteLine("name = {0}", customer.Name);
            Console.WriteLine("shortname = {0}", customer.Shortname);
            Console.WriteLine("inuse = {0}", customer.Inuse);
            Console.WriteLine("behaviour = {0}", customer.Behaviour);
            Console.WriteLine("touched = {0}", customer.Touched);
            Console.WriteLine("beginperiod = {0}", customer.Beginperiod);
            Console.WriteLine("beginyear = {0}", customer.Beginyear);
            Console.WriteLine("endperiod = {0}", customer.Endperiod);
            Console.WriteLine("endyear = {0}", customer.Endyear);
            Console.WriteLine("website = {0}", customer.Website);
            Console.WriteLine("cocnumber = {0}", customer.Cocnumber);
            Console.WriteLine("vatnumber = {0}", customer.Vatnumber);
            Console.WriteLine("editdimensionname = {0}", customer.Editdimensionname);
            Console.WriteLine("------");
            Console.WriteLine("Financials:");
            Console.WriteLine("matchtype = {0}", customer.Financials.Matchtype);
            Console.WriteLine("accounttype = {0}", customer.Financials.Accounttype);
            Console.WriteLine("subanalyse = {0}", customer.Financials.Subanalyse);
            Console.WriteLine("duedays = {0}", customer.Financials.Duedays);
            Console.WriteLine("level = {0}", customer.Financials.Level);
            Console.WriteLine("payavailable = {0}", customer.Financials.Payavailable);
            Console.WriteLine("meansofpayment = {0}", customer.Financials.Meansofpayment);
            Console.WriteLine("paycode = {0}", customer.Financials.Paycode);
            Console.WriteLine("ebilling = {0}", customer.Financials.Ebilling);
            Console.WriteLine("ebillmail = {0}", customer.Financials.Ebillmail);
            Console.WriteLine("substitutionlevel = {0}", customer.Financials.Substitutionlevel);
            Console.WriteLine("substitutewith = {0}", customer.Financials.Substitutewith);
            Console.WriteLine("relationreference = {0}", customer.Financials.Relationsreference);
            Console.WriteLine("vattype = {0}", customer.Financials.Vattype);
            Console.WriteLine("vatcode = {0}", customer.Financials.Vatcode);
            Console.WriteLine("vatobligatory = {0}", customer.Financials.Vatobligatory);
            Console.WriteLine("performancetype = {0}", customer.Financials.Performancetype);
            Console.WriteLine("Collectmandate:");
            Console.WriteLine("id = {0}", customer.Financials.Collectmandate.Id);
            Console.WriteLine("signaturedate = {0}", customer.Financials.Collectmandate.Signaturedate);
            Console.WriteLine("firstrundate = {0}", customer.Financials.Collectmandate.Firstrundate);
            Console.WriteLine("collectionschema = {0}", customer.Financials.Collectionschema);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Creditmanagement:");
            Console.WriteLine("responsibleuser = {0}", customer.Creditmanagement.Responsibleuser);
            Console.WriteLine("basecreditlimit = {0}", customer.Creditmanagement.Basecreditlimit);
            Console.WriteLine("sendreminder = {0}", customer.Creditmanagement.Sendreminder);
            Console.WriteLine("reminderemail = {0}", customer.Creditmanagement.Reminderemail);
            Console.WriteLine("blocked = {0}", customer.Creditmanagement.Blocked);
            Console.WriteLine("freetext1 = {0}", customer.Creditmanagement.Freetext1);
            Console.WriteLine("freetext2 = {0}", customer.Creditmanagement.Freetext2);
            Console.WriteLine("freetext3 = {0}", customer.Creditmanagement.Freetext3);
            Console.WriteLine("comment = {0}", customer.Creditmanagement.Comment);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("invoicing:");
            Console.WriteLine("discountarticle = {0}", customer.Invoicing.Discountarticle);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Addresses:");
            for (int i = 0; i < customer.Addresses.Address.Count; i++)
            {
                if (!customer.Addresses.Address[i].Equals(null) || customer.Addresses.Address[i] != null || !customer.Addresses.Address[i].Name.Equals("") || customer.Addresses.Address[i].Name != "")
                {
                    var address = customer.Addresses.Address[i];
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
            for (int i = 0; i < customer.Banks.Bank.Count; i++)
            {
                if (!customer.Banks.Bank[i].Equals(null) || customer.Banks.Bank[i] != null || !customer.Banks.Bank[i].Ascription.Equals("") || customer.Banks.Bank[i].Ascription != "")
                {
                    var bank = customer.Banks.Bank[i];
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
                    Console.WriteLine("------");
                }
            }

            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Groups:");
            Console.WriteLine("group = {0}", customer.Groups.Group);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Postingrules:");
            for (int i = 0; i < customer.Postingrules.Postingrule.Count; i++)
            {
                if (!customer.Postingrules.Postingrule[i].Equals(null) || customer.Postingrules.Postingrule[i] != null || !customer.Postingrules.Postingrule[i].Currency.Equals("") || customer.Postingrules.Postingrule[i].Currency != "")
                {
                    var postingrule = customer.Postingrules.Postingrule[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Postingrule: " + (i + 1));
                    Console.WriteLine("currency = {0}", postingrule.Currency);
                    Console.WriteLine("amount = {0}", postingrule.Amount);
                    Console.WriteLine("description = {0}", postingrule.Description);
                    Console.WriteLine("Lines:");
                    Console.WriteLine("Line:");
                    Console.WriteLine("office = {0}", postingrule.Lines.Line.Office);
                    Console.WriteLine("dimension1 = {0}", postingrule.Lines.Line.Dimension1);
                    Console.WriteLine("dimension2 = {0}", postingrule.Lines.Line.Dimension2);
                    Console.WriteLine("dimension3 = {0}", postingrule.Lines.Line.Dimension3);
                    Console.WriteLine("ratio = {0}", postingrule.Lines.Line.Ratio);
                    Console.WriteLine("vatcode = {0}", postingrule.Lines.Line.Vatcode);
                    Console.WriteLine("description = {0}", postingrule.Lines.Line.Description);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Paymentconditions:");
            Console.WriteLine("Paymentcondition:");
            Console.WriteLine("discountdays = {0}", customer.Paymentconditions.Paymentcondition.Discountdays);
            Console.WriteLine("discountpercentage = {0}", customer.Paymentconditions.Paymentcondition.Discountpercentage);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
