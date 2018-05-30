using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.GeneralLedgers
{
    public class GeneralLedgerService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public GeneralLedgerService(Session session) : this(session, new ClientFactory())
        {

        }

        public GeneralLedgerService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<GeneralLedgerSummary> FindGeneralLedgers(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = "DIM",
                Pattern = pattern,
                Field = field,
                MaxRows = 90,
                Options = new []{new []{"dimtype", type}}
            };
            var searchResult = finderService.Search(query);
            return searchResultToGeneralLedgerSummaries(searchResult);
        }

        private static List<GeneralLedgerSummary> searchResultToGeneralLedgerSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<GeneralLedgerSummary>();
            }

            return searchResult.Items.Select(item => new GeneralLedgerSummary {Code = item[0], Name = item[1]})
                .ToList();
        }

//        public GeneralLedger ReadGeneralLedger(string type, string code)
//        {
//            var command = new ReadGeneralLedgerCommand
//            {
//                Office = session.Office,
//                Code = code,
//                Type = type
//            };
//            var response = processXml.Process(command.ToXml());
//            return GeneralLedger.FromXml(response);
//        }

        public void CreateGeneralLedger(GeneralLedger generalLedger)
        {
            var command = new CreateGeneralLedgerCommand
            {
                GeneralLedger = generalLedger
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteGeneralLedger(GeneralLedger generalLedger)
        {
            var command = new DeleteGeneralLedgerCommand
            {
                GeneralLedger = generalLedger 
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateGeneralLedger(GeneralLedger generalLedger)
        {
            var command = new ActivateGeneralLedgerCommand
            {
                GeneralLedger = generalLedger
            };
            processXml.Process(command.ToXml());
        }
    }
}
