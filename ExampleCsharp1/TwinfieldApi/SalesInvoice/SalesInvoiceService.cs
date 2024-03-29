﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Dimensions;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.SalesInvoice
{
    public class SalesInvoiceService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public SalesInvoiceService(Session session) : this(session, new ClientFactory())
        {

        }

        public SalesInvoiceService(Session session, IClientFactory clienFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clienFactory);
            finderService = new FinderService(session, clienFactory);
        }

//        public List<SalesInvoiceSummary> FindSelesInvoices(string pattern, string salesInvoiceType, int field)
//        {
//            //hij haalt gegevens op die niet bestaan in de omgeving
//            var query = new FinderService.Query
//            {
//                Type = "IVT",
//                Pattern = pattern,
//                Field = field
//            };
//            var searchResult = finderService.Search(query);
//            return SearchResultToSalesInvoiceSummaries(searchResult);
//        }
//
//        private static List<SalesInvoiceSummary> SearchResultToSalesInvoiceSummaries(FinderData searchResult)
//        {
//            if (searchResult.Items == null)
//            {
//                return new List<SalesInvoiceSummary>();
//            }
//
//            return searchResult.Items.Select(item => new SalesInvoiceSummary {Invoicenumber = item[0], Amount = item[1], Customer = item[2], Name = item[3], Status = item[4]}).ToList();
//        }

        public SalesInvoice ReadSalesInvoice(string invoiceNumber, string salesInvoiceType)
        {
            var command = new ReadSalesInvoiceCommand
            {
                Office = session.Office,
                SalesInvoiceType = salesInvoiceType,
                InvoiceNumber = invoiceNumber
            };
            var response = processXml.Process(command.ToXml());
            return SalesInvoice.FromXml(response);
        }

        public void CreateSalesInvoice(SalesInvoice salesInvoice)
        {
            var command = new CreateSalesInvoiceCommand
            {
                SalesInvoice = salesInvoice
            };
            processXml.Process(command.ToXml());
        }

    }
}
