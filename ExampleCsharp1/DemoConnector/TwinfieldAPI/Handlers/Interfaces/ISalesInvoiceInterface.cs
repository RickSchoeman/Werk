using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface ISalesInvoiceInterface
    {
        List<Data.SalesInvoice.SalesInvoice> GetByInvoiceType(string invoiceType);
        List<Data.SalesInvoice.SalesInvoice> GetByNumber(string number);
        List<Data.SalesInvoice.SalesInvoice> GetAll();
        Data.SalesInvoice.SalesInvoice Read(string number, string type);
        string Create(Data.SalesInvoice.SalesInvoice salesInvoice);
    }
}
