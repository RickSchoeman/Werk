using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.AssetMethods;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.AssetMethods
{
    public class AssetMethodService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public AssetMethodService(Session session) : this(session, new ClientFactory())
        {

        }

        public AssetMethodService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<AssetMethodSummary> FindAssetMethods(string pattern, string assetMethodType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "ASM",
                Pattern = pattern,
                Field= field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToAssetMethodSummaries(searchResult);
        }

        private static List<AssetMethodSummary> SearchResultToAssetMethodSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<AssetMethodSummary>();
            }

            return searchResult.Items.Select(item => new AssetMethodSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public AssetMethod ReadAssetMethod(string assetMethodType, string assetMethodCode)
        {
            
            var command = new ReadAssetMethodCommand
            {
                Office = session.Office,
                AssetMethodType = assetMethodType,
                AssetMethodCode = assetMethodCode
            };
            var response = processXml.Process(command.ToXml());
            return AssetMethod.FromXml(response);
        }

        public void CreateAssetMethod(AssetMethod assetMethod)
        {
            var command = new CreateAssetMethodCommand
            {
                AssetMethod = assetMethod
            };

            processXml.Process(command.ToXml());
        }

        public void DeleteAssetMethod(AssetMethod assetMethod)
        {
            var command = new DeleteAssetMethodCommand
            {
                AssetMethod = assetMethod
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateAssetMethod(AssetMethod assetMethod)
        {
            var command = new ActivateAssetMethodCommand
            {
                AssetMethod = assetMethod
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteAssetMethod(AssetMethod assetMethod)
        {
            var response = processXml.Process(assetMethod.ToXml());
            return response.IsSuccess();
        }
    }
}
