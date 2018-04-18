using System;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldBankBookService;
using BankBookService = DemoConnector.TwinfieldAPI.Handlers.BankBooks.BankBookService;

namespace DemoConnector.TwinfieldAPI.Demo
{
	class BankBookDemo
	{
		private readonly BankBookService bankBookService;

		public BankBookDemo(Session session)
		{
			bankBookService = new BankBookService(session);
		}

		public void Run()
		{
		    var bank = new BankAccount
		    {
                Country = "NL",
                Number = "",
                Name = "Bank book name",
                Iban = "NL13TEST0123456789",
                Bic = "",
                Nbic = "",
                ReferenceNumber = ""
            };
//            bankBookService.CreateBankBook("TEST", "bank book name", bank, "1000");
            bankBookService.ChangeBankBookName("BNK", "test");
            bankBookService.ChangeBankBookShortName("BNK", "test");
            bankBookService.ChangeBankBookGeneralLedgerAccount("BNK", "1000");

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
                Console.WriteLine("\tshortname = {0}", bankBook.Shortname);
				Console.WriteLine("\taccount number = {0}", bankBook.AccountNumber);
				Console.WriteLine("\tIBAN = {0}", bankBook.Iban);
                Console.WriteLine("\tgeneralledgeraccount = {0}", bankBook.GeneralLedgerAccount);
			}

			Console.WriteLine();
		}
	}
}