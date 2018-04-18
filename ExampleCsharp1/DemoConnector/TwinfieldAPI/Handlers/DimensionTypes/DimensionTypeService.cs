using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.DimensionTypes;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.DimensionTypes
{
    public class DimensionTypeService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public DimensionTypeService(Session session) : this(session, new ClientFactory())
        {

        }

        public DimensionTypeService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<DimensionTypeSummary> FindDimensionTypes(string pattern, int field)
        {
            var query = new FinderService.Query
            {
                Type = "DMT",
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToDimensionTypeSummaries(searchResult);
        }

        private static List<DimensionTypeSummary> SearchResultToDimensionTypeSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<DimensionTypeSummary>();
            }

            return searchResult.Items.Select(item => new DimensionTypeSummary {Code = item[0], Name = item[1]})
                .ToList();
        }

        public DimensionType ReadDimensionType(string dimensionTypeCode)
        {
            var command = new ReadDimensionTypeCommand
            {
                Office = session.Office,
                DimensionTypeCode = dimensionTypeCode
            };
            var response = processXml.Process(command.ToXml());
            return DimensionType.FromXml(response);
        }

        public void UpdateDimensionType(DimensionType dimensionType)
        {
            var command = new UpdateDimensionTypeCommand
            {
                DimensionType = dimensionType
            };

            processXml.Process(command.ToXml());
        }

        public bool WriteDimensionType(DimensionType dimensionType)
        {
            var response = processXml.Process(dimensionType.ToXml());
            return response.IsSuccess();
        }
    }
}
