using System;
using System.Linq;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Controllers.Services
{
	class FinderService
	{
		private readonly Session session;
		private readonly IClientFactory clientFactory;

		public FinderService(Session session)
			: this(session, new ClientFactory())
		{ }

		public FinderService(Session session, IClientFactory clientFactory)
		{
			this.session = session;
			this.clientFactory = clientFactory;
		}		 

		public FinderData Search(Query query)
		{
			var client = clientFactory.CreateFinderClient(session.ClusterUrl);
			var header = new TwinfieldFinderService.Header { SessionID = session.SessionId };

			FinderData data;
			var messages = client.Search(header, query.Type, query.Pattern,
				query.Field, query.FirstRow, query.MaxRows, query.Options, out data);
			AssertNoMessages(messages);

			return data;
		}

		private static void AssertNoMessages(MessageOfErrorCodes[] messages)
		{
			if (messages.Any())
				throw new FinderException(messages);
		}

		public class Query
		{
			public string @Type { get; set; }
			public string Pattern { get; set; }
			public int Field { get; set; }
			public int FirstRow { get; set; }
			public int MaxRows { get; set; }
			public string[][] Options { get; set; }

			public Query()
			{
				Field = 0;
				FirstRow = 1;
				MaxRows = 10;
				Options = null;
			}
		}
	}

	public class FinderException : Exception
	{
		public MessageOfErrorCodes[] Messages { get; private set; }

		public FinderException(MessageOfErrorCodes[] messages)
		{
			Messages = messages;
		}

		public override string Message
		{
			get
			{
				var messages = Messages.Select(m => m.Text).ToArray();
				return String.Join(". ", messages);
			}
		}
	}

}