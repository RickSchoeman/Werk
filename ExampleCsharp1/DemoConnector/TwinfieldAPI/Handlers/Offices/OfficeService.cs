using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Offices;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Offices
{
    public class OfficeService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public OfficeService(Session session) : this(session, new ClientFactory())
        {

        }

        public OfficeService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<OfficeSummary> FindOffices(string pattern, string officeType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "OFF",
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return searchResultToOfficeSummaries(searchResult);
        }

        private static List<OfficeSummary> searchResultToOfficeSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<OfficeSummary>();
            }

            return searchResult.Items.Select(item => new OfficeSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public Office ReadOffice(string officeCode)
        {
            var command = new ReadOfficeCommand
            {
                Office = session.Office,
                OfficeCode = officeCode
            };
            var response = processXml.Process(command.ToXml());
            return Office.FromXml(response);
        }
    }
}
