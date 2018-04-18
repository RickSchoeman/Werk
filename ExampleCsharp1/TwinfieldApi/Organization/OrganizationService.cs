using System.Collections.Generic;
using TwinfieldApi.Services;

namespace TwinfieldApi.Organization
{
	public class OrganizationService
	{
		private readonly ProcessXmlService processXml;

		public OrganizationService(Session session)
		{
			processXml = new ProcessXmlService(session);
		}

		public List<OfficeSummary> GetOffices()
		{
			var command = new ListOfficesCommand();
			var response = processXml.Process(command.ToXml());
			return OfficeSummaryList.FromXml(response);
		}
	}
}
