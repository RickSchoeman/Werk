using DemoConnector.TwinfieldAPI.Controllers.Browse.Data;
using DemoConnector.TwinfieldAPI.Controllers.Browse.Query;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;

namespace DemoConnector.TwinfieldAPI.Controllers.Browse
{
	public class BrowseService
	{
		private readonly Session session;
		private readonly ProcessXmlService processXml;

		public BrowseService(Session session)
		{
			this.session = session;
			processXml = new ProcessXmlService(session);
			processXml.Compressed = true;
		}

		public BrowseDefinition ReadBrowseDefinition(string browseCode)
		{
			var command = new ReadBrowseDefinitionCommand
			{
				Office = session.Office,
				Code = browseCode
			};
			var response = processXml.Process(command.ToXml());
			return BrowseDefinition.FromXml(response);
		}

		public BrowseResult Read(BrowseQuery query)
		{
			var response = processXml.Process(query.ToXml());
			return BrowseResult.FromXml(response);
		}
	}
}
