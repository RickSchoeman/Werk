using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.CostCenters;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.CostCenters
{
    public class CostCenterService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public CostCenterService(Session session) : this(session, new ClientFactory())
        {

        }

        public CostCenterService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<CostCenterSummary> FindCostCenters(string pattern, string costCenterType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "DIM",
                Pattern = pattern,
                Field = field,
                MaxRows = 10,
                Options = new []{new []{"dimtype", costCenterType}}
            };
            var searchresult = finderService.Search(query);
            return SearchResulttoCostCenterSummaries(searchresult);
        }

        private static List<CostCenterSummary> SearchResulttoCostCenterSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<CostCenterSummary>();
            }

            return searchResult.Items.Select(item => new CostCenterSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public CostCenter ReadCostCenter(string costCenterType, string costCenterCode)
        {
            var command = new ReadCostCenterCommand
            {
                Office = session.Office,
                CostCenterType = costCenterType,
                CostCenterCode = costCenterCode
            };
            var response = processXml.Process(command.ToXml());
            return CostCenter.FromXml(response);
        }

        public void CreateCostCenter(CostCenter costCenter)
        {
            var command = new CreateCostCenterCommand
            {
                CostCenter = costCenter
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteCostCenter(CostCenter costCenter)
        {
            var command = new DeleteCostCenterCommand
            {
                CostCenter = costCenter
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateCostCenter(CostCenter costCenter)
        {
            var command = new ActivateCostCenterCommand
            {
                CostCenter = costCenter
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteCostCenter(CostCenter costCenter)
        {
            var response = processXml.Process(costCenter.ToXml());
            return response.IsSuccess();
        }
    }
}
