using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;

namespace TwinfieldApi.BankTransactions
{
    public class BankTransactionService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public BankTransactionService(Session session) : this(session, new ClientFactory())
        {

        }

        public BankTransactionService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<BankTransactionSummary> FindBankTransactions(string pattern, string bankTransactionType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "BNK",
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToBankTransactionSummaries(searchResult);
        }

        private static List<BankTransactionSummary> SearchResultToBankTransactionSummaries(FinderData searchResult)
        {
            if (searchResult == null)
            {
                return new List<BankTransactionSummary>();
            }

            return searchResult.Items.Select(item => new BankTransactionSummary {Code = item[0], Name = item[1]})
                .ToList();
        }

        public BankTransaction ReadBankTransaction(string banktransactionNumber, string banktransactionCode)
        {
            var command = new ReadBankTransactionCommand
            {
                Office = session.Office,
                BankTransactionNumber = banktransactionCode,
                BankTransactionCode = banktransactionNumber
            };
            var response = processXml.Process(command.ToXml());
            return BankTransaction.FromXml(response);
        }

        public void CreateBankTransaction(BankTransaction bankTransaction)
        {
            var command = new CreateBankTransactionCommand
            {
                BankTransaction = bankTransaction
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteBankTransaction(BankTransaction bankTransaction)
        {
            return true;
        }
    }
}
