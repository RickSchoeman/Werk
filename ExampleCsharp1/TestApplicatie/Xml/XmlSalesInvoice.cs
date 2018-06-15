using System.Collections.Generic;

namespace TestApplicatie.Xml
{
    public class XmlSalesInvoice
    {
        public string CustomerId { get; set; }
        public string Project { get; set; }
        public string CustomerReference { get; set; }
        public string Name { get; set; }
        public string OrderNummer { get; set; }
        public string OrderType { get; set; }
        public string InvoiceTypeAndNumber { get; set; }
        public List<XmlSalesInvoiceLine> SalesInvoiceLines { get; set; }
    }

    public class XmlSalesInvoiceLine
    {
        public string Article { get; set; }
        public string Subarticle { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public decimal? Quantity { get; set; }
        public decimal VatPercentage { get; set; }
        public string VatType { get; set; }
    }
}
