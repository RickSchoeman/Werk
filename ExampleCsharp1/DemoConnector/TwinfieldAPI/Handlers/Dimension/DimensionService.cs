﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Articles;
using DemoConnector.TwinfieldAPI.Data.BalanceSheet;
using DemoConnector.TwinfieldAPI.Data.CostCenters;
using DemoConnector.TwinfieldAPI.Data.Currencies;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Data.Dimensions;
using DemoConnector.TwinfieldAPI.Data.DimensionTypes;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Data.ProfitLoss;
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldAPI.Data.VATs;
using DemoConnector.TwinfieldAPI.Handlers.Articles;
using DemoConnector.TwinfieldAPI.Handlers.CostCenters;
using DemoConnector.TwinfieldAPI.Handlers.Currencies;
using DemoConnector.TwinfieldAPI.Handlers.Customers;
using DemoConnector.TwinfieldAPI.Handlers.DimensionGroups;
using DemoConnector.TwinfieldAPI.Handlers.DimensionTypes;
using DemoConnector.TwinfieldAPI.Handlers.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Handlers.SalesInvoice;
using DemoConnector.TwinfieldAPI.Handlers.Suppliers;
using DemoConnector.TwinfieldAPI.Handlers.VATs;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Dimension
{
    public class DimensionService
    {
        private readonly Session _session;
        private readonly ProcessXmlService _processXml;
        private readonly FinderService _finderService;

        public DimensionService(Session session) : this(session, new ClientFactory())
        {

        }

        public DimensionService(Session session, IClientFactory clientFactory)
        {
            _session = session;
            _processXml = new ProcessXmlService(session, clientFactory);
            _finderService = new FinderService(session, clientFactory);
        }

        public List<DimensionSummary> FindDimensions(string pattern, string type, int field) //Customers, Suppliers, General Ledgers
        {
            var query = new FinderService.Query
            {
                Type = "DIM",
                Pattern = pattern,
                Field = field,
                MaxRows = 100,
                Options = new []{new []{"dimtype", type}}
            };
            var searchResult = _finderService.Search(query);
            return SearchResultToDimensionSummaries(searchResult);
        }

        private static List<DimensionSummary> SearchResultToDimensionSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<DimensionSummary>();
            }

            return searchResult.Items.Select(item => new DimensionSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public TResult ReadDimension<TResult>(string code) where TResult : class
        {
            var resultType = typeof(TResult);

            var dimensionCommand = new ReadDimension
            {
                Office = _session.Office,
                ReadType = "dimensions",
                Code = code
            };
           
            if (resultType == typeof(Customer))
            {
                dimensionCommand.Type = "DEB";
                var dimensionResponse = _processXml.Process(dimensionCommand.ToXml());
                return Customer.FromXml(dimensionResponse) as TResult;
            }

            if (resultType == typeof(Supplier))
            {
                dimensionCommand.Type = "CRD";
                var dimensionResponse = _processXml.Process(dimensionCommand.ToXml());
                return Supplier.FromXml(dimensionResponse) as TResult;
            }

            if (resultType == typeof(BalanceSheet))
            {
                dimensionCommand.Type = "BAS";
                var dimensionResponse = _processXml.Process(dimensionCommand.ToXml());
                return BalanceSheet.FromXml(dimensionResponse) as TResult;
            }

            if (resultType == typeof(ProfitLoss))
            {
                dimensionCommand.Type = "PNL";
                var dimensionResponse = _processXml.Process(dimensionCommand.ToXml());
                return ProfitLoss.FromXml(dimensionResponse) as TResult;
            }

            if (resultType == typeof(CostCenter))
            {
                dimensionCommand.Type = "KPL";
                var dimensionResponse = _processXml.Process(dimensionCommand.ToXml());
                return CostCenter.FromXml(dimensionResponse) as TResult;
            }

            return default(TResult);
        }

        public void CreateDimension<TResult>(TResult obj) where TResult : class
        {
            var resultType = typeof(TResult);
            if (resultType == typeof(Customer))
            {
                var command = new CreateCustomerCommand
                {
                    Customer = obj as Customer
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Supplier))
            {
                var command = new CreateSupplierCommand
                {
                    Supplier = obj as Supplier
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(BalanceSheet))
            {
                var command = new CreateGeneralLedgerCommand
                {
                    GeneralLedger = obj as BalanceSheet
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(ProfitLoss))
            {
                var command = new CreateGeneralLedgerCommand
                {
                    GeneralLedger = obj as ProfitLoss
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(CostCenter))
            {
                var command = new CreateCostCenterCommand
                {
                    CostCenter = obj as CostCenter
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Article))
            {
                var command = new CreateArticleCommand
                {
                    Article = obj as Article
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Data.SalesInvoice.SalesInvoice))
            {
                var command = new CreateSalesInvoiceCommand
                {
                    SalesInvoice = obj as Data.SalesInvoice.SalesInvoice
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Vat))
            {
                var command = new CreateVatCommand
                {
                    Vat = obj as Vat
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Currency))
            {
                var command = new CreateCurrencyCommand
                {
                    Currency = obj as Currency
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(DimensionType))
            {
                var command = new UpdateDimensionTypeCommand
                {
                    DimensionType = obj as DimensionType
                };
                _processXml.Process(command.ToXml());
            }
        }

        public void DeleteDimension<TResult>(TResult obj) where TResult : class
        {
            var resultType = typeof(TResult);
            if (resultType == typeof(Customer))
            {
                var command = new DeleteCustomerCommand
                {
                    Customer = obj as Customer
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Supplier))
            {
                var command = new DeleteSupplierCommand
                {
                    Supplier = obj as Supplier
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(BalanceSheet))
            {
                var command = new DeleteGeneralLedgerCommand
                {
                    GeneralLedger = obj as BalanceSheet
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(ProfitLoss))
            {
                var command = new DeleteGeneralLedgerCommand
                {
                    GeneralLedger = obj as ProfitLoss
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(CostCenter))
            {
                var command = new DeleteCostCenterCommand
                {
                    CostCenter = obj as CostCenter
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Article))
            {
                var command = new DeleteArticleCommand
                {
                    Article = obj as Article
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Vat))
            {
                var command = new DeleteVatCommand
                {
                    Vat = obj as Vat
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Currency))
            {
                var command = new DeleteCurrencyCommand
                {
                    Currency = obj as Currency
                };
                _processXml.Process(command.ToXml());
            }
        }

        public void ActivateDimension<TResult>(TResult obj) where TResult : class
        {
            var resultType = typeof(TResult);
            if (resultType == typeof(Customer))
            {
                var command = new ActivateCustomerCommand
                {
                    Customer = obj as Customer
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Supplier))
            {
                var command = new ActivateSupplierCommand
                {
                    Supplier = obj as Supplier
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(BalanceSheet))
            {
                var command = new ActivateGeneralLedgerCommand
                {
                    GeneralLedger = obj as BalanceSheet
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(ProfitLoss))
            {
                var command = new ActivateGeneralLedgerCommand
                {
                    GeneralLedger = obj as ProfitLoss
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(CostCenter))
            {
                var command = new ActivateCostCenterCommand
                {
                    CostCenter = obj as CostCenter
                };
                _processXml.Process(command.ToXml());
            }

            if (resultType == typeof(Article))
            {
                var command = new ActivateArticleCommand
                {
                    Article = obj as Article
                };
                _processXml.Process(command.ToXml());
            }
        }

    }
}
