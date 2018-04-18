using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.VAT;

namespace Demo.Extras.VAT
{
    class VatCountryDemo
    {
        private const string VatCountrytype = "VGM";
        private readonly VatCountryService vatCountryService;

        public VatCountryDemo(Session session)
        {
            vatCountryService = new VatCountryService(session);
        }

        public void Run()
        {
            if (!FindVatCountries())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindVatCountries()
        {
            Console.WriteLine("Searching VAT groups countries");
            const int searchField = 0;
            var vatCountries = vatCountryService.FindVatCountries("*", VatCountrytype, searchField);
            DisplayVatCountrySummaries(vatCountries);
            if (vatCountries.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayVatCountrySummaries(IEnumerable<VatCountrySummary> vatCountries)
        {
            foreach (var v in vatCountries)
            {
                Console.WriteLine("{0,-16} {1}", v.Code, v.Name);
            }
            Console.WriteLine();
        }
    }
}
