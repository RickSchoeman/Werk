using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.TimeQuantities;

namespace Demo.Extras.TimeQuantity
{
    class TimeQuantityDemo
    {
        private const string TimeQuantityType = "TEQ";
        private readonly TimeQuantityService timeQuantityService;

        public TimeQuantityDemo(Session session)
        {
            timeQuantityService = new TimeQuantityService(session);
        }

        public void Run()
        {
            if (!FindTimeQuantities())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindTimeQuantities()
        {
            Console.WriteLine("Searching time & quantity transaction types");
            const int searchField = 0;
            var timeQuantities = timeQuantityService.FindTimeQuantities("*", TimeQuantityType, searchField);
            DisplayTimeQuantitySummaries(timeQuantities);
            if (timeQuantities.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayTimeQuantitySummaries(IEnumerable<TimeQuantitySummary> timeQuantities)
        {
            foreach (var t in timeQuantities)
            {
                Console.WriteLine("{0,-16} {1}", t.Code, t.Name);
            }
            Console.WriteLine();
        }
    }
}
