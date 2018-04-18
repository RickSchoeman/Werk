using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.Reports;

namespace Demo.Extras.Report
{
    class ReportDemo
    {
        private const string ReportType = "REP";
        private readonly ReportService reportService;

        public ReportDemo(Session session)
        {
            reportService = new ReportService(session);
        }

        public void Run()
        {
            if (!FindReports())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindReports()
        {
            Console.WriteLine("Searching reports");
            const int searchField = 0;
            var reports = reportService.FindReports("*", ReportType, searchField);
            DisplayReportSummaries(reports);
            if (reports.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayReportSummaries(IEnumerable<ReportSummary> reports)
        {
            foreach (var report in reports)
            {
                Console.WriteLine("{0,-16} {1}", report.Code, report.Name);
            }
            Console.WriteLine();
        }
    }
}
