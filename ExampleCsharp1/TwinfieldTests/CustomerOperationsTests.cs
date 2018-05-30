using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwinfieldTests
{
    [TestClass]
    public class CustomerOperationsTests
    {
        private IApiOperationsBase<Customer> _customerInterface;

        [TestInitialize]
        public void Initialize()
        {
            var session = Utilities.CreateValidSession();
            _customerInterface = new CustomerOperations(session);
        }

        [TestMethod]
        public void Should_find_all_customers()
        {
            var customers = _customerInterface.GetAll();
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void Should_find_all_customer_summaries()
        {
            var customers = _customerInterface.GetSummaries();
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void Should_read_given_customer()
        {
            var c = _customerInterface.GetByName("1000");
            List<Customer> customers = new List<Customer>();
            foreach (var x in c)
            {
                var customer = _customerInterface.Read(x.Code);
                customers.Add(customer);
            }
            Assert.IsNotNull(customers);
            Assert.AreEqual(customers[0].Code, "1000");
        }

        [TestMethod]
        public void Should_fail_to_create_empty_customer()
        {
            try
            {
                _customerInterface.Create(new Customer());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_delete_with_empty_customer()
        {
            try
            {
                _customerInterface.Delete(new Customer());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_activate_with_empty_customer()
        {
            try
            {
                _customerInterface.Activate(new Customer());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }
    }
}
