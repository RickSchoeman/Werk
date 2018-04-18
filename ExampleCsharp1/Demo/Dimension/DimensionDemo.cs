using System;
using System.Collections.Generic;
using System.Linq;
using TwinfieldApi;
using TwinfieldApi.Dimensions;

namespace Demo
{
	class DimensionDemo
	{
		const string CustomerDimensionType = "DEB";

		private readonly DimensionService dimensionService;
	    private readonly Session session;
		private DimensionSummary customerSummary;
		private Dimension customer;
	    private IEnumerable<DimensionSummary> customers;

		public DimensionDemo(Session session)
		{
		    this.session = session;
			dimensionService = new DimensionService(session);
		}

		public void Run()
		{
//		    var bank = new Bank
//		    {
//                Bankname = "ing",
//                Ascription = "test",
//                Accountnumber = "",
//                Iban = "NL20INGB0001234567",
//                Biccode = "INGBNL2A",
//                Natbiccode = "",
//                Country = "Nederland",
//                Address = new Address
//                {
//
//                }
//		    };
//		    var banks = new List<Bank>();
//            banks.Add(bank);
//		    var address = new Address
//		    {
//                Name = "testlocatie",
//                Country = "Nederland",
//                City = "testplaats"
//		    };
//            var addresses = new List<Address>();
//            addresses.Add(address);
//		    var paymentcondition = new Paymentcondition
//		    {
//		        Discountdays = "30",
//		        Discountpercentage = "20"
//		    };
//            var paymentconditions = new List<Paymentcondition>();
//            paymentconditions.Add(paymentcondition);
//            var dim = new Dimension
//            {
//                Office = session.Office,
//                Type = "DEB",
//                Name = "test",
//                Code = "1010",
//                addresses = new Addresses
//                {
//                    Address = addresses
//                },
//                banks = new Banks
//                {
//                    Bank = banks
//                },
//                creditmanagement = new Creditmanagement
//                {
//                    Basecreditlimit = "500"
//                },
//                financials = new Financials
//                {
//                    Collectmandate = new Collectmandate(),
//                    Childvalidations = new Childvalidations(),
//                    Duedays = "30",
//                    Payavailable = "false",
//                    Meansofpayment = "paymentfile"
//                },
//                remittanceadvice = new Remittanceadvice
//                {
//
//                },
//                paymentconditions = new Paymentconditions
//                {
//                    Paymentcondition = paymentconditions
//                },
//                groups = new Groups
//                {
//
//                }
//            };
//            dimensionService.CreateDimension(dim);
			if (!FindCustomersWithType("DEB"))
				return;

			if (!ReadCustomerDetails())
				return;

			Console.WriteLine();
		}

