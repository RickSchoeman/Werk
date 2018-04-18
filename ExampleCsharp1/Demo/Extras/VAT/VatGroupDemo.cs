using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.VAT;

namespace Demo.Extras.VAT
{
    class VatGroupDemo
    {
        private const string VatGroupType = "VTB";
        private readonly VatGroupService vatGroupService;

        public VatGroupDemo(Session session)
        {
            vatGroupService = new VatGroupService(session);
        }

        public void Run()
        {
            if (!FindVatGroups())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindVatGroups()
        {
            Console.WriteLine("Searching VAT groups");
            const int searchField = 0;
            var vatGroups = vatGroupService.FindVatGroups("*", VatGroupType, searchField);
            DisplayVatGroupSummaries(vatGroups);
            if (vatGroups.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayVatGroupSummaries(IEnumerable<VatGroupSummary> vatGroups)
        {
            foreach (var v in vatGroups)
            {
                Console.WriteLine("{0,-16} {1}", v.Code, v.Name);
            }
            Console.WriteLine();
        }
    }
}
