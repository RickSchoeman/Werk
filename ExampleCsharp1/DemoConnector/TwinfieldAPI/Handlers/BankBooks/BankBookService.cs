using System;
using System.ServiceModel;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.BankBooks;
using DemoConnector.TwinfieldBankBookService;

namespace DemoConnector.TwinfieldAPI.Handlers.BankBooks
{
	public class BankBookService
	{
		private readonly Session session;
		private readonly IClientFactory clientFactory;

		public BankBookService(Session session)
			: this(session, new ClientFactory())
		{}

		public BankBookService(Session session, IClientFactory clientFactory)
		{
			this.session = session;
			this.clientFactory = clientFactory;
		}

		public BankBook FindBankBook(string code)
		{
			var queryResult = Query(new GetBankBook { Code = code });
			return BankBook.FromQueryResult(code, queryResult);
		}

		private QueryResult Query(GetBankBook query)
		{
			var bankBookClient = clientFactory.CreateBankBookClient(session.ClusterUrl);
			return bankBookClient.Query(session.SessionId, query);
		}

	    public void CreateBankBook(string code, string name, BankAccount bankAccount, string generalLedgerAccount)
	    {
	        try
	        {
                var cmd = new CommandRequest
                {
                    SessionId = session.SessionId,
                    Command = new CreateBankBook
                    {
                        Code = code,
                        Name = name,
                        BankAccount = bankAccount,
                        GeneralLedgerAccount = generalLedgerAccount
                    }
                };
	            var bankBookClient = clientFactory.CreateBankBookClient(session.ClusterUrl);
                bankBookClient.Process(session.SessionId, cmd.Command);
	        }
	        catch (FaultException<BankBookServiceFault> e)
	        {
	            Console.WriteLine("Failed to create the bank book");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
	        }
	    }

	    public void ChangeBankBookName(string code, string name)
	    {
	        try
	        {
                var cmd = new CommandRequest
                {
                    SessionId = session.SessionId,
                    Command = new ChangeBankBookName
                    {
                        Code = code,
                        Name = name
                    }
                };
	            var bankBookClient = clientFactory.CreateBankBookClient(session.ClusterUrl);
                bankBookClient.Process(session.SessionId, cmd.Command);
	        }
	        catch (FaultException<BankBookServiceFault> e)
	        {
	            Console.WriteLine("Failed to update bank book name:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
	        }
	    }

	    public void ChangeBankBookShortName(string code, string shortname)
	    {
	        try
	        {
                var cmd = new CommandRequest
                {
                    SessionId = session.SessionId,
                    Command = new ChangeBankBookShortName
                    {
                        Code = code,
                        ShortName = shortname
                    }
                };
	            var bankBookClient = clientFactory.CreateBankBookClient(session.ClusterUrl);
                bankBookClient.Process(session.SessionId, cmd.Command);
	        }
	        catch (FaultException<BankBookServiceFault> e)
	        {
	            Console.WriteLine("Failed to update bank book shortname:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
	        }
	    }

	    public void ChangeBankBookBankAccount(string code, BankAccount bankAccount)
	    {
	        try
	        {
                var cmd = new CommandRequest
                {
                    SessionId = session.SessionId,
                    Command = new ChangeBankBookBankAccount
                    {
                        Code = code,
                        BankAccount = bankAccount
                    }
                };
	            var bankBookClient = clientFactory.CreateBankBookClient(session.ClusterUrl);
                bankBookClient.Process(session.SessionId, cmd.Command);
	        }
	        catch (FaultException<BankBookServiceFault> e)
	        {
	            Console.WriteLine("Failed to update bank book bank account:");
	            Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
	        }
	    }

	    public void ChangeBankBookGeneralLedgerAccount(string code, string generalLedgerAccount)
	    {
	        try
	        {
                var cmd = new CommandRequest
                {
                    SessionId = session.SessionId,
                    Command = new ChangeBankBookGeneralLedgerAccount
                    {
                        Code = code,
                        GeneralLedgerAccount = generalLedgerAccount
                    }
                };
	            var bankBookClient = clientFactory.CreateBankBookClient(session.ClusterUrl);
                bankBookClient.Process(session.SessionId, cmd.Command);
	        }
	        catch (FaultException<BankBookServiceFault> e)
	        {
	            Console.WriteLine("Failed to update bank book general ledger account:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
	        }
	    }
	}
}
