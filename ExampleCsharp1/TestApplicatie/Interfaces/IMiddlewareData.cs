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
        List<CustomerResponse> GetCustomerData();
        List<SupplierResponse> GetSupplierData();
        List<Product> GetProductData();
        List<SalesInvoiceResponse> GetSalesInvoiceData();
        List<GeneralLedgerResponse> GetBalanceSheetData();
        List<GeneralLedgerResponse> GetProfitAndLossData();
        List<CostCenterResponse> GetCostCenterData();
    }
}
