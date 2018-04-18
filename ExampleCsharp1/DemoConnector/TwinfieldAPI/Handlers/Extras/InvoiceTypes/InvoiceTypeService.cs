using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Extras.InvoiceTypes;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Extras.InvoiceTypes
{
    public class InvoiceTypeService
    {
        private readonly FinderService finderService;

        public InvoiceTypeService(Session session) : this(session, new ClientFactory())
        {

        }

        public InvoiceTypeService(Session session, IClientFactory clientFactory)
        {
            finderService = new FinderService(session, clientFactory);
        }

        public List<InvoiceTypeSummary> FindInvoiceTypes(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToInvoiceTypeSummaries(searchResult);
        }

        private static List<InvoiceTypeSummary> SearchResultToInvoiceTypeSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<InvoiceTypeSummary>();
            }

            return searchResult.Items.Select(item => new InvoiceTypeSummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
