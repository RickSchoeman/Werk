using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Middleware
{
    class SalesInvoiceResponse
    {
        public String CustomerId { get; set; }
        public String Project { get; set; }
        public String CustomerReference { get; set; }
        public String Name { get; set; }
        public String OrderNummer { get; set; }
        public List<SalesInvoiceLine> SalesInvoicesLines { get; set; }

        public SalesInvoiceResponse()
        {
            SalesInvoicesLines = new List<SalesInvoiceLine>();
        }
    }

    public class SalesInvoiceLine
    {
        public Decimal Amount { get; set; }
        public String Currncy { get; set; }
        public String Description { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal VatPercent { get; set; }
        public int VatType { get; set; }
    }
}
