using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Extras.ReminderScenarios;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Extras.ReminderScenarios
{
    public class ReminderScenarioService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public ReminderScenarioService(Session session) : this(session, new ClientFactory())
        {

        }

        public ReminderScenarioService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<ReminderScenarioSummary> FindReminderScenarios(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToReminderScenarioSummaries(searchResult);
        }

        public List<ReminderScenarioSummary> SearchResultToReminderScenarioSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<ReminderScenarioSummary>();
            }

            return searchResult.Items.Select(item => new ReminderScenarioSummary {Code = item[0], Name = item[1]})
                .ToList();
        }
    }
}
