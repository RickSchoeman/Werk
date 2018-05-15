using System;
using System.Collections.Generic;

namespace DemoConnector.Middleware
{
    public class SalesInvoiceResponse
    {
        private SalesInvoiceLines _salesInvoiceLines;

        public SalesInvoiceResponse()
        {
            _salesInvoiceLines = new SalesInvoiceLines();
        }

        public string CustomerId { get; set; }
        public string Project { get; set; }
        public string CustomerReference { get; set; }
        public string Name { get; set; }
        public string OrderNummer { get; set; }
        public string OrderType { get; set; }

        public string InvoiceTypeAndNumber
        {
            get { return OrderType + "," + OrderNummer; }
        }

        public SalesInvoiceLines SalesInvoiceLines
        {
            get { return _salesInvoiceLines; }
        }

    }

    public class SalesInvoiceLines
    {
        public List<SalesInvoiceLine> SalesInvoiceLine { get; set; }
    }

    public class SalesInvoiceLine
    {
        public string Article { get; set; }
        public string Subarticle { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public decimal? Quantity { get; set; }
        public decimal VatPercent { get; set; }
        public string VatType { get; set; }
        
    }
}
