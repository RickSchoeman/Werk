using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.TaxGroups;

namespace Demo.Extras.TaxGroup
{
    public class TaxGroupDemo
    {
        private const string TaxGroupType = "TXG";
        private readonly TaxGroupService taxGroupService;
        private readonly Session session;
        private TaxGroupSummary taxGroupSummary;
        private IEnumerable<TaxGroupSummary> taxGroups;

        public TaxGroupDemo(Session session)
        {
            this.session = session;
            taxGroupService = new TaxGroupService(session);
        }

        public void Run()
        {
            if (!FindTaxGroups())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindTaxGroups()
        {
            Console.WriteLine("searching tax groups");
            const int searchField = 0;
            var taxGroups = taxGroupService.FindTaxGroups("*", TaxGroupType, searchField);
            DisplayTaxGroupSummaries(taxGroups);
            if (taxGroups.Count < 1)
            {
                return false;
            }
            else
            {
                this.taxGroups = taxGroups;
                taxGroupSummary = taxGroups.First();
                return true;
            }
        }

        private static void DisplayTaxGroupSummaries(IEnumerable<TaxGroupSummary> taxGroups)
        {
            foreach (var taxGroup in taxGroups)
            {
                Console.WriteLine("{0,-16} {1}", taxGroup.Code, taxGroup.Name);
            }
            Console.WriteLine();
        }
    }
}
