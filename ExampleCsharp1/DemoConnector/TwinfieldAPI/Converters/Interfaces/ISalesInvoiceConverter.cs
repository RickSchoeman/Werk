using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Data.SalesInvoice;

namespace DemoConnector.TwinfieldAPI.Converters.Interfaces
{
    public interface ISalesInvoiceConverter
    {
        SalesInvoiceResponse ConvertSalesInvoice(SalesInvoice salesInvoice);
        SalesInvoice ConvertSalesInvoiceResponse(SalesInvoiceResponse salesInvoiceResponse, string vatCode);
    }
}
