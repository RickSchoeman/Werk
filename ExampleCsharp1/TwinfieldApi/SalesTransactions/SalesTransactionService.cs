﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.SalesTransactions
{
    public class SalesTransactionService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public SalesTransactionService(Session session) : this(session, new ClientFactory())
        {

        }

        public SalesTransactionService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<SalesTransactionSummary> FindSalesTransactions(string pattern, string salesTransactionType,
            int field)
        {
            var query = new FinderService.Query
            {
                Type = salesTransactionType,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return searchResultToSalesTransactionSummaries(searchResult);
        }

        private static List<SalesTransactionSummary> searchResultToSalesTransactionSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<SalesTransactionSummary>();
            }

            return searchResult.Items.Select(item => new SalesTransactionSummary {Code = item[0], Name = item[1]})
                .ToList();
        }

        public SalesTransaction ReadSalesTransaction(string salesTransationCode, string salesTransactionNumber)
        {
            var command = new ReadSalesTransactionCommand
            {
                Office = session.Office,
                SalesTransactionCode = salesTransationCode,
                SalesTransactionNumber = salesTransactionNumber
            };
            var response = processXml.Process(command.ToXml());
            return SalesTransaction.FromXml(response);
        }

        public void CreateSalesTransaction(SalesTransaction salesTransaction)
        {
            var command = new CreateSalesTransaction
            {
                SalesTransaction = salesTransaction
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteSalesTransaction(SalesTransaction salesTransaction)
        {
            var response = processXml.Process(salesTransaction.ToXml());
            return response.IsSuccess();
        } 
    }
}
