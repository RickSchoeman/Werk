using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;

namespace TestApplicatie.Interfaces
{
    public interface IMiddlewareData
    {
        CustomerResponse GetCustomerData();
        SupplierResponse GetSupplierData();
        Product GetProductData();
        SalesInvoiceResponse GetSalesInvoiceData();
        GeneralLedgerResponse GetGeneralLedgerData();
        CostCenterResponse GetCostCenterData();
    }
}
