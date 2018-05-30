using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Converters;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplicatie;
using TestApplicatie.Interfaces;

namespace TwinfieldTests
{
    [TestClass]
    public class CustomerConverterTests
    {
        private IMiddlewareData _middlewareData;
        private IApiOperationsBase<Customer> _customerInterface;
        private ICustomerConverter _customerConverter;
        private Session _session;

        [TestInitialize]
        public void Initialize()
        {
            _middlewareData = new MiddlewareData();
            _session = Utilities.CreateValidSession();
            _customerConverter = new CustomerConverter();
            _customerInterface = new CustomerOperations(_session);
        }

        [TestMethod]
        public void Should_convert_customer_response_to_customer()
        {
            var customer =
                _customerConverter.ConvertCustomerResponse(_middlewareData.GetCustomerData(), _session.Office);
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void Should_convert_customer_to_customer_response()
        {
            var customer = _customerInterface.GetByName("1000");
            var customerResponse = _customerConverter.ConvertCustomer(customer[0]);
            Assert.IsNotNull(customerResponse);
        }
    }
}
