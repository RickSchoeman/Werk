using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.DimensionTypes;

namespace Demo
{
    class DimensionTypeDemo
    {
        private readonly DimensionTypeService dimensionTypeService;
        private readonly Session session;
        private DimensionTypeSummary dimensionTypeSummary;
        private DimensionType dimensionType;
        private IEnumerable<DimensionTypeSummary> dimensiontypes;

        public DimensionTypeDemo(Session session)
        {
            this.session = session;
            dimensionTypeService = new DimensionTypeService(session);
        }

        public void Run()
        {
            var dimType = new DimensionType
            {
                Office = session.Office,
                Code = "TEST",
                Mask = "T[0-9][0-9][0-9]",
                Name = "test",
                Shortname = "test",
                address = new Address
                {
                    Label1 = "test",
                    Label2 = "",
                    Label3 = "",
                    Label4 = "",
                    Label5 = "",
                    Label6 = ""
                }
            };
//            dimensionTypeService.UpdateDimensionType(dimType);

            if (!FindDimensionTypes())
            {
                return;
            }

            if (!ReadDimensionTypeDetails())
            {
                return;
            }

            Console.WriteLine();
        }

        private bool FindDimensionTypes()
        {
            Console.WriteLine("Searching dimension types");
            const int searchField = 2;
            var dimensionTypes = dimensionTypeService.FindDimensionTypes("*", searchField);
            DisplayDimensionTypeSummaries(dimensionTypes);
            if (dimensionTypes.Count < 1)
            {
                return false;
            }
            else
            {
                this.dimensiontypes = dimensionTypes;
                dimensionTypeSummary = dimensionTypes.First();
                return true;
            }
        }

        private bool ReadDimensionTypeDetails()
        {
            Console.WriteLine("Read dimension type details");

            foreach (var d in this.dimensiontypes)
            {
                dimensionType = dimensionTypeService.ReadDimensionType(d.Code);
                if (dimensionTypeSummary == null)
                {
                    Console.WriteLine("Project type {0} not found", dimensionType.Code);
                    return false;
                }

                DisplayDimensioTypeDetails(dimensionType);
            }

            return true;
        }

        private static void DisplayDimensionTypeSummaries(IEnumerable<DimensionTypeSummary> dimensions)
        {
            foreach (var dimension in dimensions)
            {
                Console.WriteLine("{0, -16} {1}", dimension.Code, dimension.Name);
            }

            Console.WriteLine();
        }

        private static void DisplayDimensioTypeDetails(DimensionType dimensionType)
        {
            Console.WriteLine("------");
            Console.WriteLine("Dimension types of: {0}", dimensionType.Name);
            Console.WriteLine("office = {0}", dimensionType.Office);
            Console.WriteLine("code = {0}", dimensionType.Code);
            Console.WriteLine("mask = {0}", dimensionType.Mask);
            Console.WriteLine("name = {0}", dimensionType.Name);
            Console.WriteLine("shortname = {0}", dimensionType.Shortname);
            Console.WriteLine("------");
            Console.WriteLine("Address:");
            Console.WriteLine("label1 = {0}", dimensionType.address.Label1);
            Console.WriteLine("label2 = {0}", dimensionType.address.Label2);
            Console.WriteLine("label3 = {0}", dimensionType.address.Label3);
            Console.WriteLine("label4 = {0}", dimensionType.address.Label4);
            Console.WriteLine("label5 = {0}", dimensionType.address.Label5);
            Console.WriteLine("label6 = {0}", dimensionType.address.Label6);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Levels:");
            Console.WriteLine("financials = {0}", dimensionType.levels.Financials);
            Console.WriteLine("time = {0}", dimensionType.levels.Time);
            Console.WriteLine("fixedassets = {0}", dimensionType.levels.Fixedassets);
            Console.WriteLine("invoices = {0}", dimensionType.levels.Invoices);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}