using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Suppliers
{
    public class SupplierService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public SupplierService(Session session) : this(session, new ClientFactory())
        {

        }

        public SupplierService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<SupplierSummary> FindSuppliers(string pattern, string supplierType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "DIM",
                Pattern = pattern,
                Field = field,
                MaxRows = 10,
                Options = new []{new []{"dimtype", supplierType}}
            };
            var searchResult = finderService.Search(query);

            return SearchResultToSupplierSummaries(searchResult);
        }

        private static List<SupplierSummary> SearchResultToSupplierSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<SupplierSummary>();
            }

            return searchResult.Items.Select(item => new SupplierSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public Supplier ReadSupplier(string supplierType, string supplierCode)
        {
            var command = new ReadSupplierCommand
            {
                Office = session.Office,
                SupplierType = supplierType,
                SupplierCode = supplierCode
            };
            var response = processXml.Process(command.ToXml());
            return Supplier.FromXml(response);
        }

        public void CreateSupplier(Supplier supplier)
        {
            var command = new CreateSupplierCommand
            {
                Supplier = supplier
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteSupplier(Supplier supplier)
        {
            var command = new DeleteSupplierCommand
            {
                Supplier = supplier
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateSupplier(Supplier supplier)
        {
            var command = new ActivateSupplierCommand
            {
                Supplier = supplier
            };
            processXml.Process(command.ToXml());
        }

        public void DeletePostingRule(Supplier supplier)
        {
            var command = new DeletePostingRuleCommand
            {
                Supplier = supplier
            };
            processXml.Process(command.ToXml());
        }


    }
}
