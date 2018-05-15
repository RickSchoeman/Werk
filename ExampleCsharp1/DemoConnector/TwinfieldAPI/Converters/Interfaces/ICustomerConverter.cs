using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Data.Customers;

namespace DemoConnector.TwinfieldAPI.Converters.Interfaces
{
    public interface ICustomerConverter
    {
        CustomerResponse ConvertCustomer(Customer customer);
        Customer ConvertCustomerResponse(CustomerResponse customerResponse, string office);
    }
}
