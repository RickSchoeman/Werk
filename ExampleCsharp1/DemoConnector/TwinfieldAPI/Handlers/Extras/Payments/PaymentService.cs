using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Extras.Payments;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Extras.Payments
{
    public class PaymentService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public PaymentService(Session session) : this(session, new ClientFactory())
        {

        }

        public PaymentService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<PaymentSummary> FindPayments(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToPaymentSummaries(searchResult);
        }

        private static List<PaymentSummary> SearchResultToPaymentSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<PaymentSummary>();
            }

            return searchResult.Items.Select(item => new PaymentSummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
