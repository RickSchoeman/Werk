using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinfieldApi.SalesInvoice
{
    public class SalesInvoiceSummary
    {
        public string Invoicenumber { get; set; }
        public string Amount { get; set; }
        public string Customer { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
