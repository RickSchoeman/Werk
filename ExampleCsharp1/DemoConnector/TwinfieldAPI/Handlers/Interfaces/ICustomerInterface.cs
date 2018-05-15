using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.Customers;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface ICustomerInterface
    {
        List<Customer> GetByName(string name);
        List<Customer> GetAll();
        Customer Read(string code);
        string Create(Customer customer);
        string Delete(Customer customer);
        string Activate(Customer customer);
    }
}
