using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Summaries;
using DemoConnector.TwinfieldAPI.Handlers.Extras.Countries;
using DemoConnector.TwinfieldAPI.Handlers.Extras.InvoiceTypes;
using DemoConnector.TwinfieldAPI.Handlers.NotImplemented.Summaries;

namespace DemoConnector.TwinfieldAPI.Handlers
{
    public class SummaryOperations
    {
        private readonly SummaryService _summaryService;
        private const int SearchField = 0;

        public SummaryOperations(Session session)
        {
            _summaryService = new SummaryService(session);
        }

        public List<Summary> GetByName(string name, string type)
        {
            var sums = _summaryService.FindSummaries(name, type, SearchField);
            return sums;
        }

        public List<Summary> GetAll(string type)
        {
            var sums = _summaryService.FindSummaries("*", type, SearchField);
            return sums;
        }
    }
}
