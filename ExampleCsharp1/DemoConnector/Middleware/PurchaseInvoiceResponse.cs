using System;
using System.Collections.Generic;

namespace DemoConnector.Middleware
{
    public class PurchaseInvoiceResponse
    {
        public String SuplierName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public String Description { get; set; }
        public String InvoiceNummer { get; set; }
        public List<PurchaseInvoiceLine> PurchaseInvoiceLines { get; set; }

        public PurchaseInvoiceResponse()
        {
            PurchaseInvoiceLines = new List<PurchaseInvoiceLine>();
        }
    }

    public class PurchaseInvoiceLine
    {
        public Decimal Amount { get; set; }
        public String Project { get; set; }
        public Decimal Tax { get; set; }
    }
}