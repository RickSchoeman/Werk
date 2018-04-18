using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.Countries;

namespace Demo.Extras.Countries
{
    public class CountryDemo
    {
        private const string CountryType = "CTR";
        private readonly CountryService countryService;
        private readonly Session session;
        private CountrySummary countrySummary;
        private IEnumerable<CountrySummary> countries;

        public CountryDemo(Session session)
        {
            this.session = session;
            countryService = new CountryService(session);
        }

        public void Run()
        {
            if (!FindCountries())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindCountries()
        {
            Console.WriteLine("Searching countries");
            const int searchField = 0;
            var countries = countryService.FindCountries("*", CountryType, searchField);
            DisplayCountrySummaries(countries);
            if (countries.Count < 1)
            {
                return false;
            }
            else
            {
                this.countries = countries;
                countrySummary = countries.First();
                return true;
            }
        }

        private static void DisplayCountrySummaries(IEnumerable<CountrySummary> countries)
        {
            foreach (var country in countries)
            {
                Console.WriteLine("{0,-16} {1}", country.Code, country.Name);
            }
            Console.WriteLine();
        }
    }
}
