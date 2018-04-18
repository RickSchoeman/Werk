using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.DistByPeriods;

namespace Demo.Extras.DistByPeriod
{
    class DistByPeriodDemo
    {
        private const string DistByPeriodType = "SPM";
        private readonly DistByPeriodService distByPeriodService;

        public DistByPeriodDemo(Session session)
        {
            distByPeriodService = new DistByPeriodService(session);
        }

        public void Run()
        {
            if (!FindDistByPeriods())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindDistByPeriods()
        {
            Console.WriteLine("Searching distribution by periods");
            const int searchField = 0;
            var distByperiods = distByPeriodService.FindDistByPeriods("*", DistByPeriodType, searchField);
            DisplayDistByPeriodSummaries(distByperiods);
            if (distByperiods.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayDistByPeriodSummaries(IEnumerable<DistByPeriodSummary> distByPeriods)
        {
            foreach (var d in distByPeriods)
            {
                Console.WriteLine("{0,-16} {1}", d.Code, d.Name);
            }
        }
    }
}
