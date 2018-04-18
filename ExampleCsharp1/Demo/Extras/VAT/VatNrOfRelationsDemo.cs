using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.VAT;

namespace Demo.Extras.VAT
{
    class VatNrOfRelationsDemo
    {
        private const string VatNrOfRelationsType = "VATN";
        private readonly VatNrOfRelationsService vatNrOfRelationsService;

        public VatNrOfRelationsDemo(Session session)
        {
            vatNrOfRelationsService = new VatNrOfRelationsService(session);
        }

        public void Run()
        {
            if (!FindVatNrOfRelations())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindVatNrOfRelations()
        {
            Console.WriteLine("Searching VAT number of relations");
            const int searchField = 0;
            var vatNrOfRelations = vatNrOfRelationsService.FindVatNrOfRelations("*", VatNrOfRelationsType, searchField);
            DisplayVatNrOfRelationsSummaries(vatNrOfRelations);
            if (vatNrOfRelations.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayVatNrOfRelationsSummaries(IEnumerable<VatNrOfRelationsSummary> vatNrOfRelations)
        {
            foreach (var v in vatNrOfRelations)
            {
                Console.WriteLine("------");
                Console.WriteLine("Vat number of relation:");
                Console.WriteLine("code = {0}", v.Code);
                Console.WriteLine("name = {0}", v.Name);
                Console.WriteLine("country = {0}", v.Country);
                Console.WriteLine("vat number = {0}", v.VatNumber);
                Console.WriteLine("relation company = {0}", v.RelationCompany);
                Console.WriteLine("city = {0}", v.City);
                Console.WriteLine("------");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
