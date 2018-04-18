using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Period;

namespace Demo
{
    class PeriodDemo
    {
        private readonly PeriodService periodService;

        public PeriodDemo(Session session)
        {
            periodService = new PeriodService(session);
        }

        public void Run()
        {
//            periodService.CreateYear(12);
            periodService.ChangeEndDate(2019, 1, new DateTime(2019, 02,02));
            periodService.ChangeName(2019, 1, "test");
            periodService.OpenPeriod(2019, 0);
            periodService.ClosePeriod(2019, 0);
//            periodService.ResetYears(1998, 12);
//            periodService.DeleteYear(2019);
            Console.WriteLine("Read Periods");
            var period = periodService.FindPeriods(2019);
            if (period == null)
            {
                Console.WriteLine("Periods not found");
            }
            else
            {
                Console.WriteLine("Periods found");
                foreach (var p in period.periods)
                {
                    Console.WriteLine("Period found");
                    Console.WriteLine("name = {0}", p.Name);
                    Console.WriteLine("number = {0}", p.Number);
                    Console.WriteLine("enddate = {0}", p.EndDate);
                    Console.WriteLine("open = {0}", p.Open);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.WriteLine("Read Years");
            var year = periodService.FindYears();
            if (year == null)
            {
                Console.WriteLine("Years not found");
            }
            else
            {
                Console.WriteLine("Years found");
                foreach (var y in year.years)
                {
                    Console.WriteLine("Year found");
                    Console.WriteLine("id = {0}", y);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
