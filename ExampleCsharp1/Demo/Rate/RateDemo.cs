using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Rates;

namespace Demo
{
    class RateDemo
    {
        private const string RateType = "TRT";
        private readonly RateService rateService;
        private readonly Session session;
        private RateSummary rateSummary;
        private Rate rate;
        private IEnumerable<RateSummary> rates;

        public RateDemo(Session session)
        {
            this.session = session;
            rateService = new RateService(session);
        }

        public void Run()
        {
            var ratechanges = new List<Ratechange>();
            var ratechange = new Ratechange
            {
                Begindate = "20000101",
                Enddate = "20200101",
                Internalrate = "0.1500",
                Externalrate = "0.3200"
            };
            ratechanges.Add(ratechange);
            var pRate = new Rate
            {
                Office = session.Office,
                Code = "M",
                Name = "meter",
                Shortname = "meter",
                Type = "quantity",
                Unit = "1",
                Currency = "EUR",
                Ratechanges = new Ratechanges
                {
                    Ratechange = ratechanges
                }
            };

            rateService.CreateRate(pRate);

            var delRate = new Rate
            {
                Office = session.Office,
                Code = "M"
            };
//            rateService.DeleteRate(delRate);

            var rateCs = new List<Ratechange>();
            var rateC = new Ratechange
            {
                Id = "1"
            };
            rateCs.Add(rateC);
            var delRC = new Rate
            {
                Office = session.Office,
                Code = "M",
                Ratechanges = new Ratechanges
                {
                    Ratechange = rateCs
                }
            };
            rateService.DeleteRateChange(delRC);

            if (!FindRates())
            {
                return;
            }

            if (!ReadRateDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindRates()
        {
            Console.WriteLine("Searching rates");
            const int searchField = 2;
            var rates = rateService.FindRates("*", RateType, searchField);
            DisplayRateSummaries(rates);
            if (rates.Count < 1)
            {
                return false;
            }
            else
            {
                this.rates = rates;
                rateSummary = rates.First();
                return true;
            }
        }

        private bool ReadRateDetails()
        {
            Console.WriteLine("Read rate details");
            foreach (var r in rates)
            {
                rate = rateService.ReadRate(r.Code);
                if (rateSummary == null)
                {
                    Console.WriteLine("Rate {0} not found.", rate.Code);
                    return false;
                }
                DisplayRateDetails(rate);
            }

            return true;
        }

        private static void DisplayRateSummaries(IEnumerable<RateSummary> rates)
        {
            foreach (var rate in rates)
            {
                Console.WriteLine("{0, -16} {1}", rate.Code, rate.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayRateDetails(Rate rate)
        {
            Console.WriteLine("------");
            Console.WriteLine("Rate details of: {0}", rate.Name);
            Console.WriteLine("office = {0}", rate.Office);
            Console.WriteLine("code = {0}", rate.Code);
            Console.WriteLine("name = {0}", rate.Name);
            Console.WriteLine("shortname = {0}", rate.Shortname);
            Console.WriteLine("type = {0}", rate.Type);
            Console.WriteLine("unit = {0}", rate.Unit);
            Console.WriteLine("currency = {0}", rate.Currency);
            Console.WriteLine("------");
            Console.WriteLine("Ratechanges: ");
            for (int i = 0; i < rate.Ratechanges.Ratechange.Count; i++)
            {
                if (!rate.Ratechanges.Ratechange[i].Equals(null) || rate.Ratechanges.Ratechange[i] != null || !rate.Ratechanges.Ratechange[i].Begindate.Equals("") || rate.Ratechanges.Ratechange[i].Begindate != "")
                {
                    var r = rate.Ratechanges.Ratechange[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Ratechange: " + (i + 1));
                    Console.WriteLine("begindate = {0}", r.Begindate);
                    Console.WriteLine("enddate = {0}", r.Enddate);
                    Console.WriteLine("internalrate = {0}", r.Internalrate);
                    Console.WriteLine("externalrate = {0}", r.Externalrate);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("user = {0}", rate.User);
            Console.WriteLine("touched = {0}", rate.Touched);
            Console.WriteLine("created = {0}", rate.Created);
            Console.WriteLine("modified = {0}", rate.Modified);
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
