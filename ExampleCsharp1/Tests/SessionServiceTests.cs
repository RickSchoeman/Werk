using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwinfieldApi.BankBooks;
using TwinfieldApi.Organization;
using TwinfieldApi.Services;

namespace Tests
{
	[TestClass]
	public class SessionServiceTests
	{
		SessionService sessionService;

		[TestInitialize]
		public void Initialize()
		{
			var factory = new TestClientFactory();
			sessionService = new SessionService(factory);
		}

		[TestMethod]
		public void Logon_with_valid_credentials_should_create_session()
		{
			var session = sessionService.Logon("API000110", "SforSoftware12", "TWINAPPS");

			Assert.IsNotNull(session);
			Assert.IsTrue(session.LoggedOn);
		}

		[TestMethod]
		public void Logon_with_invalid_credentials_should_not_create_session()
		{
			var session = sessionService.Logon("TESTUSER", "PASSWORD", "TESTORG");

			Assert.IsNull(session);
		}

		[TestMethod]
		public void Selecting_an_office_should_set_the_sessions_office()
		{
			var session = Utilities.CreateValidSession();
			sessionService.SelectOffice(session, "002");

			Assert.AreEqual("002", session.Office);
		}

		[TestMethod]
		public void Abandoning_a_session_should_clear_it()
		{
			var session = Utilities.CreateValidSession();
			sessionService.Abandon(session);

			Assert.IsFalse(session.LoggedOn);
		}

	    [TestMethod]
	    public void Logon_test()
	    {
	        var clientFactory = new ClientFactory();
	        var sessionService = new TwinfieldApi.Services.SessionService(clientFactory);
	        var session = sessionService.Logon("API000110", "SforSoftware12", "TWINAPPS");
            

            var bankBookService = new BankBookService(session);

	        Console.WriteLine("Read bank book");

	        var bankBook = bankBookService.FindBankBook("BNK");
	        if (bankBook == null)
	        {
	            Console.WriteLine("Bank book not found.");
	        }
	        else
	        {
	            Console.WriteLine("Bank book found");
	            Console.WriteLine("\tcode = {0}", bankBook.Code);
	            Console.WriteLine("\tname = {0}", bankBook.Name);
	            Console.WriteLine("\taccount number = {0}", bankBook.AccountNumber);
	            Console.WriteLine("\tIBAN = {0}", bankBook.Iban);
	        }

	        Console.WriteLine();

	        var organizationService = new OrganizationService(session);
	        Console.WriteLine("List offices");

	        var offices = organizationService.GetOffices();
	        Console.WriteLine("Found {0} offices:", offices.Count);

	        Console.WriteLine("{0,-16} {1}", "Code", "Name");
	        foreach (var office in offices.Take(10))
	            Console.WriteLine("{0,-16} {1}", office.Code, office.Name);
	        Console.WriteLine();

            Assert.AreEqual(bankBook.Iban, "NL13TEST0123456789");
	        Assert.IsTrue(session.LoggedOn);
        }

	}
}