		private bool FindCustomersWithType(string type)
		{
			Console.WriteLine("Searching for customers");

			const int searchField = 2; // Search in name field
			var customers = dimensionService.FindDimensions("*", type, searchField);
			
			DisplayCustomerSummaries(customers);

			// Save first customer for later demo
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

		private bool ReadCustomerDetails()
		{
			Console.WriteLine("Read customer details");
            
		    foreach (var c in this.customers)
		    {
                customer = dimensionService.ReadDimension(CustomerDimensionType, c.Code);

			    if (customerSummary == null)
			    {
				    Console.WriteLine("Customer {0} not found.", customer.Code);
				    return false;
			    }
			
			    DisplayCustomerDetails(customer);
			    
		    }

		    return true;
		}

		private static void DisplayCustomerSummaries(IEnumerable<DimensionSummary> dimensions)
		{
			foreach (var dimension in dimensions)
				Console.WriteLine("{0,-16} {1}", dimension.Code, dimension.Name);
			Console.WriteLine();
		}

		private static void DisplayCustomerDetails(Dimension dimension)
		{
            Console.WriteLine("------");
			Console.WriteLine("Customer details of: {0}", dimension.Name);
			Console.WriteLine("office = {0}", dimension.Office);
			Console.WriteLine("type = {0}", dimension.Type);
			Console.WriteLine("code = {0}", dimension.Code);
            Console.WriteLine("uid = {0}", dimension.Uid);
			Console.WriteLine("name = {0}", dimension.Name);
		    Console.WriteLine("shortname = {0}", dimension.Shortname);
            Console.WriteLine("inuse = {0}", dimension.Inuse);
            Console.WriteLine("behaviour = {0}", dimension.Behaviour);
            Console.WriteLine("touched = {0}", dimension.Touched);
            Console.WriteLine("beginperiod = {0}", dimension.Beginperiod);
		    Console.WriteLine("beginyear = {0}", dimension.Beginyear);
		    Console.WriteLine("endperiod = {0}", dimension.Endperiod);
		    Console.WriteLine("endyear = {0}", dimension.Endyear);
		    Console.WriteLine("website = {0}", dimension.Website);
		    Console.WriteLine("cocnumber = {0}", dimension.Cocnumber);
		    Console.WriteLine("vatnumber = {0}", dimension.Vatnumber);
		    Console.WriteLine("editdimensionname = {0}", dimension.Editdimensionname);
		    Console.WriteLine("------");
            Console.WriteLine("Financials:");
		    Console.WriteLine("matchtype = {0}", dimension.financials.Matchtype);
		    Console.WriteLine("accounttype = {0}", dimension.financials.Accounttype);
		    Console.WriteLine("subanalyse = {0}", dimension.financials.Subanalyse);
		    Console.WriteLine("duedays = {0}", dimension.financials.Duedays);
		    Console.WriteLine("level = {0}", dimension.financials.Level);
		    Console.WriteLine("payavailable = {0}", dimension.financials.Payavailable);
		    Console.WriteLine("meansofpayment = {0}", dimension.financials.Meansofpayment);
		    Console.WriteLine("paycode = {0}", dimension.financials.Paycode);
		    Console.WriteLine("ebilling = {0}", dimension.financials.Ebilling);
		    Console.WriteLine("ebillmail = {0}", dimension.financials.Ebillmail);
		    Console.WriteLine("substitutionlevel = {0}", dimension.financials.Substitutionlevel);
		    Console.WriteLine("substitutewith = {0}", dimension.financials.Substitutewith);
		    Console.WriteLine("relationreference = {0}", dimension.financials.Relationsreference);
		    Console.WriteLine("vattype = {0}", dimension.financials.Vattype);
		    Console.WriteLine("vatcode = {0}", dimension.financials.Vatcode);
		    Console.WriteLine("vatobligatory = {0}", dimension.financials.Vatobligatory);
		    Console.WriteLine("performancetype = {0}", dimension.financials.Performancetype);
		    Console.WriteLine("Collectmandate:");
		    Console.WriteLine("id = {0}", dimension.financials.Collectmandate.Id);
		    Console.WriteLine("signaturedate = {0}", dimension.financials.Collectmandate.Signaturedate);
		    Console.WriteLine("firstrundate = {0}", dimension.financials.Collectmandate);
		    Console.WriteLine("collectionschema = {0}", dimension.financials.Collectionschema);
		    Console.WriteLine("Childvalidations:");
		    Console.WriteLine("childvalidation = {0}", dimension.financials.Childvalidations.Childvalidation);
		    Console.WriteLine("------");
		    Console.WriteLine("------");
            Console.WriteLine("Creditmanagement:");
		    Console.WriteLine("responsibleuser = {0}", dimension.creditmanagement.Responsibleuser);
		    Console.WriteLine("basecreditlimit = {0}", dimension.creditmanagement.Basecreditlimit);
		    Console.WriteLine("sendreminder = {0}", dimension.creditmanagement.Sendreminder);
		    Console.WriteLine("reminderemail = {0}", dimension.creditmanagement.Reminderemail);
		    Console.WriteLine("blocked = {0}", dimension.creditmanagement.Blocked);
		    Console.WriteLine("freetext1 = {0}", dimension.creditmanagement.Freetext1);
		    Console.WriteLine("freetext2 = {0}", dimension.creditmanagement.Freetext2);
		    Console.WriteLine("freetext3 = {0}", dimension.creditmanagement.Freetext3);
		    Console.WriteLine("comment = {0}", dimension.creditmanagement.Comment);
		    Console.WriteLine("------");
		    Console.WriteLine("------");
            Console.WriteLine("Remittanceadvice:");
		    Console.WriteLine("sendtype = {0}", dimension.remittanceadvice.Sendtype);
		    Console.WriteLine("sendmail = {0}", dimension.remittanceadvice.Sendmail);
		    Console.WriteLine("------");
		    Console.WriteLine("------");
            Console.WriteLine("Addresses:");
		    for (int i = 0; i < dimension.addresses.Address.Count; i++)
		    {
		        if (!dimension.addresses.Address[i].Equals(null) || dimension.addresses.Address[i] != null || !dimension.addresses.Address[i].Name.Equals("") || dimension.addresses.Address[i].Name != "")
		        {
		            var address = dimension.addresses.Address[i];
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
		    for (int i = 0; i < dimension.banks.Bank.Count; i++)
		    {
		        if (!dimension.banks.Bank[i].Equals(null) || dimension.banks.Bank[i] != null || !dimension.banks.Bank[i].Ascription.Equals("") || dimension.banks.Bank[i].Ascription != "")
		        {
		            var bank = dimension.banks.Bank[i];
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
            Console.WriteLine("group = {0}", dimension.groups.Group);
		    Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Paymentconditions:");
		    for (int i = 0; i < dimension.paymentconditions.Paymentcondition.Count; i++)
		    {
		        if (!dimension.paymentconditions.Paymentcondition[i].Equals(null) || dimension.paymentconditions.Paymentcondition[i] != null || !dimension.paymentconditions.Paymentcondition[i].Discountdays.Equals("") || dimension.paymentconditions.Paymentcondition[i].Discountdays != "")
		        {
		            var paymentcondition = dimension.paymentconditions.Paymentcondition[i];
                    Console.WriteLine("------");
		            Console.WriteLine("Paymentcondition: " + (i + 1));
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