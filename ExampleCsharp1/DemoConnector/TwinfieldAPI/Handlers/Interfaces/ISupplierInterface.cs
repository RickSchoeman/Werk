using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.Suppliers;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface ISupplierInterface
    {
        List<Supplier> GetByName(string name);
        List<Supplier> GetAll();
        Supplier Read(string code);
        string Create(Supplier supplier);
        string Delete(Supplier supplier);
        string Activate(Supplier supplier);
    }
}
