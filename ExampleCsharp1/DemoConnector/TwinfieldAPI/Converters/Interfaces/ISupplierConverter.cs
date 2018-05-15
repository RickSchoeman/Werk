using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Data.Suppliers;

namespace DemoConnector.TwinfieldAPI.Converters.Interfaces
{
    public interface ISupplierConverter
    {
        Supplier ConvertSupplierResponse(SupplierResponse supplierResponse, string office);
        SupplierResponse ConvertSupplier(Supplier supplier);
    }
}
