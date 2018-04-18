using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;

namespace TwinfieldApi.Extras.Reports
{
    public class ReportService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public ReportService(Session session) : this(session, new ClientFactory())
        {

        }

        public ReportService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<ReportSummary> FindReports(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToReportSummaries(searchResult);
        }

        private static List<ReportSummary> SearchResultToReportSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<ReportSummary>();
            }

            return searchResult.Items.Select(item => new ReportSummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
