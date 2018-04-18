using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.DimensionGroups
{
    public class DimensionGroupService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public DimensionGroupService(Session session) : this(session, new ClientFactory())
        {

        }

        public DimensionGroupService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<DimensionGroupSummary> FindDimensionGroups(string pattern, string dimensionGroupType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "GRP",
                Pattern = pattern,
                Field = field,
//                Options = new []{new []{"dimtype", dimensionGroupType}}
            };
            var searchResult = finderService.Search(query);
            return SearchResultToDimensionGroupSummaries(searchResult);
        }

        private static List<DimensionGroupSummary> SearchResultToDimensionGroupSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<DimensionGroupSummary>();
            }

            return searchResult.Items.Select(item => new DimensionGroupSummary {Code = item[0], Name = item[1]})
                .ToList();
        }

        public DimensionGroup ReadDimensiongroup(string dimensionGroupCode)
        {
            var command = new ReadDimensionGroupCommand
            {
                Office = session.Office,
                DimensionGroupCode = dimensionGroupCode
            };
            var response = processXml.Process(command.ToXml());
            return DimensionGroup.FromXml(response);
        }

        public void CreateDimensionGroup(DimensionGroup dimensionGroup)
        {
            var command = new CreateDimensionGroupCommand
            {
                DimensionGroup = dimensionGroup
            };

            processXml.Process(command.ToXml());
        }

        public void DeleteDimensionGroup(DimensionGroup dimensionGroup)
        {
            var command = new DeleteDimensionGroupCommand
            {
                DimensionGroup = dimensionGroup
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteDimensionGroup(DimensionGroup dimensionGroup)
        {
            var response = processXml.Process(dimensionGroup.ToXml());
            return response.IsSuccess();
        }
    }
}
