using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.DimensionGroups;

namespace Demo
{
    class DimensionGroupDemo
    {
        private const string DimensionGroupType = "";
        private readonly DimensionGroupService dimensionGroupService;
        private readonly Session session;
        private DimensionGroupSummary dimensionGroupSummary;
        private DimensionGroup dimensionGroup;
        private IEnumerable<DimensionGroupSummary> dimensionGroups;


        public DimensionGroupDemo(Session session)
        {
            this.session = session;
            dimensionGroupService = new DimensionGroupService(session);
        }

        public void Run()
        {
            var dimensions = new List<Dimension>();
            var dimension1 = new Dimension
            {
                Type = "CRD",
                Code = "2000"
            };
            dimensions.Add(dimension1);
            var dimension2 = new Dimension
            {
                Type = "CRD",
                Code = "2001"
            };
            dimensions.Add(dimension2);
            var dimGroup = new DimensionGroup
            {
                Office = session.Office,
                Code = "TEST",
                Name = "test",
                Shortname = "test",
                Dimensions = new Dimensions
                {
                    Dimension = dimensions
                }
            };
            dimensionGroupService.CreateDimensionGroup(dimGroup);

            var delDim = new DimensionGroup
            {
                Office = session.Office,
                Code = "TEST"
            };
            dimensionGroupService.DeleteDimensionGroup(delDim);

            if (!FindDimensionGroups())
            {
                return;
            }

            if (!ReadDimensionGroupDetails())
            {
                return;
            }

            Console.WriteLine();
        }

        private bool FindDimensionGroups()
        {
            Console.WriteLine("Searching dimension groups");

            const int searchField = 2;

            var dimensionGroups = dimensionGroupService.FindDimensionGroups("*", DimensionGroupType, searchField);


            DisplayDimensionGroupSummaries(dimensionGroups);
            if (dimensionGroups.Count < 1)
            {
                return false;
            }
            else
            {
                this.dimensionGroups = dimensionGroups;

                dimensionGroupSummary = dimensionGroups.First();
                return true;
            }
        }

        private bool ReadDimensionGroupDetails()
        {
            Console.WriteLine("Read dimension group details");
            foreach (var d in this.dimensionGroups)
            {
                dimensionGroup = dimensionGroupService.ReadDimensiongroup(d.Code);
                if (dimensionGroupSummary == null)
                {
                    Console.WriteLine("Project group {0} not found", dimensionGroup.Code);
                    return false;
                }

                DisplayDimenionGroupDetails(dimensionGroup);
            }

            return true;
        }

        private static void DisplayDimensionGroupSummaries(IEnumerable<DimensionGroupSummary> dimensionGroups)
        {
            foreach (var dimensionGroup in dimensionGroups)
            {
                Console.WriteLine("{0, -16} {1}", dimensionGroup.Code, dimensionGroup.Name);
            }

            Console.WriteLine();
        }

        private static void DisplayDimenionGroupDetails(DimensionGroup dimensionGroup)
        {
            Console.WriteLine("------");
            Console.WriteLine("Project group details of: {0}", dimensionGroup.Name);
            Console.WriteLine("office = {0}", dimensionGroup.Office);
            Console.WriteLine("code = {0}", dimensionGroup.Code);
            Console.WriteLine("name = {0}", dimensionGroup.Name);
            Console.WriteLine("shortname = {0}", dimensionGroup.Shortname);
            Console.WriteLine("------");
            Console.WriteLine("Dimensions:");
            for (int i = 0; i < dimensionGroup.Dimensions.Dimension.Count; i++)
            {
                if (!dimensionGroup.Dimensions.Dimension[i].Equals(null) ||
                    dimensionGroup.Dimensions.Dimension[i] != null ||
                    !dimensionGroup.Dimensions.Dimension[i].Type.Equals("") ||
                    dimensionGroup.Dimensions.Dimension[i].Type != "")
                {
                    var dimension = dimensionGroup.Dimensions.Dimension[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Project: " + (i + 1));
                    Console.WriteLine("type = {0}", dimension.Type);
                    Console.WriteLine("Code = {0}", dimension.Code);
                    Console.WriteLine("------");
                }
            }

            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}