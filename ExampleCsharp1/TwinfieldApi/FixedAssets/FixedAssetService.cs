using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.FixedAssets
{
    public class FixedAssetService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public FixedAssetService(Session session) : this(session, new ClientFactory())
        {

        }

        public FixedAssetService(Session session, IClientFactory clientfactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientfactory);
            finderService = new FinderService(session, clientfactory);
        }

        public List<FixedAssetSummary> FindFixedAssets(string pattern, string fixedAssetType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "DIM",
                Pattern = pattern,
                Field = field,
                MaxRows = 10,
                Options = new []{new []{"dimtype", fixedAssetType}}
            };
            var searchResult = finderService.Search(query);

            return searchResultToFixedAssetSummaries(searchResult);
        }

        private static List<FixedAssetSummary> searchResultToFixedAssetSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<FixedAssetSummary>();
            }

            return searchResult.Items.Select(item => new FixedAssetSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public FixedAsset ReadFixedAsset(string fixedAssetType, string fixedAssetCode)
        {
            var command = new ReadFixedAssetCommand
            {
                Office = session.Office,
                FixedAssetType = fixedAssetType,
                FixedAssetCode = fixedAssetCode
            };
            var response = processXml.Process(command.ToXml());
            return FixedAsset.FromXml(response);
        }

        public void CreateFixedAsset(FixedAsset fixedAsset)
        {
            var command = new CreateFixedAssetCommand
            {
                FixedAsset = fixedAsset
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteFixedAsset(FixedAsset fixedAsset)
        {
            var command = new DeleteFixedAssetCommand
            {
                FixedAsset = fixedAsset
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateFixedAsset(FixedAsset fixedAsset)
        {
            var command = new ActivateFixedAssetCommand
            {
                FixedAsset = fixedAsset
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteFixedAsset(FixedAsset fixedAsset)
        {
            var response = processXml.Process(fixedAsset.ToXml());
            return response.IsSuccess();
        }
    }
}
