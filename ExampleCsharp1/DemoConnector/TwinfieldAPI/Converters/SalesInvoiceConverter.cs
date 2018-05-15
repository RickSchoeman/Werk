using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.SalesInvoice;
using DemoConnector.TwinfieldAPI.Handlers;

namespace DemoConnector.TwinfieldAPI.Converters
{
    public class SalesInvoiceConverter : ISalesInvoiceConverter
    {
        private readonly Session session;
        public SalesInvoiceConverter(Session session)
        {
            this.session = session;
        }

        public SalesInvoiceResponse ConvertSalesInvoice(SalesInvoice salesInvoice)
        {

            var lines = new List<SalesInvoiceLine>();
            foreach (var l in salesInvoice.Lines.Line)
            {
                var vats = (new VatOperations(session)).GetVatsByName(l.Vatcode);
                var line = new SalesInvoiceLine
            {
                Amount = l.Units,
                Currency = salesInvoice.Header.Currency,
                Description = l.Description,
                Quantity = l.Quantity,
                VatPercent = Decimal.Parse(vats[0].Percentages.Percentage[0].percentage),
                VatType = vats[0].Type,
                Article = l.Article,
                Subarticle = l.Subarticle
            };
            lines.Add(line);
            }
            
            var salesInvoiceResponse = new SalesInvoiceResponse
            {
                CustomerId = salesInvoice.Header.Customer,
                CustomerReference = salesInvoice.Header.Customer,
                OrderNummer = salesInvoice.Header.Invoicenumber.ToString(),
                OrderType = salesInvoice.Header.Invoicetype
                
            };
            salesInvoiceResponse.SalesInvoiceLines.SalesInvoiceLine = lines;
            return salesInvoiceResponse;
        }

        public SalesInvoice ConvertSalesInvoiceResponse(SalesInvoiceResponse salesInvoiceResponse, string vatCode)
        {
            var lines = new List<Line>();
            foreach (var l in salesInvoiceResponse.SalesInvoiceLines.SalesInvoiceLine)
            {
                var line = new Line
                {
                    Article = l.Article,
                    Subarticle = l.Subarticle,
                    Units = int.Parse(l.Amount.ToString()),
                    Description = l.Description,
                    Quantity = int.Parse(l.Quantity.ToString()),
                    Vatcode = vatCode
                };
                lines.Add(line);
            }
            
            return new SalesInvoice
            {
                Header = new Header
                {
                    Invoicetype = salesInvoiceResponse.OrderType,
                    Customer = salesInvoiceResponse.CustomerId,
                    Invoicenumber = int.Parse(salesInvoiceResponse.OrderNummer),
                    Currency = salesInvoiceResponse.SalesInvoiceLines.SalesInvoiceLine[0].Currency,
                },
                Lines = new Lines
                {
                    Line = lines
                }
            };
        }
    }
}
