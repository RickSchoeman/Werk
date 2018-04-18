using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Bookkeeping;

namespace DemoConnector.TwinfieldAPI.Handlers.Bookkeeping
{
	public class BookkeepingService
	{
		private readonly ProcessXmlService processXml;
		private readonly Session session;

		public BookkeepingService(Session session)
		{
			this.session = session;
			processXml = new ProcessXmlService(session);
		}

		public Transaction ReadTransaction(string daybook, decimal transactionNumber)
		{
			var command = new ReadTransactionCommand
			{
				Office = session.Office, 
				Daybook = daybook, 
				TransactionNumber = transactionNumber
			};
			var response = processXml.Process(command.ToXml());
			return Transaction.FromXml(response);
		}

		public void BrowseTransactions()
		{
			//TODO: Implement browse transactions
		}

	}
}
