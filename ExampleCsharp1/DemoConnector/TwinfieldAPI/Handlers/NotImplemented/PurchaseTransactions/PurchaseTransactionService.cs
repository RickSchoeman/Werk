using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.PurchaseTransactions;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.PurchaseTransactions
{
    public class PurchaseTransactionService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public PurchaseTransactionService(Session session) : this(session, new ClientFactory())
        {

        }

        public PurchaseTransactionService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<PurchaseTransactionSummary> FindPurchaseTransactions(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToPurchaseTransactionSummaries(searchResult);
        }

        private static List<PurchaseTransactionSummary> SearchResultToPurchaseTransactionSummaries(
            FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<PurchaseTransactionSummary>();
            }

            return searchResult.Items.Select(item => new PurchaseTransactionSummary {Code = item[0], Name = item[1]})
                .ToList();
        }

        public PurchaseTransaction ReadPurchaseTransaction(
            string purchaseTransactionNumber)
        {
            var command = new ReadPurchaseTransactionCommand
            {
                Office = session.Office,
                PurchaseTransactionNumber = purchaseTransactionNumber
            };
            var response = processXml.Process(command.ToXml());
            return PurchaseTransaction.FromXml(response);
        }

        public void CreatePurchaseTransaction(PurchaseTransaction purchaseTransaction)
        {
            var command = new CreatePurchaseTransactionCommand
            {
                PurchaseTransaction = purchaseTransaction
            };
            processXml.Process(command.ToXml());
        }

        public bool WritePurchaseTransaction(PurchaseTransaction purchaseTransaction)
        {
            var response = processXml.Process(purchaseTransaction.ToXml());
            return response.IsSuccess();
        }
    }
}
