using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Currencies;

namespace Demo
{
    class CurrenciesDemo
    {
        private const string CurrenciesType = "CUR";
        private readonly CurrenciesService currenciesService;
        private readonly Session session;
        private CurrenciesSummary currenciesSummary;
        private Currency currency;
        private IEnumerable<CurrenciesSummary> currencies;

        public CurrenciesDemo(Session session)
        {
            this.session = session;
            currenciesService = new CurrenciesService(session);
        }

        public void Run()
        {
            var rates = new List<Rate>();
            var rate1 = new Rate
            {
                Startdate = "20180101",
                rate = "0.000937"
            };
            rates.Add(rate1);
            var rate2 = new Rate
            {
                Startdate = "20190101",
                rate = "0.000938"
            };
            rates.Add(rate2);
            var cur = new Currency
            {
                Office = session.Office,
                Code = "KRW",
                Name = "Won",
                Shortname = "W",
                Rates = new Rates
                {
                    Rate = rates
                }
            };
            currenciesService.CreateCurrency(cur);

            var delCur = new Currency
            {
                Office = session.Office,
                Code = "KRW"
            };
//            currenciesService.DeleteCurrency(delCur);
            var dR = new List<Rate>();
            dR.Add(rate1);
            var delRate = new Currency
            {
                Office = session.Office,
                Code = "KRW",
                Rates = new Rates
                {
                    Rate = dR 
                }
            };
            currenciesService.DeleteCurrencyRate(delRate);

            if (!FindCurrencies())
            {
                return;
            }

            if (!ReadCurrenciesDetails())
            {
                return;
            }

            Console.WriteLine();
        }

        private bool FindCurrencies()
        {
            Console.WriteLine("Searching currencies");
            const int searchField = 2;
            var currenciesList = currenciesService.FindCurrencies("*", CurrenciesType, searchField);
            DisplayCurrenciesSummaries(currenciesList);
            if (currenciesList.Count < 1)
            {
                return false;
            }
            else
            {
                this.currencies = currenciesList;
                currenciesSummary = currenciesList.First();
                return true;
            }
        }

        private bool ReadCurrenciesDetails()
        {
            Console.WriteLine("Read currencies details");
            foreach (var c in currencies)
            {
                currency = currenciesService.ReadCurrencies(CurrenciesType, c.Code);

                if (currenciesSummary == null)
                {
                    Console.WriteLine("Currencies {0} not found.", currency.Code);
                }

                DisplayCurrenciesDetails(currency);
            }

            return true;
        }

        private static void DisplayCurrenciesSummaries(IEnumerable<CurrenciesSummary> currenciesList)
        {
            foreach (var currencies in currenciesList)
            {
                Console.WriteLine("{0, -16} {1}", currencies.Code, currencies.Name);
            }

            Console.WriteLine();
        }

        private static void DisplayCurrenciesDetails(Currency currency)
        {
            Console.WriteLine("------");

            Console.WriteLine("office = {0}", currency.Office);
            Console.WriteLine("code = {0}", currency.Code);
            Console.WriteLine("touched = {0}", currency.Touched);
            Console.WriteLine("------");
            Console.WriteLine("Rates:");
            for (int i2 = 0; i2 < currency.Rates.Rate.Count; i2++)
            {
                if (!currency.Rates.Rate[i2].Equals(null) || currency.Rates.Rate[i2] != null ||
                    !currency.Rates.Rate[i2].rate.Equals("") || currency.Rates.Rate[i2].rate != "")
                {
                    Console.WriteLine("------");
                    Console.WriteLine("Rate: " + (i2 + 1));
                    Console.WriteLine("startdate = {0}", currency.Rates.Rate[i2].Startdate);
                    Console.WriteLine("rate = {0}", currency.Rates.Rate[i2].rate);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("uid = {0}", currency.Uid);
            Console.WriteLine("user = {0}", currency.User);
            Console.WriteLine("created = {0}", currency.Created);
            Console.WriteLine("modified = {0}", currency.Modified);
            Console.WriteLine("name = {0}", currency.Name);
            Console.WriteLine("shortname = {0}", currency.Shortname);
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}